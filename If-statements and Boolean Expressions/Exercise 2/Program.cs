using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercise_2
{
    public class Program
    {
        public static void Main()
        {
            // We need this to make sure we can always use periods for decimal points.
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            Console.Write("Enter your age: ");
            int age = int.Parse(Console.ReadLine());

            if (age >= 18)
            {
                Console.WriteLine("Access granted.");
            }
            else
            {
                Console.WriteLine("Access denied.");
            }
        }
    }

    [TestClass]
    public class ProgramTests
    {
        [DataTestMethod]
        [DataRow(18, "Access granted.")]
        [DataRow(15, "Access denied.")]
        [DataRow(0, "Access denied.")]
        [DataRow(-100, "Access denied.")]
        public void AgeParameterTest(int ageInput, string expectedAccess)
        {
            using FakeConsole console = new FakeConsole(ageInput.ToString());
            Program.Main();
            Assert.AreEqual(expectedAccess, console.Output);
        }
    }
}
