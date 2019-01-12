using Farm_ASPCore_Webapi.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Farm_ASPCore_Webapi.Models
{
    public class CultivationStrategy : IWorkStrategy
    {
        public double TimeOfWork(int hours) => hours * hours - refuelTime;

        private double refuelTime = 10;
    }
}
