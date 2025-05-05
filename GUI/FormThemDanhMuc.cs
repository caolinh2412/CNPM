using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class FormThemDanhMuc : Form
    {
        // Khởi tạo đối tượng tầng nghiệp vụ cho danh mục
        private BUS_DanhMuc busDanhMuc = new BUS_DanhMuc();
        public FormThemDanhMuc()
        {
            InitializeComponent();
            // Gán sự kiện click vào bảng dữ liệu
            dgv_DanhMuc.CellContentClick += dgv_DanhMuc_CellContentClick;

            // Tải danh sách danh mục vào DataGridView
            KhoiTaoDanhMuc();
        }

        // Tải danh sách danh mục từ cơ sở dữ liệu lên bảng
        private void KhoiTaoDanhMuc()
        {
            List<DTO_DanhMuc> danhMucs = busDanhMuc.LayDanhSachTenDanhMuc();
            dgv_DanhMuc.AutoGenerateColumns = false;
            dgv_DanhMuc.DataSource = danhMucs;

            // Gán dữ liệu cho từng cột tương ứng trong DataGridView
            dgv_DanhMuc.Columns["col_MaDM"].DataPropertyName = "MaDM";
            dgv_DanhMuc.Columns["col_TenDM"].DataPropertyName = "TenDM";
        }

        // Xử lý khi người dùng nhấn nút "Thêm danh mục"
        private void btnThemDM_Click(object sender, EventArgs e)
        {
            string maDM = txt_MaDM.Text.Trim();
            string tenDM = txt_TenDM.Text.Trim();

            if (string.IsNullOrEmpty(maDM) || string.IsNullOrEmpty(tenDM))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin danh mục!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Lấy danh sách hiện có để kiểm tra trùng tên
            List<DTO_DanhMuc> danhMucs = busDanhMuc.LayDanhSachTenDanhMuc();
            bool tenDaTonTai = danhMucs.Any(dm => dm.TenDM.Equals(tenDM, StringComparison.OrdinalIgnoreCase));

            if (tenDaTonTai)
            {
                MessageBox.Show("Tên danh mục đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Thực hiện thêm danh mục mới
            try
            {
                busDanhMuc.ThemDanhMuc(maDM, tenDM);
                MessageBox.Show("Thêm danh mục thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Xóa nội dung ô nhập và cập nhật lại bảng
                txt_MaDM.Clear();
                txt_TenDM.Clear();
                KhoiTaoDanhMuc();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Xử lý khi người dùng click vào nút xóa trong bảng
        private void dgv_DanhMuc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu nhấn đúng vào cột "img_XoaDM" và dòng hợp lệ
            if (e.ColumnIndex == dgv_DanhMuc.Columns["img_XoaDM"].Index && e.RowIndex >= 0)
            {
                string maDM = dgv_DanhMuc.Rows[e.RowIndex].Cells["col_MaDM"].Value.ToString();

                try
                {
                    busDanhMuc.XoaDanhMuc(maDM);
                    MessageBox.Show("Xóa danh mục thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    KhoiTaoDanhMuc();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
