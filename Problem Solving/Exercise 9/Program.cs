using System;
using System.Collections.Generic;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercise_9
{
    public class Program
    {
        public static void Main()
        {
            // We need this to make sure we can always use periods for decimal points.
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            Dictionary<string, string> wordsToTranslate = new Dictionary<string, string>()
            {
                {"hello", "hej" }, {"good", "bra"}
            };

            Console.Write("Enter some text: ");
            string input = Console.ReadLine();

            foreach (KeyValuePair<string, string> pair in wordsToTranslate)
            {
                if (input.Contains(pair.Key))
                {
                    input = input.Replace(pair.Key, pair.Value);
                }
            }

            Console.WriteLine($"Translated text: {input}");
        }
    }

    [TestClass]
    public class ProgramTests
    {
        [DataTestMethod]
        [DataRow("hello there, today is a good day", "hej there, today is a bra day")]
        public void TextInputTest(string input, string expectedOutput)
        {
            using FakeConsole console = new FakeConsole(input);
            Program.Main();
            Assert.AreEqual($"Translated text: {expectedOutput}", console.Output);
        }
    }
}
