namespace Farm_ASPCore_Webapi.Models
{
    public class Farmer : Worker
    {
        public Farmer() { Kind = Enums.Worker.Farmer; }
        public override double Salary { get; set; }

        public override double GetTaxes()
        {
            double incomeTax = 1.20;
            double healthCare = -500;
            return healthCare * incomeTax;
        }
    }
}
