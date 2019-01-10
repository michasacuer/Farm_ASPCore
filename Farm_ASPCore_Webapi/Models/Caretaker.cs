using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Farm_ASPCore_Webapi.Models
{
    public class Caretaker
    {
        private static Caretaker _instance;
        private Memento _empmemento;

        private Caretaker()
        {
        }
        public static Caretaker Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new Caretaker();
                }
                return _instance;
            }
        }
        public Memento memento
        {
            get
            {
                return _empmemento;
            }
            set
            {
                _empmemento = value;
            }
        }
        //private List<Memento> mementos = new List<Memento>();

        //public void addMemento(Memento m)
        //{
        //    mementos.Add(m);
        //}
        //public Memento getMemento(int index)
        //{
        //    return mementos[index];
        //}
    }
}
