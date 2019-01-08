using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Farm_ASPCore_Webapi.Models;
using Farm_ASPCore_Webapi.Models.Bonus;

namespace Farm_ASPCore_Webapi.Models.Configuration
{
    public static class Configration
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            
            int countOfDrivers = 10;
            int countOfFarmer = 10;

            modelBuilder.Entity<Farm>().HasData(
                Farm.GetFarm());

            modelBuilder.Entity<Driver>().HasData(
            new Driver
            {
                Id = 1,
                FarmId = 1,
                FirstName = "Czarek",
                Salary = 1000
            });

            modelBuilder.Entity<Farmer>().HasData(
            new Farmer
            {
                Id = 2,
                FarmId = 1,
                FirstName = "Michał",
                Salary = 15000
            });

        }
    }
}
