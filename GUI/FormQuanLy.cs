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

        // Phương thức để hiển thị UserControl trong panelMain
        private void ShowUserControl(UserControl control)
        {

            panelMain.Controls.Clear(); // Xóa các điều khiển hiện tại trong panelMain
            control.Dock = DockStyle.Fill;   //Đặt điều khiển mới vào panelMain
            panelMain.Controls.Add(control);    //Thêm điều khiển mới vào panelMain
        }

        // Sự kiện khi nhấn nút "Trang Chủ"
        private void btnTrangChu_Click(object sender, EventArgs e)
        {
            ShowUserControl(new UC_TrangChu()); // Hiển thị UserControl UC_TrangChu
        }
        // Sự kiện khi nhấn nút "Thực đơn"
        private void btnDanhMuc_Click(object sender, EventArgs e)
        {
            ShowUserControl(new UC_Menu()); // Hiển thị UserControl UC_Menu
        }

        // Sự kiện khi nhấn nút "Nhân viên"
        private void guna2Button3_Click(object sender, EventArgs e)
        {
            ShowUserControl(new UC_QuanLyNV()); // Hiển thị UserControl UC_QuanLyNV

        }

        // Sự kiện khi nhấn nút "Đăng xuất"
        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Close(); // Đóng form hiện tại
            FormDangNhap signInForm = new FormDangNhap();
            signInForm.Show(); // Hiển thị form đăng nhập
        }

        // Sự kiện khi nhấn nút "Thông kê hóa đơn"
        private void guna2Button4_Click(object sender, EventArgs e)
        {
            ShowUserControl(new UC_QuanLyHoaDon()); // Hiển thị UserControl UC_QuanLyHoaDon
        }

        // Sự kiện khi nhấn nút "Quản lý kho"
        private void guna2Button5_Click(object sender, EventArgs e)
        {
            ShowUserControl(new UC_QuanLyKho()); // Hiển thị UserControl UC_QuanLyKho
        }
        public void ShowDashboardOnSignIn()
        {
            btnTrangChu.PerformClick();
        }
    }
}
