using GUI;
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
    public partial class ManagerForm : Form
    {
        public ManagerForm()
        {
            InitializeComponent();
        }
        private void ShowUserControl(UserControl control)
        {
            panelMain.Controls.Clear();
            control.Dock = DockStyle.Fill;
            panelMain.Controls.Add(control);
        }

        private void btnTrangChu_Click(object sender, EventArgs e)
        {
            ShowUserControl(new DashboardForm());
        }

        private void btnDanhMuc_Click(object sender, EventArgs e)
        {
            ShowUserControl(new MenuForm());
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            ShowUserControl(new FormQuanLyNV());
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Close();
            SignInForm signInForm = new SignInForm();
            signInForm.Show();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            ShowUserControl(new FormQuanLyHoaDon());
        }
    }
}
