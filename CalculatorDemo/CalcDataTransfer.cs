using System.Collections.Generic;


namespace CalculatorDemo
{
    public class CalcDataTransfer
    {
        public IEnumerable<int> NumbersInput {get; set;}
        public string ErrorMessage { get; set; }
        public int NumberOutput { get; set; }

        public string InputString { get; set; }
        public string SearchString { get; set; }
        public List<string> Delimiters { get; set; }
    }
}
