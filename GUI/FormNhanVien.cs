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
    public partial class FormNhanVien : Form
    {
        public FormNhanVien()
        {
            InitializeComponent();
        }
        private void ShowUserControl(UserControl control)
        {
            panelMain.Controls.Clear();
            control.Dock = DockStyle.Fill;
            panelMain.Controls.Add(control);
        }
        private void guna2Button4_Click(object sender, EventArgs e)
        {
            ShowUserControl(new FormDatHang());
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Close();
            FormDangNhap signInForm = new FormDangNhap();
            signInForm.Show();
        }
    }
}
