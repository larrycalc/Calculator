using System;
using System.Collections.Generic;


namespace CalculatorDemo
{
    public class InputProcessor
    {
        // Seperate the input string using delimiters and return the number values
        public CalcDataTransfer SeperateValues(string argument)
        {
            CalcDataTransfer calcDataTransfer = new CalcDataTransfer();

            string delimiter = ",";

            // Separate the input numbers based on a delimiter
            var strList = argument.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);

            // Reports error if more than 2 values entered.
            //if (strList.Length > 2)
            //{
            //    calcDataTransfer.ErrorMessage = "Error:  Only 2 values can be entered.";
            //    return calcDataTransfer;
            //}

            List<int> numberList = new List<int>();

            if (strList.Length > 0)
            {
                // Place each number into array
                for (int i = 0; i < strList.Length; i++)
                {
                    if (Int32.TryParse(strList[i], out int number))
                    {
                        numberList.Add(number);
                    }
                    else
                    {
                        numberList.Add(0);
                    }
                }
            }
            else                                // handle "" scenario
            {
                numberList.Add(0);
            }

            calcDataTransfer.NumbersInput = numberList;

            return calcDataTransfer;
        }
    }
}
