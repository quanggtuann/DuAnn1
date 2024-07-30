using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

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

        public virtual DbSet<ChinhSachBaoHanh> ChinhSachBaoHanhs { get; set; } = null!;
        public virtual DbSet<CpuchiTiet> CpuchiTiets { get; set; } = null!;
        public virtual DbSet<CputanNhiet> CputanNhiets { get; set; } = null!;
        public virtual DbSet<DichVu> DichVus { get; set; } = null!;
        public virtual DbSet<Gpu> Gpus { get; set; } = null!;
        public virtual DbSet<HangSanXuat> HangSanXuats { get; set; } = null!;
        public virtual DbSet<HoaDon> HoaDons { get; set; } = null!;
        public virtual DbSet<HoaDonChiTiet> HoaDonChiTiets { get; set; } = null!;
        public virtual DbSet<Igpu> Igpus { get; set; } = null!;
        public virtual DbSet<KhachHang> KhachHangs { get; set; } = null!;
        public virtual DbSet<MaGiamGium> MaGiamGia { get; set; } = null!;
        public virtual DbSet<NhanVien> NhanViens { get; set; } = null!;
        public virtual DbSet<Ram> Rams { get; set; } = null!;
        public virtual DbSet<Sanpham> Sanphams { get; set; } = null!;
        public virtual DbSet<Storage> Storages { get; set; } = null!;
        public virtual DbSet<ThongTinLienHe> ThongTinLienHes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-6F007S99;Database=Duan1;User Id=SA;Password=12345;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChinhSachBaoHanh>(entity =>
            {
                entity.HasKey(e => e.IdBaoHanh)
                    .HasName("PK__ChinhSac__55EC3123DD083F1F");

                entity.ToTable("ChinhSachBaoHanh");

                entity.Property(e => e.IdBaoHanh)
                    .HasMaxLength(300)
                    .HasColumnName("ID_BaoHanh");

                entity.Property(e => e.DieuKienBaoHanh).HasMaxLength(300);

                entity.Property(e => e.DieuKienTuChoiBaoHanh).HasMaxLength(300);

                entity.Property(e => e.GhiChu).HasMaxLength(300);

                entity.Property(e => e.IdDichVu)
                    .HasMaxLength(300)
                    .HasColumnName("ID_DichVu");

                entity.Property(e => e.NgayBatDau).HasColumnType("date");

                entity.Property(e => e.NgayKetThuc).HasColumnType("date");

                entity.Property(e => e.ThoiGianBaoHanh).HasMaxLength(30);

                entity.HasOne(d => d.IdDichVuNavigation)
                    .WithMany(p => p.ChinhSachBaoHanhs)
                    .HasForeignKey(d => d.IdDichVu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ChinhSach__ID_Di__4E88ABD4");
            });

            modelBuilder.Entity<CpuchiTiet>(entity =>
            {
                entity.HasKey(e => e.IdCpu)
                    .HasName("PK__CPUChiTi__2BF960E0A9072906");

                entity.ToTable("CPUChiTiet");

                entity.Property(e => e.IdCpu)
                    .HasMaxLength(300)
                    .HasColumnName("ID_CPU");

                entity.Property(e => e.Amdpro)
                    .HasMaxLength(300)
                    .HasColumnName("AMDPRO");

                entity.Property(e => e.BaoHanh).HasColumnType("date");

                entity.Property(e => e.BoHuongDan).HasMaxLength(300);

                entity.Property(e => e.DaLuong).HasMaxLength(300);

                entity.Property(e => e.Dong).HasMaxLength(300);

                entity.Property(e => e.Gia).HasColumnType("money");

                entity.Property(e => e.GiaDinh).HasMaxLength(300);

                entity.Property(e => e.HeThongHoTro).HasMaxLength(300);

                entity.Property(e => e.HoTroOverclock).HasMaxLength(300);

                entity.Property(e => e.IdIgpu)
                    .HasMaxLength(300)
                    .HasColumnName("ID_IGPU");

                entity.Property(e => e.L1cache)
                    .HasMaxLength(300)
                    .HasColumnName("L1Cache");

                entity.Property(e => e.L2cache)
                    .HasMaxLength(300)
                    .HasColumnName("L2Cache");

                entity.Property(e => e.L3cache)
                    .HasMaxLength(300)
                    .HasColumnName("L3Cache");

                entity.Property(e => e.LoaiThietKe).HasMaxLength(300);

                entity.Property(e => e.Loi).HasMaxLength(300);

                entity.Property(e => e.Luong).HasMaxLength(300);

                entity.Property(e => e.LuongTonTdp)
                    .HasMaxLength(300)
                    .HasColumnName("LuongTonTDP");

                entity.Property(e => e.NgayRaMat).HasColumnType("date");

                entity.Property(e => e.NhietDoCpu)
                    .HasMaxLength(300)
                    .HasColumnName("NhietDoCPU");

                entity.Property(e => e.PrecisionBoost).HasMaxLength(300);

                entity.Property(e => e.Socket).HasMaxLength(300);

                entity.Property(e => e.TanSoCoBan).HasMaxLength(300);

                entity.Property(e => e.TanSoTurbo).HasMaxLength(300);

                entity.Property(e => e.Ten).HasMaxLength(300);

                entity.HasOne(d => d.IdIgpuNavigation)
                    .WithMany(p => p.CpuchiTiets)
                    .HasForeignKey(d => d.IdIgpu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CPUChiTie__ID_IG__3E52440B");
            });

            modelBuilder.Entity<CputanNhiet>(entity =>
            {
                entity.HasKey(e => e.IdCputanNhiet)
                    .HasName("PK__CPUTanNh__F4F31C68092772FD");

                entity.ToTable("CPUTanNhiet");

                entity.Property(e => e.IdCputanNhiet)
                    .HasMaxLength(300)
                    .HasColumnName("ID_CPUTanNhiet");

                entity.Property(e => e.BaoHanh).HasMaxLength(300);

                entity.Property(e => e.DienApHoatDong).HasMaxLength(300);

                entity.Property(e => e.Hang).HasMaxLength(300);

                entity.Property(e => e.LoaiBearing).HasMaxLength(300);

                entity.Property(e => e.LoaiTanNhiet).HasMaxLength(300);

                entity.Property(e => e.LuongTdp).HasColumnName("LuongTDP");

                entity.Property(e => e.LxWxH).HasMaxLength(300);

                entity.Property(e => e.NgayRaMat).HasColumnType("date");

                entity.Property(e => e.Socket).HasMaxLength(300);

                entity.Property(e => e.TanNhietCpu).HasColumnName("TanNhietCPU");

                entity.Property(e => e.Ten).HasMaxLength(300);
            });

            modelBuilder.Entity<DichVu>(entity =>
            {
                entity.HasKey(e => e.IdDichVu)
                    .HasName("PK__DichVu__6C465C9FBB51FB3F");

                entity.ToTable("DichVu");

                entity.Property(e => e.IdDichVu)
                    .HasMaxLength(300)
                    .HasColumnName("ID_DichVu");

                entity.Property(e => e.GhiChu).HasMaxLength(300);

                entity.Property(e => e.IdSanPham)
                    .HasMaxLength(300)
                    .HasColumnName("ID_SanPham");

                entity.Property(e => e.LoaiDichVu).HasMaxLength(300);

                entity.Property(e => e.MoTa).HasMaxLength(300);

                entity.Property(e => e.NgayBatDauCungCap).HasColumnType("date");

                entity.Property(e => e.NgayKetThucCungCap).HasColumnType("date");

                entity.Property(e => e.TenDichVu).HasMaxLength(300);

                entity.Property(e => e.ThoiGianThucHien).HasColumnType("date");

                entity.HasOne(d => d.IdSanPhamNavigation)
                    .WithMany(p => p.DichVus)
                    .HasForeignKey(d => d.IdSanPham)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DichVu__ID_SanPh__4BAC3F29");
            });

            modelBuilder.Entity<Gpu>(entity =>
            {
                entity.HasKey(e => e.IdGpu)
                    .HasName("PK__GPU__2EC9F1AE8605F654");

                entity.ToTable("GPU");

                entity.Property(e => e.IdGpu)
                    .HasMaxLength(300)
                    .HasColumnName("ID_GPU");

                entity.Property(e => e.ChipDoHoa).HasMaxLength(300);

                entity.Property(e => e.CongKetNoi).HasMaxLength(300);

                entity.Property(e => e.Gia).HasColumnType("money");

                entity.Property(e => e.HoTroDx12)
                    .HasMaxLength(300)
                    .HasColumnName("HoTroDX12");

                entity.Property(e => e.KichCoBus).HasMaxLength(300);

                entity.Property(e => e.KichCoChip).HasMaxLength(300);

                entity.Property(e => e.KichCoGpu)
                    .HasMaxLength(300)
                    .HasColumnName("KichCoGPU");

                entity.Property(e => e.L1cache)
                    .HasMaxLength(300)
                    .HasColumnName("L1Cache");

                entity.Property(e => e.L2cache)
                    .HasMaxLength(300)
                    .HasColumnName("L2Cache");

                entity.Property(e => e.LoaiVram).HasMaxLength(300);

                entity.Property(e => e.Loi).HasMaxLength(300);

                entity.Property(e => e.LoiRt)
                    .HasMaxLength(300)
                    .HasColumnName("LoiRT");

                entity.Property(e => e.LoiTensor).HasMaxLength(300);

                entity.Property(e => e.LuongTdp)
                    .HasMaxLength(300)
                    .HasColumnName("LuongTDP");

                entity.Property(e => e.NgayRaMat).HasColumnType("date");

                entity.Property(e => e.NguonChip).HasMaxLength(300);

                entity.Property(e => e.NguonKetNoi).HasMaxLength(300);

                entity.Property(e => e.Rops)
                    .HasMaxLength(300)
                    .HasColumnName("ROPS");

                entity.Property(e => e.Ten).HasMaxLength(300);

                entity.Property(e => e.Tmus)
                    .HasMaxLength(300)
                    .HasColumnName("TMUS");

                entity.Property(e => e.Vram)
                    .HasMaxLength(300)
                    .HasColumnName("VRam");
            });

            modelBuilder.Entity<HangSanXuat>(entity =>
            {
                entity.HasKey(e => e.IdHangSanXuat)
                    .HasName("PK__HangSanX__434B0283F7F560CF");

                entity.ToTable("HangSanXuat");

                entity.Property(e => e.IdHangSanXuat)
                    .HasMaxLength(300)
                    .HasColumnName("ID_HangSanXuat");

                entity.Property(e => e.DanhSachSanPham).HasMaxLength(300);

                entity.Property(e => e.DiaChi).HasMaxLength(300);

                entity.Property(e => e.Email).HasMaxLength(300);

                entity.Property(e => e.GhiChu).HasMaxLength(300);

                entity.Property(e => e.IdSanPham)
                    .HasMaxLength(300)
                    .HasColumnName("ID_SanPham");

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
                    .HasConstraintName("FK__HangSanXu__ID_Sa__48CFD27E");
            });

            modelBuilder.Entity<HoaDon>(entity =>
            {
                entity.HasKey(e => e.IdHoaDon)
                    .HasName("PK__HoaDon__14AFCFC5D9044691");

                entity.ToTable("HoaDon");

                entity.Property(e => e.IdHoaDon)
                    .HasMaxLength(300)
                    .HasColumnName("ID_HoaDon");

                entity.Property(e => e.GhiChu).HasMaxLength(100);

                entity.Property(e => e.IdKhachHang)
                    .HasMaxLength(300)
                    .HasColumnName("ID_KhachHang");

                entity.Property(e => e.IdMaGiamGia)
                    .HasMaxLength(300)
                    .HasColumnName("ID_MaGiamGia");

                entity.Property(e => e.IdNhanVien)
                    .HasMaxLength(300)
                    .HasColumnName("ID_NhanVien");

                entity.Property(e => e.NgayTao).HasColumnType("date");

                entity.Property(e => e.ThanhTien).HasColumnType("money");

                entity.Property(e => e.TrangThai).HasMaxLength(50);

                entity.HasOne(d => d.IdKhachHangNavigation)
                    .WithMany(p => p.HoaDons)
                    .HasForeignKey(d => d.IdKhachHang)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__HoaDon__ID_Khach__5EBF139D");

                entity.HasOne(d => d.IdMaGiamGiaNavigation)
                    .WithMany(p => p.HoaDons)
                    .HasForeignKey(d => d.IdMaGiamGia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__HoaDon__ID_MaGia__5FB337D6");

                entity.HasOne(d => d.IdNhanVienNavigation)
                    .WithMany(p => p.HoaDons)
                    .HasForeignKey(d => d.IdNhanVien)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__HoaDon__ID_NhanV__5DCAEF64");
            });

            modelBuilder.Entity<HoaDonChiTiet>(entity =>
            {
                entity.HasKey(e => e.IdChiTiet)
                    .HasName("PK__HoaDonCh__1EF2F7059018B0E0");

                entity.ToTable("HoaDonChiTiet");

                entity.Property(e => e.IdChiTiet)
                    .HasMaxLength(100)
                    .HasColumnName("ID_ChiTiet");

                entity.Property(e => e.GhiChu).HasMaxLength(100);

                entity.Property(e => e.GiaBan).HasColumnType("money");

                entity.Property(e => e.IdHoaDon)
                    .HasMaxLength(300)
                    .HasColumnName("ID_HoaDon");

                entity.Property(e => e.IdSanPham)
                    .HasMaxLength(300)
                    .HasColumnName("ID_SanPham");

                entity.Property(e => e.PhuongThucThanhToan).HasMaxLength(200);

                entity.Property(e => e.ThanhTien).HasColumnType("money");

                entity.Property(e => e.TrangThai).HasMaxLength(200);

                entity.HasOne(d => d.IdHoaDonNavigation)
                    .WithMany(p => p.HoaDonChiTiets)
                    .HasForeignKey(d => d.IdHoaDon)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__HoaDonChi__ID_Ho__628FA481");

                entity.HasOne(d => d.IdSanPhamNavigation)
                    .WithMany(p => p.HoaDonChiTiets)
                    .HasForeignKey(d => d.IdSanPham)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__HoaDonChi__ID_Sa__6383C8BA");
            });

            modelBuilder.Entity<Igpu>(entity =>
            {
                entity.HasKey(e => e.IdIgpu)
                    .HasName("PK__IGPU__52E9A0EBDAB80D81");

                entity.ToTable("IGPU");

                entity.HasIndex(e => e.TenModel, "UQ__IGPU__BB9657F0BF543650")
                    .IsUnique();

                entity.Property(e => e.IdIgpu)
                    .HasMaxLength(300)
                    .HasColumnName("ID_IGPU");

                entity.Property(e => e.LoiIgpu)
                    .HasMaxLength(300)
                    .HasColumnName("LoiIGPU");

                entity.Property(e => e.TanSoIgpu)
                    .HasMaxLength(300)
                    .HasColumnName("TanSoIGPU");

                entity.Property(e => e.TenModel).HasMaxLength(300);
            });

            modelBuilder.Entity<KhachHang>(entity =>
            {
                entity.HasKey(e => e.IdKhachHang)
                    .HasName("PK__KhachHan__263C4E85B06D60DB");

                entity.ToTable("KhachHang");

                entity.Property(e => e.IdKhachHang)
                    .HasMaxLength(300)
                    .HasColumnName("ID_KhachHang");

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
                    .HasName("PK__MaGiamGi__3BDA8EB04FFABAAF");

                entity.Property(e => e.IdMaGiamGia)
                    .HasMaxLength(300)
                    .HasColumnName("ID_MaGiamGia");

                entity.Property(e => e.GiamGia).HasMaxLength(300);

                entity.Property(e => e.HieuLucDen).HasColumnType("date");

                entity.Property(e => e.HieuLucTu).HasColumnType("date");

                entity.Property(e => e.PhamViSuDung).HasMaxLength(300);
            });

            modelBuilder.Entity<NhanVien>(entity =>
            {
                entity.HasKey(e => e.IdNhanVien)
                    .HasName("PK__NhanVien__EF603D12DBCDC936");

                entity.ToTable("NhanVien");

                entity.HasIndex(e => e.HoTen, "UQ__NhanVien__27AEE13CE7139446")
                    .IsUnique();

                entity.Property(e => e.IdNhanVien)
                    .HasMaxLength(300)
                    .HasColumnName("ID_NhanVien");

                entity.Property(e => e.BoPhan).HasMaxLength(100);

                entity.Property(e => e.Cccd)
                    .HasMaxLength(200)
                    .HasColumnName("CCCD");

                entity.Property(e => e.ChucVu).HasMaxLength(200);

                entity.Property(e => e.Email).HasMaxLength(500);

                entity.Property(e => e.HoTen).HasMaxLength(200);

                entity.Property(e => e.MucLuong).HasColumnType("money");

                entity.Property(e => e.NgayBatDauLam).HasColumnType("date");

                entity.Property(e => e.Sdt)
                    .HasMaxLength(11)
                    .HasColumnName("SDT");
            });

            modelBuilder.Entity<Ram>(entity =>
            {
                entity.HasKey(e => e.IdRam)
                    .HasName("PK__Ram__202A43E9605CA6E2");

                entity.ToTable("Ram");

                entity.Property(e => e.IdRam)
                    .HasMaxLength(300)
                    .HasColumnName("ID_Ram");

                entity.Property(e => e.BaoHanh).HasMaxLength(500);

                entity.Property(e => e.DongGoi).HasMaxLength(100);

                entity.Property(e => e.Gia).HasColumnType("money");

                entity.Property(e => e.HoTroEec)
                    .HasMaxLength(100)
                    .HasColumnName("HoTroEEC");

                entity.Property(e => e.LoaiRam).HasMaxLength(500);

                entity.Property(e => e.Mau).HasMaxLength(100);

                entity.Property(e => e.TanNhiet).HasMaxLength(500);

                entity.Property(e => e.Ten).HasMaxLength(500);
            });

            modelBuilder.Entity<Sanpham>(entity =>
            {
                entity.HasKey(e => e.IdSanpham)
                    .HasName("PK__Sanpham__6F92EF6ADD6054F2");

                entity.ToTable("Sanpham");

                entity.Property(e => e.IdSanpham)
                    .HasMaxLength(300)
                    .HasColumnName("ID_Sanpham");

                entity.Property(e => e.BoNhoRam).HasMaxLength(300);

                entity.Property(e => e.CardDoHoa).HasMaxLength(300);

                entity.Property(e => e.GiaBan).HasColumnType("money");

                entity.Property(e => e.HeDieuHanh).HasMaxLength(300);

                entity.Property(e => e.IdCpu)
                    .HasMaxLength(300)
                    .HasColumnName("ID_CPU");

                entity.Property(e => e.IdCputanNhiet)
                    .HasMaxLength(300)
                    .HasColumnName("ID_CPUTanNhiet");

                entity.Property(e => e.IdGpu)
                    .HasMaxLength(300)
                    .HasColumnName("ID_GPU");

                entity.Property(e => e.IdRam)
                    .HasMaxLength(300)
                    .HasColumnName("ID_Ram");

                entity.Property(e => e.Ochung)
                    .HasMaxLength(300)
                    .HasColumnName("OChung");

                entity.Property(e => e.Soluong).HasColumnName("soluong");

                entity.Property(e => e.Ten).HasMaxLength(300);

                entity.Property(e => e.ThuongHieu).HasMaxLength(100);

                entity.HasOne(d => d.IdCpuNavigation)
                    .WithMany(p => p.Sanphams)
                    .HasForeignKey(d => d.IdCpu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Sanpham__ID_CPU__4316F928");

                entity.HasOne(d => d.IdCputanNhietNavigation)
                    .WithMany(p => p.Sanphams)
                    .HasForeignKey(d => d.IdCputanNhiet)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Sanpham__ID_CPUT__45F365D3");

                entity.HasOne(d => d.IdGpuNavigation)
                    .WithMany(p => p.Sanphams)
                    .HasForeignKey(d => d.IdGpu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Sanpham__ID_GPU__440B1D61");

                entity.HasOne(d => d.IdRamNavigation)
                    .WithMany(p => p.Sanphams)
                    .HasForeignKey(d => d.IdRam)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Sanpham__ID_Ram__44FF419A");
            });

            modelBuilder.Entity<Storage>(entity =>
            {
                entity.HasKey(e => e.IdStorage)
                    .HasName("PK__Storage__C6296E1A1CD3598D");

                entity.ToTable("Storage");

                entity.Property(e => e.IdStorage)
                    .HasMaxLength(300)
                    .HasColumnName("ID_Storage");

                entity.Property(e => e.BaoHanh).HasColumnType("date");

                entity.Property(e => e.DungLuong).HasMaxLength(300);

                entity.Property(e => e.GiaoDien).HasMaxLength(300);

                entity.Property(e => e.Hang).HasMaxLength(300);

                entity.Property(e => e.HoTroTanNhiet).HasMaxLength(300);

                entity.Property(e => e.IdHangSanXuat)
                    .HasMaxLength(300)
                    .HasColumnName("ID_HangSanXuat");

                entity.Property(e => e.KieuFlash).HasMaxLength(300);

                entity.Property(e => e.LoaiBoNho).HasMaxLength(300);

                entity.Property(e => e.NgayRaMat).HasColumnType("date");

                entity.Property(e => e.TenBoNho).HasMaxLength(300);

                entity.Property(e => e.TocDoDoc).HasMaxLength(300);

                entity.Property(e => e.TocDoGhi).HasMaxLength(300);

                entity.HasOne(d => d.IdHangSanXuatNavigation)
                    .WithMany(p => p.Storages)
                    .HasForeignKey(d => d.IdHangSanXuat)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Storage__ID_Hang__5441852A");
            });

            modelBuilder.Entity<ThongTinLienHe>(entity =>
            {
                entity.HasKey(e => e.IdLienHe)
                    .HasName("PK__ThongTin__2E67B9C559076BFB");

                entity.ToTable("ThongTinLienHe");

                entity.Property(e => e.IdLienHe)
                    .HasMaxLength(300)
                    .HasColumnName("ID_LienHe");

                entity.Property(e => e.DiaChi).HasMaxLength(500);

                entity.Property(e => e.Email).HasMaxLength(300);

                entity.Property(e => e.GhiChu).HasMaxLength(500);

                entity.Property(e => e.IdBaoHanh)
                    .HasMaxLength(300)
                    .HasColumnName("ID_BaoHanh");

                entity.Property(e => e.Sdt).HasColumnName("SDT");

                entity.HasOne(d => d.IdBaoHanhNavigation)
                    .WithMany(p => p.ThongTinLienHes)
                    .HasForeignKey(d => d.IdBaoHanh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ThongTinL__ID_Ba__5165187F");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
