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

namespace CoffeeShopManagementSystem
{
    public partial class FromChangePass : Form
    {
        private string userEmail; // Email người dùng nhập
        private BUS_DangNhap dangNhapBus; // Đối tượng xử lý nghiệp vụ đăng nhập

        // Hàm khởi tạo - nhận vào email người dùng và đối tượng BUS để xử lý
        public FromChangePass(string email, BUS_DangNhap bus)
        {
            InitializeComponent();
            userEmail = email; // Lưu email để sử dụng khi đổi mật khẩu
            dangNhapBus = bus; // Gán đối tượng xử lý đăng nhập
        }

        // Sự kiện khi nhấn nút "Đổi mật khẩu"
        private void btnSignUp_LogIn_Click(object sender, EventArgs e)
        {
            string newPassword = newPass.Text; // Mật khẩu mới
            string confirmPassword = cfPass.Text; // Mật khẩu xác nhận

            // Kiểm tra xem 2 mật khẩu có giống nhau không
            if (newPassword != confirmPassword)
            {
                MessageBox.Show("Mật khẩu và xác nhận mật khẩu không khớp!");
                return;
            }

            try
            {
                // Gọi hàm ResetPassword trong BUS để cập nhật mật khẩu
                if (dangNhapBus.ResetPassword(userEmail, newPassword))
                {
                    MessageBox.Show("Mật khẩu đã được đổi thành công!");
                    this.Close(); // Đóng form đổi mật khẩu

                    // Mở lại form đăng nhập
                    FormDangNhap signIn = new FormDangNhap();
                    signIn.Show(); 

                    this.Hide(); // Ẩn form đổi mật khẩu
                }
                else
                {
                    MessageBox.Show("Đổi mật khẩu thất bại. Vui lòng thử lại!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}");
            }
        }

        // Sự kiện khi checkbox "Hiện mật khẩu" thay đổi trạng thái
        private void signIn_showpass_CheckedChanged(object sender, EventArgs e)
        {
            // Nếu checkbox được chọn thì hiện mật khẩu, ngược lại thì ẩn mật khẩu
            newPass.PasswordChar = signIn_showpass.Checked ? '\0' : '*'; 
            cfPass.PasswordChar = signIn_showpass.Checked ? '\0' : '*'; 
        }

        // Sự kiện khi nhấn nút đóng (close)
        private void close_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Đóng ứng dụng
        }
    }
}
