using System;
using System.IO;
using System.Text.RegularExpressions;
using Xunit;

namespace Calculator.Tests
{
    public class CalculatorTests
    {
        [Fact]
        public void ShouldBeAbleToCreateCalculatorClass()
        {
            CalculatorProgram.Calculator calculator = new CalculatorProgram.Calculator();

            Assert.NotNull(calculator);

            calculator.Finish();
        }

        [Fact]
        public void ShouldBeAbleToDoAddOperation()
        {
            CalculatorProgram.Calculator calculator = new CalculatorProgram.Calculator();

            Assert.Equal(11.6, calculator.DoOperation(5.1, 6.5, "a"));

            calculator.Finish();
        }

        [Fact]
        public void ShouldBeAbleToDoMultiplyOperation()
        {
            CalculatorProgram.Calculator calculator = new CalculatorProgram.Calculator();

            Assert.Equal(65.0, calculator.DoOperation(10.0, 6.5, "m"));

            calculator.Finish();
        }

        [Fact]
        public void ShouldBeAbleToDoSubstractOperation()
        {
            CalculatorProgram.Calculator calculator = new CalculatorProgram.Calculator();

            Assert.Equal(71.1, calculator.DoOperation(132.5, 61.4, "s"));

            calculator.Finish();
        }

        [Fact]
        public void ShouldBeAbleToDoDivideOperation()
        {
            CalculatorProgram.Calculator calculator = new CalculatorProgram.Calculator();

            Assert.Equal(2.5, calculator.DoOperation(5.0, 2.0, "d"));

            calculator.Finish();
        }

        [Fact]
        public void ShouldNotBeAbleToDoDivideByZeroOperation()
        {
            CalculatorProgram.Calculator calculator = new CalculatorProgram.Calculator();

            Assert.Throws<Newtonsoft.Json.JsonWriterException>(() => calculator.DoOperation(16.2, 0.0, "d"));

            calculator.Finish();
        }

        [Fact]
        public void ShouldNotBeAbleToDoOtherOperations()
        {
            CalculatorProgram.Calculator calculator = new CalculatorProgram.Calculator();

            Assert.Throws<Newtonsoft.Json.JsonWriterException>(() => calculator.DoOperation(16.2, 0.0, "d"));

            calculator.Finish();
        }

        [Fact]
        public void ShouldBeAbleToCreateProgramClass()
        {
            CalculatorProgram.Program program = new CalculatorProgram.Program();

            Assert.NotNull(program);
        }

        [Fact]
        public void ShouldBeAbleToRunProgramMain()
        {
            var output = new StringWriter();
            Console.SetOut(output);

            var input = new StringReader(@"43
119
d
n");
            Console.SetIn(input);

            CalculatorProgram.Program.Main(new string[] { });

            var expectedOutput = "Console Calculator in C#"+
                                 "------------------------"+
                                 "Type a number, and then press Enter: " +
                                 "Type another number, and then press Enter: " +
                                 "Choose an operator from the following list:" +
                                 "a - Add" +
                                 "s - Subtract" +
                                 "m - Multiply" +
                                 "d - Divide" +
                                 "Your option? " +
                                 "Your result: 0,36" +
                                 "------------------------" +
                                 "Press 'n' and Enter to close the app, or press any other key and Enter to continue: ";

            Assert.Equal(expectedOutput, Regex.Replace(output.ToString(), @"[\r\t\n]+", string.Empty));
        }

        [Fact]
        public void ShouldBeAbleToRunProgramMainWithIncorrectFirstArg()
        {
            var output = new StringWriter();
            Console.SetOut(output);

            var input = new StringReader(@"avd
43
119
d
n");
            Console.SetIn(input);

            CalculatorProgram.Program.Main(new string[] { });

            var expectedOutput = "Console Calculator in C#" +
                                 "------------------------" +
                                 "Type a number, and then press Enter: " +
                                 "This is not valid input. Please enter an integer value: " +
                                 "Type another number, and then press Enter: " +
                                 "Choose an operator from the following list:" +
                                 "a - Add" +
                                 "s - Subtract" +
                                 "m - Multiply" +
                                 "d - Divide" +
                                 "Your option? " +
                                 "Your result: 0,36" +
                                 "------------------------" +
                                 "Press 'n' and Enter to close the app, or press any other key and Enter to continue: ";

            Assert.Equal(expectedOutput, Regex.Replace(output.ToString(), @"[\r\t\n]+", string.Empty));
        }

        [Fact]
        public void ShouldBeAbleToRunProgramMainWithIncorrectSecondArg()
        {
            var output = new StringWriter();
            Console.SetOut(output);

            var input = new StringReader(@"43
avd
119
d
n");
            Console.SetIn(input);

            CalculatorProgram.Program.Main(new string[] { });

            var expectedOutput = "Console Calculator in C#" +
                                 "------------------------" +
                                 "Type a number, and then press Enter: " +
                                 "Type another number, and then press Enter: " +
                                 "This is not valid input. Please enter an integer value: " +
                                 "Choose an operator from the following list:" +
                                 "a - Add" +
                                 "s - Subtract" +
                                 "m - Multiply" +
                                 "d - Divide" +
                                 "Your option? " +
                                 "Your result: 0,36" +
                                 "------------------------" +
                                 "Press 'n' and Enter to close the app, or press any other key and Enter to continue: ";

            Assert.Equal(expectedOutput, Regex.Replace(output.ToString(), @"[\r\t\n]+", string.Empty));
        }

        [Fact]
        public void ShouldBeAbleToRunProgramMainWithDivisionByZero()
        {
            var output = new StringWriter();
            Console.SetOut(output);

            var input = new StringReader(@"43
0
d
n");
            Console.SetIn(input);

            CalculatorProgram.Program.Main(new string[] { });

            var expectedOutput = "Console Calculator in C#" +
                                 "------------------------" +
                                 "Type a number, and then press Enter: " +
                                 "Type another number, and then press Enter: " +
                                 "Choose an operator from the following list:" +
                                 "a - Add" +
                                 "s - Subtract" +
                                 "m - Multiply" +
                                 "d - Divide" +
                                 "Your option? " +
                                 "Oh no! An exception occurred trying to do the math. - Details: " +
                                 "Token PropertyName in state Property would result in an invalid JSON object. Path 'Operations[0]'." +
                                 "------------------------" +
                                 "Press 'n' and Enter to close the app, or press any other key and Enter to continue: ";

            Assert.Equal(expectedOutput, Regex.Replace(output.ToString(), @"[\r\t\n]+", string.Empty));
        }
    }
}