using DAL;
using DTO.Models;

namespace BLL
{
    public class DichvuBLL
    {
        private DichvuDAL dichvudal = new DichvuDAL();

        public List<int> GetListSanPhamIds()
        {
            return dichvudal.GetListSanPhamIds();
        }

        public List<DichVu> Getlistdv()
        {
            return dichvudal.Getlist();
        }

        public void CNThem(DichVu dichvu)
        {
            dichvudal.GetThem(dichvu);
        }

        public List<DichVu> TimKiem(string ten)
        {
            return dichvudal.Getlist(ten);
        }

        public List<DichVu> TimKiemid(string id)
        {
            if (int.TryParse(id, out int parsedId))
            {
                return dichvudal.Getlistid(parsedId);
            }
            return new List<DichVu>();
        }

        public void CNsua(DichVu sua)
        {
            dichvudal.GetSua(sua);
        }

        public void CNXoa(int xoa)
        {
            dichvudal.GetXoa(xoa);
        }

        public string GetSanPhamNameById(int idSanPham)
        {
            return dichvudal.GetSanPhamNameById(idSanPham);
        }
    }
}