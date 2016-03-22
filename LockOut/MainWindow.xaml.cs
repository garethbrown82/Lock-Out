using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;
using System.IO;

namespace LockOut
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Level[] CurrentLevels = LevelCreator.CreateLevels(); //Create the level Array and fill it useing the CreateLevels method
        Level CurrentLevel;
        //SavedLevel Save1 = new SavedLevel(); //Not sure if I need this here yet

        public MainWindow()
        {
            InitializeComponent();
        }

        
        //Initialise all values ---------------------------------------------------------------------------------------------------------------------------        
        
        //Set initial values
        private int TargetNumber;       
        private bool PuzzleSolved = false; //-------------- Not used yet but may be needed for level change               
        private int LevelsIndex;
        private int LevelNumber;

        //These are the level values that need to be obtained from the level class or an array


        //Initialise and Reset the Values for the current level ---------------------------------------------------------------------------------------------------
        private void InitialiseButtons() //Resets the buttons numbers to their initial values for the beggining of the level and for reset button
        {           
            LevelsIndex = cmbLevelChange.SelectedIndex; //Assign the current level as the level selected in the level selection combo box.
            CurrentLevel = CurrentLevels[LevelsIndex]; //Assign the selected level to the CurrentLevel variable

            LevelNumber = LevelsIndex + 1; //Sets the correct level number as the LevelsIndex(Which starts at 0) and adding 1.
            
            CurrentLevel.ResetValues(); //Reset the button Values to their initial start value
            DisplayValues();

            TargetNumber = CurrentLevel.TargetNumber;

            txtOutput.Text = "Equal = " + TargetNumber.ToString();
        }
        
        private void Grid_Loaded(object sender, RoutedEventArgs e) //GRID LOAD - Loads buttons initial values when grid is loaded
        {
            for (int i = 1; i <= CurrentLevels.Count(); ++i) //Populate the level selector with all levels
            {
                cmbLevelChange.Items.Add("Level " + i.ToString());
            }
            cmbLevelChange.SelectedIndex = 0;
            //End Populate level selector
            
            InitialiseButtons(); //Set the values of all the buttons
        }

        
        
        
        
        //Button Click Event Handlers ------------------------------------------------------------------------------------------------------------------------

        private void btn1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) //Button 1 Click - Event Handler
        {
            ButtonAction(1);
            DisplayValues();            
            CheckWin();
        }

        private void btn2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) //Button 2 Click - Event Handler
        {
            ButtonAction(2);
            DisplayValues();
            CheckWin();
        }

        private void btn3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) //Button 3 Click - Event Handler
        {
            ButtonAction(3);
            DisplayValues();
            CheckWin();
        }

        private void btn4_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) //Button 4 Click - Event Handler
        {
            ButtonAction(4);
            DisplayValues();
            CheckWin();
        }

        private void btnReset_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) //Reset button event handler
        {
            InitialiseButtons();
        }

        private void cmbLevelChange_SelectionChanged(object sender, SelectionChangedEventArgs e) //Level select change event handler
        {
            InitialiseButtons(); //Reset the values of the buttons            
        }

        
        
        
        //Methods for Main class -----------------------------------------------------------------------------------------------------------------------------

        private void CheckWin() //Checks to see if the Button numbers all equal the Target Number
        {
            if (int.Parse(btn1.Text) == TargetNumber &&
                int.Parse(btn2.Text) == TargetNumber &&
                int.Parse(btn3.Text) == TargetNumber && 
                int.Parse(btn4.Text) == TargetNumber)
            {
                PuzzleSolved = true;
                txtOutput.Text = "You Won!!!";
                SaveLevel();
            }
        }
        

        private void DisplayValues() //Displays the new values onto the buttons
        {
            btn1.Text = CurrentLevel.Value1.ToString();
            btn2.Text = CurrentLevel.Value2.ToString();
            btn3.Text = CurrentLevel.Value3.ToString();
            btn4.Text = CurrentLevel.Value4.ToString();
        }

        private void ButtonAction(int btnNumber) //The method for each click of the button, runs through the button actions array in the Level object
        {
            foreach (Level.ButtonAction button in CurrentLevel.ActionsArray)
            {
                button.Action(btnNumber, ref CurrentLevel.Value1, ref CurrentLevel.Value2, ref CurrentLevel.Value3, ref CurrentLevel.Value4);
            }
        }

        private void SaveLevel() //Saves the Current SavedLevel object as an XML file to the file path "Saves/Save1.xml
        {
            SavedLevel LevelSave1 = new SavedLevel();
            LevelSave1.LevelNumber = LevelNumber;
            XmlSerializer write = new XmlSerializer(typeof(SavedLevel));

            FileStream file = File.Create("Saves/Save1.xml");
            write.Serialize(file, LevelSave1);
            file.Close();
        }
    }
}
