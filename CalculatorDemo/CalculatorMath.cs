
namespace CalculatorDemo
{
    public class CalculatorMath
    {
        public int MathOperation(CalcDataTransfer arguments)
        {
            int result = 0;

            // loop through list and perform mathematical operation
            foreach (int s in arguments.NumbersInput)
            {
                result += s;
            }

            return result;
        }
    }
}
