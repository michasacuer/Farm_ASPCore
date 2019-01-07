using Microsoft.EntityFrameworkCore;
using Farm_ASPCore_Webapi.Models;

namespace Farm_ASPCore_Webapi.Models
{
    public class FarmDbContext : DbContext
    {
        public FarmDbContext(DbContextOptions<FarmDbContext> options) : base(options) { }

        public DbSet<Farm> Farms { get; set; }
        public DbSet<Machine> Machines { get; set; }
        public DbSet<Stable> Stables { get; set; }
        public DbSet<Worker> Workers { get; set; }
        //public DbSet<Farmer> Farmers { get; set; }
        //public DbSet<Driver> Drivers { get; set; }
        public DbSet<Cultivation> Cultivations { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Driver>();
            builder.Entity<Farmer>();

            base.OnModelCreating(builder);
        }
    }
}
