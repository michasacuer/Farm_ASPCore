using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Farm_ASPCore_Webapi.Models
{
    public class Memento
    {
        private Farm state;

        public Memento(Farm state)
        {
            this.state = state;
        }
        public Farm getState()
        {
            return state;
        }
    }
}
