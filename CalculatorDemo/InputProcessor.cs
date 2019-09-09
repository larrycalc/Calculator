using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CalculatorDemo
{
    public class InputProcessor
    {
        // Seperate the input string using delimiters and return the number values
        public CalcDataTransfer SeperateValues(string argument)
        {
            CalcDataTransfer calcDataTransfer = new CalcDataTransfer();

            calcDataTransfer.InputString = argument;
            
            var customDelimiter = FindCustomDelimiter(calcDataTransfer);



            List<string> delimiterInitial = new List<string> { ",", "\n" };

            foreach (var item in customDelimiter.Delimiters)
            {
                delimiterInitial.Add(item);
            }

            var delimiter = delimiterInitial.ToArray();
            

            // Separate the input numbers based on a delimiter
            var strList = argument.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);

            // Reports error if more than 2 values entered.
            //if (strList.Length > 2)
            //{
            //    calcDataTransfer.ErrorMessage = "Error:  Only 2 values can be entered.";
            //    return calcDataTransfer;
            //}

            List<int> numberList = ValidateNumberList(strList);

            calcDataTransfer.NumbersInput = numberList;

            return calcDataTransfer;
        }


        // Adds entries in a list if numbers are valid based on rules.
        public static List<int> ValidateNumberList(string[] strList)
        {
            List<int> numberList = new List<int>();
            string negativeNumberList = "";

            if (strList.Length > 0)
            {
                // Place each number into array
                for (int i = 0; i < strList.Length; i++)
                {
                    if (Int32.TryParse(strList[i], out int number))
                    {
                        if (number < 1001)
                        {
                            numberList.Add(number);
                        }
                        if (number < 0)
                        {
                            negativeNumberList += number + " ";
                        }
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

            if (negativeNumberList != "")
            {
                throw new ArgumentOutOfRangeException("Negative numbers are not allowed: " + negativeNumberList);
            }

            return numberList;
        }


        // Finds custom delimiters and returns them and the remaining search string.
        public CalcDataTransfer FindCustomDelimiter(CalcDataTransfer calcDataTransfer)
        {
            // Pattern for a custom defined delimiter: //{delimiter}\n{numbers} 
            Regex rx = new Regex(@"\/\/(.)\n");

            string text = calcDataTransfer.InputString;
            string searchText = calcDataTransfer.InputString;

            // Find matches.
            MatchCollection matches = rx.Matches(text);

            var match = "";
            List<string> delimiters = new List<string>();

            // A custom delimiter exists
            if (matches.Count > 0)
            {
                // Groups[1] contains matched text only
                match = matches[0].Groups[1].Value;
                delimiters.Add(match);

                // get text after custom delimiter
                searchText = text.Substring(match.Length + 3);
            }

            calcDataTransfer.Delimiters = delimiters;
            calcDataTransfer.SearchString = searchText;

            return calcDataTransfer;
        }
    }
}
