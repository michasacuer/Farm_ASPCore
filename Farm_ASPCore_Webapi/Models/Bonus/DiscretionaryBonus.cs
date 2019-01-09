namespace Farm_ASPCore_Webapi.Models.Bonus
{
    public class DiscretionaryBonus : Bonus
    {
        public DiscretionaryBonus(Worker worker) : base(worker: worker) { }
        public override double Salary { get => worker.Salary + 1000; set { } }
    }
}
