using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeShopManagementSystem
{
    public partial class SignUpForm : Form
    {
        public SignUpForm()
        {
            InitializeComponent();
        }

        private void close_2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnlogin_signup_Click(object sender, EventArgs e)
        {
            SignInForm  login = new SignInForm();
            login.Show();

            this.Hide();
        }

        private void signup_showpass_CheckedChanged(object sender, EventArgs e)
        {
            signup_password.PasswordChar = signup_showpass.Checked ? '\0' : '*';
            signup_cfpassword.PasswordChar = signup_showpass.Checked ? '\0' : '*';
        }
    }
}
