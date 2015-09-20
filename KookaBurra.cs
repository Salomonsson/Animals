using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MH_Animal_Applikation_Upg1.Animals
{
    class Kookaburra : Bird
    {

        public Kookaburra()
        {

        }
        public Kookaburra(int id, string name, int age, double speed)
             : base(id, name, age, speed)
         {
            
         }
         public Kookaburra(Animal other)
         {
             this.gender = other.Gender;
             this.name = other.Name;
             this.age = other.Age;
             this.id = other.Id;

             //Not protected - BAD, really BAD!
             this.speed = other.speed;
         }

         public override string Sound
         {
             get { return "GRRRrrrr Quack quack"; }
         }

    }
}
