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
    public partial class FormDatHang : UserControl
    {
        private ThucDon_BUS thucDonBUS;
        private List<FormMon> danhSachMon;

        public FormDatHang()
        {
            InitializeComponent();
            thucDonBUS = new ThucDon_BUS();
            danhSachMon = new List<FormMon>();
            TaiDanhSachMon();
        }

        private void TaiDanhSachMon()
        {
            foreach (var mon in danhSachMon)
            {
                mon.Dispose();
            }
            danhSachMon.Clear();


            List<ThucDon_DTO> danhSachMonTuDB = thucDonBUS.GetAllMenuItems();

            foreach (var mon in danhSachMonTuDB)
            {
                FormMon fromMon = new FormMon();
                fromMon.SetThongTinMon(mon);
                danhSachMon.Add(fromMon);
                flp_ThucDon.Controls.Add(fromMon);
            }
        }

        public void LamMoiHienThi()
        {
            TaiDanhSachMon();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
