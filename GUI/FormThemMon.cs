using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class FormThemMon : Form
    {
        private DTO_ThucDon monDangSua = null;
        private BUS_DanhMuc bus1 = new BUS_DanhMuc();

        public FormThemMon()
        {
            InitializeComponent();
            LoadLoaiMon();
        }

        private void LoadLoaiMon()
        {
            List<DTO_DanhMuc> loaiMonList = bus1.LayDanhSachTenDanhMuc();

            cb_loaiMon.Items.Clear();
            cb_loaiMon.DataSource = loaiMonList;
            cb_loaiMon.DisplayMember = "TenDM"; 
            cb_loaiMon.ValueMember = "MaDM";     
            cb_loaiMon.SelectedIndex = 0;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_ChonAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "Image Files (*.jpg;*.png;*.bmp)|*.jpg;*.png;*.bmp"
            };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pic_Mon.Image = Image.FromFile(ofd.FileName);
                pic_Mon.ImageLocation = ofd.FileName;
            }
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            string tenMon = txt_TenMon.Text.Trim();
            string maDanhMuc = cb_loaiMon.SelectedValue?.ToString();
            string hinhAnh = pic_Mon.ImageLocation ?? "";

            if (string.IsNullOrEmpty(tenMon) || string.IsNullOrEmpty(maDanhMuc))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tên món và loại món!");
                return;
            }

            if (!decimal.TryParse(txt_GiaMon.Text, out decimal gia) || gia <= 0)
            {
                MessageBox.Show("Giá món không hợp lệ!");
                return;
            }      

            DTO.DTO_ThucDon thucDon = new DTO.DTO_ThucDon
            {
                TenMon = tenMon,              
                Gia = gia,
                HinhAnh = hinhAnh,
                MaDM = maDanhMuc
            };

            BUS_ThucDon bus = new BUS_ThucDon();
            bool result;
            if (monDangSua == null) 
            {
                result = bus.ThemMonMoi(thucDon);
                if (result)
                {
                    MessageBox.Show("Thêm món thành công!");
                    ResetFields();
                }
                else
                {
                    MessageBox.Show("Thêm món thất bại!");
                }
            }
            else 
            {
                thucDon.MaMon = monDangSua.MaMon;
                result = bus.UpdateMon(thucDon);
                if (result)
                {
                    MessageBox.Show("Cập nhật món thành công!");
                    this.Close();
                    ResetFields();
                }
                else
                {
                    MessageBox.Show("Cập nhật món thất bại!");
                }
            }
        }
        private void ResetFields()
        {
            txt_TenMon.Text = "";
            txt_GiaMon.Text = "";
            cb_loaiMon.SelectedIndex = -1; 
            pic_Mon.Image = null;
        }
        public void LoadMon(DTO_ThucDon mon)
        {
            try
            {
                monDangSua = mon;
                txt_TenMon.Text = mon.TenMon;
                txt_GiaMon.Text = mon.Gia.ToString("N0");
                cb_loaiMon.SelectedValue = mon.MaDM; 

                if (!string.IsNullOrEmpty(mon.HinhAnh) && System.IO.File.Exists(mon.HinhAnh))
                {
                    pic_Mon.Image = Image.FromFile(mon.HinhAnh);
                    pic_Mon.ImageLocation = mon.HinhAnh;
                }
                else
                {
                    pic_Mon.Image = null;
                    pic_Mon.ImageLocation = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải thông tin món: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
