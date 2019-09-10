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
            while (true)
            {
                try
                {
                    var inputString = ConsoleInput();

                    Calculator calculator = new Calculator();
                    CalcDataTransfer calcDataTransfer = calculator.Run(inputString);

                    if (calcDataTransfer.ErrorMessage == null)
                    {
                        Console.WriteLine(calcDataTransfer.NumberOutput);
                        Console.WriteLine(calcDataTransfer.Formula);
                    }
                    else
                    {
                        Console.WriteLine(calcDataTransfer.ErrorMessage);
                    }
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception)
                {
                    Console.WriteLine("An Exception occured.");
                }

                Console.WriteLine();
            }
        }


        // Receive user input from a Console window
        public static string ConsoleInput()
        {
            Console.WriteLine("Enter 1 or more numbers seperated by a , or create a custom delimited string in the format: //[{delimiter1}][{delimiter2}]...\\n{numbers}");
            Console.WriteLine("Or Press Ctrl+C to exit.");

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