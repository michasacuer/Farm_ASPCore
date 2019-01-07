using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Farm_ASPCore_Webapi.Models
{
    public class Caretaker
    {
        private List<Memento> mementos = new List<Memento>();

        public void addMemento(Memento m)
        {
            mementos.Add(m);
        }
        public Memento getMemento(int index)
        {
            return mementos[index];
        }
    }
}
