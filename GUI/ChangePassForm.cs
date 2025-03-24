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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace CoffeeShopManagementSystem
{
    public partial class ChangePassForm : Form
    {
        private string userEmail;
        private UserBUS userBUS;
        public ChangePassForm(string email, UserBUS service)
        {
            userBUS = new UserBUS();
            InitializeComponent();
            userEmail = email;
            userBUS = service;
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
            userBUS.ResetPassword(userEmail, newPassword);
            MessageBox.Show("Mật khẩu đã được đổi thành công!");
            this.Close();

            SignInForm signIn = new SignInForm();
            signIn.Show();

            this.Hide();
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
