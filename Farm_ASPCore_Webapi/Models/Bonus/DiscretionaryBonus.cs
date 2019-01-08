using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Farm_ASPCore_Webapi.Models.Bonus
{
    public class DiscretionaryBonus : Bonus
    {
        public DiscretionaryBonus(Worker worker) : base(worker: worker) { }

        public override float CountSalary() => base.worker.CountSalary();
    }
}
