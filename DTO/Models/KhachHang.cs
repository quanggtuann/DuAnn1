namespace DTO.Models
{
    public partial class KhachHang
    {
        public KhachHang()
        {
            HoaDons = new HashSet<HoaDon>();
        }

        public int IdKhachHang { get; set; }
        public string? HoTen { get; set; }
        public string? Email { get; set; }
        public string? Sdt { get; set; }
        public string? DiaChi { get; set; }
        public string? ThanhPho { get; set; }
        public string? QuocGia { get; set; }
        public DateTime? NgayDangKi { get; set; }
        public string? GhiChu { get; set; }

        public virtual ICollection<HoaDon> HoaDons { get; set; }
    }
}