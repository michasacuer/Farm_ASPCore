using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Farm_ASPCore_Webapi.Models
{
    public class Memento
    {
        private string state;

        public Memento(string state)
        {
            this.state = state;
        }
        public string getState()
        {
            return state;
        }
    }
}
