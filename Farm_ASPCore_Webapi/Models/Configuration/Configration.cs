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
            int doubleRange = 20; // for doubles

            int countOfWorkers = 10;

            modelBuilder.Entity<Farm>().HasData(Farm.GetFarm());

            //Drivers
            for (int i = 0; i < countOfWorkers; i++)
            {
                var driver = new Driver
                {
                    Id = i + 1,
                    FarmId = 1,
                    FirstName = "name" + i,
                    LastName = "lastname" + i,
                    UsdPerHour = Math.Round((random.NextDouble() * doubleRange), 2),
                    HoursPerDay = random.Next(1, 23),
                    DaysOfWork = random.Next(1, 31),
                    StartOfContract = new DateTime(random.Next(2015, 2018), random.Next(12) + 1, random.Next(25) + 1),
                    EndOfContract = new DateTime(random.Next(2015, 2018), random.Next(12) + 1, random.Next(25) + 1)
                };
                driver.BaseSalary = driver.CountBaseSalary();
                modelBuilder.Entity<Driver>().HasData(driver);
            }

            //Farmers
            for (int i = countOfWorkers; i < countOfWorkers + countOfWorkers; i++)
            {

                var farmer = new Farmer
                {
                    Id = i + 1,
                    FarmId = 1,
                    FirstName = "name" + i,
                    LastName = "lastname" + i,
                    UsdPerHour = Math.Round((random.NextDouble() * doubleRange), 2),
                    HoursPerDay = random.Next(1, 23),
                    DaysOfWork = random.Next(1, 31),
                    StartOfContract = new DateTime(random.Next(2015, 2018), random.Next(12) + 1, random.Next(25) + 1),
                    EndOfContract = new DateTime(random.Next(2015, 2018), random.Next(12) + 1, random.Next(25) + 1)
                };
                farmer.BaseSalary = farmer.CountBaseSalary();
                modelBuilder.Entity<Farmer>().HasData(farmer);
            }
            
            //Stable
            modelBuilder.Entity<Stable>().HasData(new Stable { Id = 1, FarmId = 1 });

            //Cultivations
        }
    }
}
