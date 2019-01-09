using Farm_ASPCore_Webapi.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Farm_ASPCore_Webapi.Models
{
    public class CultivationLeaf : Cultivation
    {
        public Cultivation Parent { get; set; }

        public CultivationLeaf() { }
        public CultivationLeaf(Cultivation parent)
        {
            //Id = Farm.GetFarm().Cultivations.Count;
            //farm = Farm.GetFarm();
            grain = null;
            this.Parent = parent;
        }

        public override void Add(Cultivation cultivations)
        {
            CultivationComposite cultivationComposite = new CultivationComposite();
            cultivationComposite.Add(this);
            Parent.Remove(this);
            Parent.Add(cultivationComposite);
        }

        public override void Harvest()
        {
            grain = null;
        }

        public override void Sow(Grain grain)
        {
            this.grain = grain;
        }

        public override void Remove(Cultivation cultivation)
        {
            throw new NotImplementedException();
        }
        
        private Farm farm { get => Farm; set => this.farm = value; }
        private Grain grain { get => Grain; set => this.grain = value; }
    }
}
