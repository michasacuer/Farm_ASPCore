using Farm_ASPCore_Webapi.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Farm_ASPCore_Webapi.Models
{
    public class Animal
    {
        public Species Species { get; set; }
        public Gender Sex { get; set; }

        public void AddAnimal(Gender sex, Species species)
        {
            try   { animals.Add(new Animal(sex, species)); }
            catch { throw new ArgumentOutOfRangeException(); }
        }

        public Animal GetAnimal(int id) => animals[id];
        public List<Animal> GetAll() => animals;
        public void Remove(int id) => animals.RemoveAt(id);

        private static List<Animal> animals = new List<Animal>(50);
        private Animal(Gender sex, Species species)
        {
            Sex = sex;
            Species = species;
        }
    }
}
