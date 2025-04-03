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

namespace GUI
{
    public partial class FormDatHang : UserControl
    {
        private ThucDon_BUS thucDonBUS;
        private List<FormMon> danhSachMon;
        private DonHangBUS donHangBUS;
        private ChiTietDonHang_BUS chiTietBus;
        private BindingList<ChiTietDonHang_DTO> chiTietDonHangs;
        private decimal tongTien;
        public event Action<ThucDon_DTO, int> OnMonDuocChon;
        private Bitmap memoryimg;
        private PrintDocument printDocument1;
        private PrintPreviewDialog printPreviewDialog1; 

        public FormDatHang()
        {
            InitializeComponent();
            thucDonBUS = new ThucDon_BUS();
            danhSachMon = new List<FormMon>();
            donHangBUS = new DonHangBUS();
            chiTietDonHangs = new BindingList<ChiTietDonHang_DTO>();
            chiTietBus = new ChiTietDonHang_BUS();
            TaiDanhSachMon();
            HienThiThongTinHeThong();
            KhoiTaoComboBoxDanhMuc();
            KhoiTaoDataGridView();
            CapNhatTongSoLuong();

            printDocument1 = new PrintDocument();
            printPreviewDialog1 = new PrintPreviewDialog();

        }
        private void KhoiTaoComboBoxDanhMuc()
        {

            List<string> danhMuc = new List<string> { "Tất cả", "Cà phê", "Trà sữa", "Nước ép", "Sinh tố", "Trà", "Đá xay", "Bánh ngọt" };

            cb_loaiMon.DataSource = danhMuc;
            cb_loaiMon.SelectedIndex = 0;

            cb_loaiMon.SelectedIndexChanged += Cbo_DanhMuc_ThayDoiLuaChon;
        }

        private void Cbo_DanhMuc_ThayDoiLuaChon(object sender, EventArgs e)
        {
            string danhMucDaChon = cb_loaiMon.SelectedItem.ToString();
            LocThucDonTheoDanhMuc(danhMucDaChon);
        }

