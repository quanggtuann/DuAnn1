namespace DTO.Models
{
    public partial class Chuot
    {
        public Chuot()
        {
            Sanphams = new HashSet<Sanpham>();
        }

        public int IdChuot { get; set; }
        public string? Tenchuot { get; set; }
        public int? Dpi { get; set; }
        public string? Loaiketnoi { get; set; }

        public virtual ICollection<Sanpham> Sanphams { get; set; }
    }
}