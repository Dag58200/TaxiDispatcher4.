using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace TaxiDispatcher4;

public partial class TaxiContext : DbContext
{
    public TaxiContext()
    {
    }

    public TaxiContext(DbContextOptions<TaxiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Login> Logins { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<TaxiDriver> TaxiDrivers { get; set; }

  

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;port=3306;user=root;password=student;database=taxi", Microsoft.EntityFrameworkCore.ServerVersion.Parse("11.3.2-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("latin1_swedish_ci")
            .HasCharSet("latin1");

        modelBuilder.Entity<Login>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("login")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_general_ci");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnType("int(11)");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.FirstName).HasMaxLength(255);
            entity.Property(e => e.Gpa)
                .HasPrecision(10)
                .HasColumnName("GPA");
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.RoleId).HasColumnType("int(11)");

        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("role")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_general_ci");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnType("int(11)");
            entity.Property(e => e.Title).HasMaxLength(255);

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Role)
                .HasForeignKey<Role>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<TaxiDriver>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("taxi_drivers");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.CarClass)
                .HasMaxLength(50)
                .HasColumnName("car_class");
            entity.Property(e => e.CarNumber)
                .HasMaxLength(50)
                .HasColumnName("car_number");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
        }); }

      

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
