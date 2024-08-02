using DAL;
using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class NhanvienBLL
    {
        NhanVienDAL nhanvienDAL = new NhanVienDAL();

        public List<NhanVien> Getlistnv()
        {
            var nhanViens = nhanvienDAL.Getlist();
            return nhanViens;
        }
        public void CNThem(NhanVien nhanVien)
        {
            nhanvienDAL.GetThem(nhanVien);

        }
        public List<NhanVien> TimKiem(string ten)
        {
            return nhanvienDAL.Getlist(ten);
        }
        public List<NhanVien> TimKiemid(string id)
        {
            if (int.TryParse(id, out int parsedId))
            {
                return nhanvienDAL.Getlistid(parsedId);
            }
            return new List<NhanVien>();
        }


        public void CNsua(NhanVien sua)
        {
            nhanvienDAL.GetSua(sua);
        }
        public void CNXoa(int xoa)
        {
            nhanvienDAL.GetXoa(xoa);
        }
    }
}
