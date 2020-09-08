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

            Console.Write("Enter some text: ");
            string input = Console.ReadLine();
            string modifiedInput = "";

            int firstCharIndex = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i].ToString() != " ")
                {
                    firstCharIndex = i;
                    break;
                }
            }

            for (int i = firstCharIndex; i < input.Length; i++)
            {
                modifiedInput += input[i];
            }

            Console.WriteLine($"Modified Input: {modifiedInput}");
        }
    }

    [TestClass]
    public class ProgramTests
    {
        [DataTestMethod]
        [DataRow(" welcome home", "welcome home")]
        [DataRow(" a ", "a ")]
        public void SpaceInputTest(string input, string expectedOutput)
        {
            using FakeConsole console = new FakeConsole(input);
            Program.Main();
            Assert.AreEqual($"Modified Input: {expectedOutput}", console.Output);
        }
    }
}
