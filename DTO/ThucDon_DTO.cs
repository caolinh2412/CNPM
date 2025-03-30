using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ThucDon_DTO
    {
        public int MaMon { get; set; }
        public string TenMon { get; set; }
        public decimal Gia { get; set; }
        public string LoaiMon { get; set; }
        public string TrangThai { get; set; } = "Còn bán";
        public string HinhAnh { get; set; }
    }
}
