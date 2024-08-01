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

        public int IdNhanVien { get; set; }
        public string? HoTen { get; set; }
        public string? ChucVu { get; set; }
        public DateTime? NgayBatDauLam { get; set; }
        public decimal? MucLuong { get; set; }
        public string? Email { get; set; }
        public string? Sdt { get; set; }
        public string? Cccd { get; set; }
        public bool? Gioitinh { get; set; }
        public bool? Trangthai { get; set; }

        public virtual ICollection<HoaDon> HoaDons { get; set; }
    }
}
