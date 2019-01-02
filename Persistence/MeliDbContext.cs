using meli.Models;
using Microsoft.EntityFrameworkCore;

namespace meli.Persistence
{
    public class MeliDbContext : DbContext
    {
        public MeliDbContext(DbContextOptions<MeliDbContext> options) : base(options)
        {
            
        }

        public DbSet<Feature> Features { get; set; }
        public DbSet<Maker> Makers { get; set; }
    }
}