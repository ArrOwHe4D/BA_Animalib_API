using Microsoft.EntityFrameworkCore;
using AnimalibAPI.DataModels;

namespace AnimalibAPI
{
    public class AnimalibDbContext : DbContext
    {
        public AnimalibDbContext(DbContextOptions<AnimalibDbContext> options) : base(options) 
        {

        }

        public DbSet<Animal> Animals { get; set; }

        public DbSet<Region> Regions { get; set; }

        public DbSet<Species> Species { get; set; }        
    }
}
