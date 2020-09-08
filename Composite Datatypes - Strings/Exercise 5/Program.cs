using System;
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

            Console.Write("Enter some text: ");
            string input = Console.ReadLine();
            string modifiedInput = "";

            for (int i = 0; i < input.Length; i++)
            {
                if (i % 2 == 0)
                {
                    modifiedInput += input[i];

                }
                else
                {
                    modifiedInput += "*";
                }
            }

            Console.WriteLine($"Modified Input: {modifiedInput}");
        }
    }

    [TestClass]
    public class ProgramTests
    {
        [DataTestMethod]
        [DataRow("computer", "c*m*u*e")]
        [DataRow("", "")]
        [DataRow("123", "1*3")]
        public void AsteriskInputTest(string input, string expectedOutput)
        {
            using FakeConsole console = new FakeConsole(input);
            Program.Main();
            Assert.AreEqual($"Modified Input: {expectedOutput}", console.Output);
        }
    }
}
