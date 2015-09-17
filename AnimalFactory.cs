using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MH_Animal_Applikation_Upg1.Animals;

namespace MH_Animal_Applikation_Upg1
{
    class AnimalFactory
    {
        /// <summary>
        /// Decides which class to instantiate.
        /// </summary>
        public static Animal GetMammal(string type, Animal estate)
        {
            Mammals obj = null;
            switch (type)
            {
                case "Dog":
                    obj = new Dog(estate);
                     //(Mammals)estate).teeth = int.TryParse(textBoxNoTeeth.Text);
                    //((Mammals)obj).teeth = int.Parse(textBoxNoTeeth.Text);
                    break;
                case "Cat":
                    obj = new Cat(estate);

                    break;
                default:
                    break;
            }
            return obj;
        }
    }
}
