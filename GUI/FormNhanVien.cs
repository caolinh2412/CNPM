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
        // Khởi tạo form và thiết lập thông tin người dùng
        public FormNhanVien()
        {
            InitializeComponent();
            FormNhanVien_Load();
            nameUser.TextChanged += nameUser_TextChanged;
        }

        // Hiển thị UserControl vào panelMain
        private void ShowUserControl(UserControl control)
        {
            panelMain.Controls.Clear();
            control.Dock = DockStyle.Fill;
            panelMain.Controls.Add(control);
        }

        // Lấy tên người dùng từ session
        private void FormNhanVien_Load()
        {
            nameUser.Text = Session.GetCurrentUserName();
        }

        // Mở màn hình Đặt Hàng
        private void btn_DatHang_Click(object sender, EventArgs e)
        {
            ShowUserControl(new UC_DatHang());
        }

        // Đăng xuất và quay lại màn hình đăng nhập
        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormDangNhap signInForm = new FormDangNhap();
            signInForm.Show();
        }
        public void DathangOnSignIn()
        {
            btn_DatHang.PerformClick();
        }

        // Mở màn hình Ca Làm Việc
        private void btn_LLV_Click(object sender, EventArgs e)
        {
            ShowUserControl(new uc_CaLamViec_NV());
        }

        // Căn giữa tên người dùng khi thay đổi
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
