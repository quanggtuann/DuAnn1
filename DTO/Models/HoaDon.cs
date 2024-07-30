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

        public string IdHoaDon { get; set; } = null!;
        public string IdNhanVien { get; set; } = null!;
        public string IdKhachHang { get; set; } = null!;
        public string IdMaGiamGia { get; set; } = null!;
        public string? TrangThai { get; set; }
        public DateTime? NgayTao { get; set; }
        public decimal? ThanhTien { get; set; }
        public string? GhiChu { get; set; }

        public virtual KhachHang IdKhachHangNavigation { get; set; } = null!;
        public virtual MaGiamGium IdMaGiamGiaNavigation { get; set; } = null!;
        public virtual NhanVien IdNhanVienNavigation { get; set; } = null!;
        public virtual ICollection<HoaDonChiTiet> HoaDonChiTiets { get; set; }
    }
}
