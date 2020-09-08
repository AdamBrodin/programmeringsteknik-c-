using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercise_6
{
    public class Program
    {
        public static void Main()
        {
            // We need this to make sure we can always use periods for decimal points.
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            Console.Write("Enter some text: ");
            string input = Console.ReadLine();
            int numberOfA = 0;

            foreach (char c in input)
            {
                if (c.ToString() == "a")
                {
                    numberOfA++;
                }
            }

            Console.WriteLine($"Amount of A's: {numberOfA}");
        }
    }

    [TestClass]
    public class ProgramTests
    {
        [DataTestMethod]
        [DataRow("happy birthday", 2)]
        [DataRow("ddd", 0)]
        [DataRow("A", 1)]
        public void ExampleTest(string input, int expectedOutput)
        {
            using FakeConsole console = new FakeConsole(input);
            Program.Main();
            Assert.AreEqual($"Amount of A's: {expectedOutput}", console.Output);
        }
    }
}
