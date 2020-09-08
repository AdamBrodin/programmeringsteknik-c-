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

            Console.Write("Enter some text: ");
            string input = Console.ReadLine();
            string modifiedInput = "";

            for (int i = input.Length - 1; i >= 0; i--)
            {
                modifiedInput += input[i];
            }

            Console.WriteLine($"Reversed Text: {modifiedInput}");
        }
    }

    [TestClass]
    public class ProgramTests
    {
        [DataTestMethod]
        [DataRow("summer time", "emit remmus")]
        [DataRow("123", "321")]
        [DataRow("", "")]
        public void ExampleTest(string input, string expectedOutput)
        {
            using FakeConsole console = new FakeConsole(input);
            Program.Main();
            Assert.AreEqual($"Reversed Text: {expectedOutput}", console.Output);
        }
    }
}
