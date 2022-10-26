using API_Workshop.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Workshop
{
    public class VideoGameContext : DbContext
    {
        public DbSet<VideoGame>? VideoGames { get; set; }
        public DbSet<Studio>? Studios { get; set; }
        public DbSet<MainCharacter>? MainCharacters { get; set; }
        public DbSet<Tag>? Tags { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Server=(localdb)\\mssqllocaldb;Database=VGDB_example;Trusted_Connection=True;";
            optionsBuilder.UseSqlServer(connectionString).UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // insert seed data here
            modelBuilder.Entity<VideoGame>().HasData(
                new VideoGame() { Id = 1, MainCharacterId = 1, StudioId = 1, Title = "Super Mario Brothers" }
                );
            modelBuilder.Entity<Studio>().HasData(
                new Studio() { Id = 1, Name = "Nintendo", EmployeeCount = 6500}
                );
            modelBuilder.Entity<MainCharacter>().HasData(
                new MainCharacter() { Id = 1, Name = "Mario" }
                );
            modelBuilder.Entity<Tag>().HasData(
                new Tag() { Id = 1, Name = "Platformer" }
                );
            //modelBuilder.Entity<GameTag>().HasKey(gt => new { gt.TagId, gt.VideoGameId });

            base.OnModelCreating(modelBuilder);
        }
    }
}
