using System;
using System.Globalization;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercise_2
{
    public class Program
    {
        public static void Main()
        {
            // We need this to make sure we can always use periods for decimal points.
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            Console.Write("Enter your social security number (Swedish, 12 digits): ");
            string input = Console.ReadLine();

            int birthyear = int.Parse(input.Substring(0, 4));
            int secondToLastDigit = int.Parse(input.Substring(11, 1));

            bool isFemale = secondToLastDigit % 2 == 0;
            if (isFemale)
            {
                Console.WriteLine($"This is a female born in {birthyear}");
            }
            else
            {
                Console.WriteLine($"This is a man born in {birthyear}");
            }
        }
    }

    [TestClass]
    public class ProgramTests
    {
        [DataTestMethod]
        [DataRow("19810203-1234", "This is a man born in 1981")]
        [DataRow("20010101-1111", "This is a man born in 2001")]
        public void SocialSecurityNumberInputTest(string input, string expectedOutput)
        {
            using FakeConsole console = new FakeConsole(input);
            Program.Main();
            Assert.AreEqual(expectedOutput, console.Output);
        }
    }
}
