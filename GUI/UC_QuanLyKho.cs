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

namespace GUI
{
    public partial class UC_QuanLyKho : UserControl
    {
        private BUS_Kho bus = new BUS_Kho();
        private BUS_ThucDon bus1 = new BUS_ThucDon();
        private bool isEditMode = false;
        private BUS_CongThuc bus2 = new BUS_CongThuc();
        public UC_QuanLyKho()
        {
            InitializeComponent();
            InitializeDataGridView();
            DanhSachMon();
            LoadKhoData();
            dgv_Kho.SelectionChanged += dgv_Kho_SelectionChanged;

            txt_Ten.Enabled = false;
            txt_TonKho.Enabled = false;
            txt_DonVi.Enabled = false;
            txt_sdt.Enabled = false;
            dtp_NgayNhap.Enabled = false;
            txt_NCC.Enabled = false;

            btnSua.Enabled = false;
            btnLuu.Enabled = false;

            txt_Ten.Enter += TextBox_Enter;
            txt_TonKho.Enter += TextBox_Enter;
            txt_DonVi.Enter += TextBox_Enter;
            txt_sdt.Enter += TextBox_Enter;
            dtp_NgayNhap.Enter += TextBox_Enter;
            txt_NCC.Enter += TextBox_Enter;
        }
        private void TextBox_Enter(object sender, EventArgs e)
        {
            if (!isEditMode)
            {
                MessageBox.Show("Không được phép sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (sender is TextBox tb)
                {
                    tb.ReadOnly = true;
                }
            }
        }

        private void LoadKhoData()
        {
            List<DTO_Kho> nguyenLieu = bus.GetAllNguyenLieu();
            dgv_Kho.DataSource = nguyenLieu;
            dgv_NL.DataSource = nguyenLieu;
        }
        private void InitializeDataGridView()
        {
            dgv_Kho.AutoGenerateColumns = false;
            dgv_Kho.Columns["col_MaNL"].DataPropertyName = "MaNL";
            dgv_Kho.Columns["col_TenNL"].DataPropertyName = "TenNL";
            dgv_Kho.Columns["col_TonKho"].DataPropertyName = "SoluongTon";
            dgv_Kho.Columns["col_dvt"].DataPropertyName = "DonViTinh";
            dgv_Kho.Columns["col_Ngay"].DataPropertyName = "NgayNhap";
            dgv_Kho.Columns["col_NCC"].DataPropertyName = "TenNCC";
            dgv_Kho.Columns["col_sdt"].DataPropertyName = "SDT";

            dgv_NL.AutoGenerateColumns = false;
            dgv_NL.Columns["col_MNL"].DataPropertyName = "MaNL";
            dgv_NL.Columns["col_TNL"].DataPropertyName = "TenNL";

            dgv_Kho.CellClick += dgv_Kho_CellClick;
            dgv_NL.CellClick += dgv_NL_CellClick;
            dgv_CongThuc.CellClick += dgv_CongThuc_CellClick;
        }
        private void dgv_Kho_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgv_Kho.Columns["col_del"].Index && e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgv_Kho.Rows[e.RowIndex];
                string maNL = selectedRow.Cells["col_MaNL"].Value.ToString();

                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa nguyên liệu này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (bus.DeleteNguyenLieu(maNL))
                    {
                        MessageBox.Show("Xóa nguyên liệu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadKhoData();
                    }
                    else
                    {
                        MessageBox.Show("Xóa nguyên liệu thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void dgv_Kho_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_Kho.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgv_Kho.SelectedRows[0];
                txt_MaNL.Text = selectedRow.Cells["col_MaNL"].Value.ToString();
                txt_Ten.Text = selectedRow.Cells["col_TenNL"].Value.ToString();
                txt_TonKho.Text = Convert.ToDecimal(selectedRow.Cells["col_TonKho"].Value).ToString();
                txt_DonVi.Text = selectedRow.Cells["col_dvt"].Value.ToString();
                txt_sdt.Text = selectedRow.Cells["col_sdt"].Value.ToString();
                dtp_NgayNhap.Value = DateTime.Parse(selectedRow.Cells["col_Ngay"].Value.ToString());
                txt_NCC.Text = selectedRow.Cells["col_NCC"].Value.ToString();

                btnSua.Enabled = true;
                isEditMode = false;
            }
        }

        private void btnThem_Click_1(object sender, EventArgs e)
        {
            string newNL = bus.GetNextMaNL();
            txt_MaNL.Text = newNL;


            txt_Ten.Enabled = true;
            txt_TonKho.Enabled = true;
            txt_DonVi.Enabled = true;
            txt_sdt.Enabled = true;
            dtp_NgayNhap.Enabled = true;
            txt_NCC.Enabled = true;

            txt_Ten.Clear();
            txt_TonKho.Clear();
            txt_DonVi.Clear();
            txt_sdt.Clear();
            txt_NCC.Clear();
            dtp_NgayNhap.Value = DateTime.Now;

            btnLuu.Enabled = true;
            isEditMode = true;
        }

        private void btnSua_Click_1(object sender, EventArgs e)
        {
            if (dgv_Kho.SelectedRows.Count > 0)
            {

                txt_Ten.Enabled = true;
                txt_TonKho.Enabled = true;
                txt_DonVi.Enabled = true;
                txt_sdt.Enabled = true;
                dtp_NgayNhap.Enabled = true;
                txt_NCC.Enabled = true;

                btnLuu.Enabled = true;
                isEditMode = true;
            }
        }

        private void btnLuu_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_Ten.Text) || string.IsNullOrWhiteSpace(txt_TonKho.Text) || string.IsNullOrWhiteSpace(txt_DonVi.Text) || string.IsNullOrWhiteSpace(txt_sdt.Text) || string.IsNullOrWhiteSpace(txt_NCC.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin nguyên liệu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            decimal soLuong;
            if (!decimal.TryParse(txt_TonKho.Text, out soLuong))
            {
                MessageBox.Show("Số lượng tồn không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DTO_Kho nguyeLieu = new DTO_Kho
            {
                MaNL = txt_MaNL.Text,
                TenNL = txt_Ten.Text,
                SoLuongTon = soLuong,
                DonViTinh = txt_DonVi.Text,
                SDT = txt_sdt.Text,
                TenNCC = txt_NCC.Text,
                NgayNhap = dtp_NgayNhap.Value
            };
            bool success;
            if (dgv_Kho.SelectedRows.Count > 0 && dgv_Kho.SelectedRows[0].Cells["col_MaNL"].Value.ToString() == txt_MaNL.Text)
            {
                success = bus.UpdateNguyenLieu(nguyeLieu);
            }
            else
            {
                success = bus.InsertNguyenLieu(nguyeLieu);
            }

            if (success)
            {
                MessageBox.Show("Lưu nguyên liệu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadKhoData();
            }
            else
            {
                MessageBox.Show("Lưu nguyên liệu thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            txt_Ten.Enabled = false;
            txt_TonKho.Enabled = false;
            txt_DonVi.Enabled = false;
            txt_sdt.Enabled = false;
            dtp_NgayNhap.Enabled = false;
            txt_NCC.Enabled = false;

            btnSua.Enabled = false;
            btnLuu.Enabled = false;
            isEditMode = false;
        }

        private void btnHuy_Click_1(object sender, EventArgs e)
        {
            txt_Ten.Enabled = false;
            txt_TonKho.Enabled = false;
            txt_DonVi.Enabled = false;
            txt_sdt.Enabled = false;
            dtp_NgayNhap.Enabled = false;
            txt_NCC.Enabled = false;
            btnSua.Enabled = false;
            btnLuu.Enabled = false;
            isEditMode = false;

            txt_Ten.Clear();
            txt_TonKho.Clear();
            txt_DonVi.Clear();
            txt_sdt.Clear();
            txt_NCC.Clear();
            dtp_NgayNhap.Value = DateTime.Now;

            LoadKhoData();
        }
        private void DanhSachMon()
        {
            List<DTO_ThucDon> mon = bus1.GetAllMenuItems();
            
            dgv_TenMon.AutoGenerateColumns = false;
            dgv_TenMon.DataSource = mon;
            dgv_TenMon.Columns["col_TenMon"].DataPropertyName = "TenMon";
            dgv_TenMon.Columns["col_MaMon"].DataPropertyName = "MaMon";
            dgv_TenMon.SelectionChanged += dgv_TenMon_SelectionChanged;
        }
        private void dgv_TenMon_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_TenMon.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgv_TenMon.SelectedRows[0];

                string maMon = selectedRow.Cells["col_MaMon"].Value.ToString();
                txt_MaNL.Text = maMon;

                LoadNguyenLieuCuaMon(maMon);
            }
        }
        private void LoadNguyenLieuCuaMon(string maMon)
        {
            DataTable nguyenLieu = bus2.GetCongThucByMaMon(maMon);
            dgv_CongThuc.AutoGenerateColumns = false;
            dgv_CongThuc.DataSource = nguyenLieu;

            dgv_CongThuc.Columns["col_maCT"].DataPropertyName = "MaCT";
            dgv_CongThuc.Columns["col_NL"].DataPropertyName = "TenNL";
            dgv_CongThuc.Columns["col_soluong"].DataPropertyName = "SoLuong";
            dgv_CongThuc.Columns["col_donvi"].DataPropertyName = "DonViTinh";
        }
        private void dgv_NL_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgv_TenMon.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedMonRow = dgv_TenMon.SelectedRows[0];
                string maMon = selectedMonRow.Cells["col_MaMon"].Value.ToString();

                DataGridViewRow selectedNLRow = dgv_NL.Rows[e.RowIndex];
                string tenNL = selectedNLRow.Cells["col_TNL"].Value.ToString();
                string maNL = selectedNLRow.Cells["col_MNL"].Value.ToString();

                if (dgv_Kho.SelectedRows.Count > 0)
                {
                    // Lấy đơn vị tính từ dòng đã chọn trong dgv_Kho
                    DataGridViewRow selectedRow = dgv_Kho.SelectedRows[0];
                    string donVi = selectedRow.Cells["col_dvt"].Value.ToString();

                    using (FormChonSLDonvi form = new FormChonSLDonvi(donVi))
                    {
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            DTO_CongThuc congThuc = new DTO_CongThuc
                            {
                                MaMon = maMon,
                                MaNL = maNL,
                                SoLuong = form.SoLuong,
                                DonViTinh = form.DonVi
                            };

                            if (bus2.InsertCongThuc(congThuc))
                            {
                                MessageBox.Show("Thêm công thức thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadNguyenLieuCuaMon(maMon);
                            }
                            else
                            {
                                MessageBox.Show("Thêm công thức thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một món trước khi thêm nguyên liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        private void dgv_CongThuc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgv_CongThuc.Columns["col_delete"].Index && e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgv_CongThuc.Rows[e.RowIndex];
                string maCT = selectedRow.Cells["col_MaCT"].Value.ToString();

                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa công thức này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (bus2.DeleteCongThuc(maCT))
                    {
                        MessageBox.Show("Xóa công thức này thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadNguyenLieuCuaMon(txt_MaNL.Text);
                    }
                    else
                    {
                        MessageBox.Show("Xóa công thức thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
