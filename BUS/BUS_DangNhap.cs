using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BUS
{
    public class BUS_DangNhap
    {
        private DAL_DangNhap dangNhap = new DAL_DangNhap();
        // Hàm kiểm tra đăng nhập
        public DTO_DangNhap DangNhap(string email, string matKhau)
        {
            return dangNhap.KiemTraDangNhap(email, matKhau);
        }
        // Hàm kiểm tra tài khoản có tồn tại hay không
        public bool KiemTraEmail(string email)
        {
            return dangNhap.KiemTraEmailTonTai(email);
        }
        //Cap nhật mật khẩu
        public bool ResetPassword(string email, string newPassword)
        {
            return dangNhap.ResetPassword(email, newPassword);
        }

    }
}