using System;
using System.Globalization;

namespace Exercise_3
{
    public class Program
    {
        public static void Main()
        {
            // We need this to make sure we can always use periods for decimal points.
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            Console.WriteLine("That string is " + (IsLarge(ReadString("Enter some text: ").Length) is true ? "large" : "small" + "."));
            Console.WriteLine("That number is " + (IsLarge(ReadInt("Enter a number: ")) is true ? "large" : "small" + "."));
            Console.WriteLine("That decimal number is " + (IsLarge(ReadString("Enter a decimal number: ")) is true ? "large" : "small" + "."));
        }

        public static string ReadString(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }

        public static int ReadInt(string prompt)
        {
            Console.Write(prompt);
            return int.Parse(Console.ReadLine());
        }

        public static double ReadDouble(string prompt)
        {
            Console.Write(prompt);
            return double.Parse(Console.ReadLine());
        }
        public static bool IsLarge(string str)
        {
            if (str.Length > 50)
            {
                return true;
            }

            return false;
        }

        public static bool IsLarge(int i)
        {
            if (i > 1000)
            {
                return true;
            }

            return false;
        }

        public static bool IsLarge(double d)
        {
            if (d > 1000)
            {
                return true;
            }

            return false;
        }
    }
}
