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

            int[] array = { 5, 12, 4 };
            for (int i = 0; i < array.Length; i++)
            {
                array[i] *= 2;
                Console.WriteLine($"Array[{i}]: {array[i]}");
            }

        }
    }
}
