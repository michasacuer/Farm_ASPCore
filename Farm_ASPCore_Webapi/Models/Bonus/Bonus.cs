using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Farm_ASPCore_Webapi.Models.Bonus
{
    public abstract class Bonus : Worker
    {
        public Bonus(Worker worker) => this.worker = worker;
        //public override float CountSalary() => worker.Salary;

        protected Worker worker { get; private set; }
    }
}
