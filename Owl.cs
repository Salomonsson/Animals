using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MH_Animal_Applikation_Upg1.Animals
{
    public class Owl : Bird
    {
        public Owl()
        {
            //Instantiate foodSchedule
            //myFood.Add("09:00 Möss");
            //myFood.Add("04:00 Orm");
            //myFood.Add("01:00 Kattunge");

        }
        public Owl(int id, string name, int age, double speed)
             : base(id, name, age, speed)
         {
            
         }
         public Owl(Animal other)
         {
             this.gender = other.Gender;
             this.name = other.Name;
             this.age = other.Age;
             this.id = other.Id;

             //Not protected - BAD, really BAD!
             this.speed = other.speed;

             //Instantiate foodSchedule
             myFood.Add("09:00 Möss");
             myFood.Add("04:00 Orm");
             myFood.Add("01:00 Kattunge");
         }

         public override FoodSchedule GetFoodschedule() { return myFood; }

         public override string IsGoodFor()
         {
             //return EaterTypes.EaterType.Carnivora;
             return EaterTypes.EaterType.Carnivora.ToString();
             //return (eater == EaterType.Carnivora) || (eater == EaterType.Omnivorous);
         }

         public override string GetSpecies()
         {
             return AnimalTypes.BirdType.Owl.ToString();
         }

         //Override the base toString, plus add extra info
         public override string Sound
         {
             get { return "GHOooo GHOooooooooo GHoooO"; }
         }
    }
}
