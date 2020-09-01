using System;
using System.Globalization;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercise_3
{
    public class Program
    {
        public static void Main()
        {
            // We need this to make sure we can always use periods for decimal points.
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            Console.Write("Enter the temperature (in Celsius): ");
            double inputTemp = double.Parse(Console.ReadLine());

            if (inputTemp >= 18 && inputTemp <= 26)
            {
                Console.WriteLine("Appropriate temperature");
            }
            else
            {
                Console.WriteLine("Unacceptable temperature");
            }
        }
    }

    [TestClass]
    public class ProgramTests
    {
        [DataTestMethod]
        [DataRow(20, "Appropriate temperature")]
        [DataRow(18, "Appropriate temperature")]
        [DataRow(26, "Appropriate temperature")]
        [DataRow(10, "Unacceptable temperature")]
        [DataRow(-10, "Unacceptable temperature")]
        [DataRow(17.95, "Unacceptable temperature")]
        public void TemperatureInputTest(double inputTemp, string expectedAnswer)
        {
            using FakeConsole console = new FakeConsole(inputTemp.ToString());
            Program.Main();
            Assert.AreEqual(expectedAnswer, console.Output);
        }
    }
}
