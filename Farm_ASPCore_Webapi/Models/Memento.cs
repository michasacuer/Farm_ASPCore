﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Farm_ASPCore_Webapi.Models
{
    public class Memento
    {
        private List<Worker> Workers { get; set; }

        public Memento(Farm state)
        {
            this.Workers = state.Workers;
        }
        public Memento(List<Worker> Workers)
        {
            this.Workers = Workers;
        }

       
    }
        
}
