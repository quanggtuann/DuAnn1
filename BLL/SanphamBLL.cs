using DAL;
using DTO.Models;

namespace BLL
{
    public class SanphamBLL
    {
        private SanPhamDAL sanphamdal = new SanPhamDAL();

        public List<Sanpham> Getlistsp()
        {
            var sanpham = sanphamdal.Getlist();
            return sanpham;
        }

        public void CNThem(Sanpham customer)
        {
            sanphamdal.GetThemsp(customer);
        }

        public List<Sanpham> TimKiem(string ten)
        {
            return sanphamdal.Getlist(ten);
        }

        public List<Sanpham> TimKiemid(string id)
        {
            if (int.TryParse(id, out int parsedId))
            {
                return sanphamdal.Getlistid(parsedId);
            }
            return new List<Sanpham>();
        }

        public void CNsua(Sanpham sua)
        {
            sanphamdal.GetSuasp(sua);
        }

        public void CNXoa(int xoa)
        {
            sanphamdal.GetXoasp(xoa);
        }
    }
}