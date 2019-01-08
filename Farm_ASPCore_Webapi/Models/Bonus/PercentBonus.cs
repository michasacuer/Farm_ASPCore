using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Farm_ASPCore_Webapi.Models.Bonus
{
    public class PercentBonus : Bonus
    {
        public PercentBonus(Worker worker) : base(worker: worker) { }
        public override float Salary { get => worker.Salary * (float)1.20; set { } }

        //public override float CountSalary() => base.worker.CountSalary() * (float)1.20;
    }
}
