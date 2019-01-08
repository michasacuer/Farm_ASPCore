using System;

namespace Farm_ASPCore_Webapi.Models
{
    public class Driver : Worker
    {
        public float UsdPerHour { get; set; }
        public int HoursPerDay { get; set; }
        public int DaysOfWork { get; set; }
        public override float Salary { get; set; }
        public override float BaseSalary { get; set; }

        //public override float CountSalary() => Salary = 3000;
    }
}
