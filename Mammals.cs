using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MH_Animal_Applikation_Upg1.Animals
{
    class Mammals : Animal
    {
        //Teeth and tail make it not working.
        //public int teeth;
        //public double tail;


        //Default constructor
        public Mammals()
        {
          
        }

        public Mammals(int id, string name, int age, int teeth, double tail)
            : base(id, name, age)
        {
            //Möjligt att validera inkommande parametrar, dock har jag valt mig av att använda copy constructors. 
            ////bool isNum = int.TryParse(teeth, out validInteger);
            Teeth = teeth;
            Tail = tail;
        }


        //Enligt mitt tänk så bör en hierarkisk copy-constructor kunna göra jobbet, så dem ärver ned till varandra.
        //Detta utan resultat. Nu fungerar det så att varje ToString metod i varje klass arver från underklassen
        //och där efter visas korrekt data. Nackdel i detta är att mina variablar måste finnas i basklassen Animal
        //med publika encapsulation, VILKET SKA UNDVIKAS. Dem får dock protected set i properties Teeth och Tail under.

        //public Mammals(Animal other)
        //{
        //    this.gender = other.gender;
        //    this.name = other.name;
        //    this.age = other.age;
        //    this.Id = other.Id;
        //    this.teeth = other.teeth;
        //    this.tail = other.tail;
        //}


        //Properties Teeth och Tail har protected set för att skydda objektdata. Dock har jag problemet att instansiera
        //dessa properties. 
        public int Teeth
        {
            get
            {
                return this.teeth;
            }
           protected set
            {
                this.teeth = value;
            }
        }
        public double Tail
        {
            get
            {
                return this.tail;
            }
            protected set
            {
                this.tail = value;
            }
        }

       //Override the base toString, plus add extra info
        public override string ToString()
        {
            return base.ToString() + " Antal tänder:"+ Teeth + " Svanslängd:" + Tail;
        }
    }
}
