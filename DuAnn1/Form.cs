using BLL;
using DTO.Models;
using System.Data;

namespace DuAnn1
{
    public partial class Form : System.Windows.Forms.Form
    {
        public Form()
        {
            InitializeComponent();
            Clock.Start();
        }
        public void Clock_Tick(object sender, EventArgs e)
        {
            Time.Text = GetFormattedDateTime();
        }
        private string GetFormattedDateTime()
        {
            DateTime now = DateTime.Now;
            string daySuffix = GetDaySuffix(now.Day);
            return now.ToString($"hh:mm:ss tt\nMMMM d'{daySuffix}', yyyy");
        }
        private string GetDaySuffix(int day)
        {
            if (day >= 11 && day <= 13)
            {
                return "th";
            }
            switch (day % 10)
            {
                case 1:
                    return "st";

                case 2:
                    return "nd";

                case 3:
                    return "rd";

                default:
                    return "th";
            }
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

        SanphamBLL sanphamBLL = new SanphamBLL();
        DataTable dt = new DataTable();

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

        private void ShowPanel(Control panelToShow)
        {
            sanpham.Visible = false;
            hoadon.Visible = false;
            khachhang.Visible = false;
            nhanvien.Visible = false;
            vocher.Visible = false;
            baohanhdichvu.Visible = false;
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
            ShowPanel(vocher);
        }

        private void btndichvu_Click(object sender, EventArgs e)
        {
            ShowPanel(baohanhdichvu);
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
                txtsanpham.Text = "";
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

        KhachhangBLL khachhangbll = new KhachhangBLL();
        DataTable dtkh = new DataTable();
        private void btnthem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn chắc chắn muốn thêm?", "Thêm khách hàng", MessageBoxButtons.YesNo);

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
            txtghichu.Text = "";
            dtpngaydangki.Value = DateTime.Now;
        }

        NhanvienBLL nhanvienBLL = new NhanvienBLL();
        DataTable dtnv = new DataTable();
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
            dgvnhanvien.DataSource = dtnv;
        }

        public void GetloadCaiDatnv()
        {
            dtnv.Rows.Clear();
            var nvs = nhanvienBLL.Getlistnv();
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
        }

        private void nhanvien_Paint(object sender, PaintEventArgs e)
        {
            Getloadbangnv();
            GetloadCaiDatnv();
            if (cbbchucvu.Items.Count == 0)
            {
                cbbchucvu.Items.Add("Nhân viên bán hàng");
                cbbchucvu.Items.Add("Kế Toán");
                cbbchucvu.Items.Add("Quản lí");
                cbbchucvu.Items.Add("Hỗ trợ kĩ thuật");
                cbbchucvu.Items.Add("Nhân Viên Kho");
                cbbchucvu.SelectedIndex = 0;
            }
        }

