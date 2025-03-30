using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;

namespace GUI
{
    public partial class FormMon: UserControl
    {
        public FormMon()
        {
            InitializeComponent();
        }
        private ThucDon_DTO thongTinMon;

        public void SetThongTinMon(ThucDon_DTO mon)
        {
            thongTinMon = mon;
            txt_TenMon.Text = mon.TenMon;

            if (!string.IsNullOrEmpty(mon.HinhAnh))
            {
                try
                {
                    img_Mon.Image = Image.FromFile(mon.HinhAnh);
                }
                catch (Exception ex)
                {
                    img_Mon.Image = null;
                }
            }
        }

        public ThucDon_DTO LayThongTinMon()
        {
            return thongTinMon;
        }
    }
}
