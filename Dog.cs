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
        //public int _teeth;


        public Dog(string name, string age, string gender, string teeth)
            : base(name, age, gender, teeth)
        {
            //bool isNum = int.TryParse(teeth, out validInteger);

            Sound = "Woff";
            //Sound = _sound;

            //Teeth = validInteger;
        }

        //public override string Sound
        //{
        //    get
        //    {
        //        return this._sound;
        //    }
        //    set
        //    {
        //        this._sound = "WoFF";
        //    }
        //}

        //public override int Teeth
        //{
        //    get
        //    {
        //        return this._teeth;
        //    }
        //    set
        //    {
        //        this._teeth = value;
        //    }
        //}
    }
}
