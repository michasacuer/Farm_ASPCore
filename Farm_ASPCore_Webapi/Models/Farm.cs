using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Farm_ASPCore_Webapi.Models
{
    public class Farm
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual List<Stable> Stables { get; set; }
        public virtual List<Machine> Machines { get; set; }
        public virtual List<Farmer> Farmers { get; set; }
        public virtual List<Driver> Drivers { get; set; }
        public virtual List<Cultivation> Cultivations { get; set; }

        public Farm GetFarm() => farm;

        private Farm farm;
        private Farm() { }
    }
}
