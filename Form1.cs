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
using System.Text.RegularExpressions;

namespace MH_Animal_Applikation_Upg1
{
    public partial class Form1 : Form
    {
        //Cheat counter. 
       // public int testCounter = 1;

        //Instantiate animalmanager. 
        private AnimalManager animalMngr = null;  //ref variable declared
        //Food schedule instans behövs inte, den instnsieras i animal klassen? men egentligen inte. uhm.
       // FoodSchedule instanceFoodSchedule = new FoodSchedule();

        //ListManager<AnimalManager> animalMngr = null;
        //public Recipe testMatreceot = null;

        //public Recipe testMatreceot = new Recipe();
        public RecipeManager rcpMngr = new RecipeManager();
        public StaffManager stfMngr = new StaffManager();

        public Form1()
        {
            InitializeComponent();

            //Initializations
            InitializeGUI();

            //rcpMngr = new RecipeManager();
            //AnimalManager
            animalMngr = new AnimalManager();
            //instanceFoodSchedule = new FoodSchedule();
            //animalMngr = new ListManager<AnimalManager>();
           
           
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
            //set male as default
            listBoxGender.SelectedIndex = (int)AnimalTypes.Gender.Male;
            listBoxCategories.Items.AddRange(Enum.GetNames(typeof(AnimalTypes.AnimalType)));
            listBoxCategories.SelectedIndex = (int)AnimalTypes.MammalsType.Dog;
            
        }



        #region Validation
        /// <summary>
        /// Validation of Tail-length, Age, Number of teeths, speed of bird and Name of the object. 
        /// </summary>
        /// 
        

        /// <summary>
        /// Four methods to check valid income data. Integer for Age and Teeth. Double for Tail-length and Speed.
        /// </summary>
        /// <param name="success">Success =  user input is valid.</param>
        /// <returns>state of object which is true.</returns>
        private double CheckTailLength(out bool success)
        {
            double tailLength = 0;

            success = double.TryParse(textBoxTailLength.Text, out tailLength);


            if (!success || tailLength < 0)
            {
                MessageBox.Show("The entered tail length is not valid!");
                success = false;
            }


            return tailLength;
        }
        private int CheckAge(out bool success)
        {
            int age = 0;

            success = int.TryParse(textBoxAge.Text, out age);


            if (!success || (age <= 0))
            {
                success = false;
                MessageBox.Show("The entered age is not valid, the input must be an integer!");
                
            }

            return age;
        }
        private int CheckTeeth(out bool success)
        {
            int teeth = 0;
            success = int.TryParse(textBoxNoTeeth.Text, out teeth);

            if (teeth < 0 || !success)
            {
                MessageBox.Show("The entered teeth is not valid!");
                success = false;
            }

            return teeth;
        }
        private double CheckSpeed(out bool success)
        {
            double speed = 0;
            success = double.TryParse(textBoxSpeed.Text, out speed);

            if (speed < 0 || !success)
            {
                MessageBox.Show("The entered speed of the bird is not valid!");
                success = false;
            }

            return speed;
        }

