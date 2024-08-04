using BLL;
using System.Data;

namespace DuAnn1
{
    public partial class nhanviennghi : System.Windows.Forms.Form
    {
        public nhanviennghi()
        {
            InitializeComponent();
        }

        public void dgvnhanviennghi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private NhanvienBLL NhanvienBLL = new NhanvienBLL();
        private DataTable dtnv = new DataTable();

        private void Getloadbangnv()
        {
            dtnv.Columns.Clear();
            dtnv.Columns.Add("ID Nhân Viên", typeof(int));
            dtnv.Columns.Add("Họ Tên", typeof(string));
            dtnv.Columns.Add("Chức Vụ", typeof(string));
            dtnv.Columns.Add("Giới Tính", typeof(bool));
            dtnv.Columns.Add("Ngày Bắt Đầu Làm", typeof(DateTime));
            dtnv.Columns.Add("Mức Lương", typeof(decimal));
            dtnv.Columns.Add("Email", typeof(string));
            dtnv.Columns.Add("Số Điện Thoại", typeof(string));
            dtnv.Columns.Add("Căn Cước Công Nhân", typeof(string));
            dtnv.Columns.Add("Trạng Thái", typeof(bool));
            dgvnhanviennghi.DataSource = dtnv;
        }

        private void GetloadCaiDatnv()
        {
            dtnv.Rows.Clear();
            var nvs = NhanvienBLL.LayDanhSachNhanVienNghiViec();
            MessageBox.Show($"Số nhân viên nghỉ việc: {nvs.Count}");

            foreach (var nv in nvs)
            {
                DataRow dr = dtnv.NewRow();
                dr["ID Nhân Viên"] = nv.IdNhanVien;
                dr["Họ Tên"] = nv.HoTen;
                dr["Chức Vụ"] = nv.ChucVu;
                dr["Giới Tính"] = nv.Gioitinh;
                dr["Ngày Bắt Đầu Làm"] = nv.NgayBatDauLam;
                dr["Mức Lương"] = nv.MucLuong;
                dr["Email"] = nv.Email;
                dr["Số Điện Thoại"] = nv.Sdt;
                dr["Căn Cước Công Nhân"] = nv.Cccd;
                dr["Trạng Thái"] = nv.Trangthai;
                dtnv.Rows.Add(dr);
            }

            dgvnhanviennghi.Refresh();
        }

        private void nhanviennghi_Load(object sender, EventArgs e)
        {
            Getloadbangnv();
            GetloadCaiDatnv();
        }

        private void btnxoanvnghi_Click(object sender, EventArgs e)
        {
        }

        private void dgvnhanviennghi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}