        private void btnthemnv_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn chắc chắn muốn thêm?", "Thêm sản phẩm", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                try
                {
                    var ten = txtnhanvien.Text;
                    var chucvu = cbbchucvu.Text;
                    var gioitinh = (bool)rdonam.Checked;
                    if (gioitinh == true)
                    {
                        rdonam.Checked = true;
                    }
                    else rdonu.Checked = true;
                    DateTime ngaydangki;
                    if (!DateTime.TryParse(dtpngaybatdaulam.Value.ToString(), out ngaydangki))
                    {
                        MessageBox.Show("Ngày đăng ký không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    var mucluong = Convert.ToDecimal(txtluong.Text);
                    var email = txtgmail.Text;
                    var sdt = txtsodienthoai.Text;
                    var cccd = txtcccd.Text;
                    var trangthai = (bool)rdolam.Checked;
                    if (trangthai == true)
                    {
                        rdolam.Checked = true;
                    }
                    else rdonghi.Checked = true;

                    var dangthem = new NhanVien
                    {
                        HoTen = ten,
                        ChucVu = chucvu,
                        Gioitinh = gioitinh,
                        NgayBatDauLam = ngaydangki,
                        MucLuong = mucluong,
                        Email = email,
                        Sdt = sdt,
                        Cccd = cccd,
                        Trangthai = trangthai
                    };

                    nhanvienBLL.CNThem(dangthem);

                    GetloadCaiDatnv();

                    MessageBox.Show("Thêm thành công!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnsuanv_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn chắc chắn muốn sửa?", "Sửa thông tin", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                DataRow dr = dtnv.Rows[dangchon];

                int maNhanVien = (int)dr["ID Nhân Viên"];

                bool gioitinh = rdonam.Checked;
                bool trangthai = rdolam.Checked;

                if (DateTime.TryParse(dtpngaybatdaulam.Value.ToString(), out DateTime ngayDangKi))
                {
                    var nhanVien = new NhanVien
                    {
                        IdNhanVien = maNhanVien,
                        HoTen = txtnhanvien.Text,
                        ChucVu = cbbchucvu.Text,
                        Gioitinh = gioitinh,
                        NgayBatDauLam = ngayDangKi,
                        MucLuong = decimal.TryParse(txtluong.Text, out var luong) ? luong : 0,
                        Email = txtgmail.Text,
                        Sdt = txtsodienthoai.Text,
                        Cccd = txtcccd.Text,
                        Trangthai = trangthai
                    };

                    nhanvienBLL.CNsua(nhanVien);

                    dr["Họ Tên"] = txtnhanvien.Text;
                    dr["Chức Vụ"] = cbbchucvu.Text;
                    dr["Giới Tính"] = gioitinh;
                    dr["Ngày Bắt Đầu Làm"] = ngayDangKi;
                    dr["Mức Lương"] = txtluong.Text;
                    dr["Email"] = txtgmail.Text;
                    dr["Số Điện Thoại"] = txtsodienthoai.Text;
                    dr["Căn Cước Công Nhân"] = txtcccd.Text;
                    dr["Trạng Thái"] = trangthai;

                    MessageBox.Show("Sửa thành công");
                }
                else
                {
                    MessageBox.Show("Ngày đăng ký không hợp lệ.");
                }
            }
        }

        private void dgvnhanvien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow chon = dgvnhanvien.Rows[e.RowIndex];
            txtid.Text = chon.Cells[0].Value.ToString();
            txtnhanvien.Text = chon.Cells[1].Value.ToString();
            cbbchucvu.Text = chon.Cells[2].Value.ToString();
            var gioitinh = (bool)chon.Cells[3].Value;
            if (gioitinh == true)
            {
                rdonam.Checked = true;
            }
            else rdonu.Checked = true;

            dtpngaybatdaulam.Text = chon.Cells[4].Value.ToString();
            txtluong.Text = chon.Cells[5].Value.ToString();
            txtgmail.Text = chon.Cells[6].Value.ToString();
            txtsodienthoai.Text = chon.Cells[7].Value.ToString();
            txtcccd.Text = chon.Cells[8].Value.ToString();
            var trangthai = (bool)chon.Cells[9].Value;
            if (trangthai == true)
            {
                rdolam.Checked = true;
            }
            else rdonghi.Checked = true;
            dangchon = e.RowIndex;
        }

        private void btnxoanv_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("bạn chắc chắn muốn xóa", "Xóa nhân viên", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                DialogResult tb = MessageBox.Show("Xóa thành công", "", MessageBoxButtons.OK);
                var Id = Convert.ToInt32(dtnv.Rows[dangchon]["ID Nhân Viên"]);
                nhanvienBLL.CNXoa(Id);
                GetloadCaiDatnv();
            }
        }

        private void btnressetnv_Click(object sender, EventArgs e)
        {
            txtid.Text = "";
            txtnhanvien.Text = "";
            cbbchucvu.Text = "";
            rdonam.Checked = false;
            rdonghi.Checked = false;
            rdonu.Checked = false;
            txtluong.Text = "";
            txtgmail.Text = "";
            txtsodienthoai.Text = "";
            txtcccd.Text = "";
            rdolam.Checked = false;
            dtpngaybatdaulam.Value = DateTime.Now;
        }

        private void btnnghiviec_Click(object sender, EventArgs e)
        {
            var danhSachNghiViecForm = new nhanviennghi();
            danhSachNghiViecForm.Show();
        }

