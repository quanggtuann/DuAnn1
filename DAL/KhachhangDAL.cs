using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class KhachhangDAL
    {
        Duan1Context context = new Duan1Context();
        public List<KhachHang> Getlist()
        {
            var khachhang = context.KhachHangs.ToList();
            return khachhang;
        }

        public void GetThemkh(KhachHang them)
        {
            context.KhachHangs.Add(them);
            context.SaveChanges();

        }
        public List<KhachHang> Getlist(string ten)
        {
            return context.KhachHangs.Where(p => p.HoTen.Contains(ten)).ToList();
        }
        public List<KhachHang> Getlistid(int id)
        {
            return context.KhachHangs.Where(p => p.IdKhachHang == id).ToList();
        }
        public void GetSuakh(KhachHang sua)
        {
            var khachHang = context.KhachHangs.Find(sua.IdKhachHang);
            if (khachHang != null)
            {
                khachHang.IdKhachHang = sua.IdKhachHang;
                khachHang.HoTen = sua.HoTen;
                khachHang.Email = sua.Email;
                khachHang.Sdt = sua.Sdt;
                khachHang.DiaChi = sua.DiaChi;
                khachHang.ThanhPho = sua.ThanhPho;
                khachHang.QuocGia = sua.QuocGia;
                khachHang.NgayDangKi = sua.NgayDangKi;
                khachHang.GhiChu = sua.GhiChu;

                context.SaveChanges();
            }
        }
        public void GetXoa(int xoa)
        {
            var khachHang = context.KhachHangs.Find(xoa);
            if (khachHang != null)
            {
                context.KhachHangs.Remove(khachHang);
                context.SaveChanges();
            }
        }
    }
}
