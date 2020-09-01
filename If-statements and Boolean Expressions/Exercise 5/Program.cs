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

            Console.WriteLine("false || true == " + (false || true)); // true

            Console.WriteLine("false || false || true == " + (false || false || true)); // true

            Console.WriteLine("true && false == " + (true && false)); // false

            Console.WriteLine("true && true && false == " + (true && true && false)); // false

            Console.WriteLine("(true && false) || (true || false) == " + ((true && false) || (true || false))); // true

            Console.WriteLine("!true || !false == " + (!true || !false)); // true

            Console.WriteLine("!true && !false == " + (!true && !false)); // false

            Console.WriteLine("!(true || false) == " + (!(true || false))); // false

            Console.WriteLine("!(true || false) && !false == " + (!(true || false) && !false)); // false

            Console.WriteLine("!(!(true && false)) == " + (!(!(true && false)))); // false
        }
    }
}
