using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.VisualBasic.ApplicationServices;
using CoffeeShopManagementSystem.BUS;
using CoffeeShopManagementSystem.DAL;

namespace CoffeeShopManagementSystem
{
    public partial class SignUpForm : Form
    {
        private UserBUS userBUS;
        public SignUpForm()
        {
            InitializeComponent();
            userBUS = new UserBUS();
            cbSignUp_Sex.Items.Add("Nam");
            cbSignUp_Sex.Items.Add("Nữ");
            cbSignUp_Sex.Items.Add("Khác");
        }

        private void close_2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnlogin_signup_Click(object sender, EventArgs e)
        {
            SignInForm login = new SignInForm();
            login.Show();

            this.Hide();
        }

        private void signup_showpass_CheckedChanged(object sender, EventArgs e)
        {
            signup_password.PasswordChar = signup_showpass.Checked ? '\0' : '*';
            signup_cfpassword.PasswordChar = signup_showpass.Checked ? '\0' : '*';
        }
        public bool emptyFields()
        {
            if (signup_username.Text == "" || signup_password.Text == "" || signup_cfpassword.Text == "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void signUp_btn_Click_1(object sender, EventArgs e)
        {
            if (emptyFields())
            {
                MessageBox.Show("All fields are required to be filled", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (userBUS.CheckUsernameExists(signup_username.Text.Trim()))
                {
                    MessageBox.Show("Username is already taken", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (signup_password.Text != signup_cfpassword.Text)
                {
                    MessageBox.Show("Mật khẩu không khớp.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (signup_password.Text.Length < 8)
                {
                    MessageBox.Show("Mật khẩu phải ít nhất có 8 ký tự.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrEmpty(signUp_Email.Text) || !signUp_Email.Text.EndsWith("@gmail.com"))
                {
                    MessageBox.Show("Email sai cú pháp hoặc để trống.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrEmpty(cbSignUp_Sex.Text))
                {
                    MessageBox.Show("Giới tính không được để trống.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DateTime day = DateTime.Today;
                bool registerSuccess = userBUS.Register(signup_username.Text.Trim(), signUp_Email.Text.Trim(), cbSignUp_Sex.Text.Trim(), signup_password.Text.Trim(), day);
                if (registerSuccess)
                {
                    MessageBox.Show("Đăng ký thành công.", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SignInForm login = new SignInForm();
                    login.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Đăng ký thất bại.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}