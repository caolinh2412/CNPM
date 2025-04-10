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
        private int thangHienTai = 4;
        private int namHienTai = 2025;
        public uc_CaLamViec_NV()
        {
            InitializeComponent();
        }
        private void uc_CaLamViec_NV_Load(object sender, EventArgs e)
        {
            LoadNgayCuaNhieuThang();
        }
        void LoadNgayCuaNhieuThang()
        {
            flp_Lich.Controls.Clear();

            DateTime firstDay = new DateTime(namHienTai, thangHienTai, 1);
            int soNgay = DateTime.DaysInMonth(namHienTai, thangHienTai);
            int thuBatDau = ((int)firstDay.DayOfWeek + 6) % 7; 

            for (int i = 0; i < thuBatDau; i++)
            {
                Panel padding = new Panel
                {
                    Width = 135,
                    Height = 82
                };
                flp_Lich.Controls.Add(padding);
            }

            for (int d = 1; d <= soNgay; d++)
            {
                DateTime ngay = new DateTime(namHienTai, thangHienTai, d);
                UC_Ngay ucNgay = new UC_Ngay();
                ucNgay.SetNgayVaCaLam(ngay);
                flp_Lich.Controls.Add(ucNgay);
            }
            lb_ThangHT.Text = $"Tháng {thangHienTai}";
        }

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
