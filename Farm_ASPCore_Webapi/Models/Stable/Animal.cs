using Farm_ASPCore_Webapi.Helpers;
using Farm_ASPCore_Webapi.Models.Enums;
using Farm_ASPCore_Webapi.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Farm_ASPCore_Webapi.Models
{
    public class Animals : ISummary
    {
        public int     Id      { get; set; }
        public Species Species { get; set; }
        public Gender  Sex     { get; set; }

        public static Animals GetAnimal(int id) => animals.SingleOrDefault(a => a.Id == id);
        public static List<Animals> GetAll() => animals;
        public static double GetAnimalsCost() => animals[0].GetCost();

        public double GetCost()
        {
            double cost = 0, income = 0;
            foreach (Animals animal in animals)
            {
                cost = animal.Sex == Gender.Female ? costFemale : costMale;

                income = animal.Sex == Gender.Male ? 0 :
                         animal.Species == Species.Black ? (milkPrice * 30) : (milkPrice * 20);
            }

            return (cost + income);
        }

        private static List<Animals> animals = Fill();
        private static List<Animals> Fill()
        {
            Random random = new Random();
            Array genders = Enum.GetValues(typeof(Gender));
            Array species = Enum.GetValues(typeof(Species));
            var   animals = new List<Animals>(Capacity.Stable);
            
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

        private double milkPrice  = 50 * 31;
        private double costMale   = 10 * 31;
        private double costFemale = 20 * 31;
    }
}
