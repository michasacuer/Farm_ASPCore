using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Farm_ASPCore_Webapi.Models
{
    public class Caretaker
    {
        public static Caretaker Instance { get; } = new Caretaker(); 

        public void Add(Memento state) => mementos.Add(state);
        public Memento Get(int id)     => mementos.SingleOrDefault(m => m.Id == id);
        public int GetMementoLength    => mementos.Count();

        private List<Memento> mementos = new List<Memento>();
    }
}
