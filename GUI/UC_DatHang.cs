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
    public partial class UC_DatHang : UserControl
    {
        private BUS_ThucDon thucDonBUS;
        private BUS_DanhMuc danhMucBUS;
        private List<FormMon> danhSachMon;
        private BUS_DonHang donHangBUS;
        private BUS_ChiTietDonHang chiTietBus;
        private BindingList<DTO_ChiTietDonHang> chiTietDonHangs;
        private BUS_CongThuc congThucBUS;
        private decimal tongTien;
        public event Action<DTO_ThucDon, int> OnMonDuocChon;
        private Bitmap memoryimg;
        private PrintDocument printDocument1;
        private PrintPreviewDialog printPreviewDialog1;

        public UC_DatHang()
        {
            InitializeComponent();
            thucDonBUS = new BUS_ThucDon();
            danhSachMon = new List<FormMon>();
            donHangBUS = new BUS_DonHang();
            danhMucBUS = new BUS_DanhMuc();
            chiTietDonHangs = new BindingList<DTO_ChiTietDonHang>();
            congThucBUS = new BUS_CongThuc();
            chiTietBus = new BUS_ChiTietDonHang();
            TaiDanhSachMon();
            HienThiThongTinHeThong();
            KhoiTaoComboBoxDanhMuc();
            KhoiTaoDataGridView();
            CapNhatTongSoLuong();

            printDocument1 = new PrintDocument();
            printPreviewDialog1 = new PrintPreviewDialog();
            btn_In.Enabled = false;

        }

        private void KhoiTaoComboBoxDanhMuc()
        {
            List<DTO_DanhMuc> loaiMonList = danhMucBUS.LayDanhSachTenDanhMuc();

            loaiMonList.Insert(0, new DTO_DanhMuc { MaDM = null, TenDM = "Tất cả" });

            cb_loaiMon.DisplayMember = "TenDM";
            cb_loaiMon.ValueMember = "MaDM";
            cb_loaiMon.DataSource = loaiMonList;
            cb_loaiMon.SelectedIndex = 0;

            LocThucDonTheoDanhMuc(null); 

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

        private void LocThucDonTheoDanhMuc(string danhMuc)
        {
            flp_ThucDon.SuspendLayout();

            foreach (var formMon in danhSachMon)
            {
                var dto = formMon.LayThongTinMon(); // cần tạo hàm này trong FormMon để lấy dữ liệu món
                if (danhMuc == null || dto.MaDM == danhMuc)
                {
                    formMon.Visible = true;
                }
                else
                {
                    formMon.Visible = false;
                }
            }

            flp_ThucDon.ResumeLayout();
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
                dgv_ChiTietHD.ClearSelection();
                dgv_ChiTietHD.Rows[e.RowIndex].Selected = true;

                // Truy cập dữ liệu của hàng được chọn
                var selectedRow = dgv_ChiTietHD.Rows[e.RowIndex];
                var selectedItem = (DTO_ChiTietDonHang)selectedRow.DataBoundItem;

                MessageBox.Show($"Bạn đã chọn món: {selectedItem.TenMon}, Số lượng: {selectedItem.SoLuong}, Thành tiền: {selectedItem.ThanhTien}",
                    "Thông tin món", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void TaiDanhSachMon()
        {
            flp_ThucDon.SuspendLayout();
            foreach (var mon in danhSachMon)
            {
                mon.Dispose();
            }
            danhSachMon.Clear();

            List<DTO_ThucDon> danhSachMonTuDB = thucDonBUS.GetAllMenuItems();

            foreach (var mon in danhSachMonTuDB)
            {
                FormMon formMon = new FormMon();
                formMon.SetThongTinMon(mon);
                formMon.OnMonSelected += ThemChiTietDonHang;
                danhSachMon.Add(formMon);
                flp_ThucDon.Controls.Add(formMon);
            }
            flp_ThucDon.ResumeLayout();
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
            Print(pnl_HoaDon);
            MessageBox.Show($"Đã in hóa đơn thành công!",
                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            lb_MaHD.Text = donHangBUS.GetNextMaDH();
            ResetForm();
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

                CapNhatTongSoLuong();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public decimal TongTien
        {
            get { return tongTien; }
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
                    lbTongTien.Text = tongTien.ToString("N0") + "VND";
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
            int pageWidth = e.PageBounds.Width;
            int pageHeight = e.PageBounds.Height;

            // Kéo giãn hình ảnh để phủ toàn bộ trang giấy (khung trắng)
            e.Graphics.DrawImage(memoryimg, new Rectangle(0, 0, pageWidth, pageHeight));
        }
        private void btn_ThanhToan_Click(object sender, EventArgs e)
        {
            FormThanhToan thanhtoan = new FormThanhToan(this);
            thanhtoan.ShowDialog();
            if (!thanhtoan.DaThanhToan)
            {
                MessageBox.Show("Bạn chưa thực hiện thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
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

                DTO_DonHang donHang = donHangBUS.TaoDonHang(Session.GetCurrentUserID());
                string maDH;
                donHang.PhuongThuc = thanhtoan.PhuongThucThanhToan;
                if (donHangBUS.ThemDonHangVaChiTiet(donHang, chiTietDonHangs, out maDH))
                {

                    DTO_DonHang savedDonHang = donHangBUS.GetDonHangById(maDH);
                    tongTien = savedDonHang.TongTien;
                    if (this.Controls.Find("lb_TongTien", true).FirstOrDefault() is Label lbTongTien)
                    {
                        lbTongTien.Text = tongTien.ToString("N0") + "đ";
                    }
                    btn_In.Enabled = true;
                    donHangBUS.CapNhatSoLuongTonKho(maDH);
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

        private void LocThucDonTheoDanhMuc(object sender, EventArgs e)
        {

        }
    }
}