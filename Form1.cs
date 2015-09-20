using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MH_Animal_Applikation_Upg1.Animals;

namespace MH_Animal_Applikation_Upg1
{
    public partial class Form1 : Form
    {
        //Cheat counter. 
        public int testCounter = 1;

        //Instantiate animalmanager. 
        private AnimalManager animalMngr = null;  //ref variable declared

        public Form1()
        {
            InitializeComponent();

            //Initializations
            InitializeGUI();

            //AnimalManager
            animalMngr = new AnimalManager();

           
        }

        /// <summary>
        /// Prepare the form before display
        /// Initiate input controls with default values
        /// Remove design values from output controls (label1 ex.)
        /// </summary>
        private void InitializeGUI()
        {
            //Clear output controls
            textBoxName.Text = "Beijo";
            textBoxAge.Text = "12";
            textBoxNoTeeth.Text = "20";
            textBoxTailLength.Text = "15,8";

            listBoxGender.Items.AddRange(Enum.GetNames(typeof(AnimalTypes.Gender)));
            listBoxCategories.Items.AddRange(Enum.GetNames(typeof(AnimalTypes.AnimalType)));
        }

        /// <summary>
        /// Hämata data från GUI, fyll i ett lokalt object av Fastighet
        /// för att senare skickas till fastighetMngr
        /// </summary>
        /// <param name="animalObj"></param>
        /// <returns></returns>
        private bool UserInput(out Animal animalObj)
        {
            //Create a local Animal instance for filling in input
            animalObj = new Animal();


            //Animal objects is saved to an arraylist, here is one of the few times i tried to loop out
            //each objekt for counting them. This without success. 
            //foreach (var item in animalMngr.animalArrayList)
            //{
            //   testCounter++;

            //}
            

            //<>Here is plenty more tries to get the count of object correct. this still fails since it starts
            //with 0, my testCounter gives correct results but it's ugly coding, -> DISLIKE!
            //animalObj.id = animalMngr.objCount;
            //animalObj.id = testCounter++;  //Works perfectly, but beautiful code is what i want. 
            //animalObj.id = testCounter;
            animalObj.Id = animalMngr.ElementCount;
            //animalMngr.countId(animalMngr.animalArrayList);
            //animalObj.id = animalMngr.countId(animalMngr.animalArrayList);
            //animalObj.id = animalMngr.ElementCount;
            

            //Check the users input if its valid by boolean. False -> not valid, true ->Valid
            bool validInput = false;

            //Get the user input from textboxes
            animalObj.Name = textBoxName.Text;
            //Check valid integer
            //methods are for checking int value from the textboxes.
            animalObj.Age = CheckAge(out validInput);
            animalObj.Gender = listBoxGender.Text;

            //BIG PROBLEM:!
            // I want my class Mammals and Bird to get data, this without success. I have to have public variables
            //in my baseclass (Animal), this is bad. Big dislike. 
            //I also instantiate this ones in the button method. 
            //::::
            //((Mammals)animalObj).Teeth = CheckTeeth(out prisOK);
            //((Mammals)animalObj).Teeth = int.Parse(textBoxNoTeeth.Text);
            //int x  = CheckTeeth(out prisOK);
            //((Mammals)animalObj).teeth = x;
            

            //return true or false depending on user input. 
            //If both price and nr of rooms ok, return true
            return validInput;
        }


        //Four methods to check valid income data. Integer for Age and Teeth. Double for Tail-length and Speed. 
        private double CheckTailLength(out bool success)
        {
            double tailLength = 0;

            success = double.TryParse(textBoxTailLength.Text, out tailLength);

            if (!success)
                MessageBox.Show("The entered tail length is not valid!");

            return tailLength;
        }
        private int CheckAge(out bool success)
        {
            int age = 0;

            success = int.TryParse(textBoxAge.Text, out age);

            if (!success)
                MessageBox.Show("The entered age is not valid!");

            return age;
        }
        private int CheckTeeth(out bool success)
        {
            int teeth = 0;

            success = int.TryParse(textBoxNoTeeth.Text, out teeth);

            //if (int.TryParse(textBoxNoTeeth.Text, out teeth))
            //{
            //    //((Mammals))
            //}
            if (!success)
                MessageBox.Show("The entered teeth is not valid!");

            return teeth;
        }
        private double CheckSpeed(out bool success)
        {
            double speed = 0;

            success = double.TryParse(textBoxSpeed.Text, out speed);

            //if (int.TryParse(textBoxNoTeeth.Text, out teeth))
            //{
            //    //((Mammals))
            //}
            if (!success)
                MessageBox.Show("The entered speed of the bird is not valid!");
                

            return speed;
        }



