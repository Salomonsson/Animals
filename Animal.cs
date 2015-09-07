using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestOOPAnimal.Classes
{
    public class Animal
    {

        protected string _gender;
        protected string _name;
        protected int _age;
        protected int _teeth;
        protected string _sound = "Djur kan låta";
        public Boolean flag = true;

        public int Teeth { get; protected set; }
        //public string Sound { get; protected set; }


        protected int validInteger;
        protected int validIntegerTwo;

        public Animal(string name, string age, string gender)
        {
            //Validate logic.....
            bool isNum = int.TryParse(age, out validInteger);
            //bool isNum2 = int.TryParse(teeth, out validIntegerTwo);


            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Djuret måste ha ett namn!");
                flag = false;
            }
            if (!isNum)
            {
                MessageBox.Show("Djuret måste ha en ålder, endast siffror");
                flag = false;
            }
            //if (!isNum2)
            //{
            //    MessageBox.Show("Antalet tänder måste vara i siffror.");
            //    flag = false;
            //}


            if (flag)
            {
                Name = name;
                Age = validInteger;
                Gender = gender;
                //Teeth = validIntegerTwo;
            }
            //    throw new ArgumentException("message", "text");

            //    else if (Id == null)
            //        throw new ArgumentNullException("context");
            //Name = name;
            //Age = age;
            //Gender = gender;
        }

        public string Gender
        {
            get
            {
                return this._gender;
            }
            set
            {
                this._gender = value;
            }
        }
        public int Age
        {
            get
            {
                return this._age;
            }
            set
            {
                this._age = value;
            }
        }
        public string Name
        {
            get
            {
                return this._name;
            }
            set
            {
                this._name = value;
            }
        }



        public virtual string Sound
        {
            get
            {
                return this._sound;
            }
            set
            {
                this._sound = value;
            }
        }


        //public virtual int Teeth
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
