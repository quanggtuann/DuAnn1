using System;
using System.Collections.Generic;

namespace DTO.Models
{
    public partial class ThongTinLienHe
    {
        public string IdLienHe { get; set; } = null!;
        public string IdBaoHanh { get; set; } = null!;
        public int? Sdt { get; set; }
        public string? Email { get; set; }
        public string? DiaChi { get; set; }
        public string? GhiChu { get; set; }

        public virtual ChinhSachBaoHanh IdBaoHanhNavigation { get; set; } = null!;
    }
}