        /// <summary>
        /// Check the if the input string for name is valid. 
        /// Multiple checking with -
        /// -TrimFunction
        /// -Regex library, search special characters
        /// -NullOrEmpty
        /// -Bool if textbox value is integer, then false
        /// -IsNullOrWhiteSpace, for empty spaces
        /// </summary>
        /// <param name="successtest"></param>
        /// <returns></returns>
        private string CheckValidName(out bool successtest)
        {
            var regexItem = new Regex("^[a-zA-Z0-9 ]*$");
            string name = "";
            string input = textBoxName.Text;
                

            int checkForNumber = 0;

            bool boolValue = int.TryParse(textBoxName.Text, out checkForNumber);
            //Check if the string is empty or null || income is integer.....
            if (String.IsNullOrEmpty(input) || boolValue)
            {
                successtest = false;
                MessageBox.Show("Objektet måste ha ett namn. INGA SIFFROR!");
            }
            //check the regex for special charachters, || just spaces not aloud.
            else if (!regexItem.IsMatch(input) || string.IsNullOrWhiteSpace(input))
            {
                successtest = false;
                MessageBox.Show("No special characters or empty spaces!");
            }
            else
            {
                //Set true
                name = input.TrimStart();
                successtest = true;
            }
                    
        //Wont work. uhm?
           // name = input.TrimStart();

            return name;


                //int checkForNumber = 0;
                //bool boolValue = int.TryParse(textBoxName.Text, out checkForNumber);
                ////Check if the string is empty or null.....
                //if (String.IsNullOrEmpty(textBoxName.Text) || boolValue)
                //{ 
                //    validInput = false;
                //    MessageBox.Show("Objektet måste ha ett namn. INGA SIFFROR!");
                //}


                //var regexItem = new Regex("^[a-zA-Z0-9 ]*$");

                //if (!regexItem.IsMatch(input))
                //{
                //    validInput = false;
                //    MessageBox.Show("No special characters!");
                //}


                //int checkForNumber = 0;
                //bool boolValue = int.TryParse(textBoxName.Text, out checkForNumber);
                ////Check if the string is empty or null.....
                //if (String.IsNullOrEmpty(textBoxName.Text) || boolValue)
                //{
                //    validInput = false;
                //    MessageBox.Show("Objektet måste ha ett namn. INGA SIFFROR!");
                //}
        }

        #endregion



        private void button1_Click(object sender, EventArgs e)
        {
            //Update Food schema listan.
            listBoxFood.Items.Clear();


            //boolValue, just for checking. 
            bool validInput = false;
            bool validAge = false;

            //Check valid nA
            CheckValidName(out validInput);
            CheckAge(out validAge);


            if (validAge && validInput)  //If all common data (in variable estate) is OK
            {
                //Check if valid input for teeth textbox
                bool validNrTeeth = false;

                switch ((AnimalTypes.AnimalType)listBoxCategories.SelectedIndex)
                {
                    case AnimalTypes.AnimalType.Mammals:
                        {
                            //Check if the input is valid or not!
                            bool validTail = false;
                            CheckTeeth(out validNrTeeth);
                            CheckTailLength(out validTail);

                            //If number of teeth and tail length is valid.Then create object
                            if (validNrTeeth && validTail)
                            {
                                AnimalTypes.MammalsType mammalObj = (AnimalTypes.MammalsType)Enum.Parse(typeof(AnimalTypes.MammalsType), listBoxAnimalObject.Text);
                                Animal instanceAnimal = AnimalFactory.GetMammal(mammalObj.ToString());

                                
                                //Late Binding                                
                                instanceAnimal.Name = textBoxName.Text;
                                instanceAnimal.Id = animalMngr.Count;
                                instanceAnimal.Age = int.Parse(textBoxAge.Text);
                                instanceAnimal.Gender = listBoxGender.Text;

                                //Vilket är bäst??
                                instanceAnimal.teeth = int.Parse(textBoxNoTeeth.Text);
                                //instanceAnimal.teeth = CheckTeeth(out validNrTeeth);

                                instanceAnimal.tail = double.Parse(textBoxTailLength.Text);
                                //animalMngr.Add(instanceAnimal);
                                animalMngr.AddAnimal(instanceAnimal);

                                

                                //Get FoodSchedule information. Is this correct? KISS - Keep it simple STUPID!
                                //instanceFoodSchedule.Add(position.getSchedule());
                                //label14.Text = instanceAnimal.IsGoodFor();
                                //////Här loopar jag ut från min list, som instansieras i djurobjektet
                                //foreach (string itemFoodSchedule in instanceAnimal.GetFoodschedule().GetList())
                                //{
                                //    listBoxFood.Items.Add(itemFoodSchedule);
                                //}
                         

                                //..Use the converted choosen enum objekt. IN THE SAME TIME ADD IT TO LIST ARRAY!
                                //This means less code. 
                                //animalMngr.Add(AnimalFactory.GetMammal(mammalObj.ToString(), animalObject));

                             
                            }
              

                            break;
                        }
                    case AnimalTypes.AnimalType.Bird:
                        {
                            bool validSpeed = false;
                            
                            //Add speed to object.
                            CheckSpeed(out validSpeed);
                            CheckTeeth(out validNrTeeth);

                            //If number of teeth and tail length is valid.Then create object
                            if (validNrTeeth && validSpeed)
                            {
                                //--Get choosen value from enum. And convert it
                                AnimalTypes.BirdType insectObj = (AnimalTypes.BirdType)Enum.Parse(typeof(AnimalTypes.BirdType), listBoxAnimalObject.Text);
                                Animal instanceAnimal = AnimalFactory.GetInsect(insectObj.ToString());

                                //Late binding
                                instanceAnimal.Name = textBoxName.Text;
                                instanceAnimal.Id = animalMngr.Count;
                                instanceAnimal.Age = int.Parse(textBoxAge.Text);
                                instanceAnimal.Gender = listBoxGender.Text;

                                
                                instanceAnimal.teeth = int.Parse(textBoxNoTeeth.Text);
                                //instanceAnimal.teeth = CheckTeeth(out validNrTeeth);

                                instanceAnimal.speed = double.Parse(textBoxSpeed.Text);
                               
                                //animalMngr.Add(instanceAnimal);
                                animalMngr.AddAnimal(instanceAnimal);


                                //MATSCHEMA - BEHVS INTE LÄNGRE ELLER?
                                //Get FoodSchedule information. Is this correct? KISS - Keep it simple STUPID!
                                //instanceFoodSchedule.Add(position.getSchedule());
                                //label14.Text = instanceAnimal.IsGoodFor();
                                //////Här loopar jag ut från min list, som instansieras i djurobjektet
                                //foreach (string itemFoodSchedule in instanceAnimal.GetFoodschedule().GetList())
                                //{
                                //    listBoxFood.Items.Add(itemFoodSchedule);
                                //}
                                
                            }
                            break;
                        }
                }


                lstResults.Items.Clear();
                //Then Update the GUI
                //UpdateResults();

                //Denna fungerar ypperligt! MEN jag gillar inte loop här! 
                foreach (string item in animalMngr.ToStringArray())
                {
                    lstResults.Items.Add(item);
                }


            }
        }


