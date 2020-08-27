using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercise_7
{
    public class Program
    {
        public static void Main()
        {
            // We need this to make sure we can always use periods for decimal points.
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            Console.Write("Enter amount of seconds:");
            int seconds = int.Parse(Console.ReadLine());
            int hours = seconds / 3600;
            seconds -= (hours * 3600);
            int minutes = seconds / 60;
            seconds -= (minutes * 60);

            Console.Write($"That amounts to {hours} hours, {minutes} minutes, {seconds} seconds");
        }
    }

    [TestClass]
    public class ProgramTests
    {
        [DataTestMethod]
        [DataRow("1337", new int[] { 0, 22, 17 })]
        [DataRow("15000", new int[] { 4, 10, 0 })]
        [DataRow("0", new int[] { 0, 0, 0 })]
        [DataRow("60", new int[] { 0, 1, 0 })]
        [DataRow("-100", new int[] { 0, 0, 0 })]
        public void Main_Seconds_ReturnsConvertedTime(string seconds, int[] expectedTime)
        {
            using FakeConsole console = new FakeConsole(seconds);
            Program.Main();
            Assert.AreEqual($"That amounts to {expectedTime[0]} hours, {expectedTime[1]} minutes, {expectedTime[2]} seconds", console.Output);
        }
    }
}
