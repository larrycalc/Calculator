using System;


namespace CalculatorDemo
{
    /// <summary>
    /// Calculator receives an input string with possible custom delimiters and numbers.
    /// The string will be parsed, an arithimetic operation will be performed on the numbers and a result returned.
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var inputString = ConsoleInput();

                Calculator calculator = new Calculator();
                CalcDataTransfer calcDataTransfer = calculator.Run(inputString);

                if (calcDataTransfer.ErrorMessage == null)
                {
                    Console.WriteLine(calcDataTransfer.NumberOutput);
                }
                else
                {
                    Console.WriteLine(calcDataTransfer.ErrorMessage);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("An Exception occured");
            }
        }


        // Receive user input from a Console window
        public static string ConsoleInput()
        {
            Console.WriteLine("Enter 1 or 2 numbers seperated by a , . For example 1,2");

            const int newlineValue = 10;
            const int carriageReturnValue = 13;

            string readInput = "";

            // Read input until Carriage Return And New Line entered.
            while (true)
            {
                var firstInput = Console.Read();
                if (firstInput == carriageReturnValue)
                {
                    var secondInput = Console.Read();
                    if (secondInput == newlineValue)
                    {
                        break;
                    }
                }
                readInput += Convert.ToChar(firstInput);
            }

            return readInput;
        }
    }
}