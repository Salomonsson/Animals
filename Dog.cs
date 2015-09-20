using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MH_Animal_Applikation_Upg1.Animals
{
    class Dog : Mammals
    {
         private string _sound = "Woff";


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
        }

        //protected SET.
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
