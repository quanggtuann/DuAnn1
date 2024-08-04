namespace DTO.Models
{
    public partial class ThongTinLienHe
    {
        public int IdLienHe { get; set; }
        public int IdBaoHanh { get; set; }
        public string? Sdt { get; set; }
        public string? Email { get; set; }
        public string? DiaChi { get; set; }
        public string? GhiChu { get; set; }

        public virtual ChinhSachBaoHanh IdBaoHanhNavigation { get; set; } = null!;
    }
}