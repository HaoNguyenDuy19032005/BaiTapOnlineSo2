using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BaiTap4OnlineSo2.Models
{
    public partial class BaiTapOnlineSo2Context : DbContext
    {
        public BaiTapOnlineSo2Context()
        {
        }

        public BaiTapOnlineSo2Context(DbContextOptions<BaiTapOnlineSo2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Assignment> Assignments { get; set; } = null!;
        public virtual DbSet<Device> Devices { get; set; } = null!;
        public virtual DbSet<Service> Services { get; set; } = null!;
        public virtual DbSet<ThongkeDichvu> ThongkeDichvus { get; set; } = null!;
        public virtual DbSet<ThongkeNhiemvuTheothietbi> ThongkeNhiemvuTheothietbis { get; set; } = null!;
        public virtual DbSet<ThongkeSudungNhiemvu> ThongkeSudungNhiemvus { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=BaiTapOnlineSo2;Username=postgres;Password=hao123");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Assignment>(entity =>
            {
                entity.HasKey(e => new { e.Code, e.Assignmentdate })
                    .HasName("assignments_pkey");

                entity.ToTable("assignments");

                entity.Property(e => e.Code).HasColumnName("code");

                entity.Property(e => e.Assignmentdate).HasColumnName("assignmentdate");

                entity.Property(e => e.Customeremail).HasColumnName("customeremail");

                entity.Property(e => e.Customername).HasColumnName("customername");

                entity.Property(e => e.Devicecode).HasColumnName("devicecode");

                entity.Property(e => e.Expiredate).HasColumnName("expiredate");

                entity.Property(e => e.Servicecode).HasColumnName("servicecode");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Telephone).HasColumnName("telephone");

                entity.HasOne(d => d.DevicecodeNavigation)
                    .WithMany(p => p.Assignments)
                    .HasForeignKey(d => d.Devicecode)
                    .HasConstraintName("assignments_devicecode_fkey");

                entity.HasOne(d => d.ServicecodeNavigation)
                    .WithMany(p => p.Assignments)
                    .HasForeignKey(d => d.Servicecode)
                    .HasConstraintName("assignments_servicecode_fkey");
            });

            modelBuilder.Entity<Device>(entity =>
            {
                entity.HasKey(e => e.Devicecode)
                    .HasName("devices_pkey");

                entity.ToTable("devices");

                entity.Property(e => e.Devicecode).HasColumnName("devicecode");

                entity.Property(e => e.Connected).HasColumnName("connected");

                entity.Property(e => e.Devicename).HasColumnName("devicename");

                entity.Property(e => e.Ipaddress).HasColumnName("ipaddress");

                entity.Property(e => e.Operationstatus).HasColumnName("operationstatus");

                entity.Property(e => e.Password).HasColumnName("password");

                entity.Property(e => e.Username).HasColumnName("username");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.HasKey(e => e.Servicecode)
                    .HasName("services_pkey");

                entity.ToTable("services");

                entity.Property(e => e.Servicecode).HasColumnName("servicecode");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Isinoperation).HasColumnName("isinoperation");

                entity.Property(e => e.Servicename).HasColumnName("servicename");
            });

            modelBuilder.Entity<ThongkeDichvu>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("thongke_dichvu");

                entity.Property(e => e.Servicecode).HasColumnName("servicecode");

                entity.Property(e => e.Servicename).HasColumnName("servicename");

                entity.Property(e => e.Total2024).HasColumnName("total_2024");

                entity.Property(e => e.TotalCurrentweek).HasColumnName("total_currentweek");

                entity.Property(e => e.TotalDec2024).HasColumnName("total_dec2024");
            });

            modelBuilder.Entity<ThongkeNhiemvuTheothietbi>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("thongke_nhiemvu_theothietbi");

                entity.Property(e => e.Devicecode).HasColumnName("devicecode");

                entity.Property(e => e.Devicename).HasColumnName("devicename");

                entity.Property(e => e.TongsoNhiemvu).HasColumnName("tongso_nhiemvu");
            });

            modelBuilder.Entity<ThongkeSudungNhiemvu>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("thongke_sudung_nhiemvu");

                entity.Property(e => e.SoluongChuasudung).HasColumnName("soluong_chuasudung");

                entity.Property(e => e.SoluongDasudung).HasColumnName("soluong_dasudung");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
