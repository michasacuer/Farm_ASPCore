using Farm_ASPCore_Webapi.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Farm_ASPCore_Webapi.Models
{
    public class CultivationLeaf : ICultivation
    {
        [Key]
        public int Id { get; }

        [ForeignKey("Farm")]
        public int FarmId { get; }
        public Farm Farm { get; }

        [ForeignKey("Grain")]
        public int GrainId { get; private set; }
        public Grain Grain { get; private set; }

        private readonly ICultivation parent;

        public CultivationLeaf(ICultivation parent)
        {
            //Id = Farm.GetFarm().Cultivations.Count;
            Farm = Farm.GetFarm();
            Grain = null;
            this.parent = parent;
        }

        public void Add(ICultivation cultivations)
        {
            CultivationComposite cultivationComposite = new CultivationComposite();
            cultivationComposite.Add(this);
            parent.Remove(this);
            parent.Add(cultivationComposite);
        }

        public void Harvest()
        {
            Grain = null;
        }

        public void Sow(Grain grain)
        {
            Grain = grain;
        }

        public void Remove(ICultivation cultivation)
        {
            throw new NotImplementedException();
        }
    }
}
