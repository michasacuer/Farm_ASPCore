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
            Random random = new Random();
            int range = 20; // for doubles

            int countOfWorkers = 10;

            modelBuilder.Entity<Farm>().HasData(Farm.GetFarm());

            for (int i = 0; i < countOfWorkers; i++)
            {
                modelBuilder.Entity<Driver>().HasData(
                new Driver
                {
                    Id = i + 1,
                    FarmId = 1,
                    FirstName = "name" + i,
                    LastName = "lastname" + i,
                    UsdPerHour = 7.2,
                    HoursPerDay = 8,
                    DaysOfWork = 31
                });
            }

            for (int i = countOfWorkers; i < countOfWorkers + countOfWorkers; i++)
            {
                modelBuilder.Entity<Farmer>().HasData(
                new Farmer
                {
                    Id = i + 1,
                    FarmId = 1,
                    FirstName = "name" + i,
                    LastName = "lastname" + i,
                    UsdPerHour = 29.1,
                    HoursPerDay = 7,
                    DaysOfWork = 29
                });
            }

        }
    }
}
