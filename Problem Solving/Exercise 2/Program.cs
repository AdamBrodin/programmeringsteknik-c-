using System;
using System.Globalization;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercise_2
{
    public class Program
    {
        public static void Main()
        {
            // We need this to make sure we can always use periods for decimal points.
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            Console.Write("Password: ");
            string password = Console.ReadLine();

            // If the password is 8 chars long, contains atleast an uppercase, lowercase and a number
            if (password.Length >= 8 && password.Any(char.IsUpper) && password.Any(char.IsLower) && password.Any(char.IsNumber))
            {
                Console.WriteLine("Your password meets the requirements.");
            }
            else
            {
                Console.WriteLine("Your password is too weak.");
            }
        }
    }

    [TestClass]
    public class ProgramTests
    {
        [DataTestMethod]
        [DataRow("Password123", "Your password meets the requirements.")]
        [DataRow("password", "Your password is too weak.")]
        public void PasswordInputTest(string input, string expectedAnswer)
        {
            using FakeConsole console = new FakeConsole(input);
            Program.Main();
            Assert.AreEqual(expectedAnswer, console.Output);
        }
    }
}
