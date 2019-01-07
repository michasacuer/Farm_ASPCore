using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Farm_ASPCore_Webapi.Models
{
    public class Driver : Worker
    {
        public float UsdPerHour = 10;
        public int HoursPerDay = 7;
        public int DaysOfWork = 18;

        override public float CountSalary()
        {
            throw new NotImplementedException();
        }
    }
}
