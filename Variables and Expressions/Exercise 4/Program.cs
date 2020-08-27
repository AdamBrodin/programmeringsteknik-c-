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

            Console.Write("Pick your first number: ");
            double firstNumber = double.Parse(Console.ReadLine());
            Console.Write("Pick your second number: ");
            double secondNumber = double.Parse(Console.ReadLine());
            Console.Write("Pick your third number: ");
            double thirdNumber = double.Parse(Console.ReadLine());

            double biggestNumber = Math.Max(firstNumber, secondNumber);
            biggestNumber = Math.Max(biggestNumber, thirdNumber);
            Console.WriteLine("The biggest number of them all is: " + biggestNumber);
        }
    }

    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void ExampleTest()
        {
            using FakeConsole console = new FakeConsole("100", "200", "300");
            Program.Main();
            Assert.AreEqual("The biggest number of them all is: 300", console.Output);
        }

        [TestMethod]
        public void NegativeTest()
        {
            using FakeConsole console = new FakeConsole("-100", "-200", "-300");
            Program.Main();
            Assert.AreEqual("The biggest number of them all is: -100", console.Output);
        }

        [TestMethod]
        public void DecimalTest()
        {
            using FakeConsole console = new FakeConsole("1.337", "2.667", "3.999");
            Program.Main();
            Assert.AreEqual("The biggest number of them all is: 3.999", console.Output);
        }
    }
}