        private void LocThucDonTheoDanhMuc(string danhMuc)
        {
            foreach (var mon in danhSachMon)
            {
                mon.Dispose();
            }
            danhSachMon.Clear();
            flp_ThucDon.Controls.Clear();

            List<ThucDon_DTO> danhSachMonLoc;
            if (danhMuc == "Tất cả")
            {
                danhSachMonLoc = thucDonBUS.GetAllMenuItems();
            }
            else
            {
                danhSachMonLoc = thucDonBUS.GetMenuItemsByCategory(danhMuc);
            }

            foreach (var mon in danhSachMonLoc)
            {
                FormMon formMon = new FormMon();
                formMon.SetThongTinMon(mon);
                formMon.OnMonSelected += ThemChiTietDonHang;
                danhSachMon.Add(formMon);
                flp_ThucDon.Controls.Add(formMon);
            }
        }
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
        private void dgv_ChiTietHD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem chỉ số hàng được nhấp có hợp lệ không (bỏ qua nhấp vào tiêu đề, có RowIndex = -1)
            if (e.RowIndex >= 0 && dgv_ChiTietHD.Rows.Count > 0 && e.RowIndex < dgv_ChiTietHD.Rows.Count)
            {
                // Chọn hàng được nhấp một cách lập trình
                dgv_ChiTietHD.ClearSelection();
                dgv_ChiTietHD.Rows[e.RowIndex].Selected = true;

                // Truy cập dữ liệu của hàng được chọn
                var selectedRow = dgv_ChiTietHD.Rows[e.RowIndex];
                var selectedItem = (ChiTietDonHang_DTO)selectedRow.DataBoundItem;

                // Tùy chọn: Hiển thị chi tiết mục được chọn (để gỡ lỗi hoặc phản hồi cho người dùng)
                MessageBox.Show($"Bạn đã chọn món: {selectedItem.TenMon}, Số lượng: {selectedItem.SoLuong}, Thành tiền: {selectedItem.ThanhTien}",
                    "Thông tin món", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void TaiDanhSachMon()
        {
            foreach (var mon in danhSachMon)
            {
                mon.Dispose();
            }
            danhSachMon.Clear();

            List<ThucDon_DTO> danhSachMonTuDB = thucDonBUS.GetAllMenuItems();

            foreach (var mon in danhSachMonTuDB)
            {
                FormMon formMon = new FormMon();
                formMon.SetThongTinMon(mon);
                formMon.OnMonSelected += ThemChiTietDonHang;
                danhSachMon.Add(formMon);
                flp_ThucDon.Controls.Add(formMon);
            }
        }

        private void HienThiThongTinHeThong()
        {
            lb_ThoiGian.Text = DateTime.Now.ToString("dd/MM/yyyy");
            lb_ThuNgan.Text = Session.GetCurrentUserName();
            lb_MaHD.Text = donHangBUS.GetNextMaDH();
            CapNhatTongSoLuong();
        }

        public void LamMoiHienThi()
        {
            TaiDanhSachMon();
            HienThiThongTinHeThong();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            // Để trống hoặc thêm logic nếu cần
        }

        private void btn_In_Click(object sender, EventArgs e)
        {
            try
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

                DonHangDTO donHang = donHangBUS.TaoDonHang(Session.GetCurrentUserID());
                string maDH;

                if (donHangBUS.ThemDonHangVaChiTiet(donHang, chiTietDonHangs, out maDH))
                {
                    DonHangDTO savedDonHang = donHangBUS.GetDonHangById(maDH);
                    tongTien = savedDonHang.TongTien;
                    if (this.Controls.Find("lb_TongTien", true).FirstOrDefault() is Label lbTongTien)
                    {
                        lbTongTien.Text = tongTien.ToString("N0") + "đ";
                    }
                    Print(pnl_HoaDon);
                    MessageBox.Show($"Đã in hóa đơn thành công! Mã đơn hàng: {maDH}",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lb_MaHD.Text = donHangBUS.GetNextMaDH();
                    ResetForm();
                }
                else
                {
                    throw new Exception("Không thể lưu đơn hàng vào cơ sở dữ liệu!");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error in btn_In_Click: {ex.Message}");
                MessageBox.Show($"Lỗi khi lưu đơn hàng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CapNhatTongSoLuong()
        {
            int tongSoLuong = chiTietDonHangs.Sum(x => x.SoLuong);
            if (this.Controls.Find("lb_TongSL", true).FirstOrDefault() is Label lbTongSL)
            {
                lbTongSL.Text = tongSoLuong.ToString();
            }
        }

        private void ResetForm()
        {
            chiTietDonHangs.Clear();
            tongTien = 0;           
            if (this.Controls.Find("lb_TongTien", true).FirstOrDefault() is Label lbTongTien)
            {
                lbTongTien.Text = "0";
            }
            CapNhatTongSoLuong();
        }

        private void ThemChiTietDonHang(ThucDon_DTO mon, int soLuong)
        {
            chiTietBus.ThemChiTietDonHang(chiTietDonHangs, mon, soLuong);
            tongTien = chiTietDonHangs.Sum(x => x.ThanhTien);
            if (this.Controls.Find("lb_TongTien", true).FirstOrDefault() is Label lbTongTien)
            {
                lbTongTien.Text = tongTien.ToString("N0") + "đ";
            }
            CapNhatTongSoLuong();
        }

        private void btn_XoaMon_Click(object sender, EventArgs e)
        {
            if (dgv_ChiTietHD.SelectedRows.Count > 0)
            {
                int selectedIndex = dgv_ChiTietHD.SelectedRows[0].Index;
                chiTietDonHangs.RemoveAt(selectedIndex);
                tongTien = chiTietDonHangs.Sum(x => x.ThanhTien);
                if (this.Controls.Find("lb_TongTien", true).FirstOrDefault() is Label lbTongTien)
                {
                    lbTongTien.Text = tongTien.ToString("N0") + "đ";
                }
                CapNhatTongSoLuong();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một món để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            // Xóa toàn bộ mục trong danh sách chi tiết đơn hàng
            ResetForm();

            // Thông báo cho người dùng (tùy chọn)
            MessageBox.Show("Đã hủy đơn hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void Print(Panel pnl)
        {
            PrinterSettings ps = new PrinterSettings();

            memoryimg = new Bitmap(pnl.Width, pnl.Height);

            pnl.DrawToBitmap(memoryimg, new Rectangle(0, 0, pnl.Width, pnl.Height));

            printPreviewDialog1.Document = printDocument1;
            printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
            printPreviewDialog1.ShowDialog();
        }
        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            PrinterSettings ps = new PrinterSettings();
            int pageWidth = e.PageBounds.Width;
            int pageHeight = e.PageBounds.Height;

            // Kéo giãn hình ảnh để phủ toàn bộ trang giấy (khung trắng)
            e.Graphics.DrawImage(memoryimg, new Rectangle(0, 0, pageWidth, pageHeight));
        }

    }
}