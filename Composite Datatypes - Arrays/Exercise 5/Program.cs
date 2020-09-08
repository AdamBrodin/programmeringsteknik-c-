using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercise_5
{
    public class Program
    {
        public static void Main()
        {
            // We need this to make sure we can always use periods for decimal points.
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            int[] array = { 5, 12, 7, 100 };
            int numbersGreaterThanTen = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > 10)
                {
                    numbersGreaterThanTen++;
                }
            }

            Console.WriteLine($"Amount of numbers greater than 10: {numbersGreaterThanTen}");
        }
    }
}
