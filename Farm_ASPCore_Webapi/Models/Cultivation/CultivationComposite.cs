using Farm_ASPCore_Webapi.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Farm_ASPCore_Webapi.Models
{
    public class CultivationComposite : Cultivation
    {
        private List<ICultivation> cultivations;

        public CultivationComposite()
        {
            cultivations = new List<ICultivation>();
        }

        public override void Add(ICultivation cultivation)
        {
            cultivations.Add(cultivation);
        }

        public override void Harvest()
        {
            cultivations.ForEach(c => c.Harvest());
        }

        public override void Remove(ICultivation cultivation)
        {
            throw new InvalidOperationException("Can't remove child components from leaf cultivation");
        }

        public override void Sow(Grain grain)
        {
            cultivations.ForEach(c => c.Sow(grain));
        }
    }
}
