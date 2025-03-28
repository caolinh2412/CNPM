using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;

namespace GUI
{
    public partial class FormCaLamViec : Form
    {
        private string maNV;
        private NhanVien_BUS bus = new NhanVien_BUS();

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

            dgv_CaLam.Columns["col_TenCa"].DataPropertyName = "CaLam";
            dgv_CaLam.Columns["col_NgayLam"].DataPropertyName = "Ngay";
            dgv_CaLam.Columns["col_NgayLam"].DefaultCellStyle.Format = "dd/MM/yyyy";
        }

        private void LoadWorkSchedule()
        {
            List<CaLam_DTO> workSchedule = bus.GetWorkScheduleByEmployeeId(maNV);
            dgv_CaLam.DataSource = workSchedule;
        }

        private void AddEmptyRow()
        {
            var workSchedule = (List<CaLam_DTO>)dgv_CaLam.DataSource;
            workSchedule.Add(new CaLam_DTO());
            dgv_CaLam.DataSource = null;
            dgv_CaLam.DataSource = workSchedule;
        }

        private void dgv_CaLam_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgv_CaLam.Columns["col_Save"].Index && e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgv_CaLam.Rows[e.RowIndex];
                if (selectedRow.Cells["col_TenCa"].Value != null && selectedRow.Cells["col_NgayLam"].Value != null)
                {
                    CaLam_DTO newWorkSchedule = new CaLam_DTO
                    {
                        MaND = maNV,
                        CaLam = selectedRow.Cells["col_TenCa"].Value.ToString(),
                        Ngay = Convert.ToDateTime(selectedRow.Cells["col_NgayLam"].Value)
                    };

                    bool success = bus.InsertWorkSchedule(newWorkSchedule);
                    if (success)
                    {
                        MessageBox.Show("Lưu ca làm việc thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadWorkSchedule();
                        AddEmptyRow();
                    }
                    else
                    {
                        MessageBox.Show("Lưu ca làm việc thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnThemCa_Click(object sender, EventArgs e)
        {
            AddEmptyRow();
        }
    }
}
