using Farm_ASPCore_Webapi.Models.Enums;
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
        public abstract int Id { get; set; }

        [ForeignKey("Farm")]
        public int FarmId { get; }
        public Farm Farm  { get; }

        public Grain Grain { get; private set; }

        public abstract void Sow(Grain grain);
        public abstract void Harvest();
        public abstract void Add(Cultivation cultivation);
        public abstract void Remove(Cultivation cultivation);
    }
}
