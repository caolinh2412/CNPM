using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace GUI
{
    public partial class frmConfig : Form
    {
        public frmConfig()
        {
            InitializeComponent();
        }

        private void frmConfig_Load(object sender, EventArgs e)
        {
            if (ckW.Checked == true)
            {
                txtuid.ReadOnly = true;
                txtPass.ReadOnly = true;
            }
            else
            {
                txtuid.ReadOnly = false;
                txtPass.ReadOnly = false;
            }
        }

        private void bSave_Click_1(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter("config.txt");
            if (ckW.Checked == true)
            {
                sw.WriteLine("windows");
                sw.WriteLine(txtserver.Text);
                sw.WriteLine(txtdb.Text);


            }
            else
            {
                sw.WriteLine("sql");
                sw.WriteLine(txtserver.Text);
                sw.WriteLine(txtdb.Text);
                sw.WriteLine(txtuid.Text);
                sw.WriteLine(txtPass.Text);
            }
            sw.Close();
            MessageBox.Show("Lưu thành công");
            this.Close();
        }

        private void ckW_CheckedChanged_1(object sender, EventArgs e)
        {
            if (ckW.Checked == true)
            {
                txtuid.ReadOnly = true;
                txtPass.ReadOnly = true;
            }
            else
            {
                txtuid.ReadOnly = false;
                txtPass.ReadOnly = false;
            }
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
             this.Close();
        }
    }
}