        private void button1_Click(object sender, EventArgs e)
        {
            Animal animalObject;  //holder for input
            //AnimalFactory testtt;
            

            //Send this object to ReadInput
            //for filling in values (input)
            //out tells ReadInput that the variable 
            //is data out. All changes to this object
            //comes back here.
            //ReadInput creates all data used for the common fields of all estates.
            //The special for each are filled in later in the switch case.
            bool ok = UserInput(out animalObject);
            bool validInput = false;

            if (ok)  //If all common data (in variable estate) is OK
            {
               
                switch ((AnimalTypes.AnimalType)listBoxCategories.SelectedIndex)
                {
                    case AnimalTypes.AnimalType.Mammals:
                        {

                            //Jag vill att dessa ska fungera!! Men det gör dem inte!!
                            //((Mammals)animalObject).teeth = CheckTeeth(out validInput);
                            //((Mammals)animalObject).teeth = int.Parse(textBoxNoTeeth.Text);

                            //Detta är jag inte nöjd över. Mina variabler är public, inte PROTECTED. dock
                            //Så blir dem protected i min properties i min Mammals klass. Förstår inte vad
                            //jag bör göra för att få det bra? Jag vill instansiera mina objekt på det sätt jag
                            //gör just nu. Men mitt problem är hur jag kommer åt min mellanklass samt skyddar de
                            //argument som kommer in i klasserna. 

                            //I det stora hela ska inte ens mina teeth och tail variablar vara i min Animalklass (BaseClass)
                            //Jag har inget alternativ om jag vill instansiera med en parameter till objektet?
                            animalObject.teeth = CheckTeeth(out validInput);
                            animalObject.tail = CheckTailLength(out validInput);

                            AnimalTypes.MammalsType mammalObj = (AnimalTypes.MammalsType)Enum.Parse(typeof(AnimalTypes.MammalsType), listBoxAnimalObject.Text);
                            //..Use the converted choosen enum objekt. IN THE SAME TIME ADD IT TO LIST ARRAY!
                            //This means less code. 
                            animalMngr.Add(AnimalFactory.GetMammal(mammalObj.ToString(), animalObject));

                            
                            //Försökt en alternativ väg för att instansiera min mammals klass. Detta utan lyckat
                            //resultat. 
                            //Animal position = AnimalFactory.GetMammal(mammalObj.ToString(), animalObject);
                            //((Mammals)position).Teeth = CheckTeeth(out validInput);
                            //((Mammals)position).Tail = CheckTailLength(out validInput);
                            //animalMngr.Add(position);
                            
                           
                            // --Ful-sätt, för att få unikt ID..
                            //animalObject.id = testCounter++;

                            break;
                        }
                    case AnimalTypes.AnimalType.Bird:
                        {
                            
                            //Add speed to object.
                            animalObject.speed = CheckSpeed(out validInput);
                            //--Get choosen value from enum. And convert it
                            AnimalTypes.BirdType insectObj = (AnimalTypes.BirdType)Enum.Parse(typeof(AnimalTypes.BirdType), listBoxAnimalObject.Text);
                            
                            //..Use the converted choosen enum objekt. IN THE SAME TIME ADD IT TO LIST ARRAY!
                            //Less code. 
                            animalMngr.Add(AnimalFactory.GetInsect(insectObj.ToString(), animalObject));
                            
                            break;
                        }
                }

                //Then Update the GUI
                UpdateResults();
                //estate.id = animalMngr.ElementCount;
                //estate.id = animalMngr.counter;
                //animalMngr.countId();
            }
        }

     

        /// <summary>
        /// Reset result list and fill in with new values
        /// </summary>
        private void UpdateResults()
        {
            
            lstResults.Items.Clear();  //Erase current list
            
            //Get one elemnet at a time from manager, and call its 
            //ToString method for info - send to listbox
            for (int index = 0; index < animalMngr.ElementCount; index++)
            {
                //Q: Vhy not use new in the line below?
                Animal animal = animalMngr.GetElementAtPosition(index);


                // We can get an animal since here we don't need to separate
                // the different animal,ej, we are only interested in the toString method.
                lstResults.Items.Add(animal.ToString());
                //Försök till unikt ID.
                //lstResults.Items.Add(estate.ToString() + estateMngr.countId());
            }
            
        }



        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBoxCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxCategories.SelectedIndex == (int)AnimalTypes.AnimalType.Mammals)
            {

                textBoxTailLength.Text = "12,35";
                textBoxTailLength.ReadOnly = false;
                textBoxSpeed.ReadOnly = true;
                textBoxSpeed.Text = null;

                listBoxAnimalObject.Items.Clear();
                // Fill the combobox with values from enum
                listBoxAnimalObject.Items.AddRange(Enum.GetNames(typeof(AnimalTypes.MammalsType)));
                //Make this readonly
                //Make cat as default.
                listBoxAnimalObject.SelectedIndex = (int)AnimalTypes.MammalsType.Cat; 
            }
            if (listBoxCategories.SelectedIndex == (int)AnimalTypes.AnimalType.Bird)
            {
                textBoxTailLength.Text = null;
                textBoxTailLength.ReadOnly = true;
                textBoxSpeed.ReadOnly = false;
                textBoxSpeed.Text = "2,8";

                //Clear the listbox
                listBoxAnimalObject.Items.Clear();
                //cmbTyp.Items.AddRange(Enum.GetNames(typeof(EstateTypes.InsectsType)));
                listBoxAnimalObject.Items.AddRange(Enum.GetNames(typeof(AnimalTypes.BirdType)));
                //Make Kookaburra as default.
                listBoxAnimalObject.SelectedIndex = (int)AnimalTypes.BirdType.Kookaburra; 
            }
        }

        private void textBoxTailLength_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
