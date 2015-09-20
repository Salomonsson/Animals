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
        //Jag beslöt mig för att använda mig av arrayList, detta för jag trodde att jag kunde loopa ut 
        //unikt id med foreach loop för varje objekt som är lagrat i arrayn. Problemet är dock att jag inte får
        //det att fungera. Jag vet inte varför, jag tycker att det är fullt logiskt att det ska fungera. Jag kanske
        //ska testa Eunumerable list, för att loopa ut allt utan att bry mig om vad det för typ av data. Uhm...
        public ArrayList animalArrayList = new ArrayList();

        //Ett försök till foreach. Börjar på 1.
        public int counter = 1;

        //Konstruktor - skapa objekten som ingår som variabler 
        /// <summary>
        /// Default constructor - create the estate list
        /// </summary>
        public AnimalManager()
        {
            //1.  Create the list object
            animalArrayList = new ArrayList(); 
           
        }

        public AnimalManager(AnimalManager other)
        {
            this.animalArrayList = other.animalArrayList;
            //this.id = other.id;
        }


        //Får inte denna att fungera. Det kommer ut hel fel antal, den adderar helt knäppt.
        public int countId()
        {
            foreach (var item in animalArrayList)
            {
                counter = counter++;
            }
            return counter;
        }


        public int objCount
        {
            get { return this.counter; }
        }
        /// <summary>
        /// Add a new animal object to the arraylist
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
                if (animalArrayList[index] is Kookaburra)
                    return new Kookaburra((Kookaburra)animalArrayList[index]);
                if (animalArrayList[index] is Owl)
                    return new Owl((Owl)animalArrayList[index]);
                //if (animalArrayList[index] is Bee)
                //    return new Bee((Bee)animalArrayList[index]);
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
