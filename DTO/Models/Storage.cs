using System;
using System.Collections.Generic;

namespace DTO.Models
{
    public partial class Storage
    {
        public string IdStorage { get; set; } = null!;
        public string IdHangSanXuat { get; set; } = null!;
        public string? TenBoNho { get; set; }
        public string? LoaiBoNho { get; set; }
        public string? DungLuong { get; set; }
        public string? GiaoDien { get; set; }
        public string? Hang { get; set; }
        public string? TocDoDoc { get; set; }
        public string? TocDoGhi { get; set; }
        public string? HoTroTanNhiet { get; set; }
        public string? KieuFlash { get; set; }
        public DateTime? NgayRaMat { get; set; }
        public int? Gia { get; set; }
        public int? SoLuong { get; set; }
        public DateTime? BaoHanh { get; set; }

        public virtual HangSanXuat IdHangSanXuatNavigation { get; set; } = null!;
    }
}
