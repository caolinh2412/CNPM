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
    public partial class FormChonSLDonvi : Form
    {
        // Thuộc tính lưu trữ số lượng và đơn vị
        public decimal SoLuong { get; private set; }
        public string DonVi { get; private set; }

        // Constructor nhận vào đơn vị nguyên liệu
        public FormChonSLDonvi(string donViNguyenLieu)
        {
            InitializeComponent();
            txt_DV.Text = donViNguyenLieu;  // Hiển thị đơn vị nguyên liệu
            txt_DV.ReadOnly = true;          // Đặt trường đơn vị chỉ đọc
        }

        // Sự kiện khi nhấn nút Lưu
        private void btn_Luu_Click(object sender, EventArgs e)
        {
            // Kiểm tra và lưu số lượng và đơn vị nếu hợp lệ
            if (decimal.TryParse(txt_SoLuong.Text, out decimal soLuong) && !string.IsNullOrWhiteSpace(txt_DV.Text))
            {
                SoLuong = soLuong;
                DonVi = txt_DV.Text;
                this.DialogResult = DialogResult.OK;  // Đóng form với kết quả OK
                this.Close();
            }
            else
            {
                // Hiển thị thông báo lỗi nếu thông tin không hợp lệ
                MessageBox.Show("Vui lòng nhập số lượng hợp lệ (số nguyên) và đơn vị!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Sự kiện khi nhấn nút Thoát
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();  // Đóng form
        }
    }
}

