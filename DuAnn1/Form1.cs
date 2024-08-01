﻿using BLL;
using DAL;
using DTO.Models;
using Microsoft.VisualBasic.Devices;
using System.Data;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using System.Runtime.InteropServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DuAnn1
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            MouseDown += new MouseEventHandler(Form1_MouseDown);

        }
        private void Close_Click(object sender, EventArgs e)
        {
            loginForm login = new loginForm();
            Close();
            login.Show();
        }

        private void Minimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        SanphamBLL sanphamBLL = new SanphamBLL();
        DataTable dt = new DataTable();
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnshow_Click(object sender, EventArgs e)
        {
            Getloadbang();
            Getcaidat();
        }
        public void Getloadbang()
        {
            dt.Columns.Add("Id", typeof(string));
            dt.Columns.Add("Tên Sản Phẩm", typeof(string));
            dt.Columns.Add("Thương Hiệu", typeof(string));
            dt.Columns.Add("Bộ Nhớ ram", typeof(string));
            dt.Columns.Add("Ổ Cứng", typeof(string));
            dt.Columns.Add("Card Đồ Họa", typeof(string));
            dt.Columns.Add("Hệ Điều Hành", typeof(string));
            dt.Columns.Add("Giá Bán", typeof(decimal));
            dt.Columns.Add("Số Lượng", typeof(int));
            dgvsanpham.DataSource = dt;
        }
        public void Getcaidat()
        {
            dt.Rows.Clear();

            foreach (var product in sanphamBLL.Getlistsp())
            {
                DataRow dr = dt.NewRow();
                dr["ID"] = product.IdSanpham;
                dr["Tên Sản Phẩm"] = product.Ten;
                dr["Thương Hiệu"] = product.ThuongHieu;
                dr["Bộ Nhớ ram"] = product.BoNhoRam;
                dr["Ổ Cứng"] = product.Ocung;
                dr["Card Đồ Họa"] = product.CardDoHoa;
                dr["Hệ Điều Hành"] = product.HeDieuHanh;
                dr["Giá Bán"] = product.GiaBan;
                dr["Số Lượng"] = product.Soluong;

                dt.Rows.Add(dr);
            }
        }


        private void btnadd_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("bạn chắc chắn muốn thêm", "Thêm sản phẩm", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                DialogResult tb = MessageBox.Show("thêm thành công", "", MessageBoxButtons.OK);
                var ten = txtten.Text;
                var thuonghieu = txtthuonghieu.Text;
                var bonho = txtbonho.Text;
                var ocung = txtocung.Text;
                var dohoa = txtcardohoa.Text;
                var hedieuhanh = txthedieuhanh.Text;
                var giaban = Convert.ToDecimal(txtgiaban.Text);
                var soluong = Convert.ToInt32(txtsoluong.Text);

                var dangthem = new Sanpham();
                dangthem.Ten = ten;
                dangthem.ThuongHieu = thuonghieu;
                dangthem.BoNhoRam = bonho;
                dangthem.Ocung = ocung;
                dangthem.CardDoHoa = dohoa;
                dangthem.HeDieuHanh = hedieuhanh;
                dangthem.GiaBan = giaban;
                dangthem.Soluong = soluong;
                sanphamBLL.CNThem(dangthem);
                Getcaidat();
            }

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void ShowPanel(Control panelToShow)
        {

            sanpham.Visible = false;
            hoadon.Visible = false;
            khachhang.Visible = false;
            nhanvien.Visible = false;


            panelToShow.Visible = true;
        }

        private void btnsanpham_Click(object sender, EventArgs e)
        {
            ShowPanel(sanpham);
        }

        private void btnhoadon_Click(object sender, EventArgs e)
        {
            ShowPanel(hoadon);
        }

        private void btnthongke_Click(object sender, EventArgs e)
        {
        }

        private void btnvocher_Click(object sender, EventArgs e)
        {
        }

        private void btndichvu_Click(object sender, EventArgs e)
        {
        }

        private void btnnhanvien_Click(object sender, EventArgs e)
        {
            ShowPanel(nhanvien);
        }

        private void btnkhachhang_click(object sender, EventArgs e)
        {
            ShowPanel(khachhang);
        }

        private void dgvsanpham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow chon = dgvsanpham.Rows[e.RowIndex];
            txtsanpham.Text = chon.Cells[0].Value.ToString();
            txtten.Text = chon.Cells[1].Value.ToString();
            txtthuonghieu.Text = chon.Cells[2].Value.ToString();
            txtbonho.Text = chon.Cells[3].Value.ToString();
            txtocung.Text = chon.Cells[4].Value.ToString();
            txtcardohoa.Text = chon.Cells[5].Value.ToString();
            txthedieuhanh.Text = chon.Cells[6].Value.ToString();
            txtgiaban.Text = chon.Cells[7].Value.ToString();
            txtsoluong.Text = chon.Cells[8].Value.ToString();
            dangchon = e.RowIndex;
        }
        private int dangchon;
        private void btnupdate_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("bạn chắc chắn muốn Sửa", "Sửa sản phẩm", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                DialogResult tb = MessageBox.Show("Sửa thành công", "", MessageBoxButtons.OK);
                DataRow dr = dt.Rows[dangchon];

                dr["Tên Sản Phẩm"] = txtten.Text;
                dr["Thương Hiệu"] = txtthuonghieu.Text;
                dr["Bộ Nhớ ram"] = txtbonho.Text;
                dr["Ổ Cứng"] = txtocung.Text;
                dr["Card Đồ Họa"] = txtcardohoa.Text;
                dr["Hệ Điều Hành"] = txthedieuhanh.Text;
                dr["Giá Bán"] = txtgiaban.Text;
                dr["Số Lượng"] = txtsoluong.Text;

                var dangsua = new Sanpham();
                dangsua.Ten = txtten.Text;
                dangsua.ThuongHieu = txtthuonghieu.Text;
                dangsua.BoNhoRam = txtbonho.Text;
                dangsua.Ocung = txtocung.Text;
                dangsua.CardDoHoa = txtcardohoa.Text;
                dangsua.HeDieuHanh = txthedieuhanh.Text;
                dangsua.GiaBan = Convert.ToDecimal(txtgiaban.Text);
                dangsua.Soluong = Convert.ToInt32(txtsoluong.Text);
                sanphamBLL.CNsua(dangsua);

                dr["Tên Sản Phẩm"] = dangsua.Ten;
                dr["Thương Hiệu"] = dangsua.ThuongHieu;
                dr["Bộ Nhớ ram"] = dangsua.BoNhoRam;
                dr["Ổ Cứng"] = dangsua.Ocung;
                dr["Card Đồ Họa"] = dangsua.CardDoHoa;
                dr["Hệ Điều Hành"] = dangsua.HeDieuHanh;
                dr["Giá Bán"] = dangsua.GiaBan;
                dr["Số Lượng"] = dangsua.Soluong;
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("bạn chắc chắn muốn xóa", "Xóa sản phẩm", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                DialogResult tb = MessageBox.Show("Xóa thành công", "", MessageBoxButtons.OK);
                var Id = Convert.ToInt32(dt.Rows[dangchon]["Id"]);
                sanphamBLL.CNXoa(Id);
                Getcaidat();
            }
        }
        private void btnreset_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Reset thành công", "", MessageBoxButtons.OK);

            if (result == DialogResult.OK)
            {
                txtten.Text = "";
                txtthuonghieu.Text = "";
                txtbonho.Text = "";
                txtocung.Text = "";
                txtcardohoa.Text = "";
                txthedieuhanh.Text = "";
                txtgiaban.Text = "";
                txtsoluong.Text = "";
            }
        }

        private void txttimkiem_TextChanged(object sender, EventArgs e)
        {
            List<Sanpham> timten;

            if (int.TryParse(txttimkiem.Text, out int id))
            {
                timten = sanphamBLL.TimKiemid(txttimkiem.Text);
            }
            else
            {
                timten = sanphamBLL.TimKiem(txttimkiem.Text);
            }

            dt.Clear();
            foreach (var sp in timten)
            {
                dt.Rows.Add(sp.IdSanpham, sp.Ten, sp.ThuongHieu, sp.BoNhoRam, sp.Ocung, sp.CardDoHoa, sp.HeDieuHanh, sp.GiaBan, sp.Soluong);
            }

            dgvsanpham.DataSource = dt;

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        KhachhangBLL khachhangbll = new KhachhangBLL();
        DataTable dtkh = new DataTable();
        private void btnthem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn chắc chắn muốn thêm?", "Thêm sản phẩm", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                try
                {
                    var ten = txthoten.Text;
                    var email = txtemail.Text;
                    var sdt = txtsdt.Text;
                    var diachi = txtdiachi.Text;
                    var thanhpho = txtthanhpho.Text;
                    var quocgia = txtquocgia.Text;
                    DateTime ngaydangki;
                    if (!DateTime.TryParse(dtpngaydangki.Value.ToString(), out ngaydangki))
                    {
                        MessageBox.Show("Ngày đăng ký không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    var ghichu = txtghichu.Text;

                    var dangthem = new KhachHang
                    {
                        HoTen = ten,
                        Email = email,
                        Sdt = sdt,
                        DiaChi = diachi,
                        ThanhPho = thanhpho,
                        QuocGia = quocgia,
                        NgayDangKi = ngaydangki,
                        GhiChu = ghichu
                    };

                    khachhangbll.CNThem(dangthem);

                    Getcaidatkh();

                    MessageBox.Show("Thêm thành công!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public void Getloadbangkh()
        {
            if (dtkh.Columns.Count > 0)
            {
                dtkh.Columns.Clear();
            }

            dtkh.Columns.Add("ID", typeof(int));
            dtkh.Columns.Add("Họ Tên", typeof(string));
            dtkh.Columns.Add("Email", typeof(string));
            dtkh.Columns.Add("Số Điện Thoại", typeof(string));
            dtkh.Columns.Add("Địa chỉ", typeof(string));
            dtkh.Columns.Add("Thành Phố", typeof(string));
            dtkh.Columns.Add("Quốc Gia", typeof(string));
            dtkh.Columns.Add("Ngày Đăng kí", typeof(DateTime));
            dtkh.Columns.Add("Ghi chú", typeof(string));

            dgvkhachhang.DataSource = dtkh;
        }
        public void Getcaidatkh()
        {
            dtkh.Rows.Clear();
            var khs = khachhangbll.Getlistsp();

            foreach (var kh in khs)
            {
                DataRow dr = dtkh.NewRow();
                dr["ID"] = kh.IdKhachHang;
                dr["Họ Tên"] = kh.HoTen;
                dr["Email"] = kh.Email;
                dr["Số Điện Thoại"] = kh.Sdt;
                dr["Địa chỉ"] = kh.DiaChi;
                dr["Thành Phố"] = kh.ThanhPho;
                dr["Quốc Gia"] = kh.QuocGia;
                dr["Ngày Đăng kí"] = kh.NgayDangKi.HasValue ? (object)kh.NgayDangKi.Value : DBNull.Value;
                dr["Ghi chú"] = kh.GhiChu;

                dtkh.Rows.Add(dr);
            }
        }

        private void dgvkhachhang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void khachhang_Paint(object sender, PaintEventArgs e)
        {
            Getloadbangkh();
            Getcaidatkh();
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn chắc chắn muốn sửa?", "Sửa thông tin", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                DataRow dr = dtkh.Rows[dangchon];

                dr["Họ Tên"] = txthoten.Text;
                dr["Email"] = txtemail.Text;
                dr["Số Điện Thoại"] = txtsdt.Text;
                dr["Địa chỉ"] = txtdiachi.Text;
                dr["Thành Phố"] = txtthanhpho.Text;
                dr["Quốc Gia"] = txtquocgia.Text;

                if (DateTime.TryParse(dtpngaydangki.Value.ToString(), out DateTime ngayDangKi))
                {
                    dr["Ngày Đăng kí"] = ngayDangKi;
                }
                else
                {
                    MessageBox.Show("Ngày đăng ký không hợp lệ.");
                    return;
                }

                dr["Ghi chú"] = txtghichu.Text;

                var khachHang = new KhachHang
                {
                    IdKhachHang = Convert.ToInt32(txtkhachhang.Text),
                    HoTen = txthoten.Text,
                    Email = txtemail.Text,
                    Sdt = txtsdt.Text,
                    DiaChi = txtdiachi.Text,
                    ThanhPho = txtthanhpho.Text,
                    QuocGia = txtquocgia.Text,
                    NgayDangKi = ngayDangKi,
                    GhiChu = txtghichu.Text
                };
                khachhangbll.CNsua(khachHang);

                dr["Họ Tên"] = khachHang.HoTen;
                dr["Email"] = khachHang.Email;
                dr["Số Điện Thoại"] = khachHang.Sdt;
                dr["Địa chỉ"] = khachHang.DiaChi;
                dr["Thành Phố"] = khachHang.ThanhPho;
                dr["Quốc Gia"] = khachHang.QuocGia;
                dr["Ngày Đăng kí"] = khachHang.NgayDangKi;
                dr["Ghi chú"] = khachHang.GhiChu;

                MessageBox.Show("Sửa thành công");
            }
        }


        private void dgvkhachhang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow chon = dgvkhachhang.Rows[e.RowIndex];

                txtkhachhang.Text = chon.Cells[0].Value?.ToString() ?? string.Empty;
                txthoten.Text = chon.Cells[1].Value?.ToString() ?? string.Empty;
                txtemail.Text = chon.Cells[2].Value?.ToString() ?? string.Empty;
                txtsdt.Text = chon.Cells[3].Value?.ToString() ?? string.Empty;
                txtdiachi.Text = chon.Cells[4].Value?.ToString() ?? string.Empty;
                txtthanhpho.Text = chon.Cells[5].Value?.ToString() ?? string.Empty;
                txtquocgia.Text = chon.Cells[6].Value?.ToString() ?? string.Empty;

                if (DateTime.TryParse(chon.Cells[7].Value?.ToString(), out DateTime ngayDangKi))
                {
                    dtpngaydangki.Value = ngayDangKi;
                }
                else
                {
                    dtpngaydangki.Value = DateTime.Now;
                }

                txtghichu.Text = chon.Cells[8].Value?.ToString() ?? string.Empty;
                dangchon = e.RowIndex;
            }
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("bạn chắc chắn muốn xóa", "Xóa sản phẩm", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                DialogResult tb = MessageBox.Show("Xóa thành công", "", MessageBoxButtons.OK);
                var Id = Convert.ToInt32(dtkh.Rows[dangchon]["Id"]);
                khachhangbll.CNXoa(Id);
                Getcaidatkh();
            }
        }

        private void timkh_TextChanged(object sender, EventArgs e)
        {
            List<KhachHang> timten;

            if (int.TryParse(timkh.Text, out int id))
            {
                timten = khachhangbll.TimKiemid(timkh.Text);
            }
            else
            {
                timten = khachhangbll.TimKiem(timkh.Text);
            }

            dtkh.Rows.Clear();

            foreach (var kh in timten)
            {
                dtkh.Rows.Add(kh.IdKhachHang, kh.HoTen, kh.Email, kh.Sdt, kh.DiaChi, kh.ThanhPho, kh.QuocGia, kh.NgayDangKi, kh.GhiChu);
            }

            dgvkhachhang.DataSource = dtkh;
        }

        private void Reset_Click(object sender, EventArgs e)
        {

            txtkhachhang.Text = "";
            txthoten.Text = "";
            txtemail.Text = "";
            txtsdt.Text = "";
            txtdiachi.Text = "";
            txtthanhpho.Text = "";
            txtquocgia.Text = "";
        }



    }
}
