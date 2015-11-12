using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MH_Animal_Applikation_Upg1.Animals
{
    public class Dog : Mammals
    {
         private string _sound = "Woff";

        public Dog (){

            myFood.Add("10:00 Pedigree");
            myFood.Add("15:00 KingsMoore Original");
            myFood.Add("15:30 Hills Adult Medium Hundfoder");
        }

         public Dog(int id, string name, int age, int teeth, double tail)
             : base(id, name, age, teeth, tail)
         {
             Sound = _sound;
         }

        /// <summary>
        /// Kopiera data from Animal objekt. 
        /// </summary>
        /// <param name="other"></param>
        public Dog(Animal other)
        {
            this.gender = other.Gender;
            this.name = other.Name;
            this.age = other.Age;
            this.id = other.Id;

            //Vill använda mig av dessa properties. Men det går inte. Dessa är INTE skyddade. 
            this.teeth = other.teeth;
            this.tail = other.tail;
            //this.teeth = other.teeth;
            //this.Sound = other.Sound;

            //myFood.Add("10:00 Pedigree");
            //myFood.Add("15:00 KingsMoore Original");
            //myFood.Add("15:30 Hills Adult Medium Hundfoder");
        }

        //Properties - protected SET.
        public string Sound
        {
            get
            {
                return this._sound;
            }
            protected set
            {
                this._sound = value;
            }
        }


        public override string IsGoodFor()
        {
            //return EaterTypes.EaterType.Carnivora;
            return EaterTypes.EaterType.Herbivore.ToString();
            //return (eater == EaterType.Carnivora) || (eater == EaterType.Omnivorous);
        }

        public override string GetSpecies()
        {
            return AnimalTypes.MammalsType.Dog.ToString();
        }

        public override FoodSchedule GetFoodschedule() { return myFood; }

        //Override the base toString, plus add extra info
         public override string ToString()
         {
             //myClass.foodDescriptionList.Add("OJDAN");
             return base.ToString() + " Antal tänder:"+ Teeth + " Svanslängd:" + Tail + " Ljud:" + Sound;
         }
    }
}
