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
using DAL;
using DTO;

namespace GUI
{
    public partial class UC_Menu : UserControl
    {
        // Khai báo các biến và đối tượng cần thiết
        private BUS_ThucDon bus = new BUS_ThucDon();
        private BUS_DanhMuc busDanhMuc = new BUS_DanhMuc();
        public UC_Menu()
        {
            // Khởi tạo các thành phần giao diện
            InitializeComponent();
            InitializeCategoryComboBox();
            dgv_DanhMuc.CellClick += dgv_dsNV_CellClick; // Gán sự kiện click cho DataGridView
            dgv_DanhMuc.KeyDown += dgv_DanhMuc_KeyDown; // Gán sự kiện KeyDown cho DataGridView
            cb_LoaiMon.KeyDown += cb_LoaiMon_KeyDown;  // Gán sự kiện KeyDown cho ComboBox
        }

        private void InitializeCategoryComboBox()
        {
            // Lấy danh sách danh mục từ cơ sở dữ liệu
            List<DTO_DanhMuc> loaiMonList = busDanhMuc.LayDanhSachTenDanhMuc();

            // Thêm mục "Tất cả" vào danh sách
            loaiMonList.Insert(0, new DTO_DanhMuc { MaDM = null, TenDM = "Tất cả" });

            cb_LoaiMon.DisplayMember = "TenDM"; // Tên hiển thị trong ComboBox
            cb_LoaiMon.ValueMember = "MaDM"; // Giá trị của mục trong ComboBox
            cb_LoaiMon.DataSource = loaiMonList; // Gán danh sách vào ComboBox
            cb_LoaiMon.SelectedIndex = 0;   // Chọn mục đầu tiên (Tất cả) mặc định

            LoadMenuItems(null); // Tải danh sách món ăn mặc định

            // Gán sự kiện SelectedIndexChanged cho ComboBox
            cb_LoaiMon.SelectedIndexChanged += (sender, e) =>
            {
                var selectedValue = cb_LoaiMon.SelectedValue;

                // Kiểm tra giá trị được chọn trong ComboBox
                if (selectedValue == null || selectedValue == DBNull.Value)
                {
                    // Nếu không có giá trị nào được chọn, tải tất cả món ăn
                    LoadMenuItems(null);
                }
                else
                {
                    // Nếu có giá trị được chọn, tải món ăn theo danh mục
                    LoadMenuItems(selectedValue.ToString());
                }
            };
        }

