using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;

namespace CoffeeShopManagementSystem
{
    public partial class FromChangePass : Form
    {
        private string userEmail;
        private BUS_DangNhap dangNhapBus;

        public FromChangePass(string email, BUS_DangNhap bus)
        {
            InitializeComponent();
            userEmail = email;
            dangNhapBus = bus;
        }

        private void btnSignUp_LogIn_Click(object sender, EventArgs e)
        {
            string newPassword = newPass.Text;
            string confirmPassword = cfPass.Text;

            if (newPassword != confirmPassword)
            {
                MessageBox.Show("Mật khẩu và xác nhận mật khẩu không khớp!");
                return;
            }

            try
            {
                if (dangNhapBus.ResetPassword(userEmail, newPassword))
                {
                    MessageBox.Show("Mật khẩu đã được đổi thành công!");
                    this.Close();

                    FormDangNhap signIn = new FormDangNhap();
                    signIn.Show();

                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Đổi mật khẩu thất bại. Vui lòng thử lại!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}");
            }
        }

        private void signIn_showpass_CheckedChanged(object sender, EventArgs e)
        {
            newPass.PasswordChar = signIn_showpass.Checked ? '\0' : '*';
            cfPass.PasswordChar = signIn_showpass.Checked ? '\0' : '*';
        }

        private void close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
