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

            string name = ReadString("What's your name?: ");
            int age = ReadInt("How old are you?: ");
            bool likesCandy = ReadBool("Do you like candy? Y/y/N/n: ");

            Console.WriteLine("Hello, " + name + " you are " + age + " years old and you " + (likesCandy is true ? "like" : "don't like") + " candy.");
        }

        public static string ReadString(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }

        public static int ReadInt(string prompt)
        {
            Console.Write(prompt);
            return int.Parse(Console.ReadLine());
        }

        public static double ReadDouble(string prompt)
        {
            Console.Write(prompt);
            return double.Parse(Console.ReadLine());
        }

        public static bool ReadBool(string prompt)
        {
            while(true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                if (input == "Y" || input == "y" || input == "Yes" ||input == "yes" || input == "True"|| input == "true")
                {
                    return true;
                }else if(input == "N" || input == "n" || input == "No" || input == "no" || input == "False" || input == "false")
                {
                    return false;
                }
            }
        }
    }

    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void ExampleTest()
        {
            using FakeConsole console = new FakeConsole("Adam", "18", "y");
            Program.Main();
            Assert.AreEqual("Hello, Adam you are 18 years old and you like candy.", console.Output);
        }

        [TestMethod]
        public void NegativeAgeTest()
        {
            using FakeConsole console = new FakeConsole("Adam", "-18", "y");
            Program.Main();
            Assert.AreEqual("Hello, Adam you are -18 years old and you like candy.", console.Output);
        }
    }
}
