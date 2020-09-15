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

            string[] censoredWords = new string[] { "shit", "damn", "fuck" };

            Console.Write("Enter some text: ");
            string input = Console.ReadLine();

            for (int i = 0; i < censoredWords.Length; i++)
            {
                if (input.Contains(censoredWords[i]))
                {
                    string censorString = "";

                    for (int cw = 0; cw < censoredWords[i].Length; cw++)
                    {
                        censorString += "*";
                    }

                    input = input.Replace(censoredWords[i], censorString);
                }
            }

            // Censored input
            Console.WriteLine(input);
        }
    }

    [TestClass]
    public class ProgramTests
    {
        [DataTestMethod]
        [DataRow("fuck you", "**** you")]
        [DataRow("are you shitting me?", "are you ****ting me?")]
        public void ExampleTest(string input, string censoredText)
        {
            using FakeConsole console = new FakeConsole(input);
            Program.Main();
            Assert.AreEqual(censoredText, console.Output);
        }
    }
}
