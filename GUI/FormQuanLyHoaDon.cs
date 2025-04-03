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

namespace GUI
{
    public partial class FormQuanLyHoaDon: UserControl
    {
        private DonHangBUS donHangBUS = new DonHangBUS();
        private ChiTietDonHang_BUS chiTietDonHangBUS = new ChiTietDonHang_BUS();

        public FormQuanLyHoaDon()
        {
            InitializeComponent();
            KhoiTaoDataGridView();
            TaiDanhSachHoaDon();
            dgv_DonHang.CellClick += dgv_DonHang_CellClick;
        }

        private void KhoiTaoDataGridView()
        {
            dgv_DonHang.AutoGenerateColumns = false;
            dgv_DonHang.Columns["col_MaHD"].DataPropertyName = "MaDH";
            dgv_DonHang.Columns["col_NhanVien"].DataPropertyName = "HoVaTen";
            dgv_DonHang.Columns["col_Ngay"].DataPropertyName = "NgayDat";
            dgv_DonHang.Columns["col_TongTien"].DataPropertyName = "TongTien";

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
    }
}