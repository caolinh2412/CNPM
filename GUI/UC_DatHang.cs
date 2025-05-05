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
using DTO;
using CoffeeShopManagementSystem.BUS;
using Microsoft.VisualBasic.ApplicationServices;
using System.Diagnostics;
using System.Drawing.Printing;
using System.Drawing;
using static GUI.UC_Mon;
using System.Collections.Concurrent;

namespace GUI
{
    public partial class UC_DatHang : UserControl
    {
        // Khai báo các biến và đối tượng cần thiết
        private BUS_ThucDon thucDonBUS;
        private BUS_DanhMuc danhMucBUS;
        private List<UC_Mon> danhSachMon;
        private BUS_DonHang donHangBUS;
        private BUS_ChiTietDonHang chiTietBus;
        private BindingList<DTO_ChiTietDonHang> chiTietDonHangs;
        private BUS_CongThuc congThucBUS;
        private decimal tongTien;       
        private Bitmap memoryimg;
        private PrintDocument printDocument1;
        private PrintPreviewDialog printPreviewDialog1;

        //private readonly Dictionary<string, List<UC_Mon>> _monTheoDanhMuc = new Dictionary<string, List<UC_Mon>>();

        public UC_DatHang()
        {
            // Khởi tạo các thành phần giao diện
            InitializeComponent();
            DoubleBuffered = true;
            thucDonBUS = new BUS_ThucDon();
            danhSachMon = new List<UC_Mon>();
            donHangBUS = new BUS_DonHang();
            danhMucBUS = new BUS_DanhMuc();
            chiTietDonHangs = new BindingList<DTO_ChiTietDonHang>();
            congThucBUS = new BUS_CongThuc();
            chiTietBus = new BUS_ChiTietDonHang();

            
            TaiDanhSachMon(); // Tải danh sách món lên giao diện
            HienThiThongTinHeThong(); // Hiển thị ngày, nhân viên, mã hóa đơn
            KhoiTaoComboBoxDanhMuc(); // Đổ danh mục vào combobox
            KhoiTaoDataGridView(); // Cấu hình bảng chi tiết đơn hàng
            CapNhatTongSoLuong(); // Cập nhật tổng số lượng món

            // Đặt thuộc tính cho các thành phần in ấn
            printDocument1 = new PrintDocument();
            printPreviewDialog1 = new PrintPreviewDialog();
            btn_In.Enabled = false;


        }
        // Đổ dữ liệu danh mục món vào ComboBox và gán sự kiện lọc món theo danh mục
        private void KhoiTaoComboBoxDanhMuc()
        {
            List<DTO_DanhMuc> loaiMonList = danhMucBUS.LayDanhSachTenDanhMuc();

            loaiMonList.Insert(0, new DTO_DanhMuc { MaDM = null, TenDM = "Tất cả" }); // Thêm mục "Tất cả"

            cb_loaiMon.DisplayMember = "TenDM";
            cb_loaiMon.ValueMember = "MaDM";
            cb_loaiMon.DataSource = loaiMonList;
            cb_loaiMon.SelectedIndex = 0;

            LocThucDonTheoDanhMuc(null); // Mặc định hiển thị tất cả

            // Gán sự kiện thay đổi danh mục
            cb_loaiMon.SelectedIndexChanged += (sender, e) =>
            {
                var selectedValue = cb_loaiMon.SelectedValue;

                if (selectedValue == null || selectedValue == DBNull.Value)
                {
                    LocThucDonTheoDanhMuc(null);
                }
                else
                {
                    LocThucDonTheoDanhMuc(selectedValue.ToString());
                }
            };
        }

        // Tải danh sách món ăn từ cơ sở dữ liệu và hiển thị lên giao diện
        private async void TaiDanhSachMon()
        {
            flp_ThucDon.SuspendLayout(); // Tạm dừng layout để giảm thiểu các lần vẽ lại không cần thiết

            var danhSachMoi = await Task.Run(() =>
            {
                var ds = new List<UC_Mon>();
                foreach (var mon in thucDonBUS.GetAllMenuItems())
                {
                    var control = new UC_Mon();
                    control.SetThongTinMon(mon); // Thiết lập thông tin món ăn
                    control.OnMonSelected += ThemChiTietDonHang; // Đăng ký sự kiện khi chọn món
                    ds.Add(control);
                }
                return ds;
            });

            // Cập nhật các control vào UI chỉ sau khi tất cả đều đã tải xong
            flp_ThucDon.Invoke(new Action(() =>
            {
                flp_ThucDon.Controls.Clear(); // Xóa tất cả các control hiện tại
                danhSachMon.Clear(); // Xóa danh sách cũ
                danhSachMon.AddRange(danhSachMoi); // Thêm danh sách mới
                flp_ThucDon.Controls.AddRange(danhSachMoi.ToArray()); // Cập nhật UI
            }));

            flp_ThucDon.ResumeLayout(); // Tiếp tục layout
        }
        // Lọc danh sách món ăn theo danh mục
        private void LocThucDonTheoDanhMuc(string danhMuc)
        {
            flp_ThucDon.SuspendLayout();

            foreach (var mon in danhSachMon)
            {
                var dto = mon.LayThongTinMon(); // bạn đã xử lý đúng rồi
                mon.Visible = danhMuc == null || dto.MaDM == danhMuc;
            }

            flp_ThucDon.ResumeLayout();
        }

