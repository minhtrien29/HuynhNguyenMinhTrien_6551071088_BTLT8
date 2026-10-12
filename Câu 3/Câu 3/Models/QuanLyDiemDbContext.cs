using Microsoft.EntityFrameworkCore;

namespace Câu_3.Models;

public partial class QuanLyDiemDbContext : DbContext
{
    public const string DefaultConnectionString =
        @"Server=(localdb)\MSSQLLocalDB;Database=QuanLyDiem;Trusted_Connection=True;TrustServerCertificate=True;";

    public QuanLyDiemDbContext()
    {
    }

    public QuanLyDiemDbContext(DbContextOptions<QuanLyDiemDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Lop> Lops { get; set; } = null!;
    public virtual DbSet<SinhVien> SinhViens { get; set; } = null!;
    public virtual DbSet<DiemMon> DiemMons { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(DefaultConnectionString);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Lop>(entity =>
        {
            entity.HasKey(e => e.MaLop).HasName("PK_Lop");
        });

        modelBuilder.Entity<SinhVien>(entity =>
        {
            entity.HasKey(e => e.MaSV).HasName("PK_SinhVien");
            entity.Property(e => e.NgaySinh).HasColumnType("datetime");

            entity.HasOne(d => d.Lop)
                .WithMany(p => p.SinhViens)
                .HasForeignKey(d => d.MaLop)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SinhVien_Lop");
        });

        modelBuilder.Entity<DiemMon>(entity =>
        {
            entity.HasKey(e => e.MaDiem).HasName("PK_DiemMon");
            entity.Property(e => e.Diem).HasColumnType("decimal(4, 2)");

            entity.HasOne(d => d.SinhVien)
                .WithMany(p => p.DiemMons)
                .HasForeignKey(d => d.MaSV)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_DiemMon_SinhVien");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
