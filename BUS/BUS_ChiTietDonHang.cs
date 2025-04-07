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

        public bool ThemChiTietDonHang(DTO_ChiTietDonHang chiTietDH)
        {
            if (chiTietDH.SoLuong <= 0 || chiTietDH.Gia <= 0)
                return false;

            return chiTietDonHangDAL.ThemChiTietDonHang(chiTietDH);
        }

        public List<DTO_ChiTietDonHang> LayChiTietDonHangTheoMaDH(string maDH)
        {
            return chiTietDonHangDAL.LayChiTietDonHangTheoMaDH(maDH);
        }
        public bool XoaChiTietDonHang(int maCTDH)
        {
            return chiTietDonHangDAL.XoaChiTietDonHang(maCTDH);
        }

        public decimal TinhTongTien(List<DTO_ChiTietDonHang> danhSachChiTiet)
        {
            decimal tongTien = 0;
            foreach (var chiTiet in danhSachChiTiet)
            {
                tongTien += chiTiet.ThanhTien;
            }
            return tongTien;
        }

        public int TinhTongSoLuong(List<DTO_ChiTietDonHang> danhSachChiTiet)
        {
            int tongSoLuong = 0;
            foreach (var chiTiet in danhSachChiTiet)
            {
                tongSoLuong += chiTiet.SoLuong;
            }
            return tongSoLuong;
        }
        public void ThemChiTietDonHang(BindingList<DTO_ChiTietDonHang> chiTietDonHangs, DTO_ThucDon mon, int soLuong)
        {
            var chiTiet = new DTO_ChiTietDonHang
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
        public bool XoaChiTietDonHang(BindingList<DTO_ChiTietDonHang> chiTietDonHangs, string maMon, out decimal tongTienMoi)
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
        public List<DTO_ChiTietDonHang> GetTop3MonBanChay()
        {
            DAL_ChiTietDonHang dal = new DAL_ChiTietDonHang();
            return dal.GetTop3MonBanChay();
        }
    }
}