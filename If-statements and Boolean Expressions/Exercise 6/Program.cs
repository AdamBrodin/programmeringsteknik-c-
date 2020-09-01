using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercise_6
{
    public class Program
    {
        public static void Main()
        {
            // We need this to make sure we can always use periods for decimal points.
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            Console.Write("What do you want to see? Forest/Mountains/Cities: ");
            string desiredLandscape = Console.ReadLine();

            if (desiredLandscape == "Forests")
            {
                Console.WriteLine("You should travel to Småland");
            }
            else if (desiredLandscape == "Mountains")
            {
                Console.WriteLine("You should travel to Lappland");
            }
            else if (desiredLandscape == "Cities")
            {
                Console.Write("Do you enjoy puns? True/False: ");
                bool enjoysPuns = bool.Parse(Console.ReadLine());

                if (enjoysPuns)
                {
                    Console.WriteLine("You should travel to Gothenburg");
                }
                else
                {
                    Console.WriteLine("You should travel to Stockholm");
                }
            }
        }
    }

    [TestClass]
    public class ProgramTests
    {
        [DataTestMethod]
        [DataRow("Forests", "Småland")]
        [DataRow("Mountains", "Lappland")]
        public void QuestionInputTest(string desiredLandscape, string expectedCity)
        {
            using FakeConsole console = new FakeConsole(desiredLandscape, expectedCity);
            Program.Main();
            Assert.AreEqual("You should travel to " + expectedCity, console.Output);
        }

        [DataTestMethod]
        [DataRow("Cities", "True", "Gothenburg")]
        [DataRow("Cities", "False", "Stockholm")]
        public void QuestionInputTest(string desiredLandscape, bool enjoysPuns, string expectedCity)
        {
            using FakeConsole console = new FakeConsole(desiredLandscape, enjoysPuns.ToString());
            Program.Main();
            Assert.AreEqual("You should travel to " + expectedCity, console.Output);
        }
    }
}
