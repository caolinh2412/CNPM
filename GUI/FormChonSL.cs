using DTO;
using System;
using System.Windows.Forms;

namespace GUI
{
    public partial class FormChonSL : Form
    {
        // Thuộc tính lưu trữ số lượng
        private int soLuong;
        public int SoLuong
        {
            get { return soLuong; }
        }

        // Constructor
        public FormChonSL()
        {
            InitializeComponent();
            txt_MaNV.KeyPress += Txt_MaNV_KeyPress;  // Xử lý sự kiện khi nhấn phím
        }

        // Xử lý sự kiện nhấn phím để chỉ cho phép nhập số
        private void Txt_MaNV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))  // Nếu không phải phím số
            {
                e.Handled = true;  // Ngừng xử lý phím
            }
        }

        // Sự kiện khi nhấn nút Lưu
        private void btn_Luu_Click_1(object sender, EventArgs e)
        {
            // Kiểm tra số lượng hợp lệ
            if (int.TryParse(txt_MaNV.Text, out soLuong) && soLuong > 0)
            {
                DialogResult = DialogResult.OK;  // Đóng form với kết quả OK
                Close();
            }
            else
            {
                // Hiển thị thông báo lỗi nếu số lượng không hợp lệ
                MessageBox.Show("Vui lòng nhập số lượng hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Sự kiện khi nhấn nút Đóng
        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            Close();  // Đóng form
        }

        // Sự kiện thay đổi nội dung trong txt_MaNV (chưa sử dụng)
        private void txt_MaNV_TextChanged(object sender, EventArgs e)
        {
            // Có thể xử lý thêm logic ở đây nếu cần
        }
    }
}
