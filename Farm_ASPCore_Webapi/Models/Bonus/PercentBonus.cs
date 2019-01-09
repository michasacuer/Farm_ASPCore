namespace Farm_ASPCore_Webapi.Models.Bonus
{
    public class PercentBonus : Bonus
    {
        public PercentBonus(Worker worker) : base(worker: worker) { }
        public override double Salary { get => worker.Salary * 1.20; set => worker.Salary = value; }
    }
}
