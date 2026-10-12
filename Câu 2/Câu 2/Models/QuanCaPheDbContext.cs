using Microsoft.EntityFrameworkCore;

namespace Câu_2.Models;

public partial class QuanCaPheDbContext : DbContext
{
    public const string DefaultConnectionString =
        @"Server=(localdb)\MSSQLLocalDB;Database=QuanCaPhe;Trusted_Connection=True;TrustServerCertificate=True;";

    public QuanCaPheDbContext()
    {
    }

    public QuanCaPheDbContext(DbContextOptions<QuanCaPheDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Mon> Mons { get; set; } = null!;
    public virtual DbSet<HoaDon> HoaDons { get; set; } = null!;
    public virtual DbSet<ChiTietHoaDon> ChiTietHoaDons { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(DefaultConnectionString);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Mon>(entity =>
        {
            entity.HasKey(e => e.MaMon).HasName("PK_Mon");
            entity.Property(e => e.DonGia).HasColumnType("decimal(18, 0)");
        });

        modelBuilder.Entity<HoaDon>(entity =>
        {
            entity.HasKey(e => e.MaHD).HasName("PK_HoaDon");
            entity.Property(e => e.NgayLap).HasColumnType("datetime");
        });

        modelBuilder.Entity<ChiTietHoaDon>(entity =>
        {
            entity.HasKey(e => e.MaCT).HasName("PK_ChiTietHoaDon");
            entity.Property(e => e.DonGia).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.HoaDon)
                .WithMany(p => p.ChiTietHoaDons)
                .HasForeignKey(d => d.MaHD)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_ChiTietHoaDon_HoaDon");

            entity.HasOne(d => d.Mon)
                .WithMany(p => p.ChiTietHoaDons)
                .HasForeignKey(d => d.MaMon)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ChiTietHoaDon_Mon");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