        // Khởi tạo DataGridView để hiển thị chi tiết đơn hàng
        private void KhoiTaoDataGridView()
        {
            dgv_ChiTietHD.AutoGenerateColumns = false;
            dgv_ChiTietHD.Columns["col_TenMon"].DataPropertyName = "TenMon";
            dgv_ChiTietHD.Columns["col_SoLuong"].DataPropertyName = "SoLuong";
            dgv_ChiTietHD.Columns["col_DonGia"].DataPropertyName = "Gia";
            dgv_ChiTietHD.Columns["col_ThanhTien"].DataPropertyName = "ThanhTien";

            dgv_ChiTietHD.DataSource = chiTietDonHangs;
            dgv_ChiTietHD.CellClick += dgv_ChiTietHD_CellClick;
        }
        // Xử lý sự kiện khi người dùng click vào món ăn trong DataGridView
        private void dgv_ChiTietHD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem chỉ số hàng được nhấp có hợp lệ không (bỏ qua nhấp vào tiêu đề, có RowIndex = -1)
            if (e.RowIndex >= 0 && dgv_ChiTietHD.Rows.Count > 0 && e.RowIndex < dgv_ChiTietHD.Rows.Count)
            {
                dgv_ChiTietHD.ClearSelection();
                dgv_ChiTietHD.Rows[e.RowIndex].Selected = true;

                // Truy cập dữ liệu của hàng được chọn
                var selectedRow = dgv_ChiTietHD.Rows[e.RowIndex];
                var selectedItem = (DTO_ChiTietDonHang)selectedRow.DataBoundItem;

                MessageBox.Show($"Bạn đã chọn món: {selectedItem.TenMon}, Số lượng: {selectedItem.SoLuong}, Thành tiền: {selectedItem.ThanhTien}",
                    "Thông tin món", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Hiển thị thông tin người dùng, thời gian và mã đơn hàng
        private void HienThiThongTinHeThong()
        {
            lb_ThoiGian.Text = DateTime.Now.ToString("dd/MM/yyyy");
            lb_ThuNgan.Text = Session.GetCurrentUserName();
            lb_MaHD.Text = donHangBUS.GetNextMaDH();           
            CapNhatTongSoLuong();
        }
        // Làm mới giao diện gọi món
        public void LamMoiHienThi()
        {
            TaiDanhSachMon();
            HienThiThongTinHeThong();
        }
        // Xử lý sự kiện khi nhấn nút "In"
        private void btn_In_Click(object sender, EventArgs e)
        {
            if (chiTietDonHangs.Count == 0)
            {
                MessageBox.Show("Chưa có món nào được chọn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(Session.GetCurrentUserID()))
            {
                MessageBox.Show("Không thể xác định người dùng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Tạo hóa đơn
            Print(pnl_HoaDon);
            MessageBox.Show($"Đã in hóa đơn thành công!",
                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            lb_MaHD.Text = donHangBUS.GetNextMaDH();
            ResetForm();
            btn_In.Enabled = false;
           
        }
        // Cập nhật tổng số lượng món ăn trong đơn hàng
        private void CapNhatTongSoLuong()
        {
            int tongSoLuong = chiTietDonHangs.Sum(x => x.SoLuong);
            if (this.Controls.Find("lb_TongSL", true).FirstOrDefault() is Label lbTongSL)
            {
                lbTongSL.Text = tongSoLuong.ToString();
            }
        }

        // Làm mới giao diện 
        private void ResetForm()
        {
            chiTietDonHangs.Clear();
            tongTien = 0;
            if (this.Controls.Find("lb_TongTien", true).FirstOrDefault() is Label lbTongTien)
            {
                lbTongTien.Text = "";
            }
            CapNhatTongSoLuong();
        }
        // Thêm chi tiết đơn hàng vào danh sách
        private void ThemChiTietDonHang(DTO_ThucDon mon, int soLuong)
        {
            try
            {
                // Kiểm tra tồn kho trước khi thêm
                bool duNguyenLieu = congThucBUS.KiemTraTonKho(mon, soLuong);


                if (!duNguyenLieu)
                {                   
                    throw new Exception("Không đủ nguyên liệu tồn kho để thêm món này!");
                }              
                // Nếu đủ nguyên liệu thì thêm chi tiết đơn hàng
                chiTietBus.ThemChiTietDonHang(chiTietDonHangs, mon, soLuong);

                // Cập nhật tổng tiền
                tongTien = chiTietDonHangs.Sum(x => x.ThanhTien);
                if (this.Controls.Find("lb_TongTien", true).FirstOrDefault() is Label lbTongTien)
                {
                    lbTongTien.Text = tongTien.ToString("N0") + "VND";
                }
                dgv_ChiTietHD.Refresh();
                CapNhatTongSoLuong();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Lấy tổng tiền của đơn hàng
        public decimal TongTien
        {
            get { return tongTien; }
        }
        // Xóa món ăn khỏi đơn hàng
        private void btn_XoaMon_Click(object sender, EventArgs e)
        {
            if (dgv_ChiTietHD.SelectedRows.Count > 0)
            {
                int selectedIndex = dgv_ChiTietHD.SelectedRows[0].Index;
                var selectedItem = chiTietDonHangs[selectedIndex];

                // Cập nhật lại kho khi xóa món
                congThucBUS.CapNhatKhoKhiXoaMon(selectedItem.MaMon, selectedItem.SoLuong);
                chiTietDonHangs.RemoveAt(selectedIndex);

                // Cập nhật tổng tiền sau khi xóa món
                tongTien = chiTietDonHangs.Sum(x => x.ThanhTien);
                if (this.Controls.Find("lb_TongTien", true).FirstOrDefault() is Label lbTongTien)
                {
                    lbTongTien.Text = tongTien.ToString("N0") + "VND";
                }

                CapNhatTongSoLuong();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một món để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Xóa toàn bộ đơn hàng
        private void btn_Huy_Click(object sender, EventArgs e)
        {
            if (chiTietDonHangs == null || chiTietDonHangs.Count == 0)
            {
                MessageBox.Show("Chưa có đơn hàng để hủy!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Cập nhật lại kho nguyên liệu cho từng món trong đơn hàng trước khi xóa
            foreach (var item in chiTietDonHangs)
            {
                congThucBUS.CapNhatKhoKhiXoaMon(item.MaMon, item.SoLuong);
            }

            // Đặt lại biểu mẫu và xóa toàn bộ món đã chọn
            ResetForm();

            // Thông báo cho người dùng biết đơn hàng đã được hủy thành công
            MessageBox.Show("Đã hủy đơn hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // In hóa đơn
        private void Print(Panel pnl)
        {
            PrinterSettings ps = new PrinterSettings();

            memoryimg = new Bitmap(pnl.Width, pnl.Height);

            // Chụp ảnh màn hình của bảng điều khiển và vẽ nó vào bản đồ bitmap
            pnl.DrawToBitmap(memoryimg, new Rectangle(0, 0, pnl.Width, pnl.Height));

            printPreviewDialog1.Document = printDocument1;

            // In tài liệu trong luồng nền để tránh chặn UI
            printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);

            printPreviewDialog1.ShowDialog();
        }
  
        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            int pageWidth = e.PageBounds.Width;
            int pageHeight = e.PageBounds.Height;

            // Kéo giãn hình ảnh để phủ toàn bộ trang giấy (khung trắng)
            e.Graphics.DrawImage(memoryimg, new Rectangle(0, 0, pageWidth, pageHeight));
        }

        // Xử lý sự kiện khi nhấn nút "Thanh Toán"
        private void btn_ThanhToan_Click(object sender, EventArgs e)
        {
            FormThanhToan thanhtoan = new FormThanhToan(this);
            thanhtoan.ShowDialog();

            // Kiểm tra xem người dùng đã thanh toán hay chưa
            if (!thanhtoan.DaThanhToan)
            {
                MessageBox.Show("Bạn chưa thực hiện thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                // Kiểm tra xem có món nào được chọn không
                if (chiTietDonHangs.Count == 0)
                {
                    MessageBox.Show("Chưa có món nào được chọn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrEmpty(Session.GetCurrentUserID()))
                {
                    MessageBox.Show("Không thể xác định người dùng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Tạo đơn hàng mới với ID nhân viên hiện tại từ phiên đăng nhập
                DTO_DonHang donHang = donHangBUS.TaoDonHang(Session.GetCurrentUserID());

                string maDH; // Biến lưu mã đơn hàng sau khi thêm thành công

                // Gán phương thức thanh toán được chọn vào đơn hàng
                donHang.PhuongThuc = thanhtoan.PhuongThucThanhToan;

                // Tiến hành thêm đơn hàng và các chi tiết đơn hàng vào cơ sở dữ liệu
                if (donHangBUS.ThemDonHangVaChiTiet(donHang, chiTietDonHangs, out maDH))
                {
                    // Lấy lại đơn hàng vừa lưu để lấy thông tin chi tiết như tổng tiền
                    DTO_DonHang savedDonHang = donHangBUS.GetDonHangById(maDH);

                    tongTien = savedDonHang.TongTien;

                    // Cập nhật giao diện: hiển thị tổng tiền nếu tìm thấy Label "lb_TongTien"
                    if (this.Controls.Find("lb_TongTien", true).FirstOrDefault() is Label lbTongTien)
                    {
                        lbTongTien.Text = tongTien.ToString("N0") + "đ"; // Định dạng tiền tệ
                    }

                    // Bật nút in hóa đơn sau khi đơn hàng đã được lưu thành công
                    btn_In.Enabled = true;
                }
                else
                {
                    throw new Exception("Không thể lưu đơn hàng vào cơ sở dữ liệu!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu đơn hàng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}