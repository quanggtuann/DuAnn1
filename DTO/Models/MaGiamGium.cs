using System;
using System.Collections.Generic;

namespace DTO.Models
{
    public partial class MaGiamGium
    {
        public MaGiamGium()
        {
            HoaDons = new HashSet<HoaDon>();
        }

        public string IdMaGiamGia { get; set; } = null!;
        public string? GiamGia { get; set; }
        public int? PhamTramGiam { get; set; }
        public DateTime? HieuLucTu { get; set; }
        public DateTime? HieuLucDen { get; set; }
        public double? GiaTriDonHangToiThieu { get; set; }
        public string? PhamViSuDung { get; set; }

        public virtual ICollection<HoaDon> HoaDons { get; set; }
    }
}
