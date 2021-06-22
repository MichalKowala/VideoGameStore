using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameStore.Domain.Entities;
using VideoGameStore.Persistance.EntitiesConfiguration;

namespace VideoGameStore.Persistance
{
    public class VideoGameStoreDbContext : DbContext
    {
        public IConfiguration _config;
        public VideoGameStoreDbContext(IConfiguration config)
        {
            _config = config;
        }
        public DbSet<VideoGame> VideoGames { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Developer> Developers { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_config.GetConnectionString("VideoGameStoreDb"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AddressConfiguration());
            modelBuilder.ApplyConfiguration(new DeveloperConfiguration());
            modelBuilder.ApplyConfiguration(new PublisherConfiguration());
            modelBuilder.ApplyConfiguration(new VideoGameConfiguration());
        }
    }
}
