using System;
using System.Collections.Generic;

namespace DTO.Models
{
    public partial class Igpu
    {
        public Igpu()
        {
            CpuchiTiets = new HashSet<CpuchiTiet>();
        }

        public string IdIgpu { get; set; } = null!;
        public string? TenModel { get; set; }
        public string? LoiIgpu { get; set; }
        public string? TanSoIgpu { get; set; }

        public virtual ICollection<CpuchiTiet> CpuchiTiets { get; set; }
    }
}
