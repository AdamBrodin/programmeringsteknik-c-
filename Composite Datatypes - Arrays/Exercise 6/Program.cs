using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercise_6
{
    public class Program
    {
        public static void Main()
        {
            // We need this to make sure we can always use periods for decimal points.
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            int[] startArray = { 1, 2, 3 };
            int[] repeatedArray = new int[startArray.Length * 2];

            int newArrayIndex = 0;
            for (int i = 1; i <= 2; i++)
            {
                for (int b = 0; b < startArray.Length; b++)
                {
                    repeatedArray[newArrayIndex] = startArray[b];
                    newArrayIndex++;
                }
            }

            foreach (int i in repeatedArray)
            {
                Console.WriteLine($"RepeatedArray[{i}]: {i}");
            }
        }
    }
}
