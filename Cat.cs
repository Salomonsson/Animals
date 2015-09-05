using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestOOPAnimal.Classes
{
    class cat : Animal
    {
        private string _sound = "Mjaaaau";


        public cat(string name, string age, string gender, string teeth)
            : base(name, age, gender, teeth)
        {
            Sound = _sound;
        }

        public override string Sound
        {
            get
            {
                return this._sound;
            }
        }



    }
}
