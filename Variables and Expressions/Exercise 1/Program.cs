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

            Console.WriteLine("5+2 is: " + (5 + 2));
            Console.WriteLine("5+2 * 7 is: " + (5+2)*7);
            Console.WriteLine("10+2 / 3 is: " + (10 + 2) / 3);
            Console.WriteLine("3*8 / 4*2 is: " + (3 * 8) / (4 * 2));
        }
    }
}
