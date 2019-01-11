using Farm_ASPCore_Webapi.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Farm_ASPCore_Webapi.Models
{
    public class CultivationViewModel
    {
        public int    Id          { get; set; }
        public string Grain       { get; set; }
        public int    CompositeId { get; set; }
    }
}
