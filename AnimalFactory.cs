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
        public static Animal GetMammal(string type, Animal animalObj)
        {
            Animal obj = null;
            switch (type)
            {
                case "Dog":
                    obj = new Dog(animalObj);
                    break;
                case "Cat":
                    obj = new Cat(animalObj);
                    break;
                default:
                    break;
            }
            return obj;
        }

        public static Animal GetInsect(string type, Animal animalObj)
        {
            Animal obj = null;
            switch (type)
            {
                case "Kookaburra":
                    obj = new Kookaburra(animalObj);
                    break;
                case "Owl":
                    obj = new Owl(animalObj);
                    break;
                default:
                    break;
            }
            return obj;
        }
    }
}
