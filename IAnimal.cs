using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MH_Animal_Applikation_Upg1
{
    public interface IAnimal
    {
        string Name { get; set; }
        string Gender { get; set; }
        int Id { get; set; }



        FoodSchedule GetFoodschedule();
       // EaterTypes.EaterType GetEaterType();
        //string IsGoodFor(EaterTypes.EaterType eType);
        string IsGoodFor();
        //string getSchedule();
        //FoodSchedule getFoodSchedule();

        //string[] Elements();

        string GetSpecies();
    }
}
