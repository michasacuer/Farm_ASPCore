using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Farm_ASPCore_Webapi.Models
{
    public class Farmer : Worker
    {
        public float UsdPerHour = 9;
        public int HoursPerDay = 8;
        public int DaysOfWork = 20;

        public override float CountSalary()
        {
            throw new NotImplementedException();
        }
    }
}
