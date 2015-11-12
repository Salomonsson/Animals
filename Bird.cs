using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MH_Animal_Applikation_Upg1.Animals
{


    //Detta är väldigt intressant. Jag i denna underklass har gjort ett lite annorlunda sätt. Jag testar olika sätt
    //För att lära mig. Denna klass skiljer sig gentemot min Mammalsklass då Bird hämtar metoder och data från Kookaburra
    // och Owl. Det finns ingen ToString i de klasserna. Detta fungerar utmärkt. Dock vet jag inte hur det blir för framtida
    //förändringar om det finns risk för att hela applikatinen kommer att bli knäpp.
   public abstract class Bird : Animal
    {

        public Bird()
        {

        }

        public Bird(int id, string name, int age, double speed)
            : base(id, name, age)
        {

        }

        //Virtual method för att hämta data från underklass i en override method.
        public virtual string Sound
        {
            get
            {
                return Sound;
            }
        }

        public double Speed
        {
            get
            {
                return this.speed;
            }
            set
            {
                this.speed = value;
            }
        }


        public override string ToString()
        {
            return base.ToString() + "Hastighet:" + Speed + "KM/H" + " Bird-Sound:" + Sound;
        }
    }
}








//public override FoodSchedule GetFoodschedule() { return myFood; }

////Virtual method för att hämta data från underklass i en override method.
////public virtual string getSchedule();
////public override string getSchedule()
////{
////    return "Fåglar äter faktiskt glass";
////}

//public override string IsGoodFor()
//{
//    //return EaterTypes.EaterType.Carnivora;
//    return EaterTypes.EaterType.Herbivore.ToString();
//    //return (eater == EaterType.Carnivora) || (eater == EaterType.Omnivorous);
//}
