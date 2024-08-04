using Microsoft.EntityFrameworkCore;

namespace DTO.Models
{
    public partial class Duan1Context : DbContext
    {
        public Duan1Context()
        {
        }

        public Duan1Context(DbContextOptions<Duan1Context> options)
            : base(options)
        {
        }

        public virtual DbSet<BanPhim> BanPhims { get; set; } = null!;
        public virtual DbSet<ChinhSachBaoHanh> ChinhSachBaoHanhs { get; set; } = null!;
        public virtual DbSet<Chuot> Chuots { get; set; } = null!;
        public virtual DbSet<DichVu> DichVus { get; set; } = null!;
        public virtual DbSet<HangSanXuat> HangSanXuats { get; set; } = null!;
        public virtual DbSet<HoaDon> HoaDons { get; set; } = null!;
        public virtual DbSet<HoaDonChiTiet> HoaDonChiTiets { get; set; } = null!;
        public virtual DbSet<KhachHang> KhachHangs { get; set; } = null!;
        public virtual DbSet<MaGiamGium> MaGiamGia { get; set; } = null!;
        public virtual DbSet<NhanVien> NhanViens { get; set; } = null!;
        public virtual DbSet<Sanpham> Sanphams { get; set; } = null!;
        public virtual DbSet<Tainghe> Tainghes { get; set; } = null!;
        public virtual DbSet<ThongTinLienHe> ThongTinLienHes { get; set; } = null!;
        public virtual DbSet<Xac> Xacs { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=Duan1;Trusted_Connection=True;TrustServerCertificate=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BanPhim>(entity =>
            {
                entity.HasKey(e => e.IdBanphim)
                    .HasName("PK__BanPhim__87129051E8A31AF1");

                entity.ToTable("BanPhim");

                entity.Property(e => e.IdBanphim).HasColumnName("Id_banphim");

                entity.Property(e => e.Loaiketnoi).HasMaxLength(100);

                entity.Property(e => e.TenBanPhim).HasMaxLength(100);
            });

            modelBuilder.Entity<ChinhSachBaoHanh>(entity =>
            {
                entity.HasKey(e => e.IdBaoHanh)
                    .HasName("PK__ChinhSac__55EC312396CA23E4");

                entity.ToTable("ChinhSachBaoHanh");

                entity.Property(e => e.IdBaoHanh).HasColumnName("ID_BaoHanh");

                entity.Property(e => e.DieuKienBaoHanh).HasMaxLength(300);

                entity.Property(e => e.DieuKienTuChoiBaoHanh).HasMaxLength(300);

                entity.Property(e => e.GhiChu).HasMaxLength(300);

                entity.Property(e => e.IdDichVu).HasColumnName("ID_DichVu");

                entity.Property(e => e.NgayBatDau).HasColumnType("date");

                entity.Property(e => e.NgayKetThuc).HasColumnType("date");

                entity.Property(e => e.ThoiGianBaoHanh).HasMaxLength(30);

                entity.HasOne(d => d.IdDichVuNavigation)
                    .WithMany(p => p.ChinhSachBaoHanhs)
                    .HasForeignKey(d => d.IdDichVu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ChinhSach__ID_Di__59FA5E80");
            });

            modelBuilder.Entity<Chuot>(entity =>
            {
                entity.HasKey(e => e.IdChuot)
                    .HasName("PK__Chuot__CBB4C97D85E0BC6B");

                entity.ToTable("Chuot");

                entity.Property(e => e.IdChuot).HasColumnName("Id_chuot");

                entity.Property(e => e.Dpi).HasColumnName("DPI");

                entity.Property(e => e.Loaiketnoi)
                    .HasMaxLength(100)
                    .HasColumnName("loaiketnoi");

                entity.Property(e => e.Tenchuot).HasMaxLength(100);
            });

            modelBuilder.Entity<DichVu>(entity =>
            {
                entity.HasKey(e => e.IdDichVu)
                    .HasName("PK__DichVu__6C465C9F0258EC66");

                entity.ToTable("DichVu");

                entity.Property(e => e.IdDichVu).HasColumnName("ID_DichVu");

                entity.Property(e => e.GhiChu).HasMaxLength(300);

                entity.Property(e => e.IdSanPham).HasColumnName("ID_SanPham");

                entity.Property(e => e.LoaiDichVu).HasMaxLength(300);

                entity.Property(e => e.MoTa).HasMaxLength(300);

                entity.Property(e => e.NgayBatDauCungCap).HasColumnType("date");

                entity.Property(e => e.NgayKetThucCungCap).HasColumnType("date");

                entity.Property(e => e.TenDichVu).HasMaxLength(300);

                entity.Property(e => e.ThoiGianThucHien)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdSanPhamNavigation)
                    .WithMany(p => p.DichVus)
                    .HasForeignKey(d => d.IdSanPham)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DichVu__ID_SanPh__571DF1D5");
            });

            modelBuilder.Entity<HangSanXuat>(entity =>
            {
                entity.HasKey(e => e.IdHangSanXuat)
                    .HasName("PK__HangSanX__434B02833F8A1753");

                entity.ToTable("HangSanXuat");

                entity.Property(e => e.IdHangSanXuat).HasColumnName("ID_HangSanXuat");

                entity.Property(e => e.DanhSachSanPham).HasMaxLength(300);

                entity.Property(e => e.DiaChi).HasMaxLength(300);

                entity.Property(e => e.Email).HasMaxLength(300);

                entity.Property(e => e.GhiChu).HasMaxLength(300);

                entity.Property(e => e.IdSanPham).HasColumnName("ID_SanPham");

                entity.Property(e => e.NgayHopTac).HasColumnType("date");

                entity.Property(e => e.NguoiLienHe).HasMaxLength(300);

                entity.Property(e => e.Sdt)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("SDT")
                    .IsFixedLength();

                entity.Property(e => e.TenHangSanXuat).HasMaxLength(300);

                entity.Property(e => e.WebSite).HasMaxLength(300);

                entity.HasOne(d => d.IdSanPhamNavigation)
                    .WithMany(p => p.HangSanXuats)
                    .HasForeignKey(d => d.IdSanPham)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__HangSanXu__ID_Sa__5441852A");
            });

            modelBuilder.Entity<HoaDon>(entity =>
            {
                entity.HasKey(e => e.IdHoaDon)
                    .HasName("PK__HoaDon__14AFCFC5E028E1E4");

                entity.ToTable("HoaDon");

                entity.Property(e => e.IdHoaDon).HasColumnName("ID_HoaDon");

                entity.Property(e => e.GhiChu).HasMaxLength(100);

                entity.Property(e => e.IdChiTiet).HasColumnName("ID_ChiTiet");

                entity.Property(e => e.IdKhachHang).HasColumnName("ID_KhachHang");

                entity.Property(e => e.IdNhanVien).HasColumnName("ID_NhanVien");

                entity.Property(e => e.IdSanPham).HasColumnName("ID_SanPham");

                entity.Property(e => e.NgayTao).HasColumnType("date");

                entity.Property(e => e.ThanhTien).HasColumnType("money");

                entity.Property(e => e.TrangThai).HasMaxLength(50);

                entity.HasOne(d => d.IdChiTietNavigation)
                    .WithMany(p => p.HoaDons)
                    .HasForeignKey(d => d.IdChiTiet)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__HoaDon__ID_ChiTi__4E88ABD4");

                entity.HasOne(d => d.IdKhachHangNavigation)
                    .WithMany(p => p.HoaDons)
                    .HasForeignKey(d => d.IdKhachHang)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__HoaDon__ID_Khach__5165187F");

                entity.HasOne(d => d.IdNhanVienNavigation)
                    .WithMany(p => p.HoaDons)
                    .HasForeignKey(d => d.IdNhanVien)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__HoaDon__ID_NhanV__5070F446");

                entity.HasOne(d => d.IdSanPhamNavigation)
                    .WithMany(p => p.HoaDons)
                    .HasForeignKey(d => d.IdSanPham)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__HoaDon__ID_SanPh__4F7CD00D");
            });

            modelBuilder.Entity<HoaDonChiTiet>(entity =>
            {
                entity.HasKey(e => e.IdChiTiet)
                    .HasName("PK__HoaDonCh__1EF2F705DF87694A");

                entity.ToTable("HoaDonChiTiet");

                entity.Property(e => e.IdChiTiet).HasColumnName("ID_ChiTiet");

                entity.Property(e => e.GhiChu).HasMaxLength(100);

                entity.Property(e => e.GiaBan).HasColumnType("money");

                entity.Property(e => e.IdMaGiamGia).HasColumnName("ID_MaGiamGia");

                entity.Property(e => e.PhuongThucThanhToan).HasMaxLength(200);

                entity.Property(e => e.ThanhTien).HasColumnType("money");

                entity.Property(e => e.TrangThai).HasMaxLength(200);

                entity.HasOne(d => d.IdMaGiamGiaNavigation)
                    .WithMany(p => p.HoaDonChiTiets)
                    .HasForeignKey(d => d.IdMaGiamGia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__HoaDonChi__ID_Ma__4BAC3F29");
            });

            modelBuilder.Entity<KhachHang>(entity =>
            {
                entity.HasKey(e => e.IdKhachHang)
                    .HasName("PK__KhachHan__263C4E85D12C2B29");

                entity.ToTable("KhachHang");

                entity.Property(e => e.IdKhachHang).HasColumnName("ID_KhachHang");

                entity.Property(e => e.DiaChi).HasMaxLength(100);

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.GhiChu).HasMaxLength(100);

                entity.Property(e => e.HoTen).HasMaxLength(200);

                entity.Property(e => e.NgayDangKi).HasColumnType("date");

                entity.Property(e => e.QuocGia).HasMaxLength(50);

                entity.Property(e => e.Sdt)
                    .HasMaxLength(11)
                    .HasColumnName("SDT");

                entity.Property(e => e.ThanhPho).HasMaxLength(300);
            });

            modelBuilder.Entity<MaGiamGium>(entity =>
            {
                entity.HasKey(e => e.IdMaGiamGia)
                    .HasName("PK__MaGiamGi__3BDA8EB0FDEB166E");

                entity.Property(e => e.IdMaGiamGia).HasColumnName("ID_MaGiamGia");

                entity.Property(e => e.GiamGia).HasMaxLength(300);

                entity.Property(e => e.HieuLucDen).HasColumnType("date");

                entity.Property(e => e.HieuLucTu).HasColumnType("date");

                entity.Property(e => e.PhamViSuDung).HasMaxLength(300);
            });

            modelBuilder.Entity<NhanVien>(entity =>
            {
                entity.HasKey(e => e.IdNhanVien)
                    .HasName("PK__NhanVien__EF603D1249ABAFE9");

                entity.ToTable("NhanVien");

                entity.HasIndex(e => e.HoTen, "UQ__NhanVien__27AEE13CAB7FF151")
                    .IsUnique();

                entity.Property(e => e.IdNhanVien).HasColumnName("ID_NhanVien");

                entity.Property(e => e.Cccd)
                    .HasMaxLength(200)
                    .HasColumnName("CCCD");

                entity.Property(e => e.ChucVu).HasMaxLength(200);

                entity.Property(e => e.Email).HasMaxLength(500);

                entity.Property(e => e.Gioitinh).HasColumnName("gioitinh");

                entity.Property(e => e.HoTen).HasMaxLength(200);

                entity.Property(e => e.MucLuong).HasColumnType("money");

                entity.Property(e => e.NgayBatDauLam).HasColumnType("date");

                entity.Property(e => e.Sdt)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("SDT")
                    .IsFixedLength();

                entity.Property(e => e.Trangthai).HasColumnName("trangthai");
            });

            modelBuilder.Entity<Sanpham>(entity =>
            {
                entity.HasKey(e => e.IdSanpham)
                    .HasName("PK__Sanpham__6F92EF6AF56E23F0");

                entity.ToTable("Sanpham");

                entity.Property(e => e.IdSanpham).HasColumnName("ID_Sanpham");

                entity.Property(e => e.BoNhoRam).HasMaxLength(300);

                entity.Property(e => e.CardDoHoa).HasMaxLength(300);

                entity.Property(e => e.GiaBan).HasColumnType("money");

                entity.Property(e => e.HeDieuHanh).HasMaxLength(300);

                entity.Property(e => e.IdBanphim).HasColumnName("Id_banphim");

                entity.Property(e => e.IdChuot).HasColumnName("Id_chuot");

                entity.Property(e => e.IdTainghe).HasColumnName("Id_tainghe");

                entity.Property(e => e.IdXac).HasColumnName("Id_Xac");

                entity.Property(e => e.Ocung)
                    .HasMaxLength(300)
                    .HasColumnName("OCung");

                entity.Property(e => e.Soluong).HasColumnName("soluong");

                entity.Property(e => e.Ten).HasMaxLength(300);

                entity.Property(e => e.ThuongHieu).HasMaxLength(100);

                entity.HasOne(d => d.IdBanphimNavigation)
                    .WithMany(p => p.Sanphams)
                    .HasForeignKey(d => d.IdBanphim)
                    .HasConstraintName("FK__Sanpham__Id_banp__403A8C7D");

                entity.HasOne(d => d.IdChuotNavigation)
                    .WithMany(p => p.Sanphams)
                    .HasForeignKey(d => d.IdChuot)
                    .HasConstraintName("FK__Sanpham__Id_chuo__3F466844");

                entity.HasOne(d => d.IdTaingheNavigation)
                    .WithMany(p => p.Sanphams)
                    .HasForeignKey(d => d.IdTainghe)
                    .HasConstraintName("FK__Sanpham__Id_tain__4222D4EF");

                entity.HasOne(d => d.IdXacNavigation)
                    .WithMany(p => p.Sanphams)
                    .HasForeignKey(d => d.IdXac)
                    .HasConstraintName("FK__Sanpham__Id_Xac__412EB0B6");
            });

            modelBuilder.Entity<Tainghe>(entity =>
            {
                entity.HasKey(e => e.IdTainghe)
                    .HasName("PK__Tainghe__8B71856A0554B0E1");

                entity.ToTable("Tainghe");

                entity.Property(e => e.IdTainghe).HasColumnName("Id_tainghe");

                entity.Property(e => e.LoaiKetnoi).HasMaxLength(100);

                entity.Property(e => e.Loaitainghe).HasMaxLength(100);

                entity.Property(e => e.TenTaiNghe).HasMaxLength(100);
            });

            modelBuilder.Entity<ThongTinLienHe>(entity =>
            {
                entity.HasKey(e => e.IdLienHe)
                    .HasName("PK__ThongTin__2E67B9C56C3D6FF9");

                entity.ToTable("ThongTinLienHe");

                entity.Property(e => e.IdLienHe).HasColumnName("ID_LienHe");

                entity.Property(e => e.DiaChi).HasMaxLength(500);

                entity.Property(e => e.Email).HasMaxLength(300);

                entity.Property(e => e.GhiChu).HasMaxLength(500);

                entity.Property(e => e.IdBaoHanh).HasColumnName("ID_BaoHanh");

                entity.Property(e => e.Sdt)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("SDT")
                    .IsFixedLength();

                entity.HasOne(d => d.IdBaoHanhNavigation)
                    .WithMany(p => p.ThongTinLienHes)
                    .HasForeignKey(d => d.IdBaoHanh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ThongTinL__ID_Ba__5CD6CB2B");
            });

            modelBuilder.Entity<Xac>(entity =>
            {
                entity.HasKey(e => e.IdXac)
                    .HasName("PK__Xac__562636600980E29F");

                entity.ToTable("Xac");

                entity.Property(e => e.IdXac).HasColumnName("Id_Xac");

                entity.Property(e => e.CongXuat).HasColumnName("Cong_xuat");

                entity.Property(e => e.Congxac).HasMaxLength(100);

                entity.Property(e => e.Tenxac).HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}