        /// <summary>
        /// Reset result list and fill in with new values
        /// </summary>
        private void UpdateResults()
        {
            
            
           lstResults.Items.Clear();  //Erase current list
           
           foreach (var item in animalMngr.ToStringList())
           {
               lstResults.Items.Add(item);
           }
            
            ////Get one elemnet at a time from manager, and call its 
            ////ToString method for info - send to listbox
            //for (int index = 0; index < animalMngr.Count; index++)
            //{
            //    //Q: Vhy not use new in the line below?
            //    Animal animal = animalMngr.GetElementAtPosition(index);


            //    // We can get an animal since here we don't need to separate
            //    // the different animal,ej, we are only interested in the toString method.
            //    lstResults.Items.Add(animal.ToString());
            //    //Försök till unikt ID.
            //    //lstResults.Items.Add(estate.ToString() + estateMngr.countId());
            //}
            
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

        private void listViewFoodSchedule_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBoxFood_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void lstResults_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (lstResults.SelectedIndex >= 0) // skall ju endast göra något OM något djur är markerat, är inget markerat är index -1
            {
            listBoxFood.Items.Clear();
            string getAnimal = animalMngr.GetAt(lstResults.SelectedIndex).GetSpecies();
            
            //List<string> food = animalMngr.GetElementAtPosition(lstResults.SelectedIndex).GetFoodschedule().GetList(); // Hämta aktuellt djurs FoodSchedule lista
           // List<string> food = te2.Add(animalMngr.GetElementAtPosition(lstResults.SelectedIndex).GetFoodschedule().GetList());
            //te.add(food);
            //List<string> food = animalMngr.GetType(lstResults.SelectedIndex)
            switch (animalMngr.GetAt(lstResults.SelectedIndex).GetSpecies())
            {

                case "Dog":
                    //listBoxFood.Items.Add(getAnimal);
                    Animal dog = AnimalFactory.GetMammal(animalMngr.GetAt(lstResults.SelectedIndex).GetSpecies());
            //switch ((AnimalTypes.AnimalType)lstResults.SelectedIndex)
            //{
            //    case AnimalTypes.MammalsType.Dog:        
                //listBoxFood.Items.Add(instanceAnimalTEST.GetFoodschedule().ToString());
                        //listBoxFood.Items.AddRange(instanceAnimalTEST.GetFoodschedule());
                        //List<string> food = dog.GetFoodschedule().GetList();

                       // listBoxFood.Items.Add(animalMngr.GetAt(lstResults.SelectedIndex).GetFoodschedule().GetList());
                       //JAG får ju ut att det är dog objekt, jag behöver instansen av food schedula som passar alla dog objekt!
                    //Där av behöver jag inte länka till någon manager, för behöver bara vet matschema.
                       //listBoxFood.Items.Add(dog.GetSpecies());
                        foreach (string dogFood in dog.GetFoodschedule().GetList())
                        {
                            listBoxFood.Items.Add(dogFood); // överför strängarna till listan
                            //listBoxFood.Items.Add(s);
                        }
                        break;
                    case "Cat":
                        //listBoxFood.Items.Add(getAnimal);
                        Animal cat = AnimalFactory.GetMammal(animalMngr.GetAt(lstResults.SelectedIndex).GetSpecies());
                        //listBoxFood.Items.Add(cat.GetFoodschedule().ToString());
                        //listBoxFood.Items.AddRange(instanceAnimalTEST.GetFoodschedule());
                        foreach (string catFood in cat.GetFoodschedule().GetList())
                        {
                            listBoxFood.Items.Add(catFood); // överför strängarna till listan
                        }

                        break;
                      
                }
            //for (int i = 0; i < food.ToList; i++)
            //{
            //    System.Console.WriteLine(food[i]);
            //}
            //listBoxFood.Items.Add(food);
            //listBoxFood.Items.Add(listBoxFood.Items.Add(animalMngr.GetAt(lstResults.SelectedIndex).GetSpecies()));
            //listBoxFood.Items.Add(getAnimal);
            //foreach (string s in food){
            //    listBoxFood.Items.Add(s); // överför strängarna till listan
            //}

            //label14.Text = animalMngr.GetElementAtPosition(lstResults.SelectedIndex).IsGoodFor(); // överför eatertype till label (döp om till lblEaterType)
            label14.Text = animalMngr.GetAt(lstResults.SelectedIndex).IsGoodFor();
            }
        }

