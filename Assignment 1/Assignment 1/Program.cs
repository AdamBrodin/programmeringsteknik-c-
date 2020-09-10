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
                if (c == '�' || c == '�' || c == '�' || c == '�' || c == '�' || c == '�')
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
                    if (c == '�')
                    {
                        translatedInput += "A";
                    }
                    else if (c == '�')
                    {
                        translatedInput += "a";
                    }
                    else if (c == '�')
                    {
                        translatedInput += "A";
                    }
                    else if (c == '�')
                    {
                        translatedInput += "a";
                    }
                    else if (c == '�')
                    {
                        translatedInput += "O";
                    }
                    else if (c == '�')
                    {
                        translatedInput += "o";
                    }
                    else
                    {
                        translatedInput += c;
                    }
                }

                Console.WriteLine($"\nTranslated version of the text: {translatedInput}");
            }
            else
            {
                Console.WriteLine("Your text is not written in Swedish.");
            }
        }
    }

    [TestClass]
    public class ProgramTests
    {
        [DataTestMethod]
        [DataRow("Hej, jag heter Adam och jag �r 18 �r gammal.", 2, "\nTranslated version of the text: Hej, jag heter Adam och jag ar 18 ar gammal.")]
        [DataRow("Hello, my name is Adam and I am 18 years old.", 0, "Your text is not written in Swedish.")]
        [DataRow("", 0, "Your text is not written in Swedish.")] // If the input is blank
        public void TextInputTest(string input, int expectedAmountOfSwedishLetters, string expectedOutput)
        {
            using FakeConsole console = new FakeConsole(input);
            Program.Main();
            Assert.AreEqual(expectedOutput, console.Output);
        }
    }
}
