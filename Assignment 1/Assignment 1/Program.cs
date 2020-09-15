using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment_1
{
    public class Program
    {
        public static void Main()
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            Console.Write("Hello there! Enter some text: ");
            string input = Console.ReadLine();

            int amountOfSwedishChar = 0;
            foreach (char c in input)
            {
                if (c == 'å' || c == 'Å' || c == 'ä' || c == 'Ä' || c == 'ö' || c == 'Ö')
                {
                    amountOfSwedishChar++;
                }
            }

            // If the text is written in Swedish
            if (amountOfSwedishChar > 0)
            {
                Console.WriteLine($"Your text is written in Swedish with a total of {amountOfSwedishChar} Swedish characters.");

                // Translating the text to an "international language"
                string translatedInput = "";
                foreach (char c in input)
                {
                    // Goes through each character and translates the Swedish ones
                    if (c == 'Å' || c == 'Ä')
                    {
                        translatedInput += 'A';
                    }
                    else if (c == 'å' || c == 'ä')
                    {
                        translatedInput += 'a';
                    }
                    else if (c == 'Ö')
                    {
                        translatedInput += 'O';
                    }
                    else if (c == 'ö')
                    {
                        translatedInput += 'o';
                    }
                    else
                    {
                        translatedInput += c;
                    }
                }

                Console.WriteLine($"Translated version of the text: {translatedInput}");
                return;
            }
            Console.WriteLine("Your text is not written in Swedish.");
        }
    }

    [TestClass]
    public class ProgramTests
    {
        [DataTestMethod]
        [DataRow("Hej, jag heter Adam och jag är 18 år gammal.", "Translated version of the text: Hej, jag heter Adam och jag ar 18 ar gammal.")]
        [DataRow("Hello, my name is Adam and I am 18 years old.", "Your text is not written in Swedish.")]
        [DataRow("", "Your text is not written in Swedish.")] // If the input is blank
        public void TextInputTest(string input, string expectedOutput)
        {
            using FakeConsole console = new FakeConsole(input);
            Program.Main();
            Assert.AreEqual(expectedOutput, console.Output);
        }
    }
}

