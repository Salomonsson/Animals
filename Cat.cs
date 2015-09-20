using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MH_Animal_Applikation_Upg1.Animals
{
    class Cat :  Mammals
    {
        private string _sound = "Mjaaaau";


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
             //this.MammalsObjekt = new Mammals(other.MammalsObjekt);
         }

        //Här har jag försökt med en hierarkisk copy constrcutor. Dvs. den arvs stegvis nedåt. Detta för att jag vill
        //instansiera objekten med EN-Parameter. Vilket jag tycker är snyggast. 

        //public Cat(Mammals other)
        //{
        //    this.teeth = other.teeth;
        //    this.tail = other.tail;
        //    //this.Sound = other.Sound;
        //    //this.PostAddress = new Creature(other.PostAddress);
        //}

        //Protected SET.
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

        //Override the base toString, plus add extra info
        public override string ToString()
        {
            return base.ToString() + " Ljud:" + Sound;
        }
    }
}
