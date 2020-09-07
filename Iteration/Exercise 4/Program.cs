using System;
using System.Globalization;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercise_4
{
    public class Program
    {
        public static void Main()
        {
            // We need this to make sure we can always use periods for decimal points.
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            Console.Write("Countdown Length (s): ");
            int countdownLength = int.Parse(Console.ReadLine());

            for (int i = countdownLength; i > 0; i--)
            {
                Console.WriteLine($"{i}!");
                Thread.Sleep(1000);
            }

            Console.WriteLine($"Takeoff!!! It took {countdownLength} seconds.");
        }
    }

    [TestClass]
    public class ProgramTests
    {
        [DataTestMethod]
        [DataRow(5, 5)]
        [DataRow(0, 0)]
        [DataRow(-1, 0)]
        [DataRow(10, 10)]
        [DataRow(10.5, 10.5)]

        // Thread.Sleep takes a long time in testing
        public void CountdownInputTest(int countdownLength, int expectedTakenTime)
        {
            using FakeConsole console = new FakeConsole(countdownLength.ToString());
            Program.Main();
            Assert.AreEqual($"Takeoff!!! It took {expectedTakenTime} seconds.", console.Output);
        }
    }
}
