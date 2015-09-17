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

        private AnimalManager animalMngr = null;  //ref variable declared
        //animalObj = new Animal();
        //public Animal animalObj;
        public Form1()
        {
            InitializeComponent();

            //Initializations
            InitializeGUI();

            //AnimalManager
            animalMngr = new AnimalManager();

            //animalObj = new Animal();
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
            textBoxTailLength.Text = "15";


            //listBox1.Items.AddRange(Enum.GetNames(typeof(EstateTypes.AnimalType)));
            listBoxGender.Items.AddRange(Enum.GetNames(typeof(AnimalTypes.Gender)));
            listBoxCategories.Items.AddRange(Enum.GetNames(typeof(AnimalTypes.AnimalType)));
            

        }

        /// <summary>
        /// Hämata data från GUI, fyll i ett lokalt object
        /// </summary>
        /// <param name="fastighet"></param>
        /// <returns></returns>
        private bool ReadInput(out Animal animalObj)
        {
            //Create a local estate instance for filling in input
            animalObj = new Animal();
            
            //animalObj.id = animalMngr.objCount;
            //animalObj.id = animalMngr.counter;
            ////animalObj.id = animalMngr.ElementCount;
            animalMngr.countId(animalMngr.animalArrayList);
            animalObj.id = animalMngr.counter;



            //AnimalTypes.Gender gender = (AnimalTypes.Gender)Enum.Parse(typeof(AnimalTypes.Gender), listBoxGender.Text);
            bool prisOK = false;

            animalObj.name = textBoxName.Text;
            //Check valid integer
            animalObj.age = CheckAge(out prisOK);
            animalObj.gender = listBoxGender.Text;
            //Check valid integer
            animalObj.teeth = CheckTeeth(out prisOK);
            animalObj.tail = CheckTailLength(out prisOK);
            //Tried this, but no success. WHY?!?!?
            //((Mammals)animalObj).Teeth = CheckTeeth(out prisOK);
            //((Mammals)animalObj).Teeth = int.Parse(textBoxNoTeeth.Text);
            //int x  = CheckTeeth(out prisOK);
            //((Mammals)animalObj).teeth = x;
            

            //return true or false depending on user input. 
            //If both price and nr of rooms ok, return true
            return prisOK;
        }

        private int CheckTailLength(out bool success)
        {
            int tailLength = 0;

            success = int.TryParse(textBoxTailLength.Text, out tailLength);

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
        public int CheckTeeth(out bool success)
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





        private void button1_Click(object sender, EventArgs e)
        {
            Animal estate;  //holder for input - create in ReadInput

            //Send this object to ReadInput
            //for filling in values (input)
            //out tells ReadInput that the variable 
            //is data out. All changes to this object
            //comes back here.
            //ReadInput creates all data used for the common fields of all estates.
            //The special for each are filled in later in the switch case.
            bool ok = ReadInput(out estate);


            if (ok)  //If all common data (in variable estate) is OK
            {
                switch ((AnimalTypes.AnimalType)listBoxCategories.SelectedIndex)
                {
                    case AnimalTypes.AnimalType.Mammals:
                        {

                            /
                            AnimalTypes.MammalsType mammalObj = (AnimalTypes.MammalsType)Enum.Parse(typeof(AnimalTypes.MammalsType), listBoxAnimalObject.Text);

                            //Tried this but no success. WHY?!?!?
                            //Animal position = AnimalFactory.GetMammal(mammalObj.ToString(), estate);
                            //((Mammals)position).Teeth = int.Parse(textBoxNoTeeth.Text);
                            //animalMngr.Add(position);

                            animalMngr.Add(AnimalFactory.GetMammal(mammalObj.ToString(), estate));
                            //animalMngr.countId(animalMngr.listA);
                            //estate.id = animalMngr.counter;

                            break;
                        }
                    case AnimalTypes.AnimalType.Insects:
                        {
                            AnimalTypes.InsectsType insectObj = (AnimalTypes.InsectsType)Enum.Parse(typeof(AnimalTypes.InsectsType), listBoxAnimalObject.Text);
                            break;
                        }
                }

                //Then Update the GUI

                UpdateResults();
                //estate.id = animalMngr.ElementCount;
                //estate.id = animalMngr.counter;
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
                Animal estate = animalMngr.GetElementAtPosition(index);
                
                // We can get an estate since here we don't need to separate
                // the different estates,ej, we are only interested in the toString method.
                lstResults.Items.Add(estate.ToString());
                //lstResults.Items.Add(estate.ToString() + estateMngr.countId());
            }
            
        }

        private void listBoxCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxCategories.SelectedIndex == (int)AnimalTypes.AnimalType.Mammals)
            {

                listBoxAnimalObject.Items.Clear();
                // Fill the estate combobox with values from enum
                listBoxAnimalObject.Items.AddRange(Enum.GetNames(typeof(AnimalTypes.MammalsType)));
                //Make this readonly
            }
            if (listBoxCategories.SelectedIndex == (int)AnimalTypes.AnimalType.Insects)
            {
                listBoxAnimalObject.Items.Clear();
                listBoxAnimalObject.Items.AddRange(Enum.GetNames(typeof(AnimalTypes.InsectsType)));

            }
        }
    }
}
