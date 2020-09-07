using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercise_2
{
    public class Program
    {
        public static void Main()
        {
            // We need this to make sure we can always use periods for decimal points.
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            Console.Write("Enter integer to factorial: ");
            int factorialNumber = int.Parse(Console.ReadLine());

            int sum = 1;
            for (int i = 1; i <= factorialNumber; i++)
            {
                sum *= i;
            }

            Console.Write($"Factorial of {factorialNumber} is: " + sum.ToString());
        }
    }

    [TestClass]
    public class ProgramTests
    {
        [DataTestMethod]
        [DataRow(5, 120)]
        [DataRow(1, 1)]
        [DataRow(-2, 0)]

        public void FactorialInputTest(int factorialNumber, int expectedAnswer)
        {
            using FakeConsole console = new FakeConsole(factorialNumber.ToString());
            Program.Main();
            Assert.AreEqual($"Factorial of {factorialNumber} is: " + expectedAnswer, console.Output);
        }
    }
}
