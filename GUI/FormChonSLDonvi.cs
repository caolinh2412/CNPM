using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class FormChonSLDonvi : Form
    {
        public decimal SoLuong { get; private set; }
        public string DonVi { get; private set; }
        public FormChonSLDonvi()
        {
            InitializeComponent();
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(txt_SoLuong.Text, out decimal soLuong) && !string.IsNullOrWhiteSpace(txt_DV.Text))
            {
                SoLuong = soLuong;
                DonVi = txt_DV.Text;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập số lượng hợp lệ (số nguyên) và đơn vị!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
