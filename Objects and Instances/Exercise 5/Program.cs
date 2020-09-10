using System;
using System.Collections.Generic;
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
            input = input.ToLower();

            // Splits the text and cleans out any chars that are not a word
            string[] split = input.Split(new Char[] { ' ', ',', '-', '.', ',', ':', '\t' });
            Dictionary<string, int> usedStrings = new Dictionary<string, int> { };

            foreach (string s in split)
            {
                if (!usedStrings.ContainsKey(s))
                {
                    usedStrings.Add(s, 1);
                }
                else
                {
                    usedStrings[s]++;
                }
            }

            string mostCommonWord = "";
            int highestValue = 0;

            foreach (KeyValuePair<string, int> pair in usedStrings)
            {
                if (pair.Value > highestValue)
                {
                    highestValue = pair.Value;
                    mostCommonWord = pair.Key;
                }
            }

            Console.WriteLine($"The most common word is: {mostCommonWord} which occurs {highestValue} times");
        }
    }

    [TestClass]
    public class ProgramTests
    {
        [DataTestMethod]
        [DataRow("The quick brown fox jumps over the lazy dog", "the", 2)]
        public void StringInputTest(string input, string mostCommonWord, int expectedOccurrences)
        {
            using FakeConsole console = new FakeConsole(input);
            Program.Main();
            Assert.AreEqual($"The most common word is: {mostCommonWord} which occurs {expectedOccurrences} times", console.Output);
        }
    }
}
