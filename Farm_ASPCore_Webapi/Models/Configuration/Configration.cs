﻿using System;
using Farm_ASPCore_Webapi.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace Farm_ASPCore_Webapi.Models.Configuration
{
    public static class Configration
    {
        /// <summary>
        /// Method for seeding DataBase. Seed populate new DB in values
        /// </summary>
        /// <param name="modelBuilder"></param>
        public static void Seed(this ModelBuilder modelBuilder)
        {
            Random random = new Random();
            int doubleRange = 20; // for doubles
            FarmStrategy farmStrategy = new FarmStrategy();
            CultivationStrategy cultivationStrategy = new CultivationStrategy();

            int countOfWorkers = 6;
            int countOfMachines = MachineObjectPool.MaxPoolSize;
            double budgetValue = 100000;

            //Farm
            modelBuilder.Entity<Farm>().HasData(Farm.GetFarm());

            //Budget
            var budget = Budget.GetBudget();
            budget.Value = budgetValue;
            modelBuilder.Entity<Budget>().HasData(Budget.GetBudget());

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
                    DaysOfWork = random.Next(1, 31)
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
                    DaysOfWork = random.Next(1, 31)
                };
                farmer.BaseSalary = farmer.CountBaseSalary();
                modelBuilder.Entity<Farmer>().HasData(farmer);
            }
            
            //Stable
            modelBuilder.Entity<Stable>().HasData(new Stable { Id = 1, FarmId = 1 });

            //Cultivations
            modelBuilder.Entity<CultivationLeaf>().HasData(new CultivationLeaf { Id = 1, FarmId = 1 });

            //Machines
            for(int i = 0; i < countOfMachines; i++)
            {
                Array strategies = Enum.GetValues(typeof(Strategy));
                Machine machine = new Machine
                {
                    Id = i + 1,
                    FarmId = 1,
                    HoursPerDay = Math.Round((random.NextDouble() * doubleRange), 2),
                    DaysOfWork = random.Next(1, 31),
                    MappedStrategy = (Strategy)strategies.GetValue(random.Next(strategies.Length))
                };
                modelBuilder.Entity<Machine>().HasData(machine);
            }
        }
    }
}
