using System;
using System.Globalization;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercise_6
{
    public class Program
    {
        public static void Main()
        {
            // We need this to make sure we can always use periods for decimal points.
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            Console.Write("Number of candies in bag: ");
            int numberOfCandies = int.Parse(Console.ReadLine());
            Console.Write("Amount of children at party: ");
            int childrenAtParty = int.Parse(Console.ReadLine());

            int candiesPerChild = numberOfCandies / childrenAtParty;
            Console.WriteLine("Candies per child: " + candiesPerChild.ToString());
        }
    }

    [TestClass]
    public class ProgramTests
    {
        [DataTestMethod]
        [DataRow("50", "10", 5)]
        [DataRow("1000", "2", 500)]
        [DataRow("0", "10", 0)]
        [DataRow("10000", "-2", 0)]
        public void Main_CandyValidation_ReturnsCandiesPerChild(string numberOfCandies, string amountOfChildren, int expectedCandiesPerChild)
        {
            using FakeConsole console = new FakeConsole(numberOfCandies, amountOfChildren);
            Program.Main();
            Assert.AreEqual($"Candies per child: {expectedCandiesPerChild}", console.Output);
        }
    }
}
