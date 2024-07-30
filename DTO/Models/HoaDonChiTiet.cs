using System;
using System.Collections.Generic;

namespace DTO.Models
{
    public partial class HoaDonChiTiet
    {
        public string IdChiTiet { get; set; } = null!;
        public string IdHoaDon { get; set; } = null!;
        public string IdSanPham { get; set; } = null!;
        public int? SoLuongSanPham { get; set; }
        public decimal? GiaBan { get; set; }
        public decimal? ThanhTien { get; set; }
        public string? PhuongThucThanhToan { get; set; }
        public string? TrangThai { get; set; }
        public string? GhiChu { get; set; }

        public virtual HoaDon IdHoaDonNavigation { get; set; } = null!;
        public virtual Sanpham IdSanPhamNavigation { get; set; } = null!;
    }
}
