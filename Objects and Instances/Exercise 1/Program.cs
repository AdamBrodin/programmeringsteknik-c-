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

            input = input.ToLower();
            input = input.Replace(" ", "_");

            Console.WriteLine($"Formatted text: {input}");
        }
    }

    [TestClass]
    public class ProgramTests
    {
        [DataTestMethod]
        [DataRow("Hello there my name is Adam", "hello_there_my_name_is_adam")]
        [DataRow("123", "123")]
        public void StringInputTest(string input, string expectedOutput)
        {
            using FakeConsole console = new FakeConsole(input);
            Program.Main();
            Assert.AreEqual($"Formatted text: {expectedOutput}", console.Output);
        }
    }
}
