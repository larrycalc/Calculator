
namespace CalculatorDemo
{
    /// <summary>
    /// Main processing of Calculator Demo Project.
    /// </summary>
    public class Calculator
    {
        public CalcDataTransfer Run(string inputString)
        {
            InputProcessor inputProcessing = new InputProcessor();

            CalcDataTransfer calcDataTransfer = inputProcessing.SeperateValues(inputString);

            if (calcDataTransfer.ErrorMessage == null)
            {
                var calculator = new CalculatorMath();
                calcDataTransfer.NumberOutput = calculator.MathOperation(calcDataTransfer);
            }

            return calcDataTransfer;
        }
    }
}
