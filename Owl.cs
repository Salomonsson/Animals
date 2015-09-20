using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MH_Animal_Applikation_Upg1.Animals
{
    class Owl : Bird
    {

        public Owl()
        {

        }
        public Owl(int id, string name, int age, double speed)
             : base(id, name, age, speed)
         {
            
         }
         public Owl(Animal other)
         {
             this.gender = other.Gender;
             this.name = other.Name;
             this.age = other.Age;
             this.id = other.Id;

             //Not protected - BAD, really BAD!
             this.speed = other.speed;
         }

         //Override the base toString, plus add extra info
         public override string Sound
         {
             get { return "GHOooo GHOooooooooo GHoooO"; }
         }
    }
}
