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
using BUS;
using DTO;
using GUI;

namespace CoffeeShopManagementSystem
{
    public partial class FormDangNhap : Form
    {

        public FormDangNhap()
        {
            InitializeComponent();
        }

        private void close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void signIn_showpass_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = signIn_showpass.Checked ? '\0' : '*';
        }

        private void btnLogIn_signin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtPassword.Text;

            try
            {
                BUS_DangNhap dangNhapBus = new BUS_DangNhap();
                DTO_DangNhap user = dangNhapBus.DangNhap(email, password);
                if (user != null)
                {
                    Session.Login(user);
                    MessageBox.Show("Đăng nhập thành công!");
                    if (string.IsNullOrEmpty(user.MaQL))
                    {
                        // Navigate to manager form
                        FormQuanLy managerForm = new FormQuanLy();
                        managerForm.Show();
                        managerForm.ShowDashboardOnSignIn();
                    }
                    else
                    {
                        // Navigate to staff form
                        FormNhanVien staffForm = new FormNhanVien();
                        staffForm.Show();
                        staffForm.DathangOnSignIn();

                    }
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Email hoặc mật khẩu không hợp lệ!.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi kết nối: {ex.Message}");
            }
        }
        private void fg_Pass_Click_1(object sender, EventArgs e)
        {
            FormConfirmEmail confirmEmail = new FormConfirmEmail();
            confirmEmail.Show();
            this.Hide();
        }
    }
}

