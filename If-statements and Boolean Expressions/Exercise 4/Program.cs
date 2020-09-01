using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercise_4
{
    public class Program
    {
        public static void Main()
        {
            // We need this to make sure we can always use periods for decimal points.
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            string countryOfBirth;
            int age, numberOfPriorElections;

            Console.WriteLine("Please enter your country of birth: ");
            countryOfBirth = Console.ReadLine();
            Console.WriteLine("Please enter your age: ");
            age = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter your amount of prior elections: ");
            numberOfPriorElections = int.Parse(Console.ReadLine());

            if (countryOfBirth.ToUpper() == "USA" && age >= 35 && numberOfPriorElections <= 1)
            {
                Console.WriteLine("You can be president!");
            }
            else
            {
                Console.WriteLine("Unfortunately, you cannot be president.");
            }
        }
    }

    [TestClass]
    public class ProgramTests
    {
        [DataTestMethod]
        [DataRow("USA", 35, 1, "You can be president!")]
        [DataRow("USA", 40, 0, "You can be president!")]
        [DataRow("USA", 200, 1, "You can be president!")]
        [DataRow("Sweden", 35, 1, "Unfortunately, you cannot be president.")]
        [DataRow("Sweden", 34, 1, "Unfortunately, you cannot be president.")]
        [DataRow("Sweden", -10, 0, "Unfortunately, you cannot be president.")]
        public void PresidentRequirementTest(string countryOfBirth, int age, int numberOfPriorElections, string expectedAnswer)
        {
            using FakeConsole console = new FakeConsole(countryOfBirth, age.ToString(), numberOfPriorElections.ToString());
            Program.Main();
            Assert.AreEqual(expectedAnswer, console.Output);
        }
    }
}
