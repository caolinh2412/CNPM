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
    public partial class MenuForm : UserControl
    {
        private ThucDon_BUS bus = new ThucDon_BUS();
        public MenuForm()
        {
            InitializeComponent();
            InitializeCategoryComboBox();
            dgv_DanhMuc.CellClick += dgv_dsNV_CellClick;
        }

        private void InitializeCategoryComboBox()
        {
            List<string> categories = new List<string> { "Tất cả", "Cà phê", "Trà sữa", "Nước ép", "Sinh tố", "Trà", "Đá xay", "Bánh ngọt" };
            cb_LoaiMon.DataSource = categories;
            cb_LoaiMon.SelectedIndex = 0;
            LoadMenuItems(cb_LoaiMon.SelectedItem.ToString());
            cb_LoaiMon.SelectedIndexChanged += (sender, e) => LoadMenuItems(cb_LoaiMon.SelectedItem.ToString());
        }

        private void LoadMenuItems(string category)
        {
            List<ThucDon_DTO> menuItems;
            menuItems = bus.GetAllMenuItems();
            if (category == "Tất cả")
            {
                menuItems = bus.GetAllMenuItems();
            }
            else
            {
                menuItems = bus.GetMenuItemsByCategory(category);
            }
            dgv_DanhMuc.AutoGenerateColumns = false;
            dgv_DanhMuc.DataSource = menuItems;

            dgv_DanhMuc.Columns["col_MaMon"].DataPropertyName = "MaMon";
            dgv_DanhMuc.Columns["col_TenMon"].DataPropertyName = "TenMon";
            dgv_DanhMuc.Columns["col_GiaBan"].DataPropertyName = "Gia";
            dgv_DanhMuc.Columns["col_GiaBan"].DefaultCellStyle.Format = "N0";
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            FormThemMon themMon = new FormThemMon();
            themMon.Show();
        }
        private void dgv_dsNV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgv_DanhMuc.Columns["img_delete"].Index && e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgv_DanhMuc.Rows[e.RowIndex];
                string maMon = selectedRow.Cells["col_MaMon"].Value.ToString();

                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa món này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (bus.XoaMon(maMon))
                    {
                        MessageBox.Show("Xóa món thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadMenuItems(cb_LoaiMon.SelectedItem.ToString());
                    }
                    else
                    {
                        MessageBox.Show("Xóa món thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
