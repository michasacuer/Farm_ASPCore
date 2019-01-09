namespace Farm_ASPCore_Webapi.Models
{
    public class Driver : Worker
    {
        //public Driver() => BaseSalary = CountBaseSalary();

        public override double Salary     { get; set; }
        public override double BaseSalary { get; set; }

        //public override double CountBaseSalary()
        //{
        //    double pensionContribution = 0.92;
        //    double gettingIncome = 98.5;
        //    return (UsdPerHour* HoursPerDay *DaysOfWork) * pensionContribution * gettingIncome;
        //}
    }
}
