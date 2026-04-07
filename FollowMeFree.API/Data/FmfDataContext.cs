using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FollowMeFree.API.Data;

public partial class FmfDataContext : DbContext
{
    public FmfDataContext(DbContextOptions<FmfDataContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Config> Configs { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Log> Logs { get; set; }

    public virtual DbSet<PrintJob> PrintJobs { get; set; }

    public virtual DbSet<Printer> Printers { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Config>(entity =>
        {
            entity.ToTable("Config");

            entity.Property(e => e.ApiallowedNetwork)
                .IsUnicode(false)
                .HasColumnName("APIAllowedNetwork");
            entity.Property(e => e.FmfprinterName)
                .IsUnicode(false)
                .HasColumnName("FMFPrinterName");
            entity.Property(e => e.JobFilePath).IsUnicode(false);
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.Property(e => e.DepartmentName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Log>(entity =>
        {
            entity.Property(e => e.Category).HasMaxLength(256);
            entity.Property(e => e.LogLevel).HasMaxLength(20);
            entity.Property(e => e.Source).HasMaxLength(50);
        });

        modelBuilder.Entity<PrintJob>(entity =>
        {
            entity.Property(e => e.DataType).IsUnicode(false);
            entity.Property(e => e.DateTimePrinted).HasPrecision(0);
            entity.Property(e => e.DocumentName).IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Department).WithMany(p => p.PrintJobs)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK_PrintJobs_Departments");
        });

        modelBuilder.Entity<Printer>(entity =>
        {
            entity.Property(e => e.Printer1)
                .IsUnicode(false)
                .HasColumnName("Printer");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.AllowedPrinterIds).IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Pin).HasColumnName("PIN");
            entity.Property(e => e.Surname)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Department).WithMany(p => p.Users)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Users_Departments");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
