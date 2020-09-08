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

            int[] array = { 5, 12, -3, 7 };

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > 10)
                {
                    array[i] = 10;
                }
                else if (array[i] < 0)
                {
                    array[i] = 0;
                }

                Console.WriteLine($"Array[{i}]: {array[i]}");
            }
        }
    }
}
