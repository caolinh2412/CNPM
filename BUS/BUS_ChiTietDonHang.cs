using System;
using System.Collections.Generic;
using System.ComponentModel;
using DAL;
using DTO;

namespace BUS
{
    public class BUS_ChiTietDonHang
    {
        private DAL_ChiTietDonHang chiTietDonHangDAL;

        public BUS_ChiTietDonHang()
        {
            chiTietDonHangDAL = new DAL_ChiTietDonHang();
        }
        // Thêm chi tiết đơn hàng
        public bool ThemChiTietDonHang(DTO_ChiTietDonHang chiTietDH)
        {
            if (chiTietDH.SoLuong <= 0 || chiTietDH.Gia <= 0) // kiểm tra số lượng và giá
                return false;

            return chiTietDonHangDAL.ThemChiTietDonHang(chiTietDH);
        }
        // Lấy danh sách chi tiết đơn hàng theo mã đơn hàng
        public List<DTO_ChiTietDonHang> LayChiTietDonHangTheoMaDH(string maDH)
        {
            return chiTietDonHangDAL.LayChiTietDonHangTheoMaDH(maDH);
        }
        //xóa chi tiết đơn hàng
        public bool XoaChiTietDonHang(int maCTDH)
        {
            return chiTietDonHangDAL.XoaChiTietDonHang(maCTDH);
        }
        //tính tổng tiền và số lượng
        public decimal TinhTongTien(List<DTO_ChiTietDonHang> danhSachChiTiet)
        {
            decimal tongTien = 0;
            foreach (var chiTiet in danhSachChiTiet) 
            {
                tongTien += chiTiet.ThanhTien;
            }
            return tongTien;
        }

        //tính tổng số lượng
        public int TinhTongSoLuong(List<DTO_ChiTietDonHang> danhSachChiTiet)
        {
            int tongSoLuong = 0;
            foreach (var chiTiet in danhSachChiTiet)
            {
                tongSoLuong += chiTiet.SoLuong; 
            }
            return tongSoLuong;
        }
        // Hàm dùng để thêm một món ăn vào danh sách chi tiết đơn hàng
        public void ThemChiTietDonHang(BindingList<DTO_ChiTietDonHang> chiTietDonHangs, DTO_ThucDon mon, int soLuong)
        {
            // Tạo mới một dòng chi tiết đơn hàng từ món ăn được chọn
            var chiTiet = new DTO_ChiTietDonHang
            {
                MaMon = mon.MaMon,
                TenMon = mon.TenMon,
                SoLuong = soLuong,
                Gia = mon.Gia,
                ThanhTien = soLuong * mon.Gia
            };
            // Kiểm tra xem món ăn đã tồn tại trong danh sách đơn hàng hay chưa
            var existingItem = chiTietDonHangs.FirstOrDefault(x => x.MaMon == chiTiet.MaMon);
            if (existingItem != null)
            {
                // Nếu món đã có trong danh sách, cộng thêm số lượng, cập nhật lại thành tiền
                existingItem.SoLuong += soLuong;              
                existingItem.ThanhTien = existingItem.SoLuong * existingItem.Gia;
            }
            else
            {
                chiTietDonHangs.Add(chiTiet);
            }
        }
        // Hàm dùng để xóa một món ăn khỏi danh sách chi tiết đơn hàng
        public bool XoaChiTietDonHang(BindingList<DTO_ChiTietDonHang> chiTietDonHangs, string maMon, out decimal tongTienMoi)
        {
            // Tìm món ăn trong danh sách chi tiết đơn hàng
            var itemToRemove = chiTietDonHangs.FirstOrDefault(x => x.MaMon == maMon);
            if (itemToRemove != null)
            {
                // Nếu tìm thấy, xóa món ăn khỏi danh sách
                // tính lại tổng tiền
                chiTietDonHangs.Remove(itemToRemove);
                tongTienMoi = chiTietDonHangs.Sum(x => x.ThanhTien); 
                return true;
            }
            tongTienMoi = chiTietDonHangs.Sum(x => x.ThanhTien);
            return false;
        }
        // Hàm dùng để lấy danh sách 3 món ăn bán chạy nhất
        public List<DTO_ChiTietDonHang> GetTop3MonBanChay()
        {
            DAL_ChiTietDonHang dal = new DAL_ChiTietDonHang();
            return dal.GetTop3MonBanChay();
        }
    }
}