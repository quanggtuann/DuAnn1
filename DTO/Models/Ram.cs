using System;
using System.Collections.Generic;

namespace DTO.Models
{
    public partial class Ram
    {
        public Ram()
        {
            Sanphams = new HashSet<Sanpham>();
        }

        public string IdRam { get; set; } = null!;
        public string? Ten { get; set; }
        public string? LoaiRam { get; set; }
        public int? DungLuong { get; set; }
        public int? TocDo { get; set; }
        public int? DoTre { get; set; }
        public int? HieuDienThe { get; set; }
        public string? HoTroEec { get; set; }
        public string? DongGoi { get; set; }
        public string? Mau { get; set; }
        public string? TanNhiet { get; set; }
        public int? SoLuong { get; set; }
        public decimal? Gia { get; set; }
        public string? BaoHanh { get; set; }

        public virtual ICollection<Sanpham> Sanphams { get; set; }
    }
}