        private void txttimnv_TextChanged(object sender, EventArgs e)
        {
            List<NhanVien> timten;

            if (int.TryParse(txttimnv.Text, out int idnv))
            {
                timten = nhanvienBLL.TimKiemid(txttimnv.Text);
            }
            else
            {
                timten = nhanvienBLL.TimKiem(txttimnv.Text);
            }

            dtnv.Rows.Clear();

            foreach (var nv in timten)
            {
                DataRow row = dtnv.NewRow();
                row["ID Nhân Viên"] = nv.IdNhanVien;
                row["Họ Tên"] = nv.HoTen;
                row["Ngày Bắt Đầu Làm"] = nv.NgayBatDauLam;
                row["Giới Tính"] = nv.Gioitinh;
                row["Căn Cước Công Nhân"] = nv.Cccd;
                row["Số Điện Thoại"] = nv.Sdt;
                row["Mức Lương"] = nv.MucLuong;
                row["Trạng Thái"] = nv.Trangthai;
                row["Email"] = nv.Email;
                row["Chức Vụ"] = nv.ChucVu;
                dtnv.Rows.Add(row);
            }

            dgvnhanvien.DataSource = dtnv;
            dgvnhanvien.Refresh();
        }

        private void vocher_Paint(object sender, PaintEventArgs e)
        {
            Getloadbangvocher();
            GetloadCaiDatvocher();
        }
        VocherBLL vocherBLL = new VocherBLL();
        DataTable dtvc = new DataTable();
        private void Getloadbangvocher()
        {
            dtvc.Columns.Clear();
            dtvc.Columns.Add("ID", typeof(int));
            dtvc.Columns.Add("Tên Mã", typeof(string));
            dtvc.Columns.Add("Phần Trăm Giảm", typeof(int));
            dtvc.Columns.Add("Hiệu Lực Từ", typeof(DateTime));
            dtvc.Columns.Add("Hiệu Lực Đến", typeof(DateTime));
            dtvc.Columns.Add("Đơn Hàng Tối Thiểu", typeof(double));
            dtvc.Columns.Add("Phạm Vi Sử Dụng", typeof(string));

            dgvvocher.DataSource = dtvc;
        }

        public void GetloadCaiDatvocher()
        {
            dtvc.Rows.Clear();
            var nvs = vocherBLL.Getlistvc();

            foreach (var nv in nvs)
            {
                DataRow dr = dtvc.NewRow();
                dr["ID"] = nv.IdMaGiamGia;
                dr["Tên Mã"] = nv.GiamGia;
                dr["Phần Trăm Giảm"] = nv.PhamTramGiam;
                dr["Hiệu Lực Từ"] = nv.HieuLucTu;
                dr["Hiệu Lực Đến"] = nv.HieuLucDen;
                dr["Đơn Hàng Tối Thiểu"] = nv.GiaTriDonHangToiThieu;
                dr["Phạm Vi Sử Dụng"] = nv.PhamViSuDung;

                dtvc.Rows.Add(dr);
            }
        }

