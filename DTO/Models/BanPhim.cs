namespace DTO.Models
{
    public partial class BanPhim
    {
        public BanPhim()
        {
            Sanphams = new HashSet<Sanpham>();
        }

        public int IdBanphim { get; set; }
        public string? TenBanPhim { get; set; }
        public string? Loaiketnoi { get; set; }

        public virtual ICollection<Sanpham> Sanphams { get; set; }
    }
}