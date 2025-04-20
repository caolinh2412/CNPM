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
            InitializeComponent();
            this.Click += UC_Ngay_Click;
            lb_Ngay.Click += UC_Ngay_Click;
            lb_ghichu.Click += UC_Ngay_Click;
        }
        public void SetNgayVaCaLam(DateTime date)
        {
            lb_Ngay.Text = date.Day.ToString();
            this.Tag = date;

            string maNV = Session.GetCurrentUserID();

            List<DTO_CaLam> danhSachCa = busCaLam.LayCaLamTheoNgayVaMaNV(date, maNV);

            if (danhSachCa.Count > 0)
            {
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
        private void UC_Ngay_Click(object sender, EventArgs e)
        {
            DateTime date = (DateTime)this.Tag;
            string maNV = Session.GetCurrentUserID();
            List<DTO_CaLam> danhSachCa = busCaLam.LayCaLamTheoNgayVaMaNV(date, maNV);

            if (danhSachCa.Count == 0)
            {
                MessageBox.Show("Không có ca làm để xử lý!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            bool allSuccess = true;

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