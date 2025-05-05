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
        // Biến dùng để lưu thông tin món đang được chỉnh sửa (nếu có)
        private DTO_ThucDon monDangSua = null;

        // Đối tượng BUS dùng để xử lý danh mục món ăn
        private BUS_DanhMuc bus1 = new BUS_DanhMuc();

        // Biến lưu đường dẫn ảnh đã chọn
        private string selectedImagePath = "";
        public FormThemMon()
        {
            InitializeComponent();
            LoadLoaiMon(); // Tải danh sách loại món vào combobox
        }

        // Tải danh sách loại món từ cơ sở dữ liệu và gán vào combobox
        private void LoadLoaiMon()
        {
            List<DTO_DanhMuc> loaiMonList = bus1.LayDanhSachTenDanhMuc();

            cb_loaiMon.Items.Clear();
            cb_loaiMon.DataSource = loaiMonList;
            cb_loaiMon.DisplayMember = "TenDM"; // Hiển thị tên danh mục
            cb_loaiMon.ValueMember = "MaDM";    // Lưu mã danh mục     
            cb_loaiMon.SelectedIndex = 0;
        }
        // Đóng form khi nhấn nút close
        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        // Xử lý sự kiện khi nhấn nút chọn ảnh
        private void btn_ChonAnh_Click(object sender, EventArgs e)
        {        
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "Image Files (*.jpg;*.png;*.bmp)|*.jpg;*.png;*.bmp"
            };
            // Hiển thị hộp thoại chọn file ảnh
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string sourcePath = ofd.FileName;
                string fileName = Path.GetFileName(sourcePath);
                string imagesFolder = Path.Combine(Application.StartupPath, "img");

                if (!Directory.Exists(imagesFolder))
                    Directory.CreateDirectory(imagesFolder);

                string targetPath = Path.Combine(imagesFolder, fileName);
                File.Copy(sourcePath, targetPath, true);

                pic_Mon.Image = Image.FromFile(targetPath);
                pic_Mon.ImageLocation = targetPath;

                selectedImagePath = Path.Combine("img", fileName); // lưu đường dẫn tương đối
            }
        }
        // Xử lý sự kiện khi nhấn nút lưu món
        private void btn_Luu_Click(object sender, EventArgs e)
        {
            string tenMon = txt_TenMon.Text.Trim();
            string maDanhMuc = cb_loaiMon.SelectedValue?.ToString();           
            string hinhAnh = selectedImagePath ?? "";

            // Kiểm tra dữ liệu đầu vào
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
            // Tạo đối tượng món ăn
            DTO_ThucDon thucDon = new DTO_ThucDon
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
            else // Cập nhật món đang sửa
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
        // Đặt lại các trường nhập liệu về trạng thái mặc định
        private void ResetFields()
        {
            txt_TenMon.Text = "";
            txt_GiaMon.Text = "";
            cb_loaiMon.SelectedIndex = -1; 
            pic_Mon.Image = null;
            selectedImagePath = "";
        }
        // Xử lý sự kiện khi nhấn nút xóa ảnh
        public void LoadMon(DTO_ThucDon mon)
        {
            try
            {
                monDangSua = mon;
                txt_TenMon.Text = mon.TenMon;
                txt_GiaMon.Text = mon.Gia.ToString("N0");
                cb_loaiMon.SelectedValue = mon.MaDM;
         
                string fullImagePath = Path.Combine(Application.StartupPath, mon.HinhAnh);
                if (!string.IsNullOrEmpty(mon.HinhAnh) && File.Exists(fullImagePath))
                {
                    pic_Mon.Image = Image.FromFile(fullImagePath);
                    pic_Mon.ImageLocation = fullImagePath;
                    selectedImagePath = mon.HinhAnh; // giữ lại để update
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
