using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace THUVIEN_HTHA.Models
{
    public partial class ThuVienDB : DbContext
    {
        public ThuVienDB()
            : base("name=ThuVienDB3")
        {
        }

        public virtual DbSet<DANGNHAP> DANGNHAPs { get; set; }
        public virtual DbSet<DOCGIA> DOCGIAs { get; set; }
        public virtual DbSet<NHANVIEN> NHANVIENs { get; set; }
        public virtual DbSet<NHAXUATBAN> NHAXUATBANs { get; set; }
        public virtual DbSet<PHIEUMUONSACH> PHIEUMUONSACHes { get; set; }
        public virtual DbSet<PHIEUPHAT> PHIEUPHATs { get; set; }
        public virtual DbSet<SACH> SACHes { get; set; }
        public virtual DbSet<TACGIA> TACGIAs { get; set; }
        public virtual DbSet<THELOAI> THELOAIs { get; set; }
        public virtual DbSet<CTPHIEUMUONSACH> CTPHIEUMUONSACHes { get; set; }
        public virtual DbSet<CTPHIEUPHAT> CTPHIEUPHATs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DANGNHAP>()
                .Property(e => e.USERNAME)
                .IsUnicode(false);

            modelBuilder.Entity<DANGNHAP>()
                .Property(e => e.PASSWORD)
                .IsUnicode(false);

            modelBuilder.Entity<DANGNHAP>()
                .HasMany(e => e.NHANVIENs)
                .WithRequired(e => e.DANGNHAP)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DOCGIA>()
                .Property(e => e.MADOCGIA)
                .IsUnicode(false);

            modelBuilder.Entity<DOCGIA>()
                .Property(e => e.SDTDOCGIA)
                .IsUnicode(false);

            modelBuilder.Entity<DOCGIA>()
                .HasMany(e => e.PHIEUMUONSACHes)
                .WithRequired(e => e.DOCGIA)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DOCGIA>()
                .HasMany(e => e.PHIEUPHATs)
                .WithRequired(e => e.DOCGIA)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.MANHANVIEN)
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.SDTNHANVIEN)
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .HasMany(e => e.PHIEUMUONSACHes)
                .WithRequired(e => e.NHANVIEN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NHANVIEN>()
                .HasMany(e => e.PHIEUPHATs)
                .WithRequired(e => e.NHANVIEN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NHAXUATBAN>()
                .Property(e => e.MANHAXUATBAN)
                .IsUnicode(false);

            modelBuilder.Entity<NHAXUATBAN>()
                .Property(e => e.SODTNHAXUATBAN)
                .IsUnicode(false);

            modelBuilder.Entity<NHAXUATBAN>()
                .HasMany(e => e.SACHes)
                .WithRequired(e => e.NHAXUATBAN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PHIEUMUONSACH>()
                .Property(e => e.MAMUONSACH)
                .IsUnicode(false);

            modelBuilder.Entity<PHIEUMUONSACH>()
                .Property(e => e.MADOCGIA)
                .IsUnicode(false);

            modelBuilder.Entity<PHIEUMUONSACH>()
                .Property(e => e.MANHANVIEN)
                .IsUnicode(false);

            modelBuilder.Entity<PHIEUMUONSACH>()
                .HasMany(e => e.CTPHIEUMUONSACHes)
                .WithRequired(e => e.PHIEUMUONSACH)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PHIEUMUONSACH>()
                .HasMany(e => e.CTPHIEUPHATs)
                .WithRequired(e => e.PHIEUMUONSACH)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PHIEUMUONSACH>()
                .HasMany(e => e.PHIEUPHATs)
                .WithRequired(e => e.PHIEUMUONSACH)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PHIEUPHAT>()
                .Property(e => e.MAPHIEUPHAT)
                .IsUnicode(false);

            modelBuilder.Entity<PHIEUPHAT>()
                .Property(e => e.MADOCGIA)
                .IsUnicode(false);

            modelBuilder.Entity<PHIEUPHAT>()
                .Property(e => e.MANHANVIEN)
                .IsUnicode(false);

            modelBuilder.Entity<PHIEUPHAT>()
                .Property(e => e.MASACH)
                .IsUnicode(false);

            modelBuilder.Entity<PHIEUPHAT>()
                .Property(e => e.MAMUONSACH)
                .IsUnicode(false);

            modelBuilder.Entity<PHIEUPHAT>()
                .HasMany(e => e.CTPHIEUPHATs)
                .WithRequired(e => e.PHIEUPHAT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SACH>()
                .Property(e => e.MASACH)
                .IsUnicode(false);

            modelBuilder.Entity<SACH>()
                .Property(e => e.MANHAXUATBAN)
                .IsUnicode(false);

            modelBuilder.Entity<SACH>()
                .Property(e => e.MATHELOAI)
                .IsUnicode(false);

            modelBuilder.Entity<SACH>()
                .Property(e => e.MATACGIA)
                .IsUnicode(false);

            modelBuilder.Entity<SACH>()
                .HasMany(e => e.PHIEUPHATs)
                .WithRequired(e => e.SACH)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SACH>()
                .HasMany(e => e.CTPHIEUMUONSACHes)
                .WithRequired(e => e.SACH)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TACGIA>()
                .Property(e => e.MATACGIA)
                .IsUnicode(false);

            modelBuilder.Entity<TACGIA>()
                .HasMany(e => e.SACHes)
                .WithRequired(e => e.TACGIA)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<THELOAI>()
                .Property(e => e.MATHELOAI)
                .IsUnicode(false);

            modelBuilder.Entity<THELOAI>()
                .HasMany(e => e.SACHes)
                .WithRequired(e => e.THELOAI)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CTPHIEUMUONSACH>()
                .Property(e => e.MASACH)
                .IsUnicode(false);

            modelBuilder.Entity<CTPHIEUMUONSACH>()
                .Property(e => e.MAMUONSACH)
                .IsUnicode(false);

            modelBuilder.Entity<CTPHIEUPHAT>()
                .Property(e => e.MAPHIEUPHAT)
                .IsUnicode(false);

            modelBuilder.Entity<CTPHIEUPHAT>()
                .Property(e => e.MAMUONSACH)
                .IsUnicode(false);
        }
    }
}
