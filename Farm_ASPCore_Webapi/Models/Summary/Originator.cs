using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Farm_ASPCore_Webapi.Models
{
    public class Originator
    {
        public static Originator Instance { get; } = new Originator(); 

        public void SetState(Summary state) => this.state = state;
        public Summary GetState() => state;
        public Memento Save() => new Memento(state);
        public void GetStateFromMemento(Memento memento) => state = memento.GetState();

        private Summary state;
    }
}
