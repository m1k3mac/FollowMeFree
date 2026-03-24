using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FollowMeFree.WorkerService.Data.Scaffolded;

public partial class ScaffoldedDbContext : DbContext
{
    public ScaffoldedDbContext(DbContextOptions<ScaffoldedDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Config> Configs { get; set; }

    public virtual DbSet<Log> Logs { get; set; }

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

        modelBuilder.Entity<Log>(entity =>
        {
            entity.HasIndex(e => e.Source, "IX_Logs_Source");

            entity.HasIndex(e => new { e.Source, e.Timestamp }, "IX_Logs_Source_Timestamp").IsDescending(false, true);

            entity.HasIndex(e => e.Timestamp, "IX_Logs_Timestamp").IsDescending();

            entity.Property(e => e.Category).HasMaxLength(256);
            entity.Property(e => e.LogLevel).HasMaxLength(20);
            entity.Property(e => e.Source).HasMaxLength(50);
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
