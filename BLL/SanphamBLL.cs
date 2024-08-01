using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO.Models;
namespace BLL
{
    public class SanphamBLL
    {
        SanPhamDAL sanphamdal = new SanPhamDAL();

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
