using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

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
        public static Farm GetInstance(FarmDbContext context)
        {
            if(!isPopulated)
            {
                isPopulated = true;
                farm.Stables = context.Stables.ToList();
                farm.Machines = context.Machines.ToList();
                farm.Workers = context.Workers.ToList();
                farm.Cultivations = context.Cultivations.ToList();

                Cultivation.Indexer = farm.Cultivations.Count();
                Worker.Indexer = farm.Workers.Count();
            }
            return farm;
        }

        private Farm() { }
        private static Farm farm = new Farm {  Name = "Farm" };
        private static bool isPopulated = false;
    }
}
