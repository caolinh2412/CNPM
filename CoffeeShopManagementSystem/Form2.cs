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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void close_2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnlogin_signup_Click(object sender, EventArgs e)
        {
            Form1 login = new Form1();
            login.Show();

            this.Hide();
        }
    }
}
