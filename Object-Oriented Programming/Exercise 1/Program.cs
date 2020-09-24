using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercise_1
{

    public class Person
    {
        string firstName, lastName;
        int birthyear;

        public Person(string firstName, string lastName, int birthyear)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.birthyear = birthyear;
        }

        public String Summary()
        {
            return firstName + " " + lastName + " is born " + birthyear;
        }
    }
    public class Program
    {
        public static void Main()
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
            Person p = new Person(ReadString("Enter your first name: "), ReadString("Enter your last name: "), ReadInt("When were you born?: "));
            Console.WriteLine(p.Summary());
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
    }


    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void ExampleTest()
        {
            using FakeConsole console = new FakeConsole("Bill", "Gates", "1955");
            Program.Main();
            Assert.AreEqual("Bill Gates is born 1955", console.Output);
        }
    }
}
