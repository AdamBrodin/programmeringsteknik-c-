using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercise_7
{
    public class Program
    {
        public static void Main()
        {
            // We need this to make sure we can always use periods for decimal points.
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            int totalNumberOfGrains = 0;
            int lastNumber = 1;

            Console.Write("Amount of squares: ");
            int amountOfSquares = int.Parse(Console.ReadLine());

            for (int i = 1; i <= amountOfSquares; i++)
            {
                totalNumberOfGrains += lastNumber;
                lastNumber *= 2;
            }

            Console.WriteLine($"Total number of grains: {totalNumberOfGrains}");
        }
    }

    [TestClass]
    public class ProgramTests
    {
        [DataTestMethod]
        [DataRow(24, 16777215)]
        [DataRow(0, 0)]
        [DataRow(23, 8388607)]
        [DataRow(16, 65535)]
        [DataRow(-2, -0.75)]
        public void SquareGrainsTest(int amountOfSquares, int expectedAmountOfGrains)
        {
            using FakeConsole console = new FakeConsole(amountOfSquares.ToString());
            Program.Main();
            Assert.AreEqual($"Total number of grains: {expectedAmountOfGrains}", console.Output);
        }
    }
}
