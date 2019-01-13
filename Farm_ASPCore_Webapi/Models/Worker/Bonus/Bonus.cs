using Farm_ASPCore_Webapi.Models.Enums;
using System;

namespace Farm_ASPCore_Webapi.Models.Bonus
{
    public abstract class Bonus : Worker
    {
        public Bonus(Worker worker) => this.worker = worker;

        public          int      Id              { get => worker.Id;              set => worker.Id              = value; }
        public override Job      Kind            { get => worker.Kind;            set => worker.Kind            = value; }
        public override string   FirstName       { get => worker.FirstName;       set => worker.FirstName       = value; }
        public override string   LastName        { get => worker.LastName;        set => worker.LastName        = value; }   
        public override double   UsdPerHour      { get => worker.UsdPerHour;      set => worker.UsdPerHour      = value; }
        public override int      HoursPerDay     { get => worker.HoursPerDay;     set => worker.HoursPerDay     = value; }
        public override int      DaysOfWork      { get => worker.DaysOfWork;      set => worker.DaysOfWork      = value; }
        public override double   BaseSalary      { get => worker.BaseSalary;      set => worker.BaseSalary      = value; }

        public override double GetTaxes() => worker.GetTaxes();

        protected Worker worker { get; set; }
    }
}
