using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MH_Animal_Applikation_Upg1
{
    interface IListManager<T>
    {

        int Count { get; }




        bool Add(T aType);

        bool DeleteAt(int Index);

        string[] ToStringArray();


       // bool Delete(int anIndex);
    }
}
