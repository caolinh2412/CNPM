using System;
using System.Collections.Generic;
using DTO;
using DAL;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace CoffeeShopManagementSystem.BUS
{
    public class BUS_DonHang
    {
        private readonly DAL_DonHang _donHangDAL;

        public BUS_DonHang()
        {
            _donHangDAL = new DAL_DonHang();
        }
        // Lấy danh sách đơn hàng
        public DataTable LayDanhSachDonHang()
        {
            return _donHangDAL.GetAllDonHangWithTenNV();
        }
        // Lấy danh sách đơn hàng theo mã nhân viên
        public DTO_DonHang GetDonHangById(string  maDH)
        {
            return _donHangDAL.GetDonHangById(maDH);
        }
        //tạo đơn hàng mới
        public DTO_DonHang TaoDonHang(string maND)
        {
            if (string.IsNullOrEmpty(maND))
                throw new ArgumentException("Mã người dùng không được để trống");

            return new DTO_DonHang
            {
                NgayDat = DateTime.Now,
                MaNV = maND,
                TongTien = 0
            };
        }
        // Thêm đơn hàng và chi tiết đơn hàng
        public bool ThemDonHangVaChiTiet(DTO_DonHang donHang, BindingList<DTO_ChiTietDonHang> chiTietDonHangs, out string maDH)
        {
            if (string.IsNullOrEmpty(donHang.MaNV))
                throw new ArgumentException("Mã người dùng không được để trống");           

            return _donHangDAL.ThemDonHangVaChiTiet(donHang, chiTietDonHangs, out maDH);
        }
        // Lấy mã đơn hàng tiếp theo(dùng để tạo mã đơn hàng mới, đảm bảo không trùng lặp)
        public string GetNextMaDH()
        {
            return _donHangDAL.GetNextMaDH();
        }
        // Cập nhật số lượng tồn kho sau khi tạo đơn hàng có mã là maDH
        public void CapNhatSoLuongTonKho(string maDH)
        {

            _donHangDAL.CapNhatSoLuongTonKho(maDH);
        }
        // Lấy tổng số đơn hàng đã được tạo trong hệ thống
        public int GetTongDH()
        {
            return _donHangDAL.GetTongDH();
        }
        // Lấy tổng doanh thu trong ngày được truyền vào
        public decimal GetTongDoanhThu(DateTime ngay)
        {
            return _donHangDAL.GetTongDoanhThu(ngay);
        }
        // Lấy doanh thu của từng tháng trong một năm, trả về Dictionary với:
        // Key = số tháng (1–12), Value = tổng doanh thu tháng đó
        public Dictionary<int, decimal> GetDoanhThuTheoThang(int nam)
        {          
            return _donHangDAL.GetDoanhThuTheoThang(nam);
        }
    }
}