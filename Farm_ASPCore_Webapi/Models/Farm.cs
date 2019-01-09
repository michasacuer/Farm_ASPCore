﻿using Farm_ASPCore_Webapi.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Farm_ASPCore_Webapi.Models
{
    public class Farm
    {
        [Key]
        public int Id { get; set; } = 1;
        public string Name { get; set; }

        public virtual List<Stable> Stables { get; set; }
        public virtual List<Machine> Machines { get; set; }
        public virtual List<Worker> Workers { get; set; }
        public virtual List<ICultivation> Cultivations { get; set; }

        public static Farm GetFarm() => farm;
        public void SaveState() => this.state = GetFarm();
        public Memento Save() => new Memento(state);


        public void restore(Memento m)
        {
            state = m.getState();
            Console.WriteLine("Powrot do wersji poprzedniej");
            Console.WriteLine(state);
        }

        private Farm() { }
        private static readonly Farm farm = new Farm {  Name = "Farm" };
        private Farm state;
    }
}
