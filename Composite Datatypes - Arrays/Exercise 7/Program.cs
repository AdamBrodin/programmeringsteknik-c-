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

            int[] array = { 5, 0, 7, 0, 2 };
            int amountOfZeros = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == 0)
                {
                    amountOfZeros++;
                }
            }

            int[] arrayWithoutZeros = new int[array.Length - amountOfZeros];
            int newArrayIndex = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != 0)
                {
                    arrayWithoutZeros[newArrayIndex] = array[i];
                    newArrayIndex++;
                }
            }

            foreach (int i in arrayWithoutZeros)
            {
                Console.WriteLine($"arrayWithoutZeros[{i}]: {i}");
            }
        }
    }
}
