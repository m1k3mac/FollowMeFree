using Microsoft.EntityFrameworkCore;

namespace FollowMeFree.WorkerService.Data
{
    public partial class FollowMeFreeDbContext : DbContext
    {
        public FollowMeFreeDbContext(DbContextOptions<FollowMeFreeDbContext> options)
            : base(options)
        {
        }

        public DbSet<LogEntry> Logs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LogEntry>(entity =>
            {
                entity.ToTable("Logs");

                entity.HasIndex(e => e.Source, "IX_Logs_Source");

                entity.HasIndex(e => new { e.Source, e.Timestamp }, "IX_Logs_Source_Timestamp")
                    .IsDescending(false, true);

                entity.HasIndex(e => e.Timestamp, "IX_Logs_Timestamp")
                    .IsDescending();

                entity.Property(e => e.Category).HasMaxLength(256);
                entity.Property(e => e.LogLevel).HasMaxLength(20);
                entity.Property(e => e.Source).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
