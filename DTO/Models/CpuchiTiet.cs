using System;
using System.Collections.Generic;

namespace DTO.Models
{
    public partial class CpuchiTiet
    {
        public CpuchiTiet()
        {
            Sanphams = new HashSet<Sanpham>();
        }

        public string IdCpu { get; set; } = null!;
        public string IdIgpu { get; set; } = null!;
        public string? Ten { get; set; }
        public string? GiaDinh { get; set; }
        public string? Dong { get; set; }
        public string? Socket { get; set; }
        public string? Amdpro { get; set; }
        public string? LoaiThietKe { get; set; }
        public string? Loi { get; set; }
        public string? DaLuong { get; set; }
        public string? Luong { get; set; }
        public string? TanSoTurbo { get; set; }
        public string? TanSoCoBan { get; set; }
        public string? L1cache { get; set; }
        public string? L2cache { get; set; }
        public string? L3cache { get; set; }
        public string? LuongTonTdp { get; set; }
        public string? HoTroOverclock { get; set; }
        public string? PrecisionBoost { get; set; }
        public string? BoHuongDan { get; set; }
        public string? NhietDoCpu { get; set; }
        public DateTime? NgayRaMat { get; set; }
        public string? HeThongHoTro { get; set; }
        public int? SoLuong { get; set; }
        public decimal? Gia { get; set; }
        public DateTime? BaoHanh { get; set; }

        public virtual Igpu IdIgpuNavigation { get; set; } = null!;
        public virtual ICollection<Sanpham> Sanphams { get; set; }
    }
}
