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
        public int Id { get; set; }

        [ForeignKey("Farm")]
        public int FarmId { get => 1; set { } }
        public Farm Farm   { get; set; }

        public virtual Grain Grain { get; set; }

        public abstract void Sow(Grain grain);
        public abstract void Harvest();
        public abstract (Cultivation, Cultivation, Cultivation) Split(double ratio);
        public abstract void Add(Cultivation cultivation);
        public abstract void Remove(Cultivation cultivation);
    }
}
