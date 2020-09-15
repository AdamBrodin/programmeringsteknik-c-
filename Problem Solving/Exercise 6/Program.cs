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

            string englishAlphabet = "abcdefghijklmnopqrstuvwxyz";

            Console.Write("Enter some text: ");
            string input = Console.ReadLine();

            // Make the string lowercase to make comparing easier
            input = input.ToLower();

            char[] inputArray = input.ToCharArray();
            int englishCharCount = 0;

            foreach (char ea in englishAlphabet)
            {
                foreach (char ia in inputArray)
                {
                    if (ea == ia)
                    {
                        englishCharCount++;
                    }
                }
            }

            // If every english character was found atleast once 
            if (englishCharCount >= 26)
            {
                Console.WriteLine("The text is a pangram.");
            }
            else
            {
                Console.WriteLine("The text is NOT a pangram.");
            }
        }

        [TestClass]
        public class ProgramTests
        {
            [DataTestMethod]
            [DataRow("The five boxing wizards jump quickly", "The text is a pangram.")]
            [DataRow("Hello there, my name is Adam", "The text is NOT a pangram.")]
            public void PangramTest(string input, string expectedOutput)
            {
                using FakeConsole console = new FakeConsole(input);
                Program.Main();
                Assert.AreEqual(expectedOutput, console.Output);
            }
        }
    }
}
