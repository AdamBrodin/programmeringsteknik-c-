using System;
using System.Globalization;
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

            if (input.StartsWith("Classified: "))
            {
                input = input.Replace("Classified: ", "");
                input = input.Replace("Area 51", "[AN UNDISCLOSED LOCATION]");
            }

            Console.WriteLine(input);
        }
    }

    [TestClass]
    public class ProgramTests
    {
        [DataTestMethod]
        [DataRow("Classified: There are extraterrestrials at Area 51.", "There are extraterrestrials at [AN UNDISCLOSED LOCATION].")]
        public void StringInputTest(string input, string expectedOutput)
        {
            using FakeConsole console = new FakeConsole(input);
            Program.Main();
            Assert.AreEqual(expectedOutput, console.Output);
        }
    }
}
