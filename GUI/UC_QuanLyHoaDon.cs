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
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.IO.Font;
using iText.Kernel.Colors;
using iText.Kernel.Font;



namespace GUI
{
    public partial class UC_QuanLyHoaDon : UserControl
    {
        private BUS_DonHang donHangBUS = new BUS_DonHang();
        private BUS_ChiTietDonHang chiTietDonHangBUS = new BUS_ChiTietDonHang();
        private readonly string ShopName = "Coffee 24/7";
        private readonly string OwnerName = "Nguyen Văn A";
        private readonly string ShopAddress = "558/4 Phường 12, Phạm Văn Đồng, TP Hồ Chí Minh";
       

        public UC_QuanLyHoaDon()
        {
            InitializeComponent();
            KhoiTaoDataGridView();
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

            LocHoaDon(null, null);
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
                    string ngayDatStr = row["NgayDat"].ToString();
                    if (DateTime.TryParse(ngayDatStr, out DateTime ngayDat))
                    {
                        if (ngayDat.Month == thang && ngayDat.Year == nam)
                        {
                            filteredTable.ImportRow(row);
                        }
                    }
                }

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


        private void btn_in_Click(object sender, EventArgs e)
        {
            try
            {
                int year = (int)cb_nam.SelectedItem;
                var doanhThuTheoThang = donHangBUS.GetDoanhThuTheoThang(year);
                var top3MonBanChay = chiTietDonHangBUS.GetTop3MonBanChay();

                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "PDF files (*.pdf)|*.pdf",
                    Title = "Chọn nơi lưu file báo cáo",
                    FileName = $"BaoCaoDoanhThu_{year}.pdf"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;

                    // Initialize the PDF writer and document
                    using (var writer = new PdfWriter(filePath))
                    using (var pdf = new PdfDocument(writer))
                    {
                        var document = new Document(pdf);

                        // Load font with Vietnamese support
                        string fontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "Arial.ttf");
                        var font = PdfFontFactory.CreateFont(fontPath, PdfFontFactory.EmbeddingStrategy.PREFER_EMBEDDED);
                        string LogoPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logo", "logo.png");

                        // Set font for the entire document
                        var paragraphFont = font;  // Set the font for all paragraphs
                        var cellFont = font; // Set the font for all cells

                        // Add logo (if exists)
                        if (File.Exists(LogoPath))
                        {
                            var image = new iText.Layout.Element.Image(iText.IO.Image.ImageDataFactory.Create(LogoPath));
                            image.ScaleToFit(100f, 100f);
                            image.SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER);
                            document.Add(image);
                        }

                        // Shop info
                        document.Add(new Paragraph(ShopName)
                            .SetFont(paragraphFont).SetFontSize(18).SetTextAlignment(TextAlignment.CENTER).SetBold());

                        document.Add(new Paragraph($"Chủ quán: {OwnerName}")
                            .SetFont(paragraphFont).SetFontSize(10).SetTextAlignment(TextAlignment.CENTER));
                        document.Add(new Paragraph($"Địa chỉ: {ShopAddress}")
                            .SetFont(paragraphFont).SetFontSize(10).SetTextAlignment(TextAlignment.CENTER));
                        document.Add(new Paragraph($"Ngày in báo cáo: {DateTime.Now:dd/MM/yyyy HH:mm:ss}")
                            .SetFont(paragraphFont).SetFontSize(10).SetTextAlignment(TextAlignment.CENTER).SetMarginBottom(20));

                        // Report title
                        document.Add(new Paragraph($"BÁO CÁO DOANH THU NĂM {year}")
                            .SetFont(paragraphFont).SetFontSize(18).SetTextAlignment(TextAlignment.CENTER).SetMarginBottom(20));

                        // Revenue Table
                        var revenueTable = new Table(2).UseAllAvailableWidth().SetMarginBottom(20);
                        revenueTable.AddHeaderCell(new Cell().Add(new Paragraph("Tháng").SetBold().SetBackgroundColor(ColorConstants.LIGHT_GRAY).SetTextAlignment(TextAlignment.CENTER).SetFont(cellFont)));
                        revenueTable.AddHeaderCell(new Cell().Add(new Paragraph("Doanh thu (VNĐ)").SetBold().SetBackgroundColor(ColorConstants.LIGHT_GRAY).SetTextAlignment(TextAlignment.CENTER).SetFont(cellFont)));

                        decimal tongDoanhThu = 0;
                        foreach (var item in doanhThuTheoThang.OrderBy(x => x.Key))
                        {
                            revenueTable.AddCell(new Cell().Add(new Paragraph($"Tháng {item.Key}").SetFont(paragraphFont).SetTextAlignment(TextAlignment.CENTER)));
                            revenueTable.AddCell(new Cell().Add(new Paragraph($"{item.Value:N0}").SetFont(paragraphFont).SetTextAlignment(TextAlignment.RIGHT)));
                            tongDoanhThu += item.Value;
                        }

                        revenueTable.AddCell(new Cell().Add(new Paragraph("Tổng cộng").SetBold().SetBackgroundColor(ColorConstants.LIGHT_GRAY).SetTextAlignment(TextAlignment.CENTER).SetFont(cellFont)));
                        revenueTable.AddCell(new Cell().Add(new Paragraph($"{tongDoanhThu:N0}").SetBold().SetBackgroundColor(ColorConstants.LIGHT_GRAY).SetTextAlignment(TextAlignment.RIGHT).SetFont(cellFont)));

                        document.Add(revenueTable);

                        // Top 3 items
                        document.Add(new Paragraph("TOP 3 MÓN BÁN CHẠY")
                            .SetFont(paragraphFont).SetFontSize(12).SetBold().SetTextAlignment(TextAlignment.CENTER).SetMarginBottom(10));

                        var topItemsTable = new Table(2).UseAllAvailableWidth();
                        topItemsTable.AddHeaderCell(new Cell().Add(new Paragraph("Tên món").SetBold().SetBackgroundColor(ColorConstants.LIGHT_GRAY).SetTextAlignment(TextAlignment.CENTER).SetFont(cellFont)));
                        topItemsTable.AddHeaderCell(new Cell().Add(new Paragraph("Số lượng (phần)").SetBold().SetBackgroundColor(ColorConstants.LIGHT_GRAY).SetTextAlignment(TextAlignment.CENTER).SetFont(cellFont)));

                        foreach (var mon in top3MonBanChay)
                        {
                            topItemsTable.AddCell(new Cell().Add(new Paragraph(mon.TenMon).SetFont(paragraphFont).SetTextAlignment(TextAlignment.LEFT)));
                            topItemsTable.AddCell(new Cell().Add(new Paragraph($"{mon.SoLuong}").SetFont(paragraphFont).SetTextAlignment(TextAlignment.RIGHT)));
                        }

                        document.Add(topItemsTable);

                        // Close the document
                        document.Close();
                        MessageBox.Show("Xuất file PDF thành công!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xuất file PDF: {ex.Message}");
            }
        }
    }
} 
  