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

            Console.Write("Amount of numbers: ");
            int amountOfNumbers = int.Parse(Console.ReadLine());
            int[] inputNumbers = new int[amountOfNumbers];

            for (int i = 1; i <= inputNumbers.Length; i++)
            {
                Console.Write($"Number {i}: ");
                inputNumbers[i - 1] = int.Parse(Console.ReadLine());
            }

            for (int i = 0; i < inputNumbers.Length; i++)
            {
                Console.WriteLine($"Number {i + 1} squared is: {Math.Pow(inputNumbers[i], 2)}");
            }


        }
    }

    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void PositiveNumberTest()
        {
            using FakeConsole console = new FakeConsole("3", "5", "4", "7");
            Program.Main();
            Assert.AreEqual("Number 1 squared is: 25", console.Lines[0]);
            Assert.AreEqual("Number 2 squared is: 16", console.Lines[1]);
            Assert.AreEqual("Number 3 squared is: 49", console.Lines[2]);
        }
    }
}
