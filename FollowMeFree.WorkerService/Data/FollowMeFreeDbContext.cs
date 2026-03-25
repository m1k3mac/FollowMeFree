using System;
using System.Collections.Generic;
using FollowMeFree.WorkerService.Data.Scaffolded;
using Microsoft.EntityFrameworkCore;

namespace FollowMeFree.WorkerService.Data;

public partial class FollowMeFreeDbContext : DbContext
{
    public FollowMeFreeDbContext(DbContextOptions<FollowMeFreeDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Config> Configs { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Log> Logs { get; set; }

    public virtual DbSet<PrintJob> PrintJobs { get; set; }

    public virtual DbSet<Printer> Printers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Config>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Config");

            entity.Property(e => e.FmfprinterName)
                .IsUnicode(false)
                .HasColumnName("FMFPrinterName");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
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
            entity.HasIndex(e => e.Source, "IX_Logs_Source");

            entity.HasIndex(e => new { e.Source, e.Timestamp }, "IX_Logs_Source_Timestamp").IsDescending(false, true);

            entity.HasIndex(e => e.Timestamp, "IX_Logs_Timestamp").IsDescending();

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
            entity.HasNoKey();

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Printer1)
                .IsUnicode(false)
                .HasColumnName("Printer");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
