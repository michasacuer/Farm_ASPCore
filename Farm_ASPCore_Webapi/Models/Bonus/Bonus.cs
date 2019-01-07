using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Farm_ASPCore_Webapi.Models.Bonus
{
    public abstract class Bonus : Worker
    {
        public Bonus() { }
        public Bonus(Worker worker) => worker = this.worker;
        
        private Worker worker { get; set; }
    }
}
