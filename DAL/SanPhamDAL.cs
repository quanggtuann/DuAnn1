﻿using DTO.Models;

namespace DAL
{
    public class SanPhamDAL
    {
        private Duan1Context context = new Duan1Context();

        public List<Sanpham> Getlist()
        {
            var sanpham = context.Sanphams.ToList();
            return sanpham;
        }

        public void GetThemsp(Sanpham them)
        {
            context.Sanphams.Add(them);
            context.SaveChanges();
        }

        public List<Sanpham> Getlist(string ten)
        {
            return context.Sanphams.Where(p => p.Ten.Contains(ten)).ToList();
        }

        public List<Sanpham> Getlistid(int id)
        {
            return context.Sanphams.Where(p => p.IdSanpham == id).ToList();
        }

        public void GetSuasp(Sanpham sua)
        {
            var sanpham = context.Sanphams.Find(sua.IdSanpham);
            if (sanpham != null)
            {
                sanpham.IdSanpham = sua.IdSanpham;
                sanpham.Ten = sua.Ten;
                sanpham.ThuongHieu = sua.ThuongHieu;
                sanpham.BoNhoRam = sua.BoNhoRam;
                sanpham.Ocung = sua.Ocung;
                sanpham.CardDoHoa = sua.CardDoHoa;
                sanpham.HeDieuHanh = sua.HeDieuHanh;
                sanpham.GiaBan = sua.GiaBan;
                sanpham.Soluong = sua.Soluong;

                context.SaveChanges();
            }
        }

        public void GetXoasp(int xoa)
        {
            try
            {
                var sanpham = context.Sanphams.Find(xoa);

                if (sanpham != null)
                {
                    context.Sanphams.Remove(sanpham);
                    context.SaveChanges();
                    Console.WriteLine("Sản phẩm đã được xóa thành công.");
                }
                else
                {
                    Console.WriteLine("Sản phẩm không tồn tại.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi xóa sản phẩm: {ex.Message}");
            }
        }
    }
}