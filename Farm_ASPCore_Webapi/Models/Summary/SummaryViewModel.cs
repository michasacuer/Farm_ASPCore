using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Farm_ASPCore_Webapi.Models
{
    public class SummaryViewModel
    {
        public double Budget           { get; set; }
        public double MachinesCost     { get; set; } 
        public double WorkersCost      { get; set; } 
        public double AnimalsCost      { get; set; } 
        public double CultivationsCost { get; set; }
        public double SummaryCost      { get; set; } 
        public double Balance          { get; set; }
    }
}
