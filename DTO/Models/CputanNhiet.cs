using System;
using System.Collections.Generic;

namespace DTO.Models
{
    public partial class CputanNhiet
    {
        public CputanNhiet()
        {
            Sanphams = new HashSet<Sanpham>();
        }

        public string IdCputanNhiet { get; set; } = null!;
        public string? Ten { get; set; }
        public string? Hang { get; set; }
        public string? LoaiTanNhiet { get; set; }
        public int? TanNhietCpu { get; set; }
        public int? LuongTdp { get; set; }
        public double? DienApKhoiDong { get; set; }
        public string? DienApHoatDong { get; set; }
        public double? LuongKhiThongVao { get; set; }
        public string? Socket { get; set; }
        public string? LoaiBearing { get; set; }
        public string? LxWxH { get; set; }
        public int? BaoNhieuQuat { get; set; }
        public int? SoLuong { get; set; }
        public DateTime? NgayRaMat { get; set; }
        public int? Gia { get; set; }
        public string? BaoHanh { get; set; }

        public virtual ICollection<Sanpham> Sanphams { get; set; }
    }
}
