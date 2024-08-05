using System;
using System.Collections.Generic;

namespace DTO.Models
{
    public partial class HoaDonChiTiet
    {
        public int IdChiTiet { get; set; }
        public int IdHoaDon { get; set; }
        public int IdMaGiamGia { get; set; }
        public int? SoLuongSanPham { get; set; }
        public decimal? GiaBan { get; set; }
        public decimal? ThanhTien { get; set; }
        public string? PhuongThucThanhToan { get; set; }
        public bool? TrangThai { get; set; }
        public string? GhiChu { get; set; }

        public virtual HoaDon IdHoaDonNavigation { get; set; } = null!;
        public virtual MaGiamGium IdMaGiamGiaNavigation { get; set; } = null!;
    }
}
