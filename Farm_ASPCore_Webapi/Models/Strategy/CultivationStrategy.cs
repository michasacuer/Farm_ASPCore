using Farm_ASPCore_Webapi.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Farm_ASPCore_Webapi.Models
{
    public class CultivationStrategy : WorkStrategy
    {
        public override double TimeOfWork(double hours) => hours * hours - refuelTime;

        private double refuelTime = 10;
    }
}
