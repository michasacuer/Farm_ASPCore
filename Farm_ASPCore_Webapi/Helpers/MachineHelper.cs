using Farm_ASPCore_Webapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Farm_ASPCore_Webapi
{
    public static class MachineHelper
    {
        public static List<Machine> GetPool(int poolSize) => Enumerable.Repeat(new Machine(), poolSize).ToList();
    }
}
