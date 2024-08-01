using DAL;
using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class KhachhangBLL
    {
        KhachhangDAL khachhangdal = new KhachhangDAL();

        public List<KhachHang> Getlistsp()
        {
            var khachHangs = khachhangdal.Getlist();
            return khachHangs;
        }
        public void CNThem(KhachHang khachhang)
        {
            khachhangdal.GetThemkh(khachhang);

        }
        public List<KhachHang> TimKiem(string ten)
        {
            return khachhangdal.Getlist(ten);
        }
        public List<KhachHang> TimKiemid(string id)
        {
            if (int.TryParse(id, out int parsedId))
            {
                return khachhangdal.Getlistid(parsedId);
            }
            return new List<KhachHang>();
        }


        public void CNsua(KhachHang sua)
        {
            khachhangdal.GetSuakh(sua);
        }
        public void CNXoa(int xoa)
        {
            khachhangdal.GetXoa(xoa);
        }
    }
}
