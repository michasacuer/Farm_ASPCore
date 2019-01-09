using System;

namespace Farm_ASPCore_Webapi.Models.Bonus
{
    public abstract class Bonus : Worker
    {
        public Bonus(Worker worker) => this.worker = worker;

        public override string   FirstName       { get => worker.FirstName;       set => worker.FirstName       = value; }
        public override string   LastName        { get => worker.LastName;        set => worker.LastName        = value; }
        public override DateTime StartOfContract { get => worker.StartOfContract; set => worker.StartOfContract = value; }
        public override DateTime EndOfContract   { get => worker.EndOfContract;   set => worker.EndOfContract   = value; }
        public override double   UsdPerHour      { get => worker.UsdPerHour;      set => worker.UsdPerHour      = value; }
        public override int      HoursPerDay     { get => worker.HoursPerDay;     set => worker.HoursPerDay     = value; }
        public override int      DaysOfWork      { get => worker.DaysOfWork;      set => worker.DaysOfWork      = value; }
        public override double   BaseSalary      { get => worker.BaseSalary;      set => worker.BaseSalary      = value; }

        public override double GetTaxes() => worker.GetTaxes();

        protected Worker worker { get; set; }
    }
}
