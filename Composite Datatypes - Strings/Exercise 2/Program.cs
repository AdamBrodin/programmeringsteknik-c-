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

            Console.Write("Enter some text: ");
            string input = Console.ReadLine();
            string modifiedInput = "";

            for (int i = 0; i < input.Length; i++)
            {
                modifiedInput += input[i];
                if (i < input.Length - 1)
                {
                    modifiedInput += "-";
                }
            }

            Console.WriteLine($"Modified Input: {modifiedInput}");
        }
    }

    [TestClass]
    public class ProgramTests
    {
        [DataTestMethod]
        [DataRow("Hej", "H-e-j")]
        [DataRow("", "")]
        [DataRow("--", "---")]
        public void TextHyphenTest(string input, string expectedOutput)
        {
            using FakeConsole console = new FakeConsole(input);
            Program.Main();
            Assert.AreEqual($"Modified Input: {expectedOutput}", console.Output);
        }
    }
}
