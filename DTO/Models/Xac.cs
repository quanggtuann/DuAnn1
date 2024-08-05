using System;
using System.Collections.Generic;

namespace DTO.Models
{
    public partial class Xac
    {
        public Xac()
        {
            Sanphams = new HashSet<Sanpham>();
        }

        public int IdXac { get; set; }
        public string? Tenxac { get; set; }
        public string? Congxac { get; set; }
        public int? CongXuat { get; set; }

        public virtual ICollection<Sanpham> Sanphams { get; set; }
    }
}
