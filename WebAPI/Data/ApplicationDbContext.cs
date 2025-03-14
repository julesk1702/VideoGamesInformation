using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<Requirements> Requirements { get; set; }
        public DbSet<GameDetails> GameDetails { get; set; }

        // Add this constructor to accept DbContextOptions
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure one-to-one relationship between Platform and Requirements
            modelBuilder.Entity<Platform>()
                .HasOne(p => p.Requirements)
                .WithOne()
                .HasForeignKey<Platform>(p => p.RequirementsId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
