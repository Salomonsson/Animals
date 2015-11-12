using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MH_Animal_Applikation_Upg1.Animals
{
    public abstract class Mammals : Animal
    {
        //Teeth and tail make it not working.
        //public int teeth;
        //public double tail;
        //public List<string> m_ingredient = new List<string>();
        //public string[] _elements = new string[3];
        

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



        /// <summary>
        /// GetSchedule returnerar en list till string. Vilket är rätt korkat för att sedan ska
        /// denna string in i en annan lista från FoodSchedule. uhm? Why. 
        /// Om jag kanske har olika matscheman i FoodSchedule och gör en compare med vilken species, för att
        /// sedan returnera en list från den klassen, det skulle nog vara mer logiskt.
        /// </summary>
        /// <returns>return a string of list animal_foodList</returns>
        //public override string getSchedule()
        //{
        //    //Set an counter
        //    int counter = 0;
           
        //    StringBuilder textOut = new StringBuilder();
        //    //Get named species
        //    textOut.Append(this.getSpecies()).Append(" (");

        //    //For each add into list, make as a string, then return
        //    foreach (string s in this.Elements)
        //    {
        //        counter++;
        //        //textOut.Append(counter).Append(",").Append(s).Append("\n");
        //        textOut.AppendLine().Append(counter).Append(",").Append(s).AppendLine();
        //        //test += s.ToString() + counter + "\r\n";

        //    }

        //    textOut.Append(")");
        //    //remove the last comma 
        //    //return textOut.ToString().Remove(textOut.ToString().LastIndexOf(","), 1);
        //    return textOut.ToString();
        //    //return test;
        //    //return "Endast Hamburgare tack, jag är en katt!!";
        //    //return m_ingredient;
        //}


        //public FoodSchedule getFoodSchedule() { return myFood; }

        //public override string getSchedule()
        //{

        //    foreach (string s in this.Elements)
        //    {
        //        test += "Måltid:" + s + "-  ";
        //    }

        //    return test;
        //    //return m_ingredient;
        //}


        //public override string[] Elements
        //{
        //    get { return _elements; }
        //}

       //Override the base toString, plus add extra info
        //public override string ToString()
        //{
        //    return base.ToString() + " Antal tänder:"+ Teeth + " Svanslängd:" + Tail;
        //}
    }
}
