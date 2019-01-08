using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Farm_ASPCore_Webapi.Models.Cultivation
{
    public class CultivationLeaf : ICultivation
    {
        [Key]
        public int Id { get; }

        [ForeignKey("Farm")]
        public int FarmId { get; }
        public Farm Farm { get; }

        public CultivationLeaf()
        {
            Id = Farm.GetFarm().Cultivations.Count;
        }

        public void Add()
        {
            throw new NotImplementedException();
        }

        public void Harvest()
        {
            throw new NotImplementedException();
        }

        public void Plow()
        {
            throw new NotImplementedException();
        }

        public void Sow()
        {
            throw new NotImplementedException();
        }
    }
}
