using System;
using System.Collections.Generic;

namespace DTO.Models
{
    public partial class Gpu
    {
        public Gpu()
        {
            Sanphams = new HashSet<Sanpham>();
        }

        public string IdGpu { get; set; } = null!;
        public string? Ten { get; set; }
        public string? ChipDoHoa { get; set; }
        public string? Loi { get; set; }
        public string? Tmus { get; set; }
        public string? Rops { get; set; }
        public string? Vram { get; set; }
        public string? LoaiVram { get; set; }
        public string? KichCoBus { get; set; }
        public string? NguonChip { get; set; }
        public string? KichCoChip { get; set; }
        public string? HoTroDx12 { get; set; }
        public string? LuongTdp { get; set; }
        public string? NguonKetNoi { get; set; }
        public string? LoiRt { get; set; }
        public string? L1cache { get; set; }
        public string? L2cache { get; set; }
        public string? LoiTensor { get; set; }
        public string? KichCoGpu { get; set; }
        public string? CongKetNoi { get; set; }
        public DateTime? NgayRaMat { get; set; }
        public int? SoLuong { get; set; }
        public decimal? Gia { get; set; }

        public virtual ICollection<Sanpham> Sanphams { get; set; }
    }
}
