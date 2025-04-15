using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;
using BUS;

namespace CoffeeShopManagementSystem
{
    public partial class FormConfirmEmail : Form
    {
        private string userEmail; // Email người dùng nhập
        private string verificationCode; // Mã xác nhận được gửi đến email
        private DateTime codeExpirationTime; // Thời gian hết hạn của mã xác nhận
        private BUS_DangNhap dangNhapBus = new BUS_DangNhap(); // Đối tượng xử lý nghiệp vụ đăng nhập

        public FormConfirmEmail()
        {
            InitializeComponent();
        }

        // Sự kiện khi nhấn nút xác nhận mã
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (ValidateCode(code.Text)) // Kiểm tra mã xác nhận có hợp lệ và chưa hết hạn không
            {
                MessageBox.Show("Mã hợp lệ! Đang chuyển đến form đổi mật khẩu...");
                FromChangePass changePassForm = new FromChangePass(userEmail, dangNhapBus); // Truyền email để đổi mật khẩu
                changePassForm.Show(); 
                this.Hide();
            }
            else
            {
                MessageBox.Show("Mã không hợp lệ hoặc đã hết hạn!");
            }
        }

        // Sự kiện khi nhấn nút gửi mã xác nhận
        private void btnSendCode_Click(object sender, EventArgs e)
        {
            userEmail = txt_email.Text.Trim(); // Lấy email từ textbox
            if (dangNhapBus.KiemTraEmail(userEmail)) // Kiểm tra email có tồn tại trong hệ thống không
            {
                GenerateAndSendCode(userEmail); // Gửi mã xác nhận đến email
                MessageBox.Show("Mã xác nhận đã được gửi, vui lòng kiểm tra email!");
            }
            else
            {
                MessageBox.Show("Email không tồn tại trong hệ thống!");
            }
        }
        // Tạo mã xác nhận và thiết lập thời gian hết hạn
        private void GenerateAndSendCode(string email)
        {
            verificationCode = GenerateCode(); // Tạo mã xác nhận ngẫu nhiên
            codeExpirationTime = DateTime.Now.AddSeconds(30); // Thiết lập thời gian hết hạn là 30 giây

            // Gửi email chứa mã xác nhận
            SendEmail(email, verificationCode);
        }

        // Tạo mã xác nhận ngẫu nhiên
        private string GenerateCode()
        {
            Random random = new Random(); // Tạo đối tượng Random
            return random.Next(100000, 999999).ToString(); // Tạo mã xác nhận từ 100000 đến 999999
        }

        // Gửi email chứa mã xác nhận
        private void SendEmail(string email, string code)
        {
            try
            {
                MailMessage mail = new MailMessage(); // Tạo đối tượng MailMessage
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587)
                {
                    DeliveryMethod = SmtpDeliveryMethod.Network, // Gửi qua mạng
                    Credentials = new NetworkCredential("caolinh14789@gmail.com", "ferw ueel cooj gxen"), // Thay bằng email và mật khẩu của bạn
                    EnableSsl = true
                };

                mail.From = new MailAddress("your-email@gmail.com"); // Địa chỉ email gửi
                mail.To.Add(email); // Địa chỉ email nhận
                mail.Subject = "Mã xác nhận đổi mật khẩu";
                mail.Body = "Mã xác nhận của bạn là: " + code;

                smtp.Send(mail); // Gửi email
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi gửi email: " + ex.Message);
            }
        }

        // Kiểm tra mã xác nhận có hợp lệ và chưa hết hạn không
        private bool ValidateCode(string code)
        {
            // Kiểm tra mã xác nhận và thời gian hết hạn
            return code == verificationCode && DateTime.Now <= codeExpirationTime;
        }

        // Sự kiện khi nhấn nút quay lại
        private void close_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Đóng ứng dụng
        }

        // Sự kiện khi nhấn nút đăng nhập
        private void btnLogIn_signin_Click(object sender, EventArgs e)
        {
            // Mở giao diện đăng nhập
            FormDangNhap signIn = new FormDangNhap();
            signIn.Show();
            this.Hide();
        }
    }
}
