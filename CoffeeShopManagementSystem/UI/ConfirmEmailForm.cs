using CoffeeShopManagementSystem.BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace CoffeeShopManagementSystem
{
    public partial class ConfirmEmailForm : Form

    {
        private UserBUS forgotPassword = new UserBUS();
        private string userEmail;
        public ConfirmEmailForm()
        {
            InitializeComponent();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (forgotPassword.ValidateCode(code.Text))
            {
                MessageBox.Show("Mã hợp lệ! Đang chuyển đến form đổi mật khẩu...");
                ChangePassForm changePassForm = new ChangePassForm(userEmail, forgotPassword);
                changePassForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Mã không hợp lệ hoặc đã hết hạn!");
            }

        }

        private void btnSendCode_Click(object sender, EventArgs e)
        {
            userEmail = signUp_Email.Text.Trim();
            if (forgotPassword.VerifyEmail(userEmail))
            {
                forgotPassword.GenerateAndSendCode(userEmail);
                MessageBox.Show("Mã xác nhận đã được gửi, vui lòng kiểm tra email!");
            }
            else
            {
                MessageBox.Show("Email không tồn tại trong hệ thống!");
            }
        }

        private void close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogIn_signin_Click(object sender, EventArgs e)
        {
            SignInForm signIn = new SignInForm();
            signIn.Show();

            this.Hide();
        }
    }
}
