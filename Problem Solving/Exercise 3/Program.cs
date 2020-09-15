using System;
using System.Globalization;
using System.Linq;
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

            // Turns the string into a char array, reverses it then creates a new string with the chars
            char[] inputArray = input.ToCharArray();
            Array.Reverse(inputArray);
            string reversedInput = new string(inputArray);

            if (reversedInput == input)
            {
                Console.WriteLine("That is a palindrome.");
            }
            else
            {
                Console.WriteLine("That is not a palindrome.");
            }
        }
    }

    [TestClass]
    public class ProgramTests
    {
        [DataTestMethod]
        [DataRow("wow", "That is a palindrome.")]
        [DataRow("hello", "That is not a palindrome.")]
        public void PalindromeTest(string input, string expectedOutput)
        {
            using FakeConsole console = new FakeConsole(input);
            Program.Main();
            Assert.AreEqual(expectedOutput, console.Output);
        }
    }
}
