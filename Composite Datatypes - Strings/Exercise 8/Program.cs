using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercise_8
{
    public class Program
    {
        public static void Main()
        {
            // We need this to make sure we can always use periods for decimal points.
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            Console.Write("Enter some text: ");
            string input = Console.ReadLine();
            int firstCharIndex = 0, lastCharIndex = 0;

            // Finding firstCharIndex
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i].ToString() != " ")
                {
                    firstCharIndex = i;
                    break;
                }
            }

            // Finding lastCharIndex
            for (int i = input.Length - 1; i >= 0; i--)
            {
                if (input[i].ToString() != " ")
                {
                    lastCharIndex = i;
                    break;
                }
            }

            string modifiedInput = "";
            // Creating a loop betwenn firstCharIndex and lastCharIndex
            for (int i = firstCharIndex; i <= lastCharIndex; i++)
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
        [DataRow(" welcome home ", "welcome home")]
        [DataRow(" hej", "hej")]
        [DataRow("   hej    hej    ", "hej    hej")]
        public void SpaceInputTest(string input, string expectedOutput)
        {
            using FakeConsole console = new FakeConsole(input);
            Program.Main();
            Assert.AreEqual($"Modified Input: {expectedOutput}", console.Output);
        }
    }
}
