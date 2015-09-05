using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestOOPAnimal.Classes
{
    class Dog : Mammals
    {

        //protected string _sound = "WoFF";


        public Dog(string name, string age, string gender, string numberTeeth)
            : base(name, age, gender, numberTeeth)
        {
            Sound = _sound;
        }

        public override string Sound
        {
            get
            {
                return this._sound;
            }
            set
            {
                 this._sound = "WoFF";
            }
        }
    }
}
