using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Farm_ASPCore_Webapi.Models
{
    public class Memento
    {
        public int Id { get; set; }
        public Memento(Summary state) => this.state = state;
        public Summary GetState() => state;

        private Summary state;
    }
}
