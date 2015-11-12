using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MH_Animal_Applikation_Upg1.Animals
{
    public class Kookaburra : Bird
    {

        public Kookaburra()
        {
            //Instantiate foodSchedule
            //myFood.Add("09:00 Bananer");
            //myFood.Add("11:00 Spindlar och småkryp");
            //myFood.Add("14:00 Gecko ödla och kackerlackor");
        }
        public Kookaburra(int id, string name, int age, double speed)
             : base(id, name, age, speed)
         {
            
         }
         public Kookaburra(Animal other)
         {
             this.gender = other.Gender;
             this.name = other.Name;
             this.age = other.Age;
             this.id = other.Id;

             //Not protected - BAD, really BAD!
             this.speed = other.speed;

             //Instantiate foodSchedule
             myFood.Add("09:00 Bananer");
             myFood.Add("11:00 Spindlar och småkryp");
             myFood.Add("14:00 Gecko ödla och kackerlackor");
         }

         public override FoodSchedule GetFoodschedule() { return myFood; }

         public override string IsGoodFor()
         {
             //return EaterTypes.EaterType.Carnivora;
             return EaterTypes.EaterType.Omnivorous.ToString();
             //return (eater == EaterType.Carnivora) || (eater == EaterType.Omnivorous);
         }

         public override string GetSpecies()
         {
             return AnimalTypes.BirdType.Kookaburra.ToString();
         }

         public override string Sound
         {
             get { return "GRRRrrrr Quack quack"; }
         }

    }
}
