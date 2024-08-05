using System;
using System.Collections.Generic;

namespace DTO.Models
{
    public partial class HoaDon
    {
        public HoaDon()
        {
            HoaDonChiTiets = new HashSet<HoaDonChiTiet>();
        }

        public int IdHoaDon { get; set; }
        public int IdSanPham { get; set; }
        public int IdNhanVien { get; set; }
        public int IdKhachHang { get; set; }
        public bool? TrangThai { get; set; }
        public DateTime? NgayTao { get; set; }
        public decimal? ThanhTien { get; set; }
        public string? GhiChu { get; set; }

        public virtual KhachHang IdKhachHangNavigation { get; set; } = null!;
        public virtual NhanVien IdNhanVienNavigation { get; set; } = null!;
        public virtual Sanpham IdSanPhamNavigation { get; set; } = null!;
        public virtual ICollection<HoaDonChiTiet> HoaDonChiTiets { get; set; }
    }
}
