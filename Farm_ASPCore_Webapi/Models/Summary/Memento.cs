using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Farm_ASPCore_Webapi.Models
{
    public class Memento
    {
        public Memento(Summary state, int id)
        {
            Id = id;
            this.state = state;
        }

        public int Id { get; set; }
        public Summary GetState() => state;

        private Summary state;
    }
}
