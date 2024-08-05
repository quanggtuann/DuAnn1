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
            HoaDons = new HashSet<HoaDon>();
        }

        public int IdSanpham { get; set; }
        public string? Ten { get; set; }
        public string? ThuongHieu { get; set; }
        public string? BoNhoRam { get; set; }
        public string? Ocung { get; set; }
        public string? CardDoHoa { get; set; }
        public string? HeDieuHanh { get; set; }
        public decimal? GiaBan { get; set; }
        public int? Soluong { get; set; }
        public int? IdChuot { get; set; }
        public int? IdBanphim { get; set; }
        public int? IdXac { get; set; }
        public int? IdTainghe { get; set; }

        public virtual BanPhim? IdBanphimNavigation { get; set; }
        public virtual Chuot? IdChuotNavigation { get; set; }
        public virtual Tainghe? IdTaingheNavigation { get; set; }
        public virtual Xac? IdXacNavigation { get; set; }
        public virtual ICollection<DichVu> DichVus { get; set; }
        public virtual ICollection<HangSanXuat> HangSanXuats { get; set; }
        public virtual ICollection<HoaDon> HoaDons { get; set; }
    }
}
