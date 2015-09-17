using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MH_Animal_Applikation_Upg1.Animals;
using System.Collections;

namespace MH_Animal_Applikation_Upg1
{
    class AnimalManager
    {

        
        //private List<Animal> estateList; //declaration, not yet created
        public ArrayList animalArrayList = new ArrayList();

        public int counter = 0;

        //Konstruktor - skapa objekten som ingår som variabler 
        /// <summary>
        /// Default constructor - create the estate list
        /// </summary>
        public AnimalManager()
        {
            //1.  Create the list object
            // estates = new ArrayList();  IF we are using an arrayList
            //estateList = new List<Animal>();
            animalArrayList = new ArrayList(); 
           
        }

        public AnimalManager(AnimalManager other)
        {
            this.animalArrayList = other.animalArrayList;
            //this.id = other.id;
        }

        public int countId(ArrayList t)
        {


            foreach (var item in t)
            {
                counter = counter + 1;
                 
            }
            return counter;
        }


        public int objCount
        {
            get { return counter; }
        }
        /// <summary>
        /// Add a new estate object to the list
        /// </summary>
        /// <param name="estObj"></param>
        public void Add(Animal estObj)
        {
            if (estObj != null)  //Important - the object must be created (in calling method)
                animalArrayList.Add(estObj);
        }


        /// <summary>
        /// Read only property to get nr of elemnts in list
        /// </summary>
        public int ElementCount
        {
            get { return animalArrayList.Count; }
        }


        /// <summary>
        /// Get one element from list
        /// 
        /// Two ways:
        /// 1. Return the element directly (the reference returned)
        /// 
        /// return estatList[index];  - Dangerous as any later change will also
        /// affect my list
        /// 2. return a (deep copy) element
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Animal GetElementAtPosition(int index)
        {
            //We choose to return a copy, why do we need type casting when copying?
            if (IsIndexValid(index))
            {

                if (animalArrayList[index] is Dog)
                    return new Dog((Dog)animalArrayList[index]);
                if (animalArrayList[index] is Cat)
                    return new Cat((Cat)animalArrayList[index]);
                        //if (estateList[index] is Bee)
                        //    return new Bee((Bee)estateList[index]);
                        else
                            return null;
            }           
            else
                return null;
        }

        /// <summary>
        /// A list shall not be able to be indexed out of bounds.
        /// This method can be used from different places to ensure 
        /// correct indexing.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public bool IsIndexValid(int index)
        {
            return ((index >= 0) && (index < animalArrayList.Count));
        }
    }
}
