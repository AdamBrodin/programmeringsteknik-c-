using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercise_4
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
                string x = input[i].ToString();
                if (x != "a" && x != "e" && x != "i" && x != "o" && x != "u" && x != "y")
                {
                    modifiedInput += input[i];
                }
            }

            Console.WriteLine($"Modified Input: {modifiedInput}");
        }
    }

    [TestClass]
    public class ProgramTests
    {
        [DataTestMethod]
        [DataRow("hello there", "hll thr")]
        [DataRow("yyy", "")]
        [DataRow("a e y 123", "   123")]
        public void VowelInputTest(string input, string expectedOutput)
        {
            using FakeConsole console = new FakeConsole(input);
            Program.Main();
            Assert.AreEqual($"Modified Input: {expectedOutput}", console.Output);
        }
    }
}
