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

            Console.Write("Enter your password: ");
            string input = Console.ReadLine();
            string password = "secret123";

            if (input == password)
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
        [DataRow("secret123", "Access granted.")]
        [DataRow("SECRET123", "Access denied.")]
        [DataRow("Secret123", "Access denied.")]
        public void PasswordInputTest(string input, string expectedAccess)
        {
            using FakeConsole console = new FakeConsole(input);
            Program.Main();
            Assert.AreEqual(expectedAccess, console.Output);
        }
    }
}
