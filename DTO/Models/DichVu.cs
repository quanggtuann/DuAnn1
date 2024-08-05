using System;
using System.Collections.Generic;

namespace DTO.Models
{
    public partial class DichVu
    {
        public DichVu()
        {
            ChinhSachBaoHanhs = new HashSet<ChinhSachBaoHanh>();
        }

        public int IdDichVu { get; set; }
        public int IdSanPham { get; set; }
        public string? TenDichVu { get; set; }
        public string? MoTa { get; set; }
        public string? LoaiDichVu { get; set; }
        public decimal? GiaDichVu { get; set; }
        public string? ThoiGianThucHien { get; set; }
        public DateTime? NgayBatDauCungCap { get; set; }
        public DateTime? NgayKetThucCungCap { get; set; }
        public string? GhiChu { get; set; }
        public bool? Trangthai { get; set; }

        public virtual Sanpham IdSanPhamNavigation { get; set; } = null!;
        public virtual ICollection<ChinhSachBaoHanh> ChinhSachBaoHanhs { get; set; }
    }
}
