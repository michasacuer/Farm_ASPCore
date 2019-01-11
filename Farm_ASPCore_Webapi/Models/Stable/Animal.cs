using Farm_ASPCore_Webapi.Helpers;
using Farm_ASPCore_Webapi.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Farm_ASPCore_Webapi.Models
{
    public class Animals
    {
        public int     Id      { get; set; }
        public Species Species { get; set; }
        public Gender  Sex     { get; set; }

        public static Animals GetAnimal(int id) => animals.SingleOrDefault(a => a.Id == id);
        public static List<Animals> GetAll() => animals;

        private static List<Animals> animals = Fill();
        private static List<Animals> Fill()
        {
            Random random = new Random();
            Array genders = Enum.GetValues(typeof(Gender));
            Array species = Enum.GetValues(typeof(Species));
            var animals = new List<Animals>(Capacity.Stable);
            
            for(int i = 0; i < Capacity.Stable; i++)
            {
                animals.Add(new Animals(
                    i + 1,
                    (Gender)genders.GetValue(random.Next(genders.Length)),
                    (Species)species.GetValue(random.Next(genders.Length))
                    ));
            }
            return animals;
        }

        private Animals(int id, Gender sex, Species species)
        {
            Id = id;
            Sex = sex;
            Species = species;
        }
    }
}
