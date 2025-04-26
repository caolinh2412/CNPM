using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using DTO;

namespace GUI
{
    public partial class UC_Mon : UserControl
    {
        private DTO_ThucDon thongTinMon;
        public event Action<DTO_ThucDon, int> OnMonSelected;
        

        public UC_Mon()
        {
            InitializeComponent();
            RegisterClickEvent(this);

        }

        private void RegisterClickEvent(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                control.Click += Shared_ClickHandler;
                if (control.HasChildren)
                {
                    RegisterClickEvent(control);
                }
            }
            parent.Click += Shared_ClickHandler;
        }

        private void Shared_ClickHandler(object sender, EventArgs e)
        {
            ShowFormChonSL();
        }

        private void ShowFormChonSL()
        {
            using FormChonSL formChonSL = new();
            if (formChonSL.ShowDialog() == DialogResult.OK)
            {
                int soLuong = formChonSL.SoLuong;
                OnMonSelected?.Invoke(thongTinMon, soLuong);
            }
        }
        public static class ImageHelper
        {
            private static readonly Dictionary<string, Image> cache = new();

            public static Image GetCachedImage(string path)
            {
                if (string.IsNullOrWhiteSpace(path) || !File.Exists(path))
                    return null;
         
                if (!cache.TryGetValue(path, out var img))
                {
                    try
                    {
                        using var original = Image.FromFile(path);
                        img = (Image)original.Clone(); // clone để tránh lock file
                        cache[path] = img;
                    }
                    catch
                    {
                        return null;
                    }
                }

                return img;
            }
        }

        public void SetThongTinMon(DTO_ThucDon mon)
        {
            thongTinMon = mon;

            txt_TenMon.Text = FormatTenMon(mon.TenMon);
            lb_Gia.Text = string.Format("{0:0,0} VNĐ", mon.Gia);
            img_Mon.Image = ImageHelper.GetCachedImage(mon.HinhAnh);
        }

        private string FormatTenMon(string tenMon)
        {
            if (tenMon.Length <= 10) return tenMon;

            int splitPos = tenMon.LastIndexOf(' ', 10);
            return (splitPos > 0) ?
                tenMon[..splitPos] + "\n" + tenMon[(splitPos + 1)..] :
                tenMon;
        }

        public DTO_ThucDon LayThongTinMon()
        {
            return thongTinMon;
        }
    }
}
