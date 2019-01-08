using Farm_ASPCore_Webapi.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Farm_ASPCore_Webapi.Models.Cultivation
{
    public class CultivationComposite : ICultivation
    {
        private List<ICultivation> cultivations;

        public CultivationComposite()
        {
            cultivations = new List<ICultivation>();
        }

        public void Add(ICultivation cultivation)
        {
            cultivations.Add(cultivation);
        }

        public void Harvest()
        {
            cultivations.ForEach(c => c.Harvest());
        }

        public void Remove(ICultivation cultivation)
        {
            throw new InvalidOperationException("Can't remove child components from leaf cultivation");
        }

        public void Sow(Grain grain)
        {
            cultivations.ForEach(c => c.Sow(grain));
        }
    }
}
