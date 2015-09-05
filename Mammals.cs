using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestOOPAnimal.Classes
{
    class Mammals : Animal
    {
        int _teeth;

        public Mammals(string name, string age, string gender, string numberTeeth)
            : base(name, age, gender)
        {
            bool isNum = int.TryParse(numberTeeth, out validInteger);
            nrTeeth = validInteger;
        }

        public int nrTeeth
        {
            get
            {
                return this._teeth;
            }
            set
            {
                this._teeth = 1;
            }
        }




    }
}
