using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MH_Animal_Applikation_Upg1.Animals
{
    class Animal
    {
        #region Fields
        /// <summary>
        /// Fields
        /// </summary>
        public int id;
        public string name;
        public string gender;
        public int age;
        //teeth and tail is måste för att fungera, but i DISLIKE.
        public int teeth;
        public int tail;
        protected string _sound = "Djur kan låta";
        #endregion

        /// <summary>
        /// Default construktor - a good place for creating 
        /// all the fields in the class
        /// </summary>
        public Animal()
        {
            
        }

        /// <summary>
        /// Default construktor - a good place for creating 
        /// all the fields in the class
        /// </summary>
        public Animal(int id, string name, int age, string gender)
        {
            //address = new Creature();
            //teeth;  //m is short for "money". 
            Id = id;
            Name = name;
            Age = age;
            Gender = gender;

        }

        #region properties
        //protected internal int Id { get; protected set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        //public virtual int Teeth { get; set; }
        //public virtual int Tail { get; set; }
        #endregion



        /// <summary>
        ///Format a string with values from this estate.
        ///Note that data for the address object is fetched from the
        ///address-object belonging to this estate.
        /// </summary>
        /// <returns>The formatted string.</returns>
        public override string ToString()
        {
            //Vhat is {0, -12}, {3, 6} eller {4} ?
            string strOut = String.Format("  ID:{0}, Namn: {1}, Ålder:{2}, Kön: {3}   ", this.id, this.name, this.age, this.gender);

            strOut = strOut.ToUpper();
            return strOut;
        }


    }
}
