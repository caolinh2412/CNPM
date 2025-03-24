using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShopManagementSystem.DTO
{
    public class NhanVienDTO
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string GioiTinh { get; set; }
        public string Password { get; set; }
        public DateTime? DateSignup { get; set; }
    }
}
