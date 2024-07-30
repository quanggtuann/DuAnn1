using System;
using System.Collections.Generic;

namespace DTO.Models
{
    public partial class Sanpham
    {
        public Sanpham()
        {
            DichVus = new HashSet<DichVu>();
            HangSanXuats = new HashSet<HangSanXuat>();
            HoaDonChiTiets = new HashSet<HoaDonChiTiet>();
        }

        public string IdSanpham { get; set; } = null!;
        public string IdCpu { get; set; } = null!;
        public string IdGpu { get; set; } = null!;
        public string IdRam { get; set; } = null!;
        public string IdCputanNhiet { get; set; } = null!;
        public string? Ten { get; set; }
        public string? ThuongHieu { get; set; }
        public string? BoNhoRam { get; set; }
        public string? Ochung { get; set; }
        public string? CardDoHoa { get; set; }
        public string? HeDieuHanh { get; set; }
        public decimal? GiaBan { get; set; }
        public int? Soluong { get; set; }

        public virtual CpuchiTiet IdCpuNavigation { get; set; } = null!;
        public virtual CputanNhiet IdCputanNhietNavigation { get; set; } = null!;
        public virtual Gpu IdGpuNavigation { get; set; } = null!;
        public virtual Ram IdRamNavigation { get; set; } = null!;
        public virtual ICollection<DichVu> DichVus { get; set; }
        public virtual ICollection<HangSanXuat> HangSanXuats { get; set; }
        public virtual ICollection<HoaDonChiTiet> HoaDonChiTiets { get; set; }
    }
}
