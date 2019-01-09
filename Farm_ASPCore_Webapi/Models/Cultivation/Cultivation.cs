using Farm_ASPCore_Webapi.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Farm_ASPCore_Webapi.Models
{
    public abstract class Cultivation
    {
        public abstract void Sow(Grain grain);
        public abstract void Harvest();
        public abstract void Add(Cultivation cultivation);
        public abstract void Remove(Cultivation cultivation);
    }
}
