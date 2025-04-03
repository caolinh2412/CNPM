using System;
using System.Collections.Generic;
using DTO;
using DAL;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace CoffeeShopManagementSystem.BUS
{
    public class DonHang_BUS
    {
        private readonly DonHang_DAL _donHangDAL;

        public DonHang_BUS()
        {
            _donHangDAL = new DonHang_DAL();
        }

        public DataTable LayDanhSachDonHang()
        {
            return _donHangDAL.GetAllDonHangWithTenNV();
        }
        public DonHangDTO GetDonHangById(string  maDH)
        {
            return _donHangDAL.GetDonHangById(maDH);
        }

        public DonHangDTO TaoDonHang(string maND)
        {
            if (string.IsNullOrEmpty(maND))
                throw new ArgumentException("Mã người dùng không được để trống");

            return new DonHangDTO
            {
                NgayDat = DateTime.Now,
                MaND = maND,
                TongTien = 0
            };
        }
        public bool ThemDonHangVaChiTiet(DonHangDTO donHang, BindingList<ChiTietDonHang_DTO> chiTietDonHangs, out string maDH)
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
    }
}