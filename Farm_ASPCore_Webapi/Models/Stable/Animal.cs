using Farm_ASPCore_Webapi.Helpers;
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

        private static List<Animal> animals = Fill();
        private static List<Animal> Fill()
        {
            Random random = new Random();
            Array genders = Enum.GetValues(typeof(Gender));
            Array species = Enum.GetValues(typeof(Species));
            var animals = new List<Animal>(Capacity.Stable);
            
            for(int i = 0; i < Capacity.Stable; i++)
            {
                animals.Add(new Animal(
                    (Gender)genders.GetValue(random.Next(genders.Length)),
                    (Species)species.GetValue(random.Next(genders.Length))
                    ));
            }
            return animals;
        }

        private Animal(Gender sex, Species species)
        {
            Sex = sex;
            Species = species;
        }
    }
}
