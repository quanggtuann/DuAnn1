namespace DTO.Models
{
    public partial class Tainghe
    {
        public Tainghe()
        {
            Sanphams = new HashSet<Sanpham>();
        }

        public int IdTainghe { get; set; }
        public string? TenTaiNghe { get; set; }
        public string? LoaiKetnoi { get; set; }
        public string? Loaitainghe { get; set; }

        public virtual ICollection<Sanpham> Sanphams { get; set; }
    }
}