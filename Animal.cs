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
        /// 

        //public AnimalTypes animalType;
       
        protected int id;
        protected string name;
        protected string gender;
        protected int age;

        //teeth, tail och speed är ett måste för att fungera, but i DISLIKE.
        public int teeth;
        public double tail;
        public double speed;
        protected string _sound = "Djur kan låta";


        //private EstateTypes MammalsType;
        //public Creature address;   //"has " relation
        //public string _sound = "Djur kan låta";
        //public EstateManager manager;
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
        /// Jag kan ha en constructor som inte tar några inparametrar? 
        //Jag har rört ihop det lite, jag vet inte om jag behöver constructor med inparametrar. 
        //Jag tar emot data med hjälp av mina properties. Det är lack of knowledge från min sida. då jag är ny att
        //använda mig av copy constructors som jag använder i varje instans av objekt. Det är nått som inte stämmer,
        //Vilket gör mig lite fundersam. Jag försöker få min kod så snygg som möjligt. 
        public Animal(int id, string name, int age)
        {
            //address = new Creature();
            //teeth;  //m is short for "money". 
            Id = id;
            Name = name;
            Age = age;
            //Gender = gender;

        }


        //Parameters to capture and protect the data inside of the object.
        #region properties
        public int Id
        {
            get { return id; }
            set
            {
                id = value;
            }
        }

        public string Name
        {
            get { return name; }
            set
            {
                    name = value;
            }
        }

        public int Age
        {
            get { return age; }
            set
            {
               if (value > 0)
                   age = value;
            }
        }

        public string Gender
        {
            get { return gender; }
            set
            {
                gender = value;
            }
        }

        #endregion



        /// <summary>
        ///Format a string with values from this estate.
        ///Note that data for the address object is fetched from the
        ///address-object belonging to this estate.
        /// </summary>
        /// <returns>The formatted string.</returns>
        public override string ToString()
        {
            string strOut = String.Format("  ID:{0}, Namn: {1}, Ålder:{2}, Kön: {3}   ", Id, Name, Age, Gender);

            strOut = strOut.ToUpper();
            return strOut;
        }


    }
}
