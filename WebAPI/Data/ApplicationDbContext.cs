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
        public DbSet<StoreDetails> StoreDetails { get; set; }  // ✅ Toegevoegd
        public DbSet<GameStore> GameStores { get; set; }  // ✅ Toegevoegd
        public DbSet<EsrbRating> EsrbRating { get; set; } 

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

            // ✅ Relaties voor GameStore en StoreDetails toegevoegd
            modelBuilder.Entity<GameStore>()
                .HasOne(gs => gs.Store)
                .WithMany(s => s.GameStores)
                .HasForeignKey(gs => gs.StoreId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<GameStore>()
                .HasOne(gs => gs.Game)
                .WithMany(g => g.GameStores)
                .HasForeignKey(gs => gs.GameId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
