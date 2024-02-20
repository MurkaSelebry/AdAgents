using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EmerAgency.adModels;

public partial class AdDbContext : DbContext
{
    public AdDbContext()
    {
    }

    public AdDbContext(DbContextOptions<AdDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Advertisement> Advertisements { get; set; }

    public virtual DbSet<Agent> Agents { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Transmission> Transmissions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;user id=root;password=12345;database=adDB", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.36-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Advertisement>(entity =>
        {
            entity.HasKey(e => e.AdCode).HasName("PRIMARY");

            entity.ToTable("advertisements");

            entity.HasIndex(e => e.AgentCode, "AgentCode");

            entity.HasIndex(e => e.ClientCode, "ClientCode");

            entity.HasIndex(e => e.TransmissionCode, "TransmissionCode");

            entity.Property(e => e.AdCode).ValueGeneratedNever();

            entity.HasOne(d => d.AgentCodeNavigation).WithMany(p => p.Advertisements)
                .HasForeignKey(d => d.AgentCode)
                .HasConstraintName("advertisements_ibfk_2");

            entity.HasOne(d => d.ClientCodeNavigation).WithMany(p => p.Advertisements)
                .HasForeignKey(d => d.ClientCode)
                .HasConstraintName("advertisements_ibfk_3");

            entity.HasOne(d => d.TransmissionCodeNavigation).WithMany(p => p.Advertisements)
                .HasForeignKey(d => d.TransmissionCode)
                .HasConstraintName("advertisements_ibfk_1");
        });

        modelBuilder.Entity<Agent>(entity =>
        {
            entity.HasKey(e => e.AgentCode).HasName("PRIMARY");

            entity.ToTable("agents");

            entity.Property(e => e.AgentCode).ValueGeneratedNever();
            entity.Property(e => e.BankDetails).HasMaxLength(255);
            entity.Property(e => e.CommissionRate).HasPrecision(5, 2);
            entity.Property(e => e.ContactPerson).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Phone).HasMaxLength(15);
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.ClientCode).HasName("PRIMARY");

            entity.ToTable("clients");

            entity.Property(e => e.ClientCode).ValueGeneratedNever();
            entity.Property(e => e.BankDetails).HasMaxLength(255);
            entity.Property(e => e.ContactPerson).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Phone).HasMaxLength(15);
        });

        modelBuilder.Entity<Transmission>(entity =>
        {
            entity.HasKey(e => e.TransmissionCode).HasName("PRIMARY");

            entity.ToTable("transmissions");

            entity.Property(e => e.TransmissionCode).ValueGeneratedNever();
            entity.Property(e => e.CostPerMinute).HasPrecision(5, 2);
            entity.Property(e => e.Title).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
