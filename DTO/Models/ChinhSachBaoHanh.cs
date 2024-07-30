using System;
using System.Collections.Generic;

namespace DTO.Models
{
    public partial class ChinhSachBaoHanh
    {
        public ChinhSachBaoHanh()
        {
            ThongTinLienHes = new HashSet<ThongTinLienHe>();
        }

        public string IdBaoHanh { get; set; } = null!;
        public string IdDichVu { get; set; } = null!;
        public DateTime? NgayBatDau { get; set; }
        public DateTime? NgayKetThuc { get; set; }
        public string? ThoiGianBaoHanh { get; set; }
        public string? DieuKienBaoHanh { get; set; }
        public string? DieuKienTuChoiBaoHanh { get; set; }
        public int? ThongTinLienHe { get; set; }
        public string? GhiChu { get; set; }

        public virtual DichVu IdDichVuNavigation { get; set; } = null!;
        public virtual ICollection<ThongTinLienHe> ThongTinLienHes { get; set; }
    }
}
