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
        // Lưu thông tin món ăn (dữ liệu từ lớp DTO)
        private DTO_ThucDon thongTinMon;
        // Sự kiện này được kích hoạt khi người dùng chọn món ăn
        public event Action<DTO_ThucDon, int> OnMonSelected;
        
        public UC_Mon()
        {
            // Khởi tạo các thành phần giao diện
            InitializeComponent();
            RegisterClickEvent(this);

        }
        // Đăng ký sự kiện click cho tất cả các thành phần trong điều khiển
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
            // Đăng ký sự kiện cho chính control cha
            parent.Click += Shared_ClickHandler;
        }

        // Xử lý sự kiện khi người dùng click vào món ăn
        private void Shared_ClickHandler(object sender, EventArgs e)
        {
            ShowFormChonSL();
        }

        // Hiển thị form chọn số lượng món ăn
        private void ShowFormChonSL()
        {
            using FormChonSL formChonSL = new(); // tạo form chọn số lượng
            if (formChonSL.ShowDialog() == DialogResult.OK)
            {
                int soLuong = formChonSL.SoLuong;
                OnMonSelected?.Invoke(thongTinMon, soLuong); // gọi sự kiện gửi dữ liệu ra ngoài
            }
        }
        // Lớp phụ trợ để load và cache hình ảnh từ file
        public static class ImageHelper
        {
            // Từ điển để cache hình ảnh, tránh đọc lại file nhiều lần
            private static readonly Dictionary<string, Image> cache = new();

            // Trả về hình ảnh từ cache hoặc load từ file nếu chưa có
            public static Image GetCachedImage(string path)
            {
                // Kiểm tra đường dẫn có hợp lệ không
                if (string.IsNullOrWhiteSpace(path) || !File.Exists(path))
                    return null;

                // Nếu hình ảnh chưa được cache, thì load từ file và thêm vào cache
                if (!cache.TryGetValue(path, out var img))
                {
                    try
                    {
                        using var original = Image.FromFile(path);
                        img = (Image)original.Clone(); // clone để tránh khóa file gốc
                        cache[path] = img;
                    }
                    catch
                    {
                        return null; // nếu lỗi thì trả null
                    }
                }

                return img;
            }
        }
        // Phương thức để thiết lập thông tin món ăn
        public void SetThongTinMon(DTO_ThucDon mon)
        {
            thongTinMon = mon;

            txt_TenMon.Text = FormatTenMon(mon.TenMon);
            lb_Gia.Text = string.Format("{0:0,0} VNĐ", mon.Gia);
            img_Mon.Image = ImageHelper.GetCachedImage(mon.HinhAnh);
        }

        // Phương thức để định dạng tên món ăn, nếu dài hơn 10 ký tự thì chia thành 2 dòng
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
