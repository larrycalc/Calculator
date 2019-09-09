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
            var inputString = "1,5000";
            int expected = 5001;

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

    }


    [TestClass]
    public class CalculatorMathTests
    {
        CalculatorMath calc = new CalculatorMath();

        [TestMethod]
        public void Addition_With2ValidInputs_SumsCorrectly()
        {
            // Arrange
            CalcDataTransfer calcDataTransfer = new CalcDataTransfer();
            calcDataTransfer.NumbersInput = new List<int> { 1, 5000 };

            int expected = 5001;

            // Act
            var result = calc.MathOperation(calcDataTransfer);

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
            var result = calc.MathOperation(calcDataTransfer);

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
            var result = calc.MathOperation(calcDataTransfer);

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
            var result = calc.MathOperation(calcDataTransfer);

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

    }
}
