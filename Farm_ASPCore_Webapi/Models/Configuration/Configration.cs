using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Farm_ASPCore_Webapi.Models;

namespace Farm_ASPCore_Webapi.Models.Configuration
{
    public static class Configration
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            int countOfDrivers = 0;
            int countOfFarmer = 0;
            for (int i = 0; i < countOfDrivers; i++)
            {
                modelBuilder.Entity<Driver>().HasData(
               new Driver
               {

               });
            }
            for (int i = 0; i < countOfFarmer; i++)
            {
                modelBuilder.Entity<Farmer>().HasData(
               new Farmer
               {

               });
            }
        }
    }
}
