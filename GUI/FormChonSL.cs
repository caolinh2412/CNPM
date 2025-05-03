using DTO;
using System;
using System.Windows.Forms;

namespace GUI
{
    public partial class FormChonSL : Form
    {
        private int soLuong;

        public int SoLuong
        {
            get { return soLuong; }
        }

        public FormChonSL()
        {
            InitializeComponent();
            txt_MaNV.KeyPress += Txt_MaNV_KeyPress;
        }
     
        private void Txt_MaNV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btn_Luu_Click_1(object sender, EventArgs e)
        {
            if (int.TryParse(txt_MaNV.Text, out soLuong) && soLuong > 0)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập số lượng hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void txt_MaNV_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
