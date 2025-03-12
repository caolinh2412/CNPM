using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using CoffeeShopManagementSystem.BUS;

namespace CoffeeShopManagementSystem
{
    public partial class SignInForm : Form
    {
        private UserBUS userBUS;
        public SignInForm()
        {
            InitializeComponent();
            userBUS = new UserBUS();
            cbRole.Items.Add("Nhân viên");
            cbRole.Items.Add("Quản lý");
        }

        private void close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSignUp_LogIn_Click(object sender, EventArgs e)
        {
            SignUpForm signup = new SignUpForm();
            signup.Show();

            this.Hide();
        }

        private void signIn_showpass_CheckedChanged(object sender, EventArgs e)
        {
            signIn_password.PasswordChar = signIn_showpass.Checked ? '\0' : '*';
        }
        private void btnLogIn_signin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(signIn_username.Text) || string.IsNullOrEmpty(signIn_password.Text))
            {
                MessageBox.Show("All fields are required to be filled", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string role = cbRole.Text;
                if (string.IsNullOrEmpty(role))
                {
                    MessageBox.Show("Vui lòng chọn chức vụ", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                bool loginSuccess = userBUS.Login(signIn_username.Text.Trim(), signIn_password.Text.Trim(), role);
                if (loginSuccess)
                {
                    MessageBox.Show("Đăng nhập thành công", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (role == "Nhân viên")
                    {
                        StaffForm staff = new StaffForm();
                        staff.Show();
                    }
                    else if (role == "Quản lý")
                    {
                        ManagerForm manager = new ManagerForm();
                        manager.Show();
                    }
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Tên hoặc mật khẩu không đúng.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void fg_Pass_Click(object sender, EventArgs e)
        {
            ConfirmEmailForm confirmEmail = new ConfirmEmailForm();
            confirmEmail.Show();

            this.Hide();
        }
    }
}