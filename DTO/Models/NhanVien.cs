using System;
using System.Collections.Generic;

namespace DTO.Models
{
    public partial class NhanVien
    {
        public NhanVien()
        {
            HoaDons = new HashSet<HoaDon>();
        }

        public string IdNhanVien { get; set; } = null!;
        public string? HoTen { get; set; }
        public string? ChucVu { get; set; }
        public string? BoPhan { get; set; }
        public DateTime? NgayBatDauLam { get; set; }
        public decimal? MucLuong { get; set; }
        public string? Email { get; set; }
        public string? Sdt { get; set; }
        public string? Cccd { get; set; }

        public virtual ICollection<HoaDon> HoaDons { get; set; }
    }
}
