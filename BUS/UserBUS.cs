using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeShopManagementSystem.DAL;
using System.Net.Mail;
using System.Net;
using System.Windows.Forms;
using System.Timers;
using Timer = System.Timers.Timer;
using CoffeeShopManagementSystem.DTO;

namespace CoffeeShopManagementSystem.BUS
{
    public class UserBUS
    {
        private readonly UserDAL userDAL;
        private string verificationCode;
        private bool isCodeValid = false;
        private Timer codeTimer;

        public UserBUS()
        {
            userDAL = new UserDAL();
            verificationCode = string.Empty;
            codeTimer = new Timer();
        }

        public bool Register(string username, string email, string sex, string password, DateTime date)
        {
            string newId = userDAL.GenerateNewUserId();
            var nhanVien = new NhanVienDTO
            {
                Id = newId,
                Username = username,
                Email = email,
                GioiTinh = sex,
                Password = password,
                DateSignup = date
            };
            return userDAL.RegisterUser(nhanVien);
        }

        public bool CheckUsernameExists(string username)
        {
            return userDAL.CheckUsername(username);
        }

        public bool VerifyEmail(string email)
        {
            return userDAL.IsEmailExists(email);
        }

        public void GenerateAndSendCode(string email)
        {
            Random random = new Random();
            verificationCode = random.Next(100000, 999999).ToString();
            isCodeValid = true;
            SendEmail(email, verificationCode);
            StartCodeExpirationTimer();
        }

        private void SendEmail(string toEmail, string code)
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
                mail.To.Add(toEmail);
                mail.Subject = "Mã xác nhận đổi mật khẩu";
                mail.Body = "Mã xác nhận của bạn là: " + code;

                smtp.Send(mail);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi gửi email: " + ex.Message);
            }
        }

        private void StartCodeExpirationTimer()
        {
            codeTimer = new Timer(30000);
            codeTimer.Elapsed += (sender, e) => isCodeValid = false;
            codeTimer.AutoReset = false;
            codeTimer.Start();
        }

        public bool ValidateCode(string code)
        {
            return isCodeValid && code == verificationCode;
        }

        public void ResetPassword(string email, string newPassword)
        {
            userDAL.UpdatePassword(email, newPassword);
        }

        public object GetUser(string username, string password, string role)
        {
            return userDAL.GetUser(username, password, role);
        }

        public bool CheckRole(string username, string role)
        {
            return userDAL.CheckRole(username, role);
        }
    }
}

