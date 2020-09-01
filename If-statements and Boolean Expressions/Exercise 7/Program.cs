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

            Console.Write("X: ");
            bool x = bool.Parse(Console.ReadLine());
            Console.Write("Y: ");
            bool y = bool.Parse(Console.ReadLine());

            bool result = (!x || !y); // rewritten from !(x && y)
            Console.WriteLine("Result: " + result.ToString());
        }
    }

    [TestClass]
    public class ProgramTests
    {
        // Three different tests is all that is needed to test all possible variations of bool values
        [DataTestMethod]
        [DataRow(true, false, true)]
        [DataRow(false, false, true)]
        [DataRow(true, true, false)]
        public void VariableExpressionTest(bool x, bool y, bool expectedResult)
        {
            using FakeConsole console = new FakeConsole(x.ToString(), y.ToString());
            Program.Main();
            Assert.AreEqual("Result: " + expectedResult, console.Output);
        }
    }
}
