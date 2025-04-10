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
    public partial class FormQuanLy : Form
    {
        public FormQuanLy()
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
            ShowUserControl(new UC_TrangChu());
        }

        private void btnDanhMuc_Click(object sender, EventArgs e)
        {
            ShowUserControl(new UC_Menu());
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            ShowUserControl(new UC_QuanLyNV());
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Close();
            FormDangNhap signInForm = new FormDangNhap();
            signInForm.Show();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            ShowUserControl(new UC_QuanLyHoaDon());
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            ShowUserControl(new UC_QuanLyKho());
        }
        public void ShowDashboardOnSignIn()
        {
            btnTrangChu.PerformClick();
        }
    }
}