        private void btnthemvc_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn chắc chắn muốn thêm?", "Thêm vocher", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                try
                {
                    var ten = txtmavc.Text;
                    var phantramgiam = Convert.ToInt32(txtphantramvc.Text);

                    DateTime ngaydangki;
                    if (!DateTime.TryParse(dtptuvc.Value.ToString(), out ngaydangki))
                    {
                        MessageBox.Show("Ngày đăng ký không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    DateTime ngayketthuc;
                    if (!DateTime.TryParse(dtpdenvc.Value.ToString(), out ngayketthuc))
                    {
                        MessageBox.Show("Ngày đăng ký không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    var toithieu = Convert.ToDouble(txtgiatrivc.Text);
                    var phamvi = txtphamvi.Text;

                    var dangthem = new MaGiamGium
                    {
                        GiamGia = ten,
                        PhamTramGiam = phantramgiam,
                        HieuLucTu = ngaydangki,
                        HieuLucDen = ngayketthuc,
                        GiaTriDonHangToiThieu = toithieu,
                        PhamViSuDung = phamvi,
                    };

                    vocherBLL.CNThem(dangthem);

                    GetloadCaiDatvocher();

                    MessageBox.Show("Thêm thành công!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvvocher_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow chon = dgvvocher.Rows[e.RowIndex];
            txtidvc.Text = chon.Cells[0].Value.ToString();
            txtmavc.Text = chon.Cells[1].Value.ToString();
            txtphantramvc.Text = chon.Cells[2].Value.ToString();
            dtptuvc.Text = chon.Cells[3].Value.ToString();
            dtpdenvc.Text = chon.Cells[4].Value.ToString();
            txtgiatrivc.Text = chon.Cells[5].Value.ToString();
            txtphamvi.Text = chon.Cells[6].Value.ToString();
            dangchon = e.RowIndex;
        }

        private void btnsuavc_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn chắc chắn muốn sửa?", "Sửa thông tin", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                try
                {
                    if (string.IsNullOrEmpty(txtidvc.Text))
                    {
                        MessageBox.Show("Vui lòng chọn mã giảm giá để sửa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    var id = Convert.ToInt32(txtidvc.Text);
                    var ten = txtmavc.Text;
                    var phantramgiam = Convert.ToInt32(txtphantramvc.Text);

                    DateTime ngaydangki;
                    if (!DateTime.TryParse(dtptuvc.Value.ToString(), out ngaydangki))
                    {
                        MessageBox.Show("Ngày hiệu lực từ không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    DateTime ngayketthuc;
                    if (!DateTime.TryParse(dtpdenvc.Value.ToString(), out ngayketthuc))
                    {
                        MessageBox.Show("Ngày hiệu lực đến không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    var toithieu = Convert.ToDouble(txtgiatrivc.Text);
                    var phamvi = txtphamvi.Text;

                    var dangcapnhat = new MaGiamGium
                    {
                        IdMaGiamGia = id,
                        GiamGia = ten,
                        PhamTramGiam = phantramgiam,
                        HieuLucTu = ngaydangki,
                        HieuLucDen = ngayketthuc,
                        GiaTriDonHangToiThieu = toithieu,
                        PhamViSuDung = phamvi
                    };

                    vocherBLL.CNsua(dangcapnhat);

                    GetloadCaiDatvocher();

                    MessageBox.Show("Sửa thành công!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnxoavc_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn chắc chắn muốn xóa mã giảm giá này?", "Xóa mã giảm giá", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                try
                {
                    if (dangchon < 0 || dangchon >= dgvvocher.Rows.Count)
                    {
                        MessageBox.Show("Vui lòng chọn mã giảm giá cần xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    var selectedRow = dgvvocher.Rows[dangchon];
                    int id;
                    if (!int.TryParse(selectedRow.Cells[0].Value.ToString(), out id))
                    {
                        MessageBox.Show("ID không hợp lệ hoặc không có giá trị.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    vocherBLL.CNXoa(id);

                    GetloadCaiDatvocher();

                    MessageBox.Show("Xóa thành công!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnressetvc_Click(object sender, EventArgs e)
        {
            try
            {
                txtidvc.Text = "";
                txtmavc.Text = "";
                txtphantramvc.Text = "";
                txtgiatrivc.Text = "";
                txtphamvi.Text = "";

                dtptuvc.Value = DateTime.Now;
                dtpdenvc.Value = DateTime.Now;
                MessageBox.Show("Đã làm mới tất cả các trường.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txttimkiemvc_TextChanged(object sender, EventArgs e)
        {
            string searchValue = txttimkiemvc.Text.Trim();

            List<MaGiamGium> result;

            if (int.TryParse(searchValue, out int id))
            {
                result = vocherBLL.TimKiemid(searchValue);
            }
            else
            {
                result = vocherBLL.TimKiem(searchValue);
            }

            dtvc.Rows.Clear();
            foreach (var item in result)
            {
                DataRow dr = dtvc.NewRow();
                dr["ID"] = item.IdMaGiamGia;
                dr["Tên Mã"] = item.GiamGia;
                dr["Phần Trăm Giảm"] = item.PhamTramGiam;
                dr["Hiệu Lực Từ"] = item.HieuLucTu;
                dr["Hiệu Lực Đến"] = item.HieuLucDen;
                dr["Đơn Hàng Tối Thiểu"] = item.GiaTriDonHangToiThieu;
                dr["Phạm Vi Sử Dụng"] = item.PhamViSuDung;

                dtvc.Rows.Add(dr);
            }

            dgvvocher.DataSource = dtvc;
        }

        DichvuBLL dichvuBLL = new DichvuBLL();
        DataTable dtdv = new DataTable();

        private void baohanhdichvu_Paint(object sender, PaintEventArgs e)
        {
            Getloaddichvu();
            GetCaidatdichvu();
            if (cbbloaidichvu.Items.Count == 0)
            {
                cbbloaidichvu.Items.Add("Bảo Trì");
                cbbloaidichvu.Items.Add("Cài Đặt");
                cbbloaidichvu.Items.Add("Sửa Chữa");
                cbbloaidichvu.Items.Add("Nâng Cấp");
                cbbidsanpham.Items.Clear();
                LoadSanPhamToComboBox();
            }
        }

        private void Getloaddichvu()
        {
            dtdv.Columns.Clear();
            dtdv.Columns.Add("ID", typeof(int));
            dtdv.Columns.Add("Tên Sản Phẩm", typeof(string));
            dtdv.Columns.Add("Tên Dịch Vụ", typeof(string));
            dtdv.Columns.Add("Mô tả", typeof(string));
            dtdv.Columns.Add("Loại Dịch Vụ", typeof(string));
            dtdv.Columns.Add("Giá", typeof(int));
            dtdv.Columns.Add("Thời gian", typeof(string));
            dtdv.Columns.Add("Ngày Bắt Đầu Cung cấp", typeof(DateTime));
            dtdv.Columns.Add("Ngày Kết Thúc Cung cấp", typeof(DateTime));
            dtdv.Columns.Add("Ghi Chú", typeof(string));

            dgvdichvu.DataSource = dtdv;
        }

        private int selectedSanPhamId = -1;
        public void GetCaidatdichvu()
        {
            dtdv.Rows.Clear();
            var nvs = dichvuBLL.Getlistdv();
            if (selectedSanPhamId != -1)
            {
                nvs = nvs.Where(nv => nv.IdSanPham == selectedSanPhamId).ToList();
            }
            foreach (var nv in nvs)
            {
                DataRow dr = dtdv.NewRow();
                dr["ID"] = nv.IdDichVu;
                dr["Tên Sản Phẩm"] = dichvuBLL.GetSanPhamNameById(nv.IdSanPham);
                dr["Tên Dịch Vụ"] = nv.TenDichVu;
                dr["Mô tả"] = nv.MoTa;
                dr["Loại Dịch Vụ"] = nv.LoaiDichVu;
                dr["Giá"] = nv.GiaDichVu;
                dr["Thời gian"] = nv.ThoiGianThucHien;
                dr["Ngày Bắt Đầu Cung cấp"] = nv.NgayBatDauCungCap;
                dr["Ngày Kết Thúc Cung cấp"] = nv.NgayKetThucCungCap;
                dr["Ghi Chú"] = nv.GhiChu;

                dtdv.Rows.Add(dr);
            }
        }
        private void LoadSanPhamToComboBox()
        {
            var sanPhamIds = dichvuBLL.GetListSanPhamIds();
            cbbidsanpham.Items.Clear();
            foreach (var id in sanPhamIds)
            {
                cbbidsanpham.Items.Add(id);
            }
        }

        private void btnthemdichvu_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn chắc chắn muốn thêm?", "Thêm dịch vụ", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                try
                {
                    var ten = txttendichvu.Text.Trim();
                    var idsanpham = cbbidsanpham.SelectedItem?.ToString().Trim();
                    var Mota = txtmotadichvu.Text.Trim();
                    var loaidichvu = cbbloaidichvu.SelectedItem?.ToString().Trim();
                    var giadichvuStr = txtgiadichvu.Text.Trim();
                    var thoigianthuchien = txtthoigiandichvu.Text.Trim();

                    MessageBox.Show($"Tên: {ten}\nID Sản Phẩm: {idsanpham}\nMô Tả: {Mota}\nLoại Dịch Vụ: {loaidichvu}\nGiá: {giadichvuStr}\nThời Gian: {thoigianthuchien}");

                    if (string.IsNullOrEmpty(ten) || string.IsNullOrEmpty(idsanpham) || string.IsNullOrEmpty(Mota) || string.IsNullOrEmpty(loaidichvu) || string.IsNullOrEmpty(thoigianthuchien))
                    {
                        MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (!int.TryParse(giadichvuStr, out int giadichvu))
                    {
                        MessageBox.Show("Giá dịch vụ không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    DateTime ngaydangki = dtpbatdaudichvu.Value;
                    DateTime ngayketthuc = dtpketthucdichvu.Value;

                    var ghichu = txtghichudichvu.Text.Trim();

                    var dangthem = new DichVu
                    {
                        TenDichVu = ten,
                        IdSanPham = Convert.ToInt32(idsanpham),
                        MoTa = Mota,
                        LoaiDichVu = loaidichvu,
                        GiaDichVu = giadichvu,
                        ThoiGianThucHien = thoigianthuchien,
                        NgayBatDauCungCap = ngaydangki,
                        NgayKetThucCungCap = ngayketthuc,
                        GhiChu = ghichu,
                    };

                    dichvuBLL.CNThem(dangthem);

                    GetCaidatdichvu();

                    MessageBox.Show("Thêm thành công!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnxoadichvu_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn chắc chắn muốn xóa dịch vụ?", "Xóa mã dịch vụ", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                try
                {
                    if (dangchon < 0 || dangchon >= dgvdichvu.Rows.Count)
                    {
                        MessageBox.Show("Vui lòng chọn dịch vụ cần xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    var selectedRow = dgvdichvu.Rows[dangchon];
                    int id;
                    if (!int.TryParse(selectedRow.Cells[0].Value.ToString(), out id))
                    {
                        MessageBox.Show("ID không hợp lệ hoặc không có giá trị.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    dichvuBLL.CNXoa(id);

                    GetCaidatdichvu();

                    MessageBox.Show("Xóa thành công!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvdichvu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvdichvu.Rows.Count) return;

            DataGridViewRow chon = dgvdichvu.Rows[e.RowIndex];

            txtiddichvu.Text = chon.Cells[0].Value?.ToString();

            string idSanPham = chon.Cells[1].Value?.ToString();
            if (cbbidsanpham.Items.Contains(idSanPham))
            {
                cbbidsanpham.SelectedItem = idSanPham;
            }
            else
            {
                cbbidsanpham.Text = idSanPham;
            }

            txttendichvu.Text = chon.Cells[2].Value?.ToString();
            txtmotadichvu.Text = chon.Cells[3].Value?.ToString();
            cbbloaidichvu.Text = chon.Cells[4].Value?.ToString();

            txtgiadichvu.Text = chon.Cells[5].Value?.ToString();

            txtthoigiandichvu.Text = chon.Cells[6].Value?.ToString();

            if (DateTime.TryParse(chon.Cells[7].Value?.ToString(), out DateTime ngayBatDau))
            {
                dtpbatdaudichvu.Value = ngayBatDau;
            }

            if (DateTime.TryParse(chon.Cells[8].Value?.ToString(), out DateTime ngayKetThuc))
            {
                dtpketthucdichvu.Value = ngayKetThuc;
            }

            txtghichudichvu.Text = chon.Cells[9].Value?.ToString();

            dangchon = e.RowIndex;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow chon = dataGridView1.Rows[e.RowIndex];
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
        HoaDonBLL hoaDonBLL = new HoaDonBLL();
        private void button1_Click(object sender, EventArgs e)
        {
            GetloadbangHoaDOn();
            GetcaidatHoaDon();
        }
        public void GetloadbangHoaDOn()
        {
            dt.Columns.Add("ID HoaDon", typeof(int));
            dt.Columns.Add("ID NhanVien", typeof(int));
            dt.Columns.Add("ID KhachHang", typeof(int));
            dt.Columns.Add("ID SanPham", typeof(int));
            dt.Columns.Add("ID ChiTiet", typeof(int));
            dt.Columns.Add("Ngay Tao", typeof(DateTime));
            dt.Columns.Add("Trang Thai", typeof(string));
            dt.Columns.Add("Thanh Tien", typeof(int));
            dt.Columns.Add("Ghi Chu", typeof(string));
            dataGridView1.DataSource = dt;
        }
        public void GetcaidatHoaDon()
        {
            dt.Rows.Clear();

            foreach (var item in hoaDonBLL.GetlistHoadon())
            {
                DataRow dr = dt.NewRow();
                dr["ID HoaDon"] = item.IdHoaDon;
                dr["ID NhanVien"] = item.IdNhanVien;
                dr["ID KhachHang"] = item.IdKhachHang;
                dr["ID SanPham"] = item.IdSanPham;
                dr["ID ChiTiet"] = item.IdChiTiet;
                dr["Ngay Tao"] = item.NgayTao;
                dr["Trang Thai"] = item.TrangThai;
                dr["Thanh Tien"] = item.ThanhTien;
                dr["Ghi Chu"] = item.GhiChu;

                dt.Rows.Add(dr);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("bạn chắc chắn muốn thêm", "Thêm Hóa Đơn", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                DialogResult tb = MessageBox.Show("thêm thành công", "", MessageBoxButtons.OK);
                var IDhoadon = ID_HoaDon.Text;
                var IDnhanvien = ID_NhanVien.Text;
                var IDkhachhang = ID_KhachHang.Text;
                var IDsanpham = ID_SanPham.Text;
                var IDchitiet = ID_ChiTiet.Text;
                var datecreated = Date_Created.Text;
                var status = Status.Text;
                var money = Money.Text;
                var essay = Essay.Text;

                var item = new HoaDon();
                item.IdHoaDon = Convert.ToInt32(IDhoadon);
                item.IdNhanVien = Convert.ToInt32(IDnhanvien);
                item.IdKhachHang = Convert.ToInt32(IDkhachhang);
                item.IdSanPham = Convert.ToInt32(IDsanpham);
                item.IdChiTiet = Convert.ToInt32(IDchitiet);
                item.NgayTao = DateTime.Now;
                item.TrangThai = status;
                item.ThanhTien = Convert.ToInt32(money);
                item.GhiChu = essay;
                hoaDonBLL.CNThem(item);
                GetcaidatHoaDon();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("bạn chắc chắn muốn Sửa", "Sửa sản phẩm", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                DialogResult tb = MessageBox.Show("Sửa thành công", "", MessageBoxButtons.OK);
                DataRow dr = dt.Rows[dangchon];

                dr["ID HoaDon"] = ID_HoaDon.Text;
                dr["ID NhanVien"] = ID_NhanVien.Text;
                dr["ID KhachHang"] = ID_KhachHang.Text;
                dr["ID SanPham"] = ID_SanPham.Text;
                dr["ID ChiTiet"] = ID_ChiTiet.Text;
                dr["Ngay Tao"] = Date_Created.Text;
                dr["Trang Thai"] = Status.Text;
                dr["Thanh Tien"] = Money.Text;
                dr["Ghi Chu"] = Essay.Text;

                var update = new HoaDon();
                update.IdHoaDon = Convert.ToInt32(ID_HoaDon.Text);
                update.IdNhanVien = Convert.ToInt32(ID_NhanVien.Text);
                update.IdKhachHang = Convert.ToInt32(ID_KhachHang.Text);
                update.IdSanPham = Convert.ToInt32(ID_SanPham.Text);
                update.IdChiTiet = Convert.ToInt32(ID_ChiTiet.Text);
                update.TrangThai = Status.Text;
                update.ThanhTien = Convert.ToInt32(Money.Text);
                update.GhiChu = Essay.Text;
                hoaDonBLL.CNsua(update);

                dr["ID HoaDon"] = update.IdHoaDon;
                dr["ID NhanVien"] = update.IdNhanVien;
                dr["ID KhachHang"] = update.IdKhachHang;
                dr["ID SanPham"] = update.IdSanPham;
                dr["ID ChiTiet"] = update.IdChiTiet;
                dr["Ngay Tao"] = update.NgayTao;
                dr["Trang Thai"] = update.TrangThai;
                dr["Thanh Tien"] = update.ThanhTien;
                dr["Ghi Chu"] = update.GhiChu;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("bạn chắc chắn muốn xóa", "Xóa sản phẩm", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                DialogResult tb = MessageBox.Show("Xóa thành công", "", MessageBoxButtons.OK);
                var Id = Convert.ToInt32(dt.Rows[dangchon]["ID HoaDon"]);
                hoaDonBLL.CNXoa(Id);
                GetcaidatHoaDon();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ID_HoaDon.Text = "";
            ID_NhanVien.Text = "";
            ID_KhachHang.Text = "";
            ID_SanPham.Text = "";
            ID_ChiTiet.Text = "";
            Date_Created.Text = "";
            Status.Text = "";
            Money.Text = "";
            Essay.Text = "";
        }
    }
}