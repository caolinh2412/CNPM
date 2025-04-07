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

        public DataTable LayDanhSachDonHang()
        {
            return _donHangDAL.GetAllDonHangWithTenNV();
        }
        public DTO_DonHang GetDonHangById(string  maDH)
        {
            return _donHangDAL.GetDonHangById(maDH);
        }

        public DTO_DonHang TaoDonHang(string maND)
        {
            if (string.IsNullOrEmpty(maND))
                throw new ArgumentException("Mã người dùng không được để trống");

            return new DTO_DonHang
            {
                NgayDat = DateTime.Now,
                MaND = maND,
                TongTien = 0
            };
        }
        public bool ThemDonHangVaChiTiet(DTO_DonHang donHang, BindingList<DTO_ChiTietDonHang> chiTietDonHangs, out string maDH)
        {
            if (string.IsNullOrEmpty(donHang.MaND))
                throw new ArgumentException("Mã người dùng không được để trống");           

            return _donHangDAL.ThemDonHangVaChiTiet(donHang, chiTietDonHangs, out maDH);
        }
        public string GetNextMaDH()
        {
            return _donHangDAL.GetNextMaDH();
        }
        public void CapNhatSoLuongTonKho(string maDH)
        {

            _donHangDAL.CapNhatSoLuongTonKho(maDH);
        }
        public int GetTongDH()
        {
            return _donHangDAL.GetTongDH();
        }
        public decimal GetTongDoanhThu(DateTime ngay)
        {
            return _donHangDAL.GetTongDoanhThu(ngay);
        }
        public Dictionary<int, decimal> GetDoanhThuTheoThang(int nam)
        {          
            return _donHangDAL.GetDoanhThuTheoThang(nam);
        }
    }
}