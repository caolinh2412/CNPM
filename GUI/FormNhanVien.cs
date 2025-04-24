using GUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
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

            FormNhanVien_Load();
            nameUser.TextChanged += nameUser_TextChanged;

        }
        private void ShowUserControl(UserControl control)
        {
            panelMain.Controls.Clear();
            control.Dock = DockStyle.Fill;
            panelMain.Controls.Add(control);
        }
        private void FormNhanVien_Load()
        {
            nameUser.Text = Session.GetCurrentUserName();
        }
     
        private void btn_DatHang_Click(object sender, EventArgs e)
        {
            ShowUserControl(new UC_DatHang());
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Close();
            FormDangNhap signInForm = new FormDangNhap();
            signInForm.Show();
        }
        public void DathangOnSignIn()
        {
            btn_DatHang.PerformClick();
        }

        private void btn_LLV_Click(object sender, EventArgs e)
        {
            ShowUserControl(new uc_CaLamViec_NV());
        }

        private void nameUser_TextChanged(object sender, EventArgs e)
        {
            nameUser.AutoSize = true;

            Control parent = nameUser.Parent;
            if (parent != null)
            {
                nameUser.Left = (parent.Width - nameUser.Width) / 2;
            }
            else
            {
                nameUser.Left = (this.ClientSize.Width - nameUser.Width) / 2;
            }
        }    
    }
}
