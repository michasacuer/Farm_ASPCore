using Farm_ASPCore_Webapi.Models.Enums;

namespace Farm_ASPCore_Webapi.Models
{
    public class Driver : Worker
    {
        public Driver() => Kind = Job.Driver;
        public override double Salary { get; set; }
     
        public override double GetTaxes()
        {
            double incomeTax = 1.15;
            double healthCare = -100;
            double equipmentCost = -200;
            return (healthCare + equipmentCost) * incomeTax;
        }
    }
}
