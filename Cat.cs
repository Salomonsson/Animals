using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MH_Animal_Applikation_Upg1.Animals
{
    public class Cat :  Mammals
    {
        private string _sound = "Mjaaaau";

        public Cat()
        {
            myFood.Add("09:00 Whiskas");
            myFood.Add("11:00 Orijen Cat & Kitten");
            myFood.Add("14:00 Brit Care Monty Kitten");
            myFood.Add("17:00 Whiskas Chicken");
            myFood.Add("21:00 Whiskas Beef");

        }
         public Cat(int id, string name, int age, int teeth, double tail)
             : base(id, name, age, teeth, tail)
         {
             
           
         }
         public Cat(Animal other)
         {
             this.gender = other.Gender;
             this.name = other.Name;
             this.age = other.Age;
             this.id = other.Id;

             //Detta stämmer inte, jag kommer bara åt min variablar. Men i fallet vill jag komma åt min properties
             //i Mammals klassen.
             this.teeth = other.teeth;
             this.tail = other.tail;


             //myFood.Add("09:00 Whiskas");
             //myFood.Add("11:00 Orijen Cat & Kitten");
             //myFood.Add("14:00 Brit Care Monty Kitten");
             //myFood.Add("17:00 Whiskas Chicken");
             //myFood.Add("21:00 Whiskas Beef");
         }

        //Här har jag försökt med en hierarkisk copy constrcutor. Dvs. den arvs stegvis nedåt. Detta för att jag vill
        //instansiera objekten med EN-Parameter. Vilket jag tycker är snyggast. 


        //Properties - Protected SET.
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
            return EaterTypes.EaterType.Carnivora.ToString();
            //return (eater == EaterType.Carnivora) || (eater == EaterType.Omnivorous);
        }

        public override string GetSpecies()
        {
            return AnimalTypes.MammalsType.Cat.ToString();
        }


        public override FoodSchedule GetFoodschedule() { return myFood; }

        //Override the base toString, plus add extra info
        public override string ToString()
        {
            //return base.ToString() + " Ljud:" + Sound;
            return base.ToString() + " Antal tänder:" + Teeth + " Svanslängd:" + Tail + " Ljud:" + Sound;
        }
    }
}
