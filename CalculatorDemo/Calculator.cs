using System.Collections.Generic;

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
                calcDataTransfer.NumberOutput = MathOperation(calcDataTransfer);
                calcDataTransfer.Formula = CreateFormula(calcDataTransfer);
            }

            return calcDataTransfer;
        }

        public int MathOperation(CalcDataTransfer calcDataTransfer)
        {
            int result = 0;

            // loop through list and perform mathematical operation
            foreach (int s in calcDataTransfer.NumbersInput)
            {
                result += s;
            }

            return result;
        }

        public string CreateFormula(CalcDataTransfer calcDataTransfer)
        {
            string formula = "";

            var numbersList = (List<int>)(calcDataTransfer.NumbersInput);

            for (int i = 0; i < numbersList.Count; i++)
            {
                formula += numbersList[i];
                if (i < numbersList.Count - 1)
                    formula += "+";
            }

            formula += " = " + calcDataTransfer.NumberOutput;

            return formula;
        }
    }
}
