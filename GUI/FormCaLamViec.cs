using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BUS;
using DTO;

namespace GUI
{
    public partial class FormCaLamViec : Form
    {
        private string maNV;
        private BUS_CaLam bus = new BUS_CaLam();      
        private bool isEditMode = false;
        private int selectedRowIndex = -1;

        public FormCaLamViec(string maNV)
        {
            InitializeComponent();
            this.maNV = maNV;
            InitializeDataGridView();
            LoadWorkSchedule();
        }

        private void InitializeDataGridView()
        {
            dgv_CaLam.AutoGenerateColumns = false;

            dgv_CaLam.Columns["col_MaCa"].DataPropertyName = "MaLLV";
            dgv_CaLam.Columns["col_TenCa"].DataPropertyName = "CaLam";
            dgv_CaLam.Columns["col_NgayLam"].DataPropertyName = "Ngay";
            dgv_CaLam.Columns["col_NgayLam"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgv_CaLam.Columns["col_TrangThai"].DataPropertyName = "TrangThai";

            dgv_CaLam.CellClick += dgv_CaLam_CellClick;
        }

        private void LoadWorkSchedule()
        {
            List<DTO_CaLam> workSchedule = bus.GetWorkScheduleByEmployeeId(maNV);
            dgv_CaLam.DataSource = workSchedule;
        }

        private void dgv_CaLam_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dgv_CaLam.Columns[e.ColumnIndex].Name == "img_xoaCa")
                {
                    DataGridViewRow selectedRow = dgv_CaLam.Rows[e.RowIndex];
                    string maLLV = selectedRow.Cells["col_MaCa"].Value.ToString();

                    DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa ca làm việc này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        bool success = bus.DeleteWorkSchedule(maLLV);
                        if (success)
                        {
                            MessageBox.Show("Xóa ca làm việc thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadWorkSchedule();
                        }
                        else
                        {
                            MessageBox.Show("Xóa ca làm việc thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    ClearInputFields();
                }
                else
                {
                    DataGridViewRow selectedRow = dgv_CaLam.Rows[e.RowIndex];
                    txt_TenCa.Text = selectedRow.Cells["col_TenCa"].Value.ToString();
                    dtp_NgayLam.Value = Convert.ToDateTime(selectedRow.Cells["col_NgayLam"].Value);                 
                    selectedRowIndex = e.RowIndex;
                    isEditMode = true;
                }
            }
        }
   
       private void btnThemCa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_TenCa.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (isEditMode && selectedRowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgv_CaLam.Rows[selectedRowIndex];
                string maLLV = selectedRow.Cells["col_MaCa"].Value.ToString();

                DTO_CaLam updatedWorkSchedule = new DTO_CaLam
                {
                    MaLLV = maLLV,
                    MaNV = maNV,
                    CaLam = txt_TenCa.Text,
                    Ngay = dtp_NgayLam.Value,
                    TrangThai = selectedRow.Cells["col_TrangThai"].Value.ToString()
                };

                bool success = bus.UpdateWorkSchedule(updatedWorkSchedule);
                if (success)
                {
                    MessageBox.Show("Cập nhật ca làm việc thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadWorkSchedule();
                }
                else
                {
                    MessageBox.Show("Cập nhật ca làm việc thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                DTO_CaLam newWorkSchedule = new DTO_CaLam
                {
                    MaNV = maNV,
                    CaLam = txt_TenCa.Text,
                    Ngay = dtp_NgayLam.Value
                };

                bool success = bus.InsertWorkSchedule(newWorkSchedule);
                if (success)
                {
                    MessageBox.Show("Thêm ca làm việc thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadWorkSchedule();
                }
                else
                {
                    MessageBox.Show("Thêm ca làm việc thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            ClearInputFields();
        }


        private void ClearInputFields()
        {
            txt_TenCa.Clear();
            dtp_NgayLam.Value = DateTime.Now;
            isEditMode = false;
            selectedRowIndex = -1;
        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
