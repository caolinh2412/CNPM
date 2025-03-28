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
    public partial class ConfirmEmailForm : Form
    {
        private string userEmail;
        private string verificationCode;
        private DateTime codeExpirationTime;
        private DangNhap_BUS dangNhapBus = new DangNhap_BUS();

        public ConfirmEmailForm()
        {
            InitializeComponent();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (ValidateCode(code.Text))
            {
                MessageBox.Show("Mã hợp lệ! Đang chuyển đến form đổi mật khẩu...");
                ChangePassForm changePassForm = new ChangePassForm(userEmail, dangNhapBus);
                changePassForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Mã không hợp lệ hoặc đã hết hạn!");
            }
        }

        private void btnSendCode_Click(object sender, EventArgs e)
        {
            userEmail = txt_email.Text.Trim();
            if (dangNhapBus.KiemTraEmail(userEmail))
            {
                GenerateAndSendCode(userEmail);
                MessageBox.Show("Mã xác nhận đã được gửi, vui lòng kiểm tra email!");
            }
            else
            {
                MessageBox.Show("Email không tồn tại trong hệ thống!");
            }
        }

        private void GenerateAndSendCode(string email)
        {
            verificationCode = GenerateCode();
            codeExpirationTime = DateTime.Now.AddSeconds(30);

            // Send the code via email
            SendEmail(email, verificationCode);
        }

        private string GenerateCode()
        {
            Random random = new Random();
            return random.Next(100000, 999999).ToString();
        }

        private void SendEmail(string email, string code)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587)
                {
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Credentials = new NetworkCredential("caolinh14789@gmail.com", "ferw ueel cooj gxen"),
                    EnableSsl = true
                };

                mail.From = new MailAddress("your-email@gmail.com");
                mail.To.Add(email);
                mail.Subject = "Mã xác nhận đổi mật khẩu";
                mail.Body = "Mã xác nhận của bạn là: " + code;

                smtp.Send(mail);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi gửi email: " + ex.Message);
            }
        }

        private bool ValidateCode(string code)
        {
            return code == verificationCode && DateTime.Now <= codeExpirationTime;
        }

        private void close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogIn_signin_Click(object sender, EventArgs e)
        {
            SignInForm signIn = new SignInForm();
            signIn.Show();
            this.Hide();
        }
    }
}
