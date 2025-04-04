using System;
using System.Collections.Generic;
using System.ComponentModel;
using DAL;
using DTO;

namespace BUS
{
    public class ChiTietDonHang_BUS
    {
        private ChiTietDonHang_DAL chiTietDonHangDAL;

        public ChiTietDonHang_BUS()
        {
            chiTietDonHangDAL = new ChiTietDonHang_DAL();
        }

        public bool ThemChiTietDonHang(ChiTietDonHang_DTO chiTietDH)
        {
            if (chiTietDH.SoLuong <= 0 || chiTietDH.Gia <= 0)
                return false;

            return chiTietDonHangDAL.ThemChiTietDonHang(chiTietDH);
        }

        public List<ChiTietDonHang_DTO> LayChiTietDonHangTheoMaDH(string maDH)
        {
            return chiTietDonHangDAL.LayChiTietDonHangTheoMaDH(maDH);
        }
        public bool XoaChiTietDonHang(int maCTDH)
        {
            return chiTietDonHangDAL.XoaChiTietDonHang(maCTDH);
        }

        public decimal TinhTongTien(List<ChiTietDonHang_DTO> danhSachChiTiet)
        {
            decimal tongTien = 0;
            foreach (var chiTiet in danhSachChiTiet)
            {
                tongTien += chiTiet.ThanhTien;
            }
            return tongTien;
        }

        public int TinhTongSoLuong(List<ChiTietDonHang_DTO> danhSachChiTiet)
        {
            int tongSoLuong = 0;
            foreach (var chiTiet in danhSachChiTiet)
            {
                tongSoLuong += chiTiet.SoLuong;
            }
            return tongSoLuong;
        }
        public void ThemChiTietDonHang(BindingList<ChiTietDonHang_DTO> chiTietDonHangs, ThucDon_DTO mon, int soLuong)
        {
            var chiTiet = new ChiTietDonHang_DTO
            {
                MaMon = mon.MaMon,
                TenMon = mon.TenMon,
                SoLuong = soLuong,
                Gia = mon.Gia,
                ThanhTien = soLuong * mon.Gia
            };

            var existingItem = chiTietDonHangs.FirstOrDefault(x => x.MaMon == chiTiet.MaMon);
            if (existingItem != null)
            {
                existingItem.SoLuong += soLuong;
                existingItem.ThanhTien = existingItem.SoLuong * existingItem.Gia;
            }
            else
            {
                chiTietDonHangs.Add(chiTiet);
            }
        }
        public bool XoaChiTietDonHang(BindingList<ChiTietDonHang_DTO> chiTietDonHangs, string maMon, out decimal tongTienMoi)
        {
            var itemToRemove = chiTietDonHangs.FirstOrDefault(x => x.MaMon == maMon);
            if (itemToRemove != null)
            {
                chiTietDonHangs.Remove(itemToRemove);
                tongTienMoi = chiTietDonHangs.Sum(x => x.ThanhTien);
                return true;
            }
            tongTienMoi = chiTietDonHangs.Sum(x => x.ThanhTien); 
            return false;
        }
        public List<ChiTietDonHang_DTO> GetTop3MonBanChay()
        {
            ChiTietDonHang_DAL dal = new ChiTietDonHang_DAL();
            return dal.GetTop3MonBanChay();
        }
    }
}