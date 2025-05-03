using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BUS
{
    public class BUS_NhanVien
    {
        private DAL_NhanVien dal = new DAL_NhanVien();
        // Phương thức để tạo mã nhân viên tiếp theo (ví dụ: NV001, NV002, ...)
        public string MaNVTiepTheo()
        {
            string maxCode = dal.MaNvLonNhat();
            int nextNumber = int.Parse(maxCode.Substring(2)) + 1;
            return $"NV{nextNumber:D3}";
        }
        // Phương thức để lấy danh sách nhân viên
        public List<DTO_DangNhap> GetAllEmployees()
        {
            return dal.GetAllEmployees();
        }
        // Phương thức để tắt hoạt động của một nhân viên (khóa tài khoản)
        public bool TatHD(string maNV)
        {
            return dal.TatHD(maNV);
        }
        // Phương thức để cập nhật thông tin của nhân viên
        public bool UpdateEmployee(DTO_DangNhap employee)
        {
            return dal.UpdateEmployee(employee);
        }
        // Phương thức để thêm mới một nhân viên vào cơ sở dữ liệu
        public bool InsertEmployee(DTO_DangNhap employee)
        {
            return dal.InsertEmployee(employee);
        }
        // Phương thức để lấy tổng số lượng nhân viên
        public int GetEmployeeCount()
        {
            return dal.GetEmployeeCount();
        }
    }
}
