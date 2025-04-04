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
    public partial class DashboardForm : UserControl
    {
        private NhanVien_BUS bus = new NhanVien_BUS();
        private DonHang_BUS donHangBUS = new DonHang_BUS();
        private ThucDon_BUS thucDonBUS = new ThucDon_BUS();
        private ChiTietDonHang_BUS chiTietDonHangBUS = new ChiTietDonHang_BUS();

        public DashboardForm()
        {
            InitializeComponent();
            LoadEmployeeCount();
            LoadOrderCount();
            LoadDailyRevenue();
            LoadTotalMenuItemCount();
            LoadMonthlyRevenueGunaChart();
            LoadTop3MonBanChayPieChart();
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
        private void LoadMonthlyRevenueGunaChart()
        {
            try
            {
                int namHienTai = DateTime.Today.Year; 
                var doanhThuTheoThang = donHangBUS.GetDoanhThuTheoThang(namHienTai);

                // Xóa dữ liệu cũ trong GunaChart
                gunaChart_dtThang.Datasets.Clear();

                // Tạo dataset cho biểu đồ cột
                var dataset = new GunaBarDataset();
                dataset.Label = "Doanh Thu (VNĐ)";

                // Thêm dữ liệu vào dataset
                foreach (var item in doanhThuTheoThang.OrderBy(x => x.Key))
                {
                    dataset.DataPoints.Add(new LPoint { Label = $"Tháng {item.Key}", Y = (double)item.Value });
                }

                // Thêm dataset vào GunaChart
                gunaChart_dtThang.Datasets.Add(dataset);

                // Cập nhật biểu đồ
                gunaChart_dtThang.Update();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi vẽ biểu đồ doanh thu theo tháng: {ex.Message}");
            }
        }
        private void LoadTop3MonBanChayPieChart()
        {
            try
            {
                // Lấy dữ liệu top 3 món bán chạy
                var top3MonBanChay = chiTietDonHangBUS.GetTop3MonBanChay();

                // Xóa dữ liệu cũ trong biểu đồ
                gunaChart_Mon.Datasets.Clear();

                // Tạo LPointCollection để lưu các điểm dữ liệu
                LPointCollection dataPoints = new LPointCollection();

                // Thêm các món vào LPointCollection
                foreach (var mon in top3MonBanChay)
                {
                    dataPoints.Add(new LPoint { Label = mon.TenMon, Y = mon.SoLuong });
                }

                // Tạo dataset cho biểu đồ tròn
                var dataset = new GunaPieDataset
                {
                    Label = "Top 3 Món Bán Chạy",
                    DataPoints = dataPoints
                };

                // Thêm dataset vào biểu đồ
                gunaChart_Mon.Datasets.Add(dataset);
              
                // Cập nhật biểu đồ
                gunaChart_Mon.Update();
            }
            catch (Exception ex)
            {
                // Hiển thị lỗi nếu có
                MessageBox.Show($"Lỗi khi vẽ biểu đồ top 3 món bán chạy: {ex.Message}");
            }
        }
    }
}
