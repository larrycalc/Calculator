using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalculatorDemo;
using System.Collections.Generic;


namespace CalculatorDemoTests
{
    [TestClass]
    public class CalculatorFunctionalTests
    {
        Calculator calculator = new Calculator();

        [TestMethod]
        public void CalculatorAddition_With2ValidInputs_SumsCorrectly()
        {
            // Arrange
            var inputString = "1,500";
            int expected = 501;

            // Act
            CalcDataTransfer calcDataTransfer = calculator.Run(inputString);

            // Assert
            Assert.AreEqual(expected, calcDataTransfer.NumberOutput);
        }

        [TestMethod]
        public void CalculatorAddition_WithMultipleValidInputs_SumsCorrectly()
        {
            // Arrange
            var inputString = "1,2,3";
            int expected = 6;

            // Act
            CalcDataTransfer calcDataTransfer = calculator.Run(inputString);

            // Assert
            Assert.AreEqual(expected, calcDataTransfer.NumberOutput);
        }

        [TestMethod]
        public void CalculatorAddition_WithMultipleValidInvalidInputs_SumsCorrectly()
        {
            // Arrange
            var inputString = "1,tytyt,3";
            int expected = 4;

            // Act
            CalcDataTransfer calcDataTransfer = calculator.Run(inputString);

            // Assert
            Assert.AreEqual(expected, calcDataTransfer.NumberOutput);
        }

        [TestMethod]
        public void CalculatorAddition_With3ValidInputsAndNewline_SumsCorrectly()
        {
            // Arrange
            var inputString = "1\n2,3";
            int expected = 6;

            // Act
            CalcDataTransfer calcDataTransfer = calculator.Run(inputString);

            // Assert
            Assert.AreEqual(expected, calcDataTransfer.NumberOutput);
        }

        [TestMethod]
        public void CalculatorAddition_IgnoreGreaterThan1000_SumsCorrectly()
        {
            // Arrange
            var inputString = "2,1001,6 ";
            int expected = 8;

            // Act
            CalcDataTransfer calcDataTransfer = calculator.Run(inputString);

            // Assert
            Assert.AreEqual(expected, calcDataTransfer.NumberOutput);
        }

        [TestMethod]
        public void CalculatorAddition_WithSingleCharacterCustomDelimiter_SumsCorrectly()
        {
            // Arrange
            var inputString = "//;\n2;5";
            int expected = 7;

            // Act
            CalcDataTransfer calcDataTransfer = calculator.Run(inputString);

            // Assert
            Assert.AreEqual(expected, calcDataTransfer.NumberOutput);
        }

        [TestMethod]
        public void CalculatorAddition_WithMultipleCharacterCustomDelimiter_SumsCorrectly()
        {
            // Arrange
            var inputString = "//[***]\n11***22***33";
            int expected = 66;

            // Act
            CalcDataTransfer calcDataTransfer = calculator.Run(inputString);

            // Assert
            Assert.AreEqual(expected, calcDataTransfer.NumberOutput);
        }

        [TestMethod]
        public void CalculatorAddition_WithMultipleCustomDelimiters_SumsCorrectly()
        {
            // Arrange
            var inputString = "//[*][!!][rrr]\n11rrr22*33!!44";
            int expected = 110;

            // Act
            CalcDataTransfer calcDataTransfer = calculator.Run(inputString);

            // Assert
            Assert.AreEqual(expected, calcDataTransfer.NumberOutput);
        }

        [TestMethod]
        public void CalculatorAddition_WithMultipleCustomDelimitersInvalidNumber_SumsCorrectly()
        {
            // Arrange
            var inputString = "//[*][!!][rrr]\n11rrr22,tytyt,*33!!44";
            int expected = 110;

            // Act
            CalcDataTransfer calcDataTransfer = calculator.Run(inputString);

            // Assert
            Assert.AreEqual(expected, calcDataTransfer.NumberOutput);
        }

        [TestMethod]
        public void CalculatorAddition_WithMultipleCustomDelimiters_FormulaCorrect()
        {
            // Arrange
            var inputString = "//[*][!!][rrr]\n11rrr22*33!!44";
            string expected = "11+22+33+44 = 110";

            // Act
            CalcDataTransfer calcDataTransfer = calculator.Run(inputString);

            // Assert
            Assert.AreEqual(expected, calcDataTransfer.Formula);
        }

        [TestMethod]
        public void CalculatorAddition_WithMultipleCustomDelimitersInvalidNumber_FormulaCorrect()
        {
            // Arrange
            var inputString = "//[*][!!][rrr]\n11rrr22,tytyt,*33!!44";
            string expected = "11+22+0+33+44 = 110";

            // Act
            CalcDataTransfer calcDataTransfer = calculator.Run(inputString);

            // Assert
            Assert.AreEqual(expected, calcDataTransfer.Formula);
        }

    }


