using meli.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace meli.Persistence
{
    public class MeliDbContext : DbContext
    {
        public DbSet<Feature> Features { get; set; }
        public DbSet<Maker> Makers { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Model> Models { get; set; }
        public MeliDbContext(DbContextOptions<MeliDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<VehicleFeature>().HasKey(vf => 
              new { vf.VehicleId, vf.FeatureId });
        }
    }
}