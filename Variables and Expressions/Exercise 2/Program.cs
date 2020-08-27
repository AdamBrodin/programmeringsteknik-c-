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

            Console.Write("Please enter your current cash balance: ");
            int cashOnHand = int.Parse(Console.ReadLine());
            Console.Write("Please enter your current bank balance: ");
            int cashInBank = int.Parse(Console.ReadLine());

            Console.WriteLine("You have a total of: $" + (cashOnHand + cashInBank));
        }
    }

    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void ExampleTest()
        {
            using FakeConsole console = new FakeConsole("100", "500");
            Program.Main();
            Assert.AreEqual("You have a total of: $600", console.Output);
        }

        [TestMethod]
        public void NegativeValueTest()
        {
            using FakeConsole console = new FakeConsole("-100", "200");
            Program.Main();
            Assert.AreEqual("You have a total of: $100", console.Output);
        }

        [TestMethod]
        public void DecimalTest()
        {
            using FakeConsole console = new FakeConsole("101.5", "321");
            Program.Main();
            Assert.AreEqual("You have a total of: $422.5", console.Output);
        }
    }
}
