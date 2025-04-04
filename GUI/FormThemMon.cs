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
        private ThucDon_DTO monDangSua = null;
        private ThucDon_BUS bus = new ThucDon_BUS();

        public FormThemMon()
        {
            InitializeComponent();
            LoadLoaiMon();
        }

        private void LoadLoaiMon()
        {
            cb_loaiMon.Items.AddRange(new string[]
            {
                "Cà phê",
                "Trà sữa",
                "Nước ép",
                "Sinh tố",
                "Trà",
                "Đá xay",
                "Bánh ngọt"
            });
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
            string loaiMon = cb_loaiMon.SelectedItem?.ToString();
            string hinhAnh = pic_Mon.ImageLocation ?? "";

            if (string.IsNullOrEmpty(tenMon) || string.IsNullOrEmpty(loaiMon))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tên món và loại món!");
                return;
            }

            if (!decimal.TryParse(txt_GiaMon.Text, out decimal gia) || gia <= 0)
            {
                MessageBox.Show("Giá món không hợp lệ!");
                return;
            }

            DTO.ThucDon_DTO thucDon = new DTO.ThucDon_DTO
            {
                TenMon = tenMon,
                LoaiMon = loaiMon,
                Gia = gia,
                HinhAnh = hinhAnh
            };

            BUS.ThucDon_BUS bus = new BUS.ThucDon_BUS();
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
            else // Trường hợp CHỈNH SỬA
            {
                thucDon.MaMon = monDangSua.MaMon;
                result = bus.UpdateMon(thucDon);
                if (result)
                {
                    MessageBox.Show("Cập nhật món thành công!");
                    this.Close(); // Đóng form sau khi chỉnh sửa thành công
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
        public void LoadMon(ThucDon_DTO mon)
        {
            monDangSua = mon; 
            txt_TenMon.Text = mon.TenMon;
            txt_GiaMon.Text = mon.Gia.ToString();
            cb_loaiMon.SelectedItem = mon.LoaiMon;

            if (!string.IsNullOrEmpty(mon.HinhAnh) && System.IO.File.Exists(mon.HinhAnh))
            {
                pic_Mon.Image = Image.FromFile(mon.HinhAnh);
                pic_Mon.ImageLocation = mon.HinhAnh;
            }
            else
            {
                pic_Mon.Image = null;
            }
        }
    }
}
