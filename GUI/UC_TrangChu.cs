using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using CoffeeShopManagementSystem.BUS;
using Guna.Charts.WinForms;

namespace CoffeeShopManagementSystem
{
    public partial class UC_TrangChu : UserControl
    {
        // Khai báo các lớp xử lý nghiệp vụ (BUS)
        private BUS_NhanVien bus = new BUS_NhanVien();
        private BUS_DonHang donHangBUS = new BUS_DonHang();
        private BUS_ThucDon thucDonBUS = new BUS_ThucDon();
        private BUS_ChiTietDonHang chiTietDonHangBUS = new BUS_ChiTietDonHang();       
        
        public UC_TrangChu()
        {
            InitializeComponent();
            LoadEmployeeCount();     // Tải số lượng nhân viên
            LoadOrderCount();        // Tải số lượng đơn hàng
            LoadDailyRevenue();      // Tải doanh thu trong ngày
            LoadTotalMenuItemCount();// Tải tổng số món trong menu
        }

        // Hiển thị số lượng nhân viên
        private void LoadEmployeeCount()
        {
            int employeeCount = bus.GetEmployeeCount();
            lblSoNV.Text = employeeCount.ToString();
        }

        // Hiển thị tổng số đơn hàng
        private void LoadOrderCount()
        {
            int orderCount = donHangBUS.GetTongDH();
            lbl_TongKhach.Text = orderCount.ToString();
        }

        // Hiển thị doanh thu trong ngày
        private void LoadDailyRevenue()
        {
            try
            {
                DateTime ngay = DateTime.Today; // Ngày hiện tại
                decimal dailyRevenue = donHangBUS.GetTongDoanhThu(ngay);
                lbl_DoanhThu.Text = dailyRevenue.ToString("N0");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lấy doanh thu trong ngày: {ex.Message}");
                lbl_DoanhThu.Text = "0";
            }
        }
        // Hiển thị tổng số món trong menu
        private void LoadTotalMenuItemCount()
        {
            try
            {
                int totalMenuItems = thucDonBUS.GetTongSoMon();
                lbl_slMon.Text = totalMenuItems.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lấy tổng số món trong menu: {ex.Message}");
                lbl_slMon.Text = "0";
            }
        }
    }
}
