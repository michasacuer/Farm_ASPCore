using Farm_ASPCore_Webapi.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Farm_ASPCore_Webapi.Models
{
    public abstract class Cultivation
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Farm")]
        public int FarmId { get; }
        public Farm Farm { get; }

        [ForeignKey("Grain")]
        public int GrainId { get; private set; }
        public Grain Grain { get; private set; }

        public abstract void Sow(Grain grain);
        public abstract void Harvest();
        public abstract void Add(Cultivation cultivation);
        public abstract void Remove(Cultivation cultivation);
    }
}
