using DTO.Models;

namespace DAL
{
    public class HoaDonDAL
    {
        private readonly Duan1Context _context;

        public HoaDonDAL()
        {
            _context = new Duan1Context();
        }

        public List<int> GetListSanPhamIds()
        {
            return _context.Sanphams.Select(sp => sp.IdSanpham).ToList();
        }

        public List<HoaDon> Getlist()
        {
            return _context.HoaDons.ToList();
        }

        public void GetThem(HoaDon hoadon)
        {
            _context.HoaDons.Add(hoadon);
            _context.SaveChanges();
        }

        public List<HoaDon> Getlistid(int id)
        {
            return _context.HoaDons.Where(nv => nv.IdHoaDon == id).ToList();
        }

        public void GetSua(HoaDon hoaDon)
        {
            var hoadon = _context.HoaDons.Find(hoaDon.IdHoaDon);
            if (hoadon != null)
            {
                hoadon.IdNhanVien = hoaDon.IdNhanVien;
                hoadon.IdKhachHang = hoaDon.IdKhachHang;
                hoadon.IdSanPham = hoaDon.IdSanPham;
                hoadon.IdChiTiet = hoaDon.IdChiTiet;
                hoadon.NgayTao = DateTime.Today;
                hoadon.TrangThai = hoaDon.TrangThai;
                hoadon.ThanhTien = hoaDon.ThanhTien;
                hoadon.GhiChu = hoaDon.GhiChu;

                _context.SaveChanges();
            }
        }

        public void GetXoa(int id)
        {
            var hoadon = _context.HoaDons.Find(id);
            if (hoadon != null)
            {
                _context.HoaDons.Remove(hoadon);
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