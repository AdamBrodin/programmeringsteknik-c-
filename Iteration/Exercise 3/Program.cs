using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercise_3
{
    public class Program
    {
        public static void Main()
        {
            // We need this to make sure we can always use periods for decimal points.
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            Console.Write("Input Number: ");
            int inputNumber = int.Parse(Console.ReadLine());

            Console.Write("Odd/Even: ");
            string oddEven = Console.ReadLine();
            bool evenNumbers = true;

            if (oddEven == "Odd")
            {
                evenNumbers = false;
            }
            else if (oddEven == "Even")
            {
                evenNumbers = true;
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }

            int sum = 0;
            for (int i = 1; i <= inputNumber; i++)
            {
                if (evenNumbers && i % 2 == 0)
                {
                    sum += i;
                }
                else if (!evenNumbers && i % 2 != 0)
                {
                    sum += i;
                }
            }

            Console.WriteLine($"Sum: {sum}");
        }
    }

    [TestClass]
    public class ProgramTests
    {
        [DataTestMethod]
        [DataRow(10, "Even", 30)]
        [DataRow(10, "Odd", 25)]
        [DataRow(0, "Even", 0)]
        public void EvenOddTest(int inputNumber, string oddEven, int expectedSum)
        {
            using FakeConsole console = new FakeConsole(inputNumber.ToString(), oddEven);
            Program.Main();
            Assert.AreEqual($"Sum: {expectedSum}", console.Output);
        }
    }
}
