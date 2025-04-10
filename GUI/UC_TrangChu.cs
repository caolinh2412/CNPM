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
        private BUS_NhanVien bus = new BUS_NhanVien();
        private BUS_DonHang donHangBUS = new BUS_DonHang();
        private BUS_ThucDon thucDonBUS = new BUS_ThucDon();
        private BUS_ChiTietDonHang chiTietDonHangBUS = new BUS_ChiTietDonHang();

        public UC_TrangChu()
        {
            InitializeComponent();
            LoadEmployeeCount();
            LoadOrderCount();
            LoadDailyRevenue();
            LoadTotalMenuItemCount();
            //LoadMonthlyRevenueGunaChart();
            //LoadTop3MonBanChayPieChart();
        }

        private void LoadEmployeeCount()
        {
            int employeeCount = bus.GetEmployeeCount();
            lblSoNV.Text = employeeCount.ToString();
        }
        private void LoadOrderCount()
        {
            int orderCount = donHangBUS.GetTongDH();
            lbl_TongKhach.Text = orderCount.ToString();
        }
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
