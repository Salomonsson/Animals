using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MH_Animal_Applikation_Upg1.Animals
{
    class Mammals : Animal
    {
        //DESSA BEHÖVS!??!
        //string _teeth;
        //string _sound;
        private int validInteger;
        //Teeth and tail make it not working.
        //public int teeth;
        //public int tail;
        //public int Teeth { get; protected set; }

        public Mammals()
        {
            ////bool isNum = int.TryParse(teeth, out validInteger);
        
        }

        public Mammals(int id, string name, int age, string gender, int _teeth, int _tail)
            : base(id, name, age, gender)
        {
            ////bool isNum = int.TryParse(teeth, out validInteger);

            Teeth = _teeth;
            //Tail = _tail;
        }

        //public Mammals(Animal other)
        //{
        //    this.gender = other.gender;
        //    this.name = other.name;
        //    this.age = other.age;
        //    this.Id = other.Id;
        //    //this.teeth = other.teeth;
        //    this.tail = other.tail;
        //    //this.Sound = other.Sound;
        //    //this.PostAddress = new Creature(other.PostAddress);
        //}

        public int Teeth
        {
            get
            {
                return this.teeth;
            }
            set
            {
                this.teeth = value;
            }
        }
        public int Tail
        {
            get
            {
                return this.tail;
            }
            set
            {
                this.tail = value;
            }
        }

        //public Mammals(Animal other)
        //{
        //    this.name = other.name;
        //    this.age = other.age;
        //    this.Id = other.Id;
        //    this.teeth = other.teeth;
        //    //this.Sound = other.Sound;
        //    //this.PostAddress = new Creature(other.PostAddress);
        //}

        //public virtual string Sound
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
        public override string ToString()
        {
            return base.ToString() + " Antal tänder:"+ Teeth + " Svanslängd:" + Tail;
        }
    }
}
