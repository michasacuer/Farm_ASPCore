using Farm_ASPCore_Webapi.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Farm_ASPCore_Webapi.Models
{
    public class CultivationComposite : Cultivation
    {
        private List<Cultivation> cultivations;

        public CultivationComposite()
        {
            cultivations = new List<Cultivation>();
        }

        public override void Add(Cultivation cultivation)
        {
            cultivations.Add(cultivation);
        }

        public override void Harvest()
        {
            cultivations.ForEach(c => c.Harvest());
        }

        public override void Remove(Cultivation cultivation)
        {
            cultivations.Remove(cultivation);
        }

        public override void Sow(Grain grain)
        {
            cultivations.ForEach(c => c.Sow(grain));
        }
    }
}
