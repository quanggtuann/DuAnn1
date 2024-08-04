using DTO.Models;

namespace DAL
{
    public class DichvuDAL
    {
        private readonly Duan1Context _context;

        public DichvuDAL()
        {
            _context = new Duan1Context();
        }

        public List<int> GetListSanPhamIds()
        {
            return _context.Sanphams.Select(sp => sp.IdSanpham).ToList();
        }

        public List<DichVu> Getlist()
        {
            return _context.DichVus.ToList();
        }

        public void GetThem(DichVu dichVu)
        {
            _context.DichVus.Add(dichVu);
            _context.SaveChanges();
        }

        public List<DichVu> Getlist(string name)
        {
            return _context.DichVus.Where(nv => nv.TenDichVu.Contains(name)).ToList();
        }

        public List<DichVu> Getlistid(int id)
        {
            return _context.DichVus.Where(nv => nv.IdDichVu == id).ToList();
        }

        public void GetSua(DichVu dichVus)
        {
            var dichvu = _context.DichVus.Find(dichVus.IdDichVu);
            if (dichvu != null)
            {
                dichvu.TenDichVu = dichVus.TenDichVu;
                dichvu.MoTa = dichVus.MoTa;
                dichvu.LoaiDichVu = dichVus.LoaiDichVu;
                dichvu.GiaDichVu = dichVus.GiaDichVu;
                dichvu.ThoiGianThucHien = dichVus.ThoiGianThucHien;
                dichvu.NgayBatDauCungCap = dichVus.NgayBatDauCungCap;
                dichvu.NgayKetThucCungCap = dichVus.NgayKetThucCungCap;

                _context.SaveChanges();
            }
        }

        public void GetXoa(int id)
        {
            var dichvu = _context.DichVus.Find(id);
            if (dichvu != null)
            {
                _context.DichVus.Remove(dichvu);
                _context.SaveChanges();
            }
        }

        public string GetSanPhamNameById(int idSanPham)
        {
            var sanPham = _context.Sanphams.Find(idSanPham);
            return sanPham != null ? sanPham.Ten : "Không tìm thấy";
        }
    }
}