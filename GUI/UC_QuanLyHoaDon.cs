using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using BUS;
using CoffeeShopManagementSystem.BUS;
using Guna.Charts.WinForms;

namespace GUI
{
    public partial class UC_QuanLyHoaDon : UserControl
    {
        private BUS_DonHang donHangBUS = new BUS_DonHang();
        private BUS_ChiTietDonHang chiTietDonHangBUS = new BUS_ChiTietDonHang();

        public UC_QuanLyHoaDon()
        {
            InitializeComponent();
            KhoiTaoDataGridView();
            TaiDanhSachHoaDon();
            LoadMonthlyRevenueGunaChart();
            LoadTop3MonBanChayPieChart();
            dgv_DonHang.CellClick += dgv_DonHang_CellClick;
            this.Load += FormQuanLyHoaDon_Load;

        }
        private void FormQuanLyHoaDon_Load(object sender, EventArgs e)
        {
            // Thêm các tháng từ 1 đến 12
            for (int i = 1; i <= 12; i++)
            {
                cb_thang.Items.Add(i);
            }

            // Thêm các năm từ 2020 đến năm hiện tại
            for (int i = 2020; i <= DateTime.Now.Year; i++)
            {
                cb_nam.Items.Add(i);
            }

            // Mặc định chọn tháng và năm hiện tại
            cb_thang.SelectedItem = DateTime.Now.Month;
            cb_nam.SelectedItem = DateTime.Now.Year;

            // Thêm sự kiện SelectedIndexChanged
            cb_thang.SelectedIndexChanged += new EventHandler(LocHoaDon);
            cb_nam.SelectedIndexChanged += new EventHandler(LocHoaDon);
        }
        private void LocHoaDon(object sender, EventArgs e)
        {
            if (cb_thang.SelectedItem != null && cb_nam.SelectedItem != null)
            {
                int thang = (int)cb_thang.SelectedItem;
                int nam = (int)cb_nam.SelectedItem;

                // Lấy DataTable từ DonHang_BUS
                var dataTable = donHangBUS.LayDanhSachDonHang();

                // Tạo DataTable mới để chứa kết quả lọc
                DataTable filteredTable = dataTable.Clone();

                // Duyệt qua từng hàng và lọc thủ công
                foreach (DataRow row in dataTable.Rows)
                {
                    // Chuyển chuỗi NgayDat thành DateTime với định dạng cụ thể
                    string ngayDatStr = row["NgayDat"].ToString(); // Chuỗi dạng "4/2/2025 8:46:16 AM"
                    DateTime ngayDat;
                    try
                    {
                        ngayDat = DateTime.ParseExact(ngayDatStr, "M/d/yyyy h:mm:ss tt", System.Globalization.CultureInfo.InvariantCulture);
                        if (ngayDat.Month == thang && ngayDat.Year == nam)
                        {
                            filteredTable.ImportRow(row);
                        }
                    }
                    catch (FormatException ex)
                    {
                        // Xử lý lỗi nếu chuỗi không đúng định dạng
                        MessageBox.Show($"Lỗi định dạng ngày tháng: {ngayDatStr}. Chi tiết: {ex.Message}");
                    }
                }

                // Gán DataTable đã lọc vào DataGridView
                dgv_DonHang.DataSource = filteredTable;
                dgv_CTDH.DataSource = null;
            }
        }
        private void KhoiTaoDataGridView()
        {
            dgv_DonHang.AutoGenerateColumns = false;
            dgv_DonHang.Columns["col_MaHD"].DataPropertyName = "MaDH";
            dgv_DonHang.Columns["col_NhanVien"].DataPropertyName = "HoVaTen";
            dgv_DonHang.Columns["col_Ngay"].DataPropertyName = "NgayDat";
            dgv_DonHang.Columns["col_TongTien"].DataPropertyName = "TongTien";
            dgv_DonHang.Columns["col_PhuongThuc"].DataPropertyName = "PhuongThuc";

            dgv_CTDH.AutoGenerateColumns = false;
            dgv_CTDH.Columns["col_TenMon"].DataPropertyName = "TenMon";
            dgv_CTDH.Columns["col_SL"].DataPropertyName = "SoLuong";
            dgv_CTDH.Columns["col_DonGia"].DataPropertyName = "Gia";
            dgv_CTDH.Columns["col_ThanhTien"].DataPropertyName = "ThanhTien";
        }

        private void TaiDanhSachHoaDon()
        {
            dgv_DonHang.DataSource = donHangBUS.LayDanhSachDonHang();
        }

        private void dgv_DonHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string maDH = dgv_DonHang.Rows[e.RowIndex].Cells["col_MaHD"].Value.ToString();
                dgv_CTDH.DataSource = chiTietDonHangBUS.LayChiTietDonHangTheoMaDH(maDH);
            }
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