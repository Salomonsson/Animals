using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MH_Animal_Applikation_Upg1.Animals;

namespace MH_Animal_Applikation_Upg1
{
    
    public class ListManager<T> : IListManager<T>
    { // : IListManager<T>

        protected int setID;
        protected string print_result;
        protected List<T> m_list;
        

        /// <summary>
        /// Instantiate constrctor
        /// </summary>
        public ListManager()
         {
             m_list = new List<T>();
            
         }


        /// <summary>
        /// Add new objekt(type) to list
        /// </summary>
        /// <param name="obj">income type</param>
        /// <returns></returns>
        public bool Add(T obj)
        {
            if (obj != null)
            {
                m_list.Add(obj);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Remove object by index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public bool DeleteAt(int index)
        {
            if (index != null)
            {
                m_list.RemoveAt(index);
                return true;
            }

            return false;
            //m_list.RemoveAt(index);
        }


        /// <summary>
        /// Convert the list to an array.
        /// </summary>
        /// <returns></returns>
        public string[] ToStringArray()
        {
             setID = 0;
            string[] arr = new string[m_list.Count];

            foreach (T an in m_list)
            {
                //Är detta en fullösning? :)
                arr[setID++] = "ID:" + setID + " objekt->" + an.ToString();
            }
            return arr;
        }
        //public T[] ToStringArray()
        //{
        //    //Convert List to Array
        //    T[] array1 = m_list.ToArray();
        //    string strOut;

        //    //Displaying the Array Value.
        //    foreach (T s in array1)
        //    {
        //        strOut = String.Format("  ID:{0} }   ", s);
        //    }
        //    //string strOut = strOut.ToUpper();
        //    return strOut;
        //}


        /// <summary>
        /// Return a list.
        /// </summary>
        /// <returns></returns>
        public List<string> ToStringList()
        {
            List<string> lst = new List<string>();

            foreach (T an in m_list)
            {
                lst.Add(an.ToString());
            }
            //return new List<T>();
            return lst;
            //return m_list;
        }


        /// <summary>
        /// Get index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T GetAt(int index)
        {
            return m_list[index];
        }


         /// <summary>
         /// Read only property to get nr of elemnts in list
         /// </summary>
        public int Count
        {
           get { return m_list.Count; }
        }

        public void Reset()
        {
            m_list.Clear();
        }
    

    }
}




//CODE
//public List<T> GetList()
//{
//    return m_list;
//}


//public T[] superRtn()
//{
//    T[] s = m_list.ToArray();

//    return s;
//}

//public T[] superRtn()
//{
//    //Convert List to Array
//    T[] array1 = m_list.ToArray();
//    string strOut;

//    //Displaying the Array Value.
//    foreach (T s in array1)
//    {
//        strOut = String.Format("  ID:{0} }   ", s);
//    }
//    //string strOut = strOut.ToUpper();
//    return strOut;
//}
//public override string ToString()
// {
//    T[] array1 = m_list.ToArray();

//     StringBuilder textOut = new StringBuilder();
//     //textOut.Append("ThisID").Append(" (");
//     textOut.Append(IDTEST).Append(". (");

//     foreach (T s in array1)
//     {
//         IDTEST++;
//         textOut.Append(s).Append(", ");
//     }

//     textOut.Append(")");
//     //remove the last comma 
//     return textOut.ToString().Remove(textOut.ToString().LastIndexOf(","), 1);
// }
