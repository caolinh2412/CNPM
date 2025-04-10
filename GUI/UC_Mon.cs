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
        private DTO_ThucDon thongTinMon;
        public event Action<DTO_ThucDon, int> OnMonSelected;
        private static Dictionary<string, Image> imageCache = new Dictionary<string, Image>();
        public FormMon()
        {
            InitializeComponent();
            this.Click += FormMon_Click;
            foreach (Control control in this.Controls)
            {
                control.Click -= FormMon_Click; 
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

        public void SetThongTinMon(DTO_ThucDon mon)
        {
            string tenMon = mon.TenMon;
            decimal gia = mon.Gia;
            if (tenMon.Length > 10)
            {
                int viTriChen = tenMon.LastIndexOf(' ', 10);
                if (viTriChen > 0)
                {
                    tenMon = tenMon.Substring(0, viTriChen) + "\n" + tenMon.Substring(viTriChen + 1);
                }
            }
            txt_TenMon.Text = tenMon;
            lb_Gia.Text = string.Format("{0:0,0}", gia) + " VNĐ";
            thongTinMon = mon;
            txt_TenMon.TextAlign = ContentAlignment.MiddleCenter;

            if (!string.IsNullOrEmpty(mon.HinhAnh))
            {
                try
                {
                    if (!imageCache.ContainsKey(mon.HinhAnh))
                    {
                        using (var fs = new FileStream(mon.HinhAnh, FileMode.Open, FileAccess.Read))
                        {
                            Image original = Image.FromStream(fs);
                            Image resized = ResizeImage(original, img_Mon.Width, img_Mon.Height);
                            imageCache[mon.HinhAnh] = resized;
                        }
                    }
                    img_Mon.Image = imageCache[mon.HinhAnh];
                }
                catch
                {
                    img_Mon.Image = null;
                }
            }
        }

        public DTO_ThucDon LayThongTinMon()
        {
            return thongTinMon;
        }

        private void img_Mon_Click(object sender, EventArgs e)
        {
            FormChonSL formChonSL = new FormChonSL();
            if (formChonSL.ShowDialog() == DialogResult.OK)
            {
                int soLuong = formChonSL.SoLuong;
                MessageBox.Show($"Đã chọn {soLuong} món {thongTinMon.TenMon}");
                OnMonSelected?.Invoke(thongTinMon, soLuong);
            }
        }
        private Image ResizeImage(Image img, int width, int height)
        {
            Bitmap bmp = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.DrawImage(img, 0, 0, width, height);
            }
            return bmp;
        }
    }
}
