using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MH_Animal_Applikation_Upg1.Animals;

namespace MH_Animal_Applikation_Upg1
{
    public class FoodSchedule
    {
       

       // private List<string> foodDescriptionList =  new List<string>();

        public List<string> foodDescriptionList { get; set; }

        //Constructor
        //public FoodSchedule(List<string> foodDescriptionList)
        public FoodSchedule()
        {

            foodDescriptionList = new List<string>();
            //newTwo();
            //foodDescriptionList = new List<string>();
            //this.Add("Testaren");
        }

        //private List<string> myList = new List<string>();

        public List<string> GetList()
        {
            return foodDescriptionList;
        }

        /// <summary>
        /// Read only property to get nr of elemnts in list
        /// </summary>
        public int ElementCount
        {
            get { return foodDescriptionList.Count; }
        }

        /// <summary>
        /// Add a new animal object to the arraylist
        /// </summary>
        /// <param name="estObj"></param>
        public void Add(string estObj)
        {
           //Important - the object must be created (in calling method)
                foodDescriptionList.Add(estObj);
        }

    }
}
