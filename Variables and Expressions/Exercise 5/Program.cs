using System;
using System.Data;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercise_5
{
    public class Program
    {
        public static void Main()
        {
            // We need this to make sure we can always use periods for decimal points.
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            Console.Write("X1: ");
            double x1 = double.Parse(Console.ReadLine());
            Console.Write("Y1: ");
            double y1 = double.Parse(Console.ReadLine());
            Console.Write("X2: ");
            double x2 = double.Parse(Console.ReadLine());
            Console.Write("Y2: ");
            double y2 = double.Parse(Console.ReadLine());

            double xDistance = Math.Pow((x2 - x1), 2);
            double yDistance = Math.Pow((y2 - y1), 2);

            double finalDistance = Math.Round(Math.Sqrt(xDistance + yDistance), 2);
            Console.WriteLine("Distance between points: " + finalDistance.ToString());
        }
    }

    [TestClass]
    public class ProgramTests
    {
        /*
        [TestMethod]
        public void ExampleTest()
        {
            using FakeConsole console = new FakeConsole("0", "2", "3", "5");
            Program.Main();
            Assert.AreEqual("Distance between points: 4.24", console.Output);
        }

        [TestMethod]
        public void NegativeTest()
        {
            using FakeConsole console = new FakeConsole("-1", "-3", "-10", "-20");
            Program.Main();
            Assert.AreEqual("Distance between points: 19.24", console.Output);
        }

        [TestMethod]
        public void DecimalTest()
        {
            using FakeConsole console = new FakeConsole("0.2", "2.1", "3.16", "-2.6");
            Program.Main();
            Assert.AreEqual("Distance between points: 5.55", console.Output);
        }
        */

        [DataTestMethod]
        [DataRow("0", "2", "3", "5", 4.24)]
        [DataRow("-1", "-3", "-10", "-20", 19.24)]
        [DataRow("0.2", "2.1", "3.16", "-2.6", 5.55)]
        public void Main_DistanceValidation_ReturnsDistance(string x1, string y1, string x2, string y2, double expectedDistance)
        {
            FakeConsole console = new FakeConsole(x1, y1, x2, y2);
            Program.Main();
            Assert.AreEqual($"Distance between points: {expectedDistance}", console.Output);
        }
    }
}
