using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace UCP1_PAW_004_A.Models
{
    public partial class RentKomikContext : DbContext
    {
        public RentKomikContext()
        {
        }

        public RentKomikContext(DbContextOptions<RentKomikContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Komik> Komiks { get; set; }
        public virtual DbSet<Penyewaan> Penyewaans { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasKey(e => e.IdAdmin);

                entity.ToTable("Admin");

                entity.Property(e => e.IdAdmin)
                    .ValueGeneratedNever()
                    .HasColumnName("Id_admin");

                entity.Property(e => e.NamaAdmin)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Nama_admin");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.IdCustomer);

                entity.ToTable("Customer");

                entity.Property(e => e.IdCustomer)
                    .ValueGeneratedNever()
                    .HasColumnName("Id_customer");

                entity.Property(e => e.Alamat)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.NamaCustomer)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Nama_customer");

                entity.Property(e => e.Telepon)
                    .HasMaxLength(13)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Komik>(entity =>
            {
                entity.HasKey(e => e.NoKomik);

                entity.ToTable("Komik");

                entity.Property(e => e.NoKomik)
                    .ValueGeneratedNever()
                    .HasColumnName("No_komik");

                entity.Property(e => e.NamaKomik)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Nama_komik");

                entity.Property(e => e.Penerbit)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Pengarang)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Penyewaan>(entity =>
            {
                entity.HasKey(e => e.IdSewa);

                entity.ToTable("Penyewaan");

                entity.Property(e => e.IdSewa)
                    .ValueGeneratedNever()
                    .HasColumnName("Id_sewa");

                entity.Property(e => e.IdAdmin).HasColumnName("Id_admin");

                entity.Property(e => e.IdCustomer).HasColumnName("Id_customer");

                entity.Property(e => e.NoKomik).HasColumnName("No_komik");

                entity.Property(e => e.Tanggal).HasColumnType("datetime");

                entity.HasOne(d => d.IdAdminNavigation)
                    .WithMany(p => p.Penyewaans)
                    .HasForeignKey(d => d.IdAdmin)
                    .HasConstraintName("FK_Penyewaan_Admin");

                entity.HasOne(d => d.IdCustomerNavigation)
                    .WithMany(p => p.Penyewaans)
                    .HasForeignKey(d => d.IdCustomer)
                    .HasConstraintName("FK_Penyewaan_Customer");

                entity.HasOne(d => d.NoKomikNavigation)
                    .WithMany(p => p.Penyewaans)
                    .HasForeignKey(d => d.NoKomik)
                    .HasConstraintName("FK_Penyewaan_Komik");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
