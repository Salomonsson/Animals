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
        protected string _sound = "Djur kan låta";
        public Boolean flag = true;
        protected int validInteger;

    //    public Animal(int id)
    //    : this(id, "", "") {

    //}

    //    public Animal(int id, string fName)
    //    : this(id, fName, "") {

    //}
        //bool isNumeric = int.TryParse("123", out n);
        
        public Animal(string name, string age, string gender)
        {
            //Validate logic.....
            bool isNum = int.TryParse(age, out validInteger);


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
            
           
            if (flag)
            {
                Name = name;
                Age = validInteger;
                Gender = gender;
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




    }
}
