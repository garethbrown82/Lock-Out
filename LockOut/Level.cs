using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace LockOut
{
    public class Level
    {
        //Propery values --------------------------------------------------------------------------------------------------------------------------------
        public int TargetNumber;
        public int StartValue1;
        public int StartValue2;
        public int StartValue3;
        public int StartValue4;

        public int Value1;
        public int Value2;
        public int Value3;
        public int Value4;

        public ButtonAction[] ActionsArray; //Button Actions array
        
        //Constructor methods -----------------------------------------------------------------------------------------------------------------------------
        public Level(int TargetNumber, int StartValue1, int StartValue2, int StartValue3, int StartValue4)
        {
            this.TargetNumber = TargetNumber;
            this.StartValue1 = StartValue1;
            this.StartValue2 = StartValue2;
            this.StartValue3 = StartValue3;
            this.StartValue4 = StartValue4;
        }

        
        
        //Class Methods ----------------------------------------------------------------------------------------------------------------------------------------
        public void ResetValues() //Reset the button Values to their initial start value
        {
            Value1 = StartValue1;
            Value2 = StartValue2;
            Value3 = StartValue3;
            Value4 = StartValue4;
        }
        
        
        
        //Nested class 'ButtonAction' each object is a new mathamatical operation taken during a button press -----------------------------------------------------

        public class ButtonAction
        {
            private int OnPress; //Assigns which button will be pressed
            private int ValueToEffect;
            private string Operation;
            private int OpValue;
            private bool isOperandValue = false;
            private string OperandValue = "";


            //Constructor

            public ButtonAction(int OnPress, int ValueToEffect, string Operation, int OpValue)
            {
                this.OnPress = OnPress;
                this.ValueToEffect = ValueToEffect;
                this.Operation = Operation;
                this.OpValue = OpValue;
            }

            public ButtonAction(int OnPress, int ValueToEffect, string Operation, string Value) //Over loaded constructor
            {
                this.OnPress = OnPress;
                this.ValueToEffect = ValueToEffect;
                this.Operation = Operation;
                this.OperandValue = Value;
                isOperandValue = true;
            }

            
            //Action method -----------------------------------------------------------------------------------------         


            public void Action(int ButtonPressed, ref int Value1, ref int Value2, ref int Value3, ref int Value4)
            {
                int EffectValue = 0;

                if (OnPress == ButtonPressed) //Only run if the button assigned to trigger this method has been pressed
                {


                    //Assign the specified Effected Value to the variable 'EffectValue'
                    switch (ValueToEffect)
                    {
                        case 1:
                            EffectValue = Value1;
                            break;
                        case 2:
                            EffectValue = Value2;
                            break;
                        case 3:
                            EffectValue = Value3;
                            break;
                        case 4:
                            EffectValue = Value4;
                            break;
                    }

                    if (isOperandValue) //If the Value is effected by another value and not a static number then the 'OpValue' will be set to the current Value
                    {
                        switch (OperandValue)
                        {
                            case "Value1":
                                OpValue = Value1;
                                break;
                            case "Value2":
                                OpValue = Value2;
                                break;
                            case "Value3":
                                OpValue = Value3;
                                break;
                            case "Value4":
                                OpValue = Value4;
                                break;
                        }
                    }

                    //run through the specified operation
                    if (Operation == "Add")
                    {
                        EffectValue += OpValue;
                    }
                    else if (Operation == "Sub")
                    {
                        EffectValue -= OpValue;
                    }
                    else if (Operation == "Mult")
                    {
                        EffectValue *= OpValue;
                    }
                    else if (Operation == "Div")
                    {
                        EffectValue /= OpValue;
                    }



                    //Pass the value of EffectValue back to the specified effected value
                    switch (ValueToEffect)
                    {
                        case 1:
                            Value1 = EffectValue;
                            break;
                        case 2:
                            Value2 = EffectValue;
                            break;
                        case 3:
                            Value3 = EffectValue;
                            break;
                        case 4:
                            Value4 = EffectValue;
                            break;
                    }

                }
            }
        }
    }
}
