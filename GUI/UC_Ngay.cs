using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;

namespace GUI
{
    public partial class UC_Ngay : UserControl
    {
        private BUS_CaLam busCaLam = new BUS_CaLam();
        public UC_Ngay()
        {
            // Khởi tạo các thành phần giao diện
            InitializeComponent();
            // Đặt các thuộc tính cho các thành phần giao diện
            this.Click += UC_Ngay_Click;

            // Đăng ký sự kiện click cho các thành phần giao diện
            lb_Ngay.Click += UC_Ngay_Click;
            lb_ghichu.Click += UC_Ngay_Click;
        }

        // Phương thức để thiết lập ngày và ca làm
        public void SetNgayVaCaLam(DateTime date)
        {
            lb_Ngay.Text = date.Day.ToString();
            this.Tag = date;

            string maNV = Session.GetCurrentUserID();

            // Lấy danh sách ca làm theo ngày và mã nhân viên
            List<DTO_CaLam> danhSachCa = busCaLam.LayCaLamTheoNgayVaMaNV(date, maNV);

            // Kiểm tra trạng thái của các ca làm
            if (danhSachCa.Count > 0)
            {
                // Nếu có ca làm thì hiển thị thông tin
                if (danhSachCa.All(ca => ca.TrangThai == "Xin nghỉ"))
                {
                    lb_ghichu.Text = "Xin nghỉ";
                    lb_ghichu.BackColor = Color.Red;
                }
                else
                {
                    string tatCaCa = string.Join(" - ", danhSachCa.Select(ca => ca.CaLam));
                    lb_ghichu.Text = tatCaCa;
                    lb_ghichu.BackColor = Color.LightGreen;
                }
            }
            else
            {
                lb_ghichu.Text = "";
                lb_ghichu.BackColor = Color.Transparent;
            }
        }
        // Phương thức xử lý sự kiện click
        private void UC_Ngay_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có ca làm nào không
            DateTime date = (DateTime)this.Tag;
         
            // Nếu có ca làm thì mở form để xử lý
            string maNV = Session.GetCurrentUserID();

            // Lấy danh sách ca làm theo ngày và mã nhân viên
            List<DTO_CaLam> danhSachCa = busCaLam.LayCaLamTheoNgayVaMaNV(date, maNV);

            if (danhSachCa.Count == 0)
            {
                MessageBox.Show("Không có ca làm để xử lý!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            

            bool allSuccess = true;

            // Nếu có ca làm thì cập nhật trạng thái
            foreach (DTO_CaLam ca in danhSachCa)
            {
                if (!busCaLam.ToggleWorkScheduleStatus(ca))
                {
                    allSuccess = false;
                }
            }

            if (allSuccess)
            {
                SetNgayVaCaLam(date); // Refresh UI sau khi cập nhật
            }
            else
            {
                MessageBox.Show("Có lỗi khi cập nhật ca làm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}