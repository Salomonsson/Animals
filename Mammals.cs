using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestOOPAnimal.Classes
{
    class Mammals : Animal
    {

        //DESSA BEHÖVS!??!
        //string _teeth;
        //string _sound;
        private int validInteger;

        public Mammals(string name, string age, string gender, string teeth)
            : base(name, age, gender, teeth)
        {
            bool isNum = int.TryParse(teeth, out validInteger);
            Teeth = validInteger;
        }

        public override int Teeth
        {
            get
            {
                return this._teeth;
            }
            set
            {
                this._teeth = value;
            }
        }

        //public override string Sound
        //{
        //    get
        //    {
        //        return this._sound;
        //    }
        //    set
        //    {
        //        this._sound = value;
        //    }
        //}




    }
}
