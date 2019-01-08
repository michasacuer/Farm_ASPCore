using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Farm_ASPCore_Webapi.Models.Bonus
{
    public class AmountBonus : Bonus
    {
        public AmountBonus(Worker worker) : base(worker: worker){ }
        public override double Salary { get => worker.Salary + 200; set { } }
    }
}
