using DAL;
using DTO.Models;

namespace BLL
{
    public class HoaDonBLL
    {
        private HoaDonDAL HoaDon = new HoaDonDAL();

        public List<int> GetListSanPhamIds()
        {
            return HoaDon.GetListSanPhamIds();
        }

        public List<HoaDon> GetlistHoadon()
        {
            return HoaDon.Getlist();
        }

        public void CNThem(HoaDon hoaDon)
        {
            HoaDon.GetThem(hoaDon);
        }

        public List<HoaDon> TimKiemid(string id)
        {
            if (int.TryParse(id, out int parsedId))
            {
                return HoaDon.Getlistid(parsedId);
            }
            return new List<HoaDon>();
        }

        public void CNsua(HoaDon sua)
        {
            HoaDon.GetSua(sua);
        }

        public void CNXoa(int xoa)
        {
            HoaDon.GetXoa(xoa);
        }

        public string GetSanPhamNameById(int idSanPham)
        {
            return HoaDon.GetSanPhamNameById(idSanPham);
        }
    }
}