        private void buttonAddStaff_Click(object sender, EventArgs e)
        {
            FormAddStaff formStaff = new FormAddStaff();

            if (formStaff.ShowDialog() == DialogResult.OK)
            {
                //listBoxMetaInfo.Items.Clear();
                //Staff personal = staffMngr.GetAt(0);
                stfMngr.Add(formStaff.Staff);
                //listBoxMetaInfo.Items.Add(stfMngr.GetAt(0).ToString());

                //listBoxMetaInfo.Items.Add(stfMngr.ToStringArray());
                foreach (var item in stfMngr.ToStringArray())
                {
                    listBoxMetaInfo.Items.Add(item);
                }

            }

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (lstResults.SelectedIndex >= 0) // skall ju endast göra något OM något djur är markerat, är inget markerat är index -1
            {
                //Get id as a variable.
                
                string getName = animalMngr.GetAt(lstResults.SelectedIndex).Name;
                string getGender = animalMngr.GetAt(lstResults.SelectedIndex).Gender;
                string getAnimal = animalMngr.GetAt(lstResults.SelectedIndex).GetSpecies();

                DialogResult result2 = MessageBox.Show("Vill du ta bort följande objekt?? " +
                    Environment.NewLine +
                     //animalMngr.GetElementAtPosition(lstResults.SelectedIndex).ToString(),
                     //animalMngr.GetAt(lstResults.SelectedIndex),
                     "Namn:" + getName + " Kön:" + getGender + " Typ av Djur:" + getAnimal,
                "Delete",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question);

                if (result2 == DialogResult.Yes)
                {
                    //remove from listManager.
                    animalMngr.DeleteAt(lstResults.SelectedIndex);
                    lstResults.Items.Clear();

                    //Denna fungerar ypperligt! MEN jag gillar inte loop här! 
                    foreach (string item in animalMngr.ToStringArray())
                    {
                        lstResults.Items.Add(item);
                    }

                }
                else if (result2 == DialogResult.No)
                {
                    //do something else
                }

            }
        }

        private void buttonAddFood_Click(object sender, EventArgs e)
        {
            RecipeForm formRecipe = new RecipeForm();
            //f3.ShowDialog(); // Shows Form2

            if (formRecipe.ShowDialog() == DialogResult.OK)
            {
                //Add to listManager
                rcpMngr.Add(formRecipe.Recepie);
                //Get the object from listManager
                //listBoxMetaInfo.Items.Add(rcpMngr.ToStringArray());
                foreach (var item in rcpMngr.ToStringArray())
                {
                    listBoxMetaInfo.Items.Add(item);
                }

            }
        }



    }
}




// SOME CODE IS HARD TO LET GO OFF. BEAUTY WILL BE MISSED.

/// <summary>
/// Hämata data från GUI, fyll i ett lokalt object av animal
/// för att senare skickas till animalMngr
/// </summary>
/// <param name="animalObj"></param>
/// <returns></returns>
//private bool UserInput(out Animal animalObj)
//{
//    //Create a local Animal instance for filling in input
//    animalObj = new Animal();
//    //Animal te = null;

//    //Animal objects is saved to an arraylist, here is one of the few times i tried to loop out
//    //each objekt for counting them. This without success. 
//    //foreach (var item in animalMngr.animalArrayList)
//    //{
//    //   testCounter++;

//    //}


//    //<>Here is plenty more tries to get the count of object correct. this still fails since it starts
//    //with 0, my testCounter gives correct results but it's ugly coding, -> DISLIKE!
//    //animalObj.id = animalMngr.objCount;
//    //animalObj.id = testCounter++;  //Works perfectly, but beautiful code is what i want. 
//    //animalObj.id = testCounter;
//    animalObj.Id = animalMngr.ElementCount;
//    //animalMngr.countId(animalMngr.animalArrayList);
//    //animalObj.id = animalMngr.countId(animalMngr.animalArrayList);
//    //animalObj.id = animalMngr.ElementCount;


//    //Check the users input if its valid by boolean. False -> not valid, true ->Valid
//    bool validAge = false;
//    //Check valid integer
//    //methods are for checking int value from the textboxes.
//    animalObj.Age = CheckAge(out validAge);
//    animalObj.Gender = listBoxGender.Text;



//    //int checkForNumber = 0;
//    //bool boolValue = int.TryParse(textBoxName.Text, out checkForNumber);
//    ////Check if the string is empty or null.....
//    //if (String.IsNullOrEmpty(textBoxName.Text) || boolValue)
//    //{ 
//    //    validInput = false;
//    //    MessageBox.Show("Objektet måste ha ett namn. INGA SIFFROR!");
//    //}
//    //Get the user input from textboxes

//    //Function of check valid income.
//    //boolValue, just for checking. 
//    bool validInput = false;
//    string boolValue = CheckForInt(out validInput);
//    animalObj.Name = boolValue;

//    //BIG PROBLEM:!
//    // I want my class Mammals and Bird to get data, this without success. I have to have public variables
//    //in my baseclass (Animal), this is bad. Big dislike. 
//    //I also instantiate this ones in the button method. 
//    //::::
//    //((Mammals)animalObj).Teeth = CheckTeeth(out prisOK);
//    //((Mammals)animalObj).Teeth = int.Parse(textBoxNoTeeth.Text);
//    //int x  = CheckTeeth(out prisOK);
//    //((Mammals)animalObj).teeth = x;


//    //return true or false depending on user input. 
//    //If both valid name and age ok, return true


//    return validInput && validAge;
//}
