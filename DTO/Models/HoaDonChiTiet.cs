namespace DTO.Models
{
    public partial class HoaDonChiTiet
    {
        public HoaDonChiTiet()
        {
            HoaDons = new HashSet<HoaDon>();
        }

        public int IdChiTiet { get; set; }
        public int IdMaGiamGia { get; set; }
        public int? SoLuongSanPham { get; set; }
        public decimal? GiaBan { get; set; }
        public decimal? ThanhTien { get; set; }
        public string? PhuongThucThanhToan { get; set; }
        public string? TrangThai { get; set; }
        public string? GhiChu { get; set; }

        public virtual MaGiamGium IdMaGiamGiaNavigation { get; set; } = null!;
        public virtual ICollection<HoaDon> HoaDons { get; set; }
    }
}