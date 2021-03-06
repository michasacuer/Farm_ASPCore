﻿using Microsoft.EntityFrameworkCore;
using Farm_ASPCore_Webapi.Models.Configuration;

namespace Farm_ASPCore_Webapi.Models
{
    public class FarmDbContext : DbContext
    {
        public FarmDbContext(DbContextOptions<FarmDbContext> options) : base(options) { }

        public DbSet<Farm>        Farms        { get; set; }
        public DbSet<Machine>     Machines     { get; set; }
        public DbSet<Stable>      Stables      { get; set; }
        public DbSet<Worker>      Workers      { get; set; }
        public DbSet<Cultivation> Cultivations { get; set; }
        public DbSet<Budget>      Budgets      { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Driver>();
            builder.Entity<Farmer>();

            builder.Entity<CultivationLeaf>();
            builder.Entity<CultivationComposite>();

            builder.Seed();
            base.OnModelCreating(builder);
        }
    }
}


