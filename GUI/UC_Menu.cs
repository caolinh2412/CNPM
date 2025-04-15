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
        private BUS_ThucDon bus = new BUS_ThucDon();
        private BUS_DanhMuc busDanhMuc = new BUS_DanhMuc();
        public UC_Menu()
        {
            InitializeComponent();
            InitializeCategoryComboBox();
            dgv_DanhMuc.CellClick += dgv_dsNV_CellClick;
            dgv_DanhMuc.KeyDown += dgv_DanhMuc_KeyDown;
            cb_LoaiMon.KeyDown += cb_LoaiMon_KeyDown;
        }

        private void InitializeCategoryComboBox()
        {
            List<DTO_DanhMuc> loaiMonList = busDanhMuc.LayDanhSachTenDanhMuc();

            loaiMonList.Insert(0, new DTO_DanhMuc { MaDM = null, TenDM = "Tất cả" });

            cb_LoaiMon.DisplayMember = "TenDM";
            cb_LoaiMon.ValueMember = "MaDM";
            cb_LoaiMon.DataSource = loaiMonList;
            cb_LoaiMon.SelectedIndex = 0;

            LoadMenuItems(null);

            cb_LoaiMon.SelectedIndexChanged += (sender, e) =>
            {
                var selectedValue = cb_LoaiMon.SelectedValue;

                if (selectedValue == null || selectedValue == DBNull.Value)
                {
                    LoadMenuItems(null);
                }
                else
                {
                    LoadMenuItems(selectedValue.ToString());
                }
            };
        }

        private void LoadMenuItems(string category)
        {
            List<DTO_ThucDon> menuItems;
            if (string.IsNullOrEmpty(category))
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
            themMon.FormClosed += (s, args) =>
            {
                var selectedValue = cb_LoaiMon.SelectedValue;
                LoadMenuItems(selectedValue?.ToString());
            };
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
                        ReloadMenu();
                    }
                    else
                    {
                        MessageBox.Show("Xóa món thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else if (e.ColumnIndex == dgv_DanhMuc.Columns["img_edit"].Index)
            {
                DataGridViewRow selectedRow = dgv_DanhMuc.Rows[e.RowIndex];
                string maMon = selectedRow.Cells["col_MaMon"].Value.ToString();

                DTO_ThucDon mon = bus.GetMonById(maMon);

                if (mon != null)
                {
                    FormThemMon formThemMon = new FormThemMon();
                    formThemMon.LoadMon(mon);
                    formThemMon.ShowDialog();

                    ReloadMenu();
                }
            }
        }
        private void ReloadMenu()
        {
            var selectedValue = cb_LoaiMon.SelectedValue;
            LoadMenuItems(selectedValue?.ToString());
            InitializeCategoryComboBox();
        }

        private void pic_ThemDanhMuc_Click(object sender, EventArgs e)
        {
            FormThemDanhMuc formThemDanhMuc = new FormThemDanhMuc();
            formThemDanhMuc.ShowDialog();
            if (formThemDanhMuc.DialogResult == DialogResult.OK)
            {
                MessageBox.Show("Thêm danh mục thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            InitializeCategoryComboBox();
        }
        private void dgv_DanhMuc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && dgv_DanhMuc.CurrentCell != null)
            {
                int col = dgv_DanhMuc.CurrentCell.ColumnIndex;
                int row = dgv_DanhMuc.CurrentCell.RowIndex;

                if (row >= 0 && (col == dgv_DanhMuc.Columns["img_edit"].Index || col == dgv_DanhMuc.Columns["img_delete"].Index))
                {
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    dgv_dsNV_CellClick(sender, new DataGridViewCellEventArgs(col, row));
                }
            }
        }

        private void cb_LoaiMon_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var selectedValue = cb_LoaiMon.SelectedValue;
                LoadMenuItems(selectedValue?.ToString());
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
    }
}
