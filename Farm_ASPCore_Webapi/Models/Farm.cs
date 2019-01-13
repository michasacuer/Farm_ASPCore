using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Farm_ASPCore_Webapi.Models
{
    public class Farm
    {
        [Key]
        public int    Id   { get => 1; set { } }
        public string Name { get; set; }

        public virtual List<Stable>      Stables      { get; set; }
        public virtual List<Machine>     Machines     { get; set; }
        public virtual List<Worker>      Workers      { get; set; }
        public virtual List<Cultivation> Cultivations { get; set; }

        public static Farm GetFarm() => farm;

        private Farm() { }
        private static Farm farm = new Farm {  Name = "Farm" };
    }
}
