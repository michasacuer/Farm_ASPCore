using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Farm_ASPCore_Webapi.Models
{
    public class Summary
    {
        public double Budget           { get; set; } = 0;
        public double MachinesCost     { get; set; } = 0;
        public double WorkersCost      { get; set; } = 0;
        public double AnimalsCost      { get; set; } = 0;
        public double CultivationsCost { get; set; } = 0;
        public double SummaryCost      { get; set; } = 0;

        public void GetSummary(Farm farm)
        {
            foreach (Worker worker in farm.Workers)
                WorkersCost -= worker.GetCost();
            AnimalsCost -= Animals.GetAnimalsCost();
            SummaryCost = AnimalsCost + WorkersCost;

            foreach (Machine machine in farm.Machines)
                MachinesCost -= machine.GetCost();
        }
    }
}
