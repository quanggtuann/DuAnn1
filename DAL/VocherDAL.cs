using DTO.Models;

namespace DAL
{
    public class VocherDAL
    {
        private readonly Duan1Context _context;

        public VocherDAL()
        {
            _context = new Duan1Context();
        }

        public List<MaGiamGium> Getlist()
        {
            return _context.MaGiamGia.ToList();
        }

        public void GetThem(MaGiamGium vocher)
        {
            _context.MaGiamGia.Add(vocher);
            _context.SaveChanges();
        }

        public List<MaGiamGium> Getlist(string name)
        {
            return _context.MaGiamGia.Where(nv => nv.GiamGia.Contains(name)).ToList();
        }

        public List<MaGiamGium> Getlistid(int id)
        {
            return _context.MaGiamGia.Where(nv => nv.IdMaGiamGia == id).ToList();
        }

        public void GetSua(MaGiamGium vocher)
        {
            var vochers = _context.MaGiamGia.Find(vocher.IdMaGiamGia);
            if (vochers != null)
            {
                vochers.GiamGia = vocher.GiamGia;
                vochers.PhamTramGiam = vocher.PhamTramGiam;
                vochers.HieuLucTu = vocher.HieuLucDen;
                vochers.GiaTriDonHangToiThieu = vocher.GiaTriDonHangToiThieu;
                vochers.PhamViSuDung = vocher.PhamViSuDung;

                _context.SaveChanges();
            }
        }

        public void GetXoa(int id)
        {
            var vocher = _context.MaGiamGia.Find(id);
            if (vocher != null)
            {
                _context.MaGiamGia.Remove(vocher);
                _context.SaveChanges();
            }
        }
    }
}