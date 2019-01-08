using System;

namespace Farm_ASPCore_Webapi.Models
{
    public class Farmer : Worker
    {
        public Farmer() => BaseSalary = CountBaseSalary();

        public override double Salary { get; set; }
        public override double BaseSalary { get; set; }

        public override double CountBaseSalary()
        {
            int basicEquipmentCost = 2000;
            return (UsdPerHour * HoursPerDay * DaysOfWork) - basicEquipmentCost;
        }
    }
}