        // Phương thức để tải danh sách món ăn theo danh mục
        private void LoadMenuItems(string category)
        {
            // Lấy danh sách món ăn từ cơ sở dữ liệu
            List<DTO_ThucDon> menuItems;

            // Kiểm tra xem có danh mục nào được chọn hay không
            if (string.IsNullOrEmpty(category))
            {
                // Nếu không có danh mục nào được chọn, tải tất cả món ăn
                menuItems = bus.GetAllMenuItems();
            }
            else
            {
                // Nếu có danh mục được chọn, tải món ăn theo danh mục
                menuItems = bus.GetMenuItemsByCategory(category);
            }

            // Thiết lập DataGridView để hiển thị danh sách món ăn
            dgv_DanhMuc.AutoGenerateColumns = false;
            dgv_DanhMuc.DataSource = menuItems;

            // Thiết lập các cột trong DataGridView
            dgv_DanhMuc.Columns["col_MaMon"].DataPropertyName = "MaMon";
            dgv_DanhMuc.Columns["col_TenMon"].DataPropertyName = "TenMon";
            dgv_DanhMuc.Columns["col_GiaBan"].DataPropertyName = "Gia";
            dgv_DanhMuc.Columns["col_GiaBan"].DefaultCellStyle.Format = "N0";

        }
        // Sự kiện khi nhấn nút xóa hoặc sửa món
        private void dgv_dsNV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem có nhấn vào cột xóa hoặc sửa không
            if (e.ColumnIndex == dgv_DanhMuc.Columns["img_delete"].Index && e.RowIndex >= 0) // Xóa
            {
                DataGridViewRow selectedRow = dgv_DanhMuc.Rows[e.RowIndex]; // Lấy dòng được chọn
                string maMon = selectedRow.Cells["col_MaMon"].Value.ToString(); // Lấy mã món

                // Hiển thị hộp thoại xác nhận xóa
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa món này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes) // Nếu người dùng chọn "Có"
                {
                    // Gọi phương thức xóa món trong BUS
                    if (bus.XoaMon(maMon))
                    {
                        MessageBox.Show("Xóa món thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ReloadMenu(); // Tải lại danh sách món ăn
                    }
                    else
                    {
                        MessageBox.Show("Xóa món thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else if (e.ColumnIndex == dgv_DanhMuc.Columns["img_edit"].Index) // Sửa
            {
                DataGridViewRow selectedRow = dgv_DanhMuc.Rows[e.RowIndex]; // Lấy dòng được chọn
                string maMon = selectedRow.Cells["col_MaMon"].Value.ToString(); // Lấy mã món

                // Lấy thông tin món từ cơ sở dữ liệu
                DTO_ThucDon mon = bus.GetMonById(maMon);

                // Nếu món không null, mở form sửa món -> form themMon
                if (mon != null)
                {
                    FormThemMon formThemMon = new FormThemMon();
                    formThemMon.LoadMon(mon); // Gọi phương thức LoadMon để tải thông tin món vào form
                    formThemMon.ShowDialog(); // Hiển thị form thêm món

                    ReloadMenu(); // Tải lại danh sách món ăn sau khi sửa
                }
            }
        }

        // Phương thức để tải lại danh sách món ăn
        private void ReloadMenu()
        {
            // Lấy giá trị được chọn trong ComboBox
            var selectedValue = cb_LoaiMon.SelectedValue;
            LoadMenuItems(selectedValue?.ToString()); // Tải lại danh sách món ăn
            InitializeCategoryComboBox(); // Cập nhật danh sách danh mục
        }

        // Sự kiện khi nhấn phím Enter trong DataGridView
        private void dgv_DanhMuc_KeyDown(object sender, KeyEventArgs e)
        {
            // Kiểm tra xem phím Enter có được nhấn hay không
            if (e.KeyCode == Keys.Enter && dgv_DanhMuc.CurrentCell != null)
            {
                // Lấy chỉ số cột và hàng của ô hiện tại
                int col = dgv_DanhMuc.CurrentCell.ColumnIndex;
                int row = dgv_DanhMuc.CurrentCell.RowIndex;

                // Kiểm tra xem ô hiện tại có phải là ô xóa hoặc sửa không
                if (row >= 0 && (col == dgv_DanhMuc.Columns["img_edit"].Index || col == dgv_DanhMuc.Columns["img_delete"].Index))
                {
                    e.Handled = true; // Ngăn chặn sự kiện KeyDown tiếp tục
                    e.SuppressKeyPress = true; // Ngăn chặn âm thanh "ding" khi nhấn Enter
                    dgv_dsNV_CellClick(sender, new DataGridViewCellEventArgs(col, row)); // Gọi sự kiện CellClick để xử lý xóa hoặc sửa món
                }
            }
        }

        // Sự kiện khi nhấn phím Enter trong ComboBox
        private void cb_LoaiMon_KeyDown(object sender, KeyEventArgs e)
        {
            // Kiểm tra xem phím Enter có được nhấn hay không
            if (e.KeyCode == Keys.Enter)
            {
                var selectedValue = cb_LoaiMon.SelectedValue;
                LoadMenuItems(selectedValue?.ToString()); // Tải lại danh sách món ăn theo danh mục được chọn
                e.Handled = true; // Ngăn chặn sự kiện KeyDown tiếp tục
                e.SuppressKeyPress = true; // Ngăn chặn âm thanh "ding" khi nhấn Enter
            }
        }
        // Sự kiện khi nhấn nút thêm danh mục
        private void btn_ThemDanhMuc_Click(object sender, EventArgs e)
        {
            // Mở form thêm danh mục và thêm danh mục mới 
            FormThemDanhMuc formThemDanhMuc = new FormThemDanhMuc();
            formThemDanhMuc.ShowDialog();
            if (formThemDanhMuc.DialogResult == DialogResult.OK)
            {
                MessageBox.Show("Thêm danh mục thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            // Tải lại danh sách món ăn và danh mục
            InitializeCategoryComboBox();
        }

        private void btn_ThemMon_Click(object sender, EventArgs e)
        {
            // Mở form thêm món
            FormThemMon themMon = new FormThemMon();
            themMon.Show();

            // Gán sự kiện FormClosed để cập nhật lại danh sách món ăn khi form đóng
            themMon.FormClosed += (s, args) =>
            {
                var selectedValue = cb_LoaiMon.SelectedValue; // Lấy giá trị được chọn trong ComboBox
                LoadMenuItems(selectedValue?.ToString()); // Tải lại danh sách món ăn
            };
        }
    }
}
