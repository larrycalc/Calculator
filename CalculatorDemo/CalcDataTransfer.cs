using System.Collections.Generic;


namespace CalculatorDemo
{
    public class CalcDataTransfer
    {
        public IEnumerable<int> NumbersInput {get; set;}
        public string ErrorMessage { get; set; }
        public int NumberOutput { get; set; }
    }
}
