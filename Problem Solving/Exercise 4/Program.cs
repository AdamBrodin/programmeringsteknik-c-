using System;
using System.Collections.Generic;
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
            // Make the string to lower so capital and lowercase letters won't get counted seperately
            input = input.ToLower();

            Dictionary<char, int> letterOccurrences = new Dictionary<char, int>();
            foreach (char c in input)
            {
                if (!letterOccurrences.ContainsKey(c))
                {
                    letterOccurrences.Add(c, 1);
                }
                else
                {
                    letterOccurrences[c]++;
                }
            }

            foreach (KeyValuePair<char, int> pair in letterOccurrences)
            {
                Console.WriteLine($"There are a total of {pair.Value} {pair.Key} letters in the text.");
            }
        }
    }

    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void ExampleTest()
        {
            using FakeConsole console = new FakeConsole("Hello");
            Program.Main();
            CollectionAssert.AreEqual(new[] {
                "There are a total of 1 h letters in the text.", "There are a total of 1 e letters in the text.",
                "There are a total of 2 l letters in the text.", "There are a total of 1 o letters in the text." }, console.Lines);
        }
    }
}
