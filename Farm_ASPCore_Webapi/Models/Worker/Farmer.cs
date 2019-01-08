using System;

namespace Farm_ASPCore_Webapi.Models
{
    public class Farmer : Worker
    {
        public float UsdPerHour { get; set; }
        public int HoursPerDay { get; set; }
        public int DaysOfWork { get; set; }
        public float Salary { get; set; }

        public override float CountSalary()
        {
            throw new NotImplementedException();
        }
    }
}
