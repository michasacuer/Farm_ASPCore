using Farm_ASPCore_Webapi.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Farm_ASPCore_Webapi.Models
{
    public class FarmStrategy : IWorkStrategy
    {
        public int TimeOfWork() => hours * hours;
        //to edit!

        private int hours = 10;
    }
}
