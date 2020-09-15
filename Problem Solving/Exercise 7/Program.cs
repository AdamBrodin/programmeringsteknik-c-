using System;
using System.Globalization;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercise_7
{
    public class Program
    {
        public static void Main()
        {
            // We need this to make sure we can always use periods for decimal points.
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            Console.Write("Enter an email-adress: ");
            string input = Console.ReadLine();

            char[] inputArray = input.ToArray();
            int indexOfAtSign = input.IndexOf("@");
            int indexOfDomainDecider = input.LastIndexOf(".");
            string topLevelDomain = "";

            // Loops through the array, starting at the letter after @ and adds every letter before a dot (domain decider)
            for (int i = indexOfAtSign + 1; i < indexOfDomainDecider; i++)
            {
                topLevelDomain += inputArray[i];
            }

            Console.WriteLine($"The top level domain is {topLevelDomain}");
        }
    }

    [TestClass]
    public class ProgramTests
    {
        [DataTestMethod]
        [DataRow("examplemail@gmail.com", "gmail")]
        [DataRow("examplemail@gmail.asdf.com", "gmail.asdf")]
        public void MailDomainTest(string input, string expectedDomain)
        {
            using FakeConsole console = new FakeConsole(input);
            Program.Main();
            Assert.AreEqual($"The top level domain is {expectedDomain}", console.Output);
        }
    }
}
