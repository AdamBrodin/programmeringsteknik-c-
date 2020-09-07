using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercise_1
{
    public class Program
    {
        public static void Main()
        {
            // We need this to make sure we can always use periods for decimal points.
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            Console.Write("Number 1: ");
            int number1 = int.Parse(Console.ReadLine());

            Console.Write("Number 2: ");
            int number2 = int.Parse(Console.ReadLine());

            for (int i = number1; i <= number2; i++)
            {
                Console.WriteLine(i);
            }
        }
    }

    [TestClass]
    public class ProgramTests
    {
        [DataTestMethod]
        [DataRow(1, 5, 5)]
        [DataRow(-1, 5, 4)]
        [DataRow(0, 0, 0)]
        public void NumberInputTest(int number1, int number2, int expectedAnswer)
        {
            using FakeConsole console = new FakeConsole(number1.ToString(), number2.ToString());
            Program.Main();
            Assert.AreEqual(expectedAnswer.ToString(), console.Output);
        }
    }
}
