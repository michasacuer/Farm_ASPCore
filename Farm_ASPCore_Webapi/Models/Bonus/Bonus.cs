using System;

namespace Farm_ASPCore_Webapi.Models.Bonus
{
    public abstract class Bonus : Worker
    {
        public Bonus(Worker worker) => this.worker = worker;
        protected Worker worker { get; set; }

        public override string   FirstName       { get => worker.FirstName;       set { } }
        public override string   LastName        { get => worker.LastName;        set { } }
        public override DateTime StartOfContract { get => worker.StartOfContract; set { } }
        public override DateTime EndOfContract   { get => worker.EndOfContract;   set { } }
        public override double   UsdPerHour      { get => worker.UsdPerHour;      set { } }
        public override int      HoursPerDay     { get => worker.HoursPerDay;     set { } }
        public override int      DaysOfWork      { get => worker.DaysOfWork;      set { } }
        public override double   BaseSalary      { get => worker.BaseSalary;      set { } }

        public override double GetTaxes() => worker.GetTaxes();
    }
}
