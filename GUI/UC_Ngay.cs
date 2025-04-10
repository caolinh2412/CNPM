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
        }
        public void SetNgayVaCaLam(DateTime date)
        {
            lb_Ngay.Text = date.Day.ToString();
            this.Tag = date;

            string maNV = Session.GetCurrentUserID();

            List<DTO_CaLam> danhSachCa = busCaLam.LayCaLamTheoNgayVaMaNV(date, maNV);

            if (danhSachCa.Count > 0)
            {              
                string tatCaCa = string.Join(" - ", danhSachCa.Select(ca => ca.CaLam));
                lb_ghichu.Text = tatCaCa;

                lb_ghichu.BackColor = Color.LightGreen;
            }
            else
            {
                lb_ghichu.Text = "";
                lb_ghichu.BackColor = Color.Transparent;
            }
        }
    }
}
