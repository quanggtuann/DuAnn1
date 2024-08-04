using DAL;
using DTO.Models;

namespace BLL
{
    public class VocherBLL
    {
        private VocherDAL vocherdal = new VocherDAL();

        public List<MaGiamGium> Getlistvc()
        {
            var vocher = vocherdal.Getlist();
            return vocher;
        }

        public void CNThem(MaGiamGium vocher)
        {
            vocherdal.GetThem(vocher);
        }

        public List<MaGiamGium> TimKiem(string ten)
        {
            return vocherdal.Getlist(ten);
        }

        public List<MaGiamGium> TimKiemid(string id)
        {
            if (int.TryParse(id, out int parsedId))
            {
                return vocherdal.Getlistid(parsedId);
            }
            return new List<MaGiamGium>();
        }

        public void CNsua(MaGiamGium sua)
        {
            vocherdal.GetSua(sua);
        }

        public void CNXoa(int xoa)
        {
            vocherdal.GetXoa(xoa);
        }
    }
}