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
    public partial class FormQuanLyNV : UserControl
    {
        private BUS_NhanVien bus = new BUS_NhanVien();
        private bool isEditMode = false;
        public FormQuanLyNV()
        {
            InitializeComponent();
            InitializeDataGridView();
            LoadEmployeeData();
            dgv_dsNV.SelectionChanged += dgv_dsNV_SelectionChanged;

            txt_Ten.Enabled = false;
            txt_GioiTinh.Enabled = false;
            txt_email.Enabled = false;
            txt_sdt.Enabled = false;
            dtp_NgayLam.Enabled = false;
         
            btnSua.Enabled = false;
            btnLuu.Enabled = false;

            txt_Ten.Enter += TextBox_Enter;
            txt_GioiTinh.Enter += TextBox_Enter;
            txt_email.Enter += TextBox_Enter;
            txt_sdt.Enter += TextBox_Enter;
            dtp_NgayLam.Enter += TextBox_Enter;
        }

        private void TextBox_Enter(object sender, EventArgs e)
        {
            if (!isEditMode)
            {
                MessageBox.Show("Không được phép sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ((Control)sender).Enabled = false; 
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string newEmployeeCode = bus.MaNVTiepTheo();
            txt_MaNV.Text = newEmployeeCode;


            txt_Ten.Enabled = true;
            txt_GioiTinh.Enabled = true;
            txt_email.Enabled = true;
            txt_sdt.Enabled = true;
            dtp_NgayLam.Enabled = true;

            txt_Ten.Clear();
            txt_GioiTinh.Clear();
            txt_email.Clear();
            txt_sdt.Clear();
            dtp_NgayLam.Value = DateTime.Now;

            btnLuu.Enabled = true;
            isEditMode = true;
        }

        private void LoadEmployeeData()
        {
            List<DTO_DangNhap> employees = bus.GetAllEmployees();
            dgv_dsNV.DataSource = employees;
        }

        private void InitializeDataGridView()
        {
            dgv_dsNV.AutoGenerateColumns = false;

            dgv_dsNV.Columns["col_maNV"].DataPropertyName = "MaND";
            dgv_dsNV.Columns["col_HoTen"].DataPropertyName = "HoVaTen";
            dgv_dsNV.Columns["col_GioiTinh"].DataPropertyName = "GioiTinh";
            dgv_dsNV.Columns["col_email"].DataPropertyName = "Email";
            dgv_dsNV.Columns["col_sdt"].DataPropertyName = "SDT";
            dgv_dsNV.Columns["col_NgayDiLam"].DataPropertyName = "NgayDiLam";
            dgv_dsNV.Columns["col_TrangThai"].DataPropertyName = "TrangThai";


            dgv_dsNV.CellClick += dgv_dsNV_CellClick;
        }
        private void dgv_dsNV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgv_dsNV.Columns["dgdelete"].Index && e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgv_dsNV.Rows[e.RowIndex];
                string maNV = selectedRow.Cells["col_maNV"].Value.ToString();

                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn điều chỉnh hoạt động nhân viên này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (bus.TatHD(maNV))
                    {
                        MessageBox.Show("Điều chỉnh hoạt động nhân viên thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadEmployeeData();
                    }
                    else
                    {
                        MessageBox.Show("Điều chỉnh thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else if (e.ColumnIndex == dgv_dsNV.Columns["dgedit"].Index && e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgv_dsNV.Rows[e.RowIndex];
                string maNV = selectedRow.Cells["col_maNV"].Value.ToString();

                FormCaLamViec formCaLamViec = new FormCaLamViec(maNV);
                formCaLamViec.ShowDialog();
            }
        }
        private void dgv_dsNV_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_dsNV.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgv_dsNV.SelectedRows[0];
                txt_MaNV.Text = selectedRow.Cells["col_maNV"].Value.ToString();
                txt_Ten.Text = selectedRow.Cells["col_HoTen"].Value.ToString();
                txt_GioiTinh.Text = selectedRow.Cells["col_GioiTinh"].Value.ToString();
                txt_email.Text = selectedRow.Cells["col_email"].Value.ToString();
                txt_sdt.Text = selectedRow.Cells["col_sdt"].Value.ToString();
                dtp_NgayLam.Value = Convert.ToDateTime(selectedRow.Cells["col_NgayDiLam"].Value);

                btnSua.Enabled = true;
                isEditMode = false;
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txt_Ten.Clear();
            txt_GioiTinh.Clear();
            txt_email.Clear();
            txt_sdt.Clear();
            dtp_NgayLam.Value = DateTime.Now;

            txt_Ten.Enabled = false;
            txt_GioiTinh.Enabled = false;
            txt_email.Enabled = false;
            txt_sdt.Enabled = false;
            dtp_NgayLam.Enabled = false;

            btnSua.Enabled = false;
            btnLuu.Enabled = false;
            isEditMode = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgv_dsNV.SelectedRows.Count > 0)
            {
                txt_Ten.Enabled = true;
                txt_GioiTinh.Enabled = true;
                txt_email.Enabled = true;
                txt_sdt.Enabled = true;
                dtp_NgayLam.Enabled = true;

                btnLuu.Enabled = true;
                isEditMode = true;
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            DTO_DangNhap employee = new DTO_DangNhap
            {
                MaND = txt_MaNV.Text,
                HoVaTen = txt_Ten.Text,
                GioiTinh = txt_GioiTinh.Text,
                Email = txt_email.Text,
                SDT = txt_sdt.Text,
                NgayDiLam = dtp_NgayLam.Value
            };
            bool success;
            if (dgv_dsNV.SelectedRows.Count > 0 && dgv_dsNV.SelectedRows[0].Cells["col_maNV"].Value.ToString() == txt_MaNV.Text)
            {
                success = bus.UpdateEmployee(employee);
            }
            else
            {
                success = bus.InsertEmployee(employee);
            }

            if (success)
            {
                MessageBox.Show("Lưu nhân viên thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadEmployeeData();
            }
            else
            {
                MessageBox.Show("Lưu nhân viên thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            txt_Ten.Enabled = false;
            txt_GioiTinh.Enabled = false;
            txt_email.Enabled = false;
            txt_sdt.Enabled = false;
            dtp_NgayLam.Enabled = false;
         
            btnSua.Enabled = false;
            btnLuu.Enabled = false;
            isEditMode = false;
        }
    }
}
