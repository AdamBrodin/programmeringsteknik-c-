using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercise_1
{
    public class Program
    {
        public static void Main()
        {
            // We need this to make sure we can always use periods for decimal points.
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            Console.Write("Enter some text: ");
            string input = Console.ReadLine();

            Console.Write("Amount of repetitions: ");
            int amountOfReps = int.Parse(Console.ReadLine());

            string repeatedString = "";
            for (int i = 0; i < amountOfReps; i++)
            {
                repeatedString += input;
            }

            Console.WriteLine($"Output: {repeatedString}");
        }
    }

    [TestClass]
    public class ProgramTests
    {
        [DataTestMethod]
        [DataRow("hello", 5, "hellohellohellohellohello")]
        public void RepeatStringTest(string input, int reps, string expectedOutputString)
        {
            using FakeConsole console = new FakeConsole(input, reps.ToString());
            Program.Main();
            Assert.AreEqual($"Output: {expectedOutputString}", console.Output);
        }
    }
}
