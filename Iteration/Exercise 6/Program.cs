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

            for (int diceOne = 1; diceOne <= 6; diceOne++)
            {
                for (int diceTwo = 1; diceTwo <= 6; diceTwo++)
                {
                    if (diceOne < 6 || diceTwo < 6)
                    {
                        Console.WriteLine($"({diceOne}, {diceTwo}),");
                    }
                    else
                    {
                        Console.WriteLine($"({diceOne}, {diceTwo})");
                    }
                }
            }
        }
    }
}
