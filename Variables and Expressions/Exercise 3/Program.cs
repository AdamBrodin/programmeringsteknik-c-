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

            Console.Write("Please enter the temperature in fahrenheit: ");
            double fahrenheitTemp = double.Parse(Console.ReadLine());

            // Rounded to 0 decimal places
            double celsiusTemp = Math.Round((fahrenheitTemp - 32) * 0.556, 0);
            Console.WriteLine("The temperature converted to Celsius is: " + celsiusTemp + "C");
        }
    }

    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void ExampleTest()
        {
            using FakeConsole console = new FakeConsole("100");
            Program.Main();
            Assert.AreEqual("The temperature converted to Celsius is: 38" + "C", console.Output);
        }

        [TestMethod]
        public void NegativeTest()
        {
            using FakeConsole console = new FakeConsole("-100");
            Program.Main();
            Assert.AreEqual("The temperature converted to Celsius is: -73" + "C", console.Output);
        }

        [TestMethod]
        public void DecimalTest()
        {
            using FakeConsole console = new FakeConsole("-55.5");
            Program.Main();
            Assert.AreEqual("The temperature converted to Celsius is: -49" + "C", console.Output);
        }
    }
}
