using System;
using System.Collections.Generic;

namespace DTO.Models
{
    public partial class HangSanXuat
    {
        public int IdHangSanXuat { get; set; }
        public int IdSanPham { get; set; }
        public string? TenHangSanXuat { get; set; }
        public string? DiaChi { get; set; }
        public string? Sdt { get; set; }
        public string? Email { get; set; }
        public string? WebSite { get; set; }
        public string? NguoiLienHe { get; set; }
        public string? DanhSachSanPham { get; set; }
        public DateTime? NgayHopTac { get; set; }
        public string? GhiChu { get; set; }

        public virtual Sanpham IdSanPhamNavigation { get; set; } = null!;
    }
}
