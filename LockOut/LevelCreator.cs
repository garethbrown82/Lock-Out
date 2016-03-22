using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockOut
{
    public static class LevelCreator
    {
        public static Level[] Levels; //Initiate Levels array
        
        public static Level[] CreateLevels() //Level Creator method which creates all the levels and then returns them the levels array
        {
            //First Create a new level below that takes 5 args (Target number, Button1 Start Value, Button2 Start Value, Button3 Start Value, Button4 Start Value, 
            
            Level Level1 = new Level(20, 5, 8, 4, 10); //Level 1
            
            ////Then Create a new actions array of all the button action objects this takes 4 args(Button that triggers this action, Button value to affect, operation as a string ["Add", "Sub", "Mult", "Div"] and the value operand as an integer. You can also add a button value for the operand using a string ["Value1", "Value2", "Value3" or "Value4"]          
            Level1.ActionsArray = new Level.ButtonAction[] 
            {                
                new Level.ButtonAction(1, 1, "Add", 5),
                new Level.ButtonAction(2, 2, "Add", 2),
                new Level.ButtonAction(3, 3, "Add", 4),
                new Level.ButtonAction(4, 4, "Mult", 2),
            };


            Level Level2 = new Level(40, 10, 10, 30, 10); //Level 2
            Level2.ActionsArray = new Level.ButtonAction[] 
            {
                new Level.ButtonAction(1, 1, "Add", 15),
                new Level.ButtonAction(2, 2, "Add", "Value3"),
                new Level.ButtonAction(3, 3, "Add", 5),
                new Level.ButtonAction(4, 4, "Mult", 2),
            };

            Level Level3 = new Level(100, 25, 10, 90, 400); //Level 3
            Level3.ActionsArray = new Level.ButtonAction[] 
            {
                new Level.ButtonAction(1, 1, "Mult", 2),
                new Level.ButtonAction(2, 2, "Add", "Value3"),
                new Level.ButtonAction(3, 3, "Add", 2),
                new Level.ButtonAction(4, 4, "Div", 2),
            };

            Level Level4 = new Level(30, 14, 32, 9, 12); //Level 4
            Level4.ActionsArray = new Level.ButtonAction[] 
            {
                new Level.ButtonAction(1, 1, "Add", 4),
                new Level.ButtonAction(2, 2, "Sub", 2),
                new Level.ButtonAction(2, 1, "Add", 4),
                new Level.ButtonAction(3, 3, "Add", 7),
                new Level.ButtonAction(4, 4, "Add", 9),
            };

            Level Level5 = new Level(15, 10, 11, 5, 13); //Level 5
            Level5.ActionsArray = new Level.ButtonAction[] 
            {
                new Level.ButtonAction(1, 1, "Add", 10),
                new Level.ButtonAction(2, 2, "Add", 1),
                new Level.ButtonAction(2, 3, "Add", 2),
                new Level.ButtonAction(3, 1, "Sub", 5),
                new Level.ButtonAction(3, 3, "Add", 5),
                new Level.ButtonAction(4, 3, "Sub", 3),
                new Level.ButtonAction(4, 4, "Add", 2),
            };

            Level Level6 = new Level(60, 35, 20, 62, 12); //Level 6
            Level6.ActionsArray = new Level.ButtonAction[] 
            {
                new Level.ButtonAction(1, 3, "Sub", 4),
                new Level.ButtonAction(2, 1, "Add", 5),
                new Level.ButtonAction(2, 3, "Add", 2),
                new Level.ButtonAction(4, 2, "Add", 20),
                new Level.ButtonAction(4, 4, "Add", 24),
            };

            Level Level7 = new Level(42, 38, 6, 70, 40); //Level 7
            Level7.ActionsArray = new Level.ButtonAction[] 
            {
                new Level.ButtonAction(1, 1, "Sub", 3),
                new Level.ButtonAction(4, 1, "Add", 8),
                new Level.ButtonAction(2, 3, "Sub", 7),
                new Level.ButtonAction(2, 2, "Add", 9),
                new Level.ButtonAction(3, 2, "Add", 20),
                new Level.ButtonAction(4, 4, "Add", 1),
            };

            Level Level8 = new Level(16, 2, 2, 4, 8); //Level 8
            Level8.ActionsArray = new Level.ButtonAction[] 
            {
                new Level.ButtonAction(1, 1, "Mult", 2),
                new Level.ButtonAction(2, 2, "Add", 7),
                new Level.ButtonAction(3, 3, "Add", 4),
                new Level.ButtonAction(4, 4, "Add", 2),
                new Level.ButtonAction(4, 1, "Sub", 4),
            };

            Level Level9 = new Level(21, 7, 9, 42, 7); //Level 9
            Level9.ActionsArray = new Level.ButtonAction[] 
            {
                new Level.ButtonAction(1, 1, "Add", 2),
                new Level.ButtonAction(1, 3, "Add", 7),
                new Level.ButtonAction(2, 2, "Add", 4),
                new Level.ButtonAction(3, 3, "Add", 2),
                new Level.ButtonAction(4, 3, "Sub", 10),
                new Level.ButtonAction(4, 4, "Add", 2),
            };

            Level Level10 = new Level(50, 1, 38, 20, 22); //Level 10
            Level10.ActionsArray = new Level.ButtonAction[] 
            {
                new Level.ButtonAction(1, 1, "Add", 7),
                new Level.ButtonAction(2, 2, "Add", 3),
                new Level.ButtonAction(3, 3, "Add", 5),
                new Level.ButtonAction(4, 1, "Add", 7),
                new Level.ButtonAction(4, 4, "Add", 4),
            };


            
            
            //Put all levels into Levels[] Array - Make sure you add a new Level object to the Level Array when you create one above
            Levels = new Level[] {
                Level1,
                Level2,
                Level3,
                Level4,
                Level5,
                Level6,
                Level7,
                Level8,
                Level9,
                Level10
            };

            return Levels;
        }
    }
}


//Harder levels for later---------------------------------------------------

//Level Level4 = new Level(27, 3, 49, 11, 20); //Level 4
//Level4.ActionsArray = new Level.ButtonAction[] 
//{
//    new Level.ButtonAction(1, 1, "Add", 6),
//    new Level.ButtonAction(2, 2, "Sub", 2),
//    new Level.ButtonAction(2, 1, "Add", 6),
//    new Level.ButtonAction(3, 3, "Add", 4),
//    new Level.ButtonAction(4, 3, "Sub", 8),
//    new Level.ButtonAction(4, 4, "Add", 7),
//    new Level.ButtonAction(4, 2, "Sub", 14)

//};