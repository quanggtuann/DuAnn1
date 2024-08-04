namespace DTO.Models
{
    public partial class MaGiamGium
    {
        public MaGiamGium()
        {
            HoaDonChiTiets = new HashSet<HoaDonChiTiet>();
        }

        public int IdMaGiamGia { get; set; }
        public string? GiamGia { get; set; }
        public int? PhamTramGiam { get; set; }
        public DateTime? HieuLucTu { get; set; }
        public DateTime? HieuLucDen { get; set; }
        public double? GiaTriDonHangToiThieu { get; set; }
        public string? PhamViSuDung { get; set; }

        public virtual ICollection<HoaDonChiTiet> HoaDonChiTiets { get; set; }
    }
}