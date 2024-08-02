using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class NhanVienDAL
    {
        private readonly Duan1Context _context;

        public NhanVienDAL()
        {
            _context = new Duan1Context();
        }

        public List<NhanVien> Getlist()
        {
            return _context.NhanViens.Where(nv => nv.Trangthai == true).ToList();
        }

        public void GetThem(NhanVien nhanVien)
        {
            _context.NhanViens.Add(nhanVien);
            _context.SaveChanges();
        }

        public List<NhanVien> Getlist(string name)
        {
            return _context.NhanViens.Where(nv => nv.HoTen.Contains(name)).ToList();
        }

        public List<NhanVien> Getlistid(int id)
        {
            return _context.NhanViens.Where(nv => nv.IdNhanVien == id).ToList();
        }

        public void GetSua(NhanVien nhanVien)
        {
            var existingNhanVien = _context.NhanViens.Find(nhanVien.IdNhanVien);
            if (existingNhanVien != null)
            {
                existingNhanVien.HoTen = nhanVien.HoTen;
                existingNhanVien.ChucVu = nhanVien.ChucVu;
                existingNhanVien.NgayBatDauLam = nhanVien.NgayBatDauLam;
                existingNhanVien.MucLuong = nhanVien.MucLuong;
                existingNhanVien.Email = nhanVien.Email;
                existingNhanVien.Sdt = nhanVien.Sdt;
                existingNhanVien.Cccd = nhanVien.Cccd;
                existingNhanVien.Gioitinh= nhanVien.Gioitinh;
                existingNhanVien.Trangthai= nhanVien.Trangthai;
                _context.SaveChanges();
            }
        }

        public void GetXoa(int id)
        {
            var nhanVien = _context.NhanViens.Find(id);
            if (nhanVien != null)
            {
                _context.NhanViens.Remove(nhanVien);
                _context.SaveChanges();
            }
        }
        public List<NhanVien> GetNhanVienNghiViec()
        {
            return _context.NhanViens.Where(nv => nv.Trangthai == false).ToList();
        }
    }
}
