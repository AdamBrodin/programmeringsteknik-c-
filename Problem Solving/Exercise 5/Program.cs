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

            Console.Write("Enter the first text: ");
            string firstText = Console.ReadLine();

            Console.Write("Enter the second text: ");
            string secondText = Console.ReadLine();

            // Creates arrays out of the texts, and sets them to lowercase to more easily compare them
            char[] firstTextChars = firstText.ToLower().ToCharArray();
            char[] secondTextChars = secondText.ToLower().ToCharArray();

            // Sorts both arrays the same way
            Array.Sort(firstTextChars);
            Array.Sort(secondTextChars);

            // Creates new strings from the arrays
            string newFirstText = new string(firstTextChars);
            string newSecondText = new string(secondTextChars);

            // Compares them
            if (newFirstText == newSecondText)
            {
                Console.WriteLine("The two texts are anagrams.");
            }
            else
            {
                Console.WriteLine("No anagrams here!");
            }

        }
    }

    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void AnagramTest()
        {
            using FakeConsole console = new FakeConsole("hello", "ohell");
            Program.Main();
            Assert.AreEqual("The two texts are anagrams.", console.Output);
        }

        [TestMethod]
        public void CapsAnagramTest()
        {
            using FakeConsole console = new FakeConsole("HELLO", "ohell");
            Program.Main();
            Assert.AreEqual("The two texts are anagrams.", console.Output);
        }

        [TestMethod]
        public void AllCapsAnagramTest()
        {
            using FakeConsole console = new FakeConsole("HELLO", "OHELL");
            Program.Main();
            Assert.AreEqual("The two texts are anagrams.", console.Output);
        }

        [TestMethod]
        public void NoAnagramTest()
        {
            using FakeConsole console = new FakeConsole("hello", "hello there");
            Program.Main();
            Assert.AreEqual("No anagrams here!", console.Output);
        }
    }
}
