using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class uc_CaLamViec_NV : UserControl
    {
        private int thangHienTai = DateTime.Now.Month; // Current month
        private int namHienTai = DateTime.Now.Year;

        public uc_CaLamViec_NV()
        {
            InitializeComponent();
            DoubleBuffered = true;

        }
        // Sự kiện này sẽ được gọi khi điều khiển được tải
        private void uc_CaLamViec_NV_Load(object sender, EventArgs e)
        {
            LoadNgayCuaNhieuThang();
        }
        // Phương thức này sẽ tải ngày của nhiều tháng vào FlowLayoutPanel
        void LoadNgayCuaNhieuThang()
        {
            flp_Lich.Controls.Clear(); // Xóa các điều khiển hiện tại trong FlowLayoutPanel

            DateTime firstDay = new DateTime(namHienTai, thangHienTai, 1); // Ngày đầu tiên của tháng
            int soNgay = DateTime.DaysInMonth(namHienTai, thangHienTai);   // Tổng số ngày trong tháng
            int thuBatDau = ((int)firstDay.DayOfWeek + 6) % 7; // Thứ bắt đầu (chuyển từ Chủ Nhật = 0 sang Thứ Hai = 0)

            // Thêm các ô trống (panel padding) để căn chỉnh ngày cho đúng thứ bắt đầu trong tuần
            for (int i = 0; i < thuBatDau; i++)
            {
                Panel padding = new Panel
                {
                    Dock = DockStyle.Fill
                };
                flp_Lich.Controls.Add(padding, i, 0);
            }

            for (int d = 1; d <= soNgay; d++)
            {
                DateTime ngay = new DateTime(namHienTai, thangHienTai, d);
                UC_Ngay ucNgay = new UC_Ngay(); // Tạo user control cho từng ngày
                ucNgay.SetNgayVaCaLam(ngay);   // Thiết lập ngày và ca làm việc
                ucNgay.Dock = DockStyle.Fill;
                flp_Lich.Controls.Add(ucNgay);
            }
            lb_ThangHT.Text = $"Tháng {thangHienTai}";
        }

        // Sự kiện này sẽ được gọi khi người dùng nhấn nút "Tháng trước"
        private void btn_Thangtrc_Click(object sender, EventArgs e)
        {
            thangHienTai--;
            if (thangHienTai < 1)
            {
                thangHienTai = 12;
                namHienTai--;
            }
            LoadNgayCuaNhieuThang();
        }
        // Sự kiện này sẽ được gọi khi người dùng nhấn nút "Tháng sau"
        private void btn_ThangSau_Click(object sender, EventArgs e)
        {
            thangHienTai++;
            if (thangHienTai > 12)
            {
                thangHienTai = 1;
                namHienTai++;
            }
            LoadNgayCuaNhieuThang();
        }

    }
}

  
