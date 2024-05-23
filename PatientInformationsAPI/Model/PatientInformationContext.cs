using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PatientInformationsAPI.Model;

public partial class PatientInformationContext : DbContext
{
    private readonly string _connectionstring;
    public PatientInformationContext()
    {
        
    }

    public PatientInformationContext(DbContextOptions<PatientInformationContext> options, IConfiguration config)
        : base(options)
    {
        _connectionstring = config.GetSection("Api")["ConnectionString"];
    }

    public virtual DbSet<AllergiesDetail> AllergiesDetails { get; set; }

    public virtual DbSet<Allergy> Allergies { get; set; }

    public virtual DbSet<DiseaseInformation> DiseaseInformations { get; set; }

    public virtual DbSet<Ncd> Ncds { get; set; }

    public virtual DbSet<NcdDetail> NcdDetails { get; set; }

    public virtual DbSet<PatientInformation> PatientInformations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(_connectionstring);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AllergiesDetail>(entity =>
        {
            entity.ToTable("Allergies_Details");

            entity.Property(e => e.Id).HasMaxLength(50);
            entity.Property(e => e.AllergieId).HasMaxLength(50);
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.ModifierDate).HasColumnType("datetime");
            entity.Property(e => e.PatientId).HasMaxLength(50);

            entity.HasOne(d => d.Allergie).WithMany(p => p.AllergiesDetails)
                .HasForeignKey(d => d.AllergieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Allergies_Details_Allergies");

            entity.HasOne(d => d.Patient).WithMany(p => p.AllergiesDetails)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Allergies_Details_PatientInformations");
        });

        modelBuilder.Entity<Allergy>(entity =>
        {
            entity.Property(e => e.Id).HasMaxLength(50);
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.Details).HasMaxLength(50);
            entity.Property(e => e.ModifierDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<DiseaseInformation>(entity =>
        {
            entity.Property(e => e.Id).HasMaxLength(50);
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.Details).HasMaxLength(50);
            entity.Property(e => e.ModifierDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Ncd>(entity =>
        {
            entity.ToTable("NCDs");

            entity.Property(e => e.Id).HasMaxLength(50);
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.Details).HasMaxLength(50);
            entity.Property(e => e.ModifierDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<NcdDetail>(entity =>
        {
            entity.ToTable("NCD_Details");

            entity.Property(e => e.Id).HasMaxLength(50);
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.ModifierDate).HasColumnType("datetime");
            entity.Property(e => e.Ncdid)
                .HasMaxLength(50)
                .HasColumnName("NCDId");
            entity.Property(e => e.PatientId).HasMaxLength(50);

            entity.HasOne(d => d.Ncd).WithMany(p => p.NcdDetails)
                .HasForeignKey(d => d.Ncdid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NCD_Details_NCDs");

            entity.HasOne(d => d.Patient).WithMany(p => p.NcdDetails)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NCD_Details_PatientInformations");
        });

        modelBuilder.Entity<PatientInformation>(entity =>
        {
            entity.Property(e => e.Id).HasMaxLength(50);
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.DiseaseId).HasMaxLength(50);
            entity.Property(e => e.ModifierDate).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(50);

            entity.HasOne(d => d.Disease).WithMany(p => p.PatientInformations)
                .HasForeignKey(d => d.DiseaseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PatientInformations_DiseaseInformations");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
