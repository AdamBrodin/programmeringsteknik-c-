using System;
using System.Collections.Generic;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercise_4
{
    public class Program
    {
        public static void Main()
        {
            // We need this to make sure we can always use periods for decimal points.
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            string input = null;
            List<int> numbers = new List<int> { };
            while (input != "")
            {
                Console.Write("Enter a number: ");
                input = Console.ReadLine();

                if (input != "")
                {
                    numbers.Add(int.Parse(input));
                }
            }

            int sum = 0;
            for (int i = 0; i < numbers.Count; i++)
            {
                sum += numbers[i];
            }

            Console.WriteLine($"Sum of all numbers: {sum}");
        }
    }

    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void NumbersTest()
        {
            using FakeConsole console = new FakeConsole("1", "2", "3", "");
            Program.Main();
            Assert.AreEqual($"Sum of all numbers: 6", console.Output);
        }

        [TestMethod]
        public void NegativeNumbersTest()
        {
            using FakeConsole console = new FakeConsole("-1", "-2", "-3", "");
            Program.Main();
            Assert.AreEqual($"Sum of all numbers: -6", console.Output);
        }
    }
}
