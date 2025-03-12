using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeShopManagementSystem.DAO;
using System.Net.Mail;
using System.Net;
using System.Windows.Forms;
using System.Timers;

namespace CoffeeShopManagementSystem.BUS
{
    public class UserBUS
    {
        private UserDAL userDAL;
        private string verificationCode;
        private bool isCodeValid = false;
        private System.Timers.Timer codeTimer;
        public UserBUS()
        {
            userDAL = new UserDAL();
        }

        public bool Login(string username, string password, string role)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                throw new ArgumentException("Tên đăng nhập và mật khẩu không được để trống.");
            }

            DataTable user = userDAL.GetUser(username, password, role);
            return user.Rows.Count > 0;
        }
        public bool Register(string username, string email, string sex, string password, DateTime date)
        {
            string newId = userDAL.GenerateNewUserId();
            return userDAL.RegisterUser(newId, username, email, sex, password, date);
        }

        public bool CheckUsernameExists(string username)
        {
            DataTable dataTable = userDAL.CheckUsername(username);
            return dataTable.Rows.Count >= 1;
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
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential("caolinh14789@gmail.com", "btyi xepc jltp xoke");
                smtp.EnableSsl = true;

                mail.From = new MailAddress("caolinh14789@gmail.com");
                mail.To.Add(toEmail);
                mail.Subject = "Mã xác nhận đổi mật khẩu";
                mail.Body = "Mã xác nhận của bạn là: " + code;

                smtp.Send(mail);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi gửi email: " + ex.Message);
            }
        }

        private void StartCodeExpirationTimer()
        {
            codeTimer = new System.Timers.Timer(30000);
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
    }
}