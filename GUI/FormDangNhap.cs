using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using BUS;
using DTO;
using GUI;
using CoffeeShopManagementSystem.UI;

namespace CoffeeShopManagementSystem
{
    public partial class FormDangNhap : Form
    {
        
        public FormDangNhap()
        {
            InitializeComponent(); // Khởi tạo giao diện đăng nhập
            if (File.Exists("config.txt"))
            {
                StreamReader rd = new StreamReader("config.txt");
                string auth = rd.ReadLine();

                if (auth.Equals("windows"))
                {
                    Program.authen = "windows";
                    Program.server = rd.ReadLine();
                    Program.db = rd.ReadLine();
                }
                else // SQL Authentication
                {
                    Program.authen = "sql";
                    Program.server = rd.ReadLine();
                    Program.db = rd.ReadLine();
                    Program.uid = rd.ReadLine();
                    Program.pw = rd.ReadLine();
                }

                rd.Close();
            }
            else
            {
                // Mở form cấu hình nếu chưa có config.txt
                frmConfig f = new frmConfig();
                f.ShowDialog();  // Chặn tới khi đóng config
            }
        }


        // Sự kiện khi nhấn nút đóng (close)
        private void close_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Đóng ứng dụng
        }
        private void signIn_showpass_CheckedChanged(object sender, EventArgs e)
        {
            // Kiểm tra trạng thái của checkbox "show password"
            txtPassword.PasswordChar = signIn_showpass.Checked ? '\0' : '*';
        }

        // Sự kiện khi nhấn nút đăng nhập
        private void btnLogIn_signin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text; // Lấy email từ textbox
            string password = txtPassword.Text; // Lấy mật khẩu từ textbox

            try
            {
                BUS_DangNhap dangNhapBus = new BUS_DangNhap(); // Tạo đối tượng BUS xử lý đăng nhập
                DTO_DangNhap user = dangNhapBus.DangNhap(email, password); // Gọi hàm đăng nhập trong BUS để kiểm tra

                if (user != null)  // Nếu đăng nhập thành công (có trả về user)
                {                  
                    Session.Login(user); // Lưu thông tin người dùng vào session
                    MessageBox.Show("Đăng nhập thành công!");

                    if (string.IsNullOrEmpty(user.MaQL)) // Nếu không có mã quản lý => Quản lý
                    {
                        // Mở giao diện quản lý
                        FormQuanLy managerForm = new FormQuanLy();
                        managerForm.Show();
                        managerForm.ShowDashboardOnSignIn();
                    }
                    else
                    {
                        // Mở giao diện nhân viên
                        FormNhanVien staffForm = new FormNhanVien();
                        staffForm.Show();
                        staffForm.DathangOnSignIn();

                    }
                    this.Hide(); // Ẩn form đăng nhập
                }
                else
                {
                    // Nếu không có user => Đăng nhập thất bại
                    MessageBox.Show("Email hoặc mật khẩu không hợp lệ!.");
                }
            }
            catch (Exception ex)
            {
                // Bắt lỗi nếu có sự cố kết nối hoặc lỗi không mong muốn
                MessageBox.Show($"Lỗi kết nối: {ex.Message}");
            }
        }
        private void fg_Pass_Click_1(object sender, EventArgs e)
        {
            // Khi nhấn vào "Quên mật khẩu", mở form xác nhận email
            FormConfirmEmail confirmEmail = new FormConfirmEmail();
            confirmEmail.Show(); //hiển thị form xác nhận email
            this.Hide();
        }
    }
}

