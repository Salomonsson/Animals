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


         public Dog(int id, string name, int age, string gender, int teeth, int tail)
             : base(id, name, age, gender, teeth, tail)
         {
             Sound = _sound;
         }

        ///// <summary>
        ///// The copy constructor
        ///// </summary>
        ///// <param name="other"></param>
        //public Dog(Dog other)
        //{
        //    //this.EType = other.EType;
        //    this.Teeth = other.Teeth;
        //    this.Id = other.Id;
        //    //this.PostAddress = new Creature(other.PostAddress);

        //    // Then copy the special data for this estate
        //}

        /// <summary>
        /// Copy the common data from a estate object
        /// </summary>
        /// <param name="other"></param>
        public Dog(Animal other)
        {
            this.gender = other.gender;
            this.name = other.name;
            this.age = other.age;
            this.Id = other.Id;
            this.teeth = other.teeth;
            this.tail = other.tail;
            //this.teeth = other.teeth;
            //this.Sound = other.Sound;
            //this.PostAddress = new Creature(other.PostAddress);
        }

        public string Sound
        {
            get
            {
                return this._sound;
            }
            set
            {
                this._sound = value;
            }
        }



         public override string ToString()
         {
             return base.ToString() + " Ljud:" + Sound;
         }

        //public override string ToString()
        //{
        //    //Vhat is {0, -12}, {3, 6} eller {4} ?
        //    string strOut = String.Format(" , Namn:{0} Ålder: {1},  Kön:{2}, Antal tänder:{3},  Svanslängd:{4}, Ljud: {5}", 
        //        this.name, this.age, this.gender, this.teeth,this.tail);

        //    strOut = strOut.ToUpper();
        //    return strOut;
        //}
    }
}
