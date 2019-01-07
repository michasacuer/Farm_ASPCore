using Microsoft.EntityFrameworkCore;

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
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
