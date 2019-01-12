using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Farm_ASPCore_Webapi.Models
{
    public class Summary
    {
        public Summary(Farm farm)
        {

        }

        public int Id { get; set; }

        public double StablesCost { get; set; }
        public double MachinesCost { get; set; }
        public double WorkersCost { get; set; }

        public double CultivationIncome { get; set; }
    }
}
