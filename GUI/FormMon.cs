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
    public partial class FormMon : UserControl
    {
        private ThucDon_DTO thongTinMon;
        public event Action<ThucDon_DTO, int> OnMonSelected;
        public FormMon()
        {
            InitializeComponent();
            this.Click += FormMon_Click;          
            foreach (Control control in this.Controls)
            {
                control.Click += FormMon_Click;
            }
        }

        private void FormMon_Click(object sender, EventArgs e)
        {
            FormChonSL formChonSL = new FormChonSL();
            if (formChonSL.ShowDialog() == DialogResult.OK)
            {
                int soLuong = formChonSL.SoLuong;
                MessageBox.Show($"Đã chọn {soLuong} món {thongTinMon.TenMon}");
                OnMonSelected?.Invoke(thongTinMon, soLuong);
            }
        }

        public void SetThongTinMon(ThucDon_DTO mon)
        {
            string tenMon = mon.TenMon;
            if (tenMon.Length > 10)
            {
                int viTriChen = tenMon.LastIndexOf(' ',10 );
                if (viTriChen > 0)
                {
                    tenMon = tenMon.Substring(0, viTriChen) + "\n" + tenMon.Substring(viTriChen + 1);
                }
            }
            txt_TenMon.Text = tenMon;
            thongTinMon = mon;            
            txt_TenMon.TextAlign = ContentAlignment.MiddleCenter;

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