    [TestClass]
    public class CalculatorMathTests
    {
        Calculator calculator = new Calculator();

        [TestMethod]
        public void Addition_With2ValidInputs_SumsCorrectly()
        {
            // Arrange
            CalcDataTransfer calcDataTransfer = new CalcDataTransfer();
            calcDataTransfer.NumbersInput = new List<int> { 1, 5000 };

            int expected = 5001;

            // Act
            var result = calculator.MathOperation(calcDataTransfer);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Addition_WithNumerousValidInputs_SumsCorrectly()
        {
            // Arrange
            CalcDataTransfer calcDataTransfer = new CalcDataTransfer();
            calcDataTransfer.NumbersInput = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };

            int expected = 78;

            // Act
            var result = calculator.MathOperation(calcDataTransfer);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Addition_With1ValidInput_SumsCorrectly()
        {
            // Arrange
            CalcDataTransfer calcDataTransfer = new CalcDataTransfer();
            calcDataTransfer.NumbersInput = new List<int> { 20 };

            int expected = 20;

            // Act
            var result = calculator.MathOperation(calcDataTransfer);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Addition_WithMissingInput_Returns0()
        {
            // Arrange
            CalcDataTransfer calcDataTransfer = new CalcDataTransfer();
            calcDataTransfer.NumbersInput = new List<int> { };

            int expected = 0;

            // Act
            var result = calculator.MathOperation(calcDataTransfer);

            // Assert
            Assert.AreEqual(expected, result);
        }
    }


    [TestClass]
    public class InputProcessingTests
    {
        InputProcessor inputProcessor = new InputProcessor();

        [TestMethod]
        public void SeperateValues_With2ValidInputs_StoresCorrectly()
        {
            // Arrange
            string inputValues = "1,2";
            List<int> expected = new List<int> { 1, 2 };

            // Act
            CalcDataTransfer calcDataTransfer = inputProcessor.SeperateValues(inputValues);

            // Assert
            CollectionAssert.AreEquivalent(expected, (List<int>)calcDataTransfer.NumbersInput);
        }

        [TestMethod]
        public void SeperateValues_With3ValidInputs_StoresCorrectly()
        {
            // Arrange
            string inputValues = "1,2,3";
            List<int> expected = new List<int> { 1, 2, 3 };

            // Act
            CalcDataTransfer calcDataTransfer = inputProcessor.SeperateValues(inputValues);

            // Assert
            CollectionAssert.AreEquivalent(expected, (List<int>)calcDataTransfer.NumbersInput);
        }

        [TestMethod]
        public void SeperateValues_WithInValidInteger_Stores0()
        {
            // Arrange
            string inputValues = "tytyt";
            List<int> expected = new List<int> { 0 };

            // Act
            CalcDataTransfer calcDataTransfer = inputProcessor.SeperateValues(inputValues);

            // Assert
            CollectionAssert.AreEquivalent(expected, (List<int>)calcDataTransfer.NumbersInput);
        }

        [TestMethod]
        public void SeperateValues_WithEmptyStringInput_Returns0()
        {
            // Arrange
            string inputValues = "";
            List<int> expected = new List<int> { 0 };

            // Act
            CalcDataTransfer calcDataTransfer = inputProcessor.SeperateValues(inputValues);

            // Assert
            CollectionAssert.AreEquivalent(expected, (List<int>)calcDataTransfer.NumbersInput);
        }

        //[TestMethod]
        //public void SeperateValues_With3Inputs_ReturnsError()
        //{
        //    // Arrange
        //    string inputValues = "1,2,3";
        //    List<int> expected = new List<int> { 1, 2 };

        //    // Act
        //    CalcDataTransfer calcDataTransfer = inputProcessor.SeperateValues(inputValues);

        //    // Assert
        //    Assert.IsNotNull(calcDataTransfer.ErrorMessage);
        //}

        [TestMethod]
        public void SeperateValues_With2ValidInputsAndNewline_StoresCorrectly()
        {
            // Arrange
            string inputValues = "1\n2";
            List<int> expected = new List<int> { 1, 2 };

            // Act
            CalcDataTransfer calcDataTransfer = inputProcessor.SeperateValues(inputValues);

            // Assert
            CollectionAssert.AreEquivalent(expected, (List<int>)calcDataTransfer.NumbersInput);
        }

        [TestMethod]
        public void SeperateValues_WithMultipleCharacterCustomDelimiter_StoresCorrectly()
        {
            // Arrange
            string inputValues = "//[*][!!][rrr]\n11rrr22*33!!44";
            List<int> expected = new List<int> { 11, 22, 33, 44 };

            // Act
            CalcDataTransfer calcDataTransfer = inputProcessor.SeperateValues(inputValues);

            // Assert
            CollectionAssert.AreEquivalent(expected, (List<int>)calcDataTransfer.NumbersInput);
        }

        [TestMethod]
        public void ValidateNumberList_With1NegativeNumber_ThrowsException()
        {
            // Arrange
            string[] inputValues = new string[] { "-1" };

            try
            {
                inputProcessor.ValidateNumberList(inputValues);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                // Assert
                StringAssert.Contains(e.Message, "-1");
            }
        }

        [TestMethod]
        public void ValidateNumberList_WithNegativePositiveNumbers_ThrowsExceptionWithOnlyNegativeNumbersReturned()
        {
            // Arrange
            string[] inputValues = new string[] { "-1", "3", "-2" };

            try
            {
                inputProcessor.ValidateNumberList(inputValues);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                // Assert
                StringAssert.Contains(e.Message, "-1");
                StringAssert.Contains(e.Message, "-2");
                Assert.IsFalse(e.Message.Contains("3"));
            }
        }

        [TestMethod]
        public void FindCustomDelimiter_With1CharacterCustomDelimiter_ReturnsDelimiterAndSearchText()
        {
            // Arrange
            CalcDataTransfer calcDataTransfer = new CalcDataTransfer();
            calcDataTransfer.InputString = "//;\n2;5";

            List<string> expected = new List<string> { ";" };
            string searchText = "2;5";

            // Act
            var result = inputProcessor.FindCustomDelimiterSearchText(calcDataTransfer);

            // Assert
            CollectionAssert.AreEquivalent(expected, (List<string>)result.Delimiters);
            Assert.AreEqual(searchText, result.SearchString);
        }

        [TestMethod]
        public void FindCustomDelimiter_With2CharacterCustomDelimiter_ReturnsNoDelimiterAndCompleteInputString()
        {
            // Arrange
            CalcDataTransfer calcDataTransfer = new CalcDataTransfer();
            calcDataTransfer.InputString = "//;:\n2;5";

            List<string> expected = new List<string> {};
            string searchText = "//;:\n2;5";

            // Act
            var result = inputProcessor.FindCustomDelimiterSearchText(calcDataTransfer);

            // Assert
            CollectionAssert.AreEquivalent(expected, (List<string>)result.Delimiters);
            Assert.AreEqual(searchText, result.SearchString);
        }

        [TestMethod]
        public void FindCustomDelimiter_WithMultipleCharacterCustomDelimiter_ReturnsDelimiterAndSearchText()
        {
            // Arrange
            CalcDataTransfer calcDataTransfer = new CalcDataTransfer();
            calcDataTransfer.InputString = "//[***]\n11***22***33";

            List<string> expected = new List<string> { "***" };
            string searchText = "11***22***33";

            // Act
            var result = inputProcessor.FindCustomDelimiterSearchText(calcDataTransfer);

            // Assert
            CollectionAssert.AreEquivalent(expected, (List<string>)result.Delimiters);
            Assert.AreEqual(searchText, result.SearchString);
        }

        [TestMethod]
        public void FindCustomDelimiter_WithMultipleCustomDelimiters_ReturnsDelimitersAndSearchText()
        {
            // Arrange
            CalcDataTransfer calcDataTransfer = new CalcDataTransfer();
            calcDataTransfer.InputString = "//[*][!!][rrr]\n11rrr22*33!!44";

            List<string> expected = new List<string> { "*", "!!", "rrr" };
            string searchText = "11rrr22*33!!44";

            // Act
            var result = inputProcessor.FindCustomDelimiterSearchText(calcDataTransfer);

            // Assert
            CollectionAssert.AreEquivalent(expected, (List<string>)result.Delimiters);
            Assert.AreEqual(searchText, result.SearchString);
        }

    }

    [TestClass]
    public class CalulatorTests
    {
        [TestMethod]
        public void CreateFormula_WithValidNumbers_OutputsFormula()
        {
            // Arrange
            Calculator calculator = new Calculator();
            CalcDataTransfer calcDataTransfer = new CalcDataTransfer();
            calcDataTransfer.NumbersInput = new List<int> { 1, 2, 3 };
            calcDataTransfer.NumberOutput = 6;
            string expected = "1+2+3 = 6";

            // Act
            var result = calculator.CreateFormula(calcDataTransfer);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void CreateFormula_WithNoNumbers_OutputsFormula()
        {
            // Arrange
            Calculator calculator = new Calculator();
            CalcDataTransfer calcDataTransfer = new CalcDataTransfer();
            calcDataTransfer.NumbersInput = new List<int> { };
            calcDataTransfer.NumberOutput = 0;
            string expected = " = 0";

            // Act
            var result = calculator.CreateFormula(calcDataTransfer);

            // Assert
            Assert.AreEqual(expected, result);
        }

    }

}
