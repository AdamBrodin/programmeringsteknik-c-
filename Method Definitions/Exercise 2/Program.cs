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

            int temperatureInDegrees = ReadInt("What is the temperature?: ");
            bool isInCelsius = ReadBool("Is that in Celsius? Y/y/N/n: ");
            Console.WriteLine("The temperature converted to " + (isInCelsius is true ? "fahrenheit" : "celsius") + " is: " + DegreeConverter(temperatureInDegrees, isInCelsius).ToString());
        }

        public static int ReadInt(string prompt)
        {
            Console.Write(prompt);
            return int.Parse(Console.ReadLine());
        }

        public static bool ReadBool(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                if (input == "Y" || input == "y" || input == "Yes" || input == "yes" || input == "True" || input == "true")
                {
                    return true;
                }
                else if (input == "N" || input == "n" || input == "No" || input == "no" || input == "False" || input == "false")
                {
                    return false;
                }
            }
        }

        public static double DegreeConverter(int degrees, bool isCelsius)
        {
            if (isCelsius)
            {
                return (9.0 / 5.0) * degrees + 32;
            }
            else
            {
                return (5.0 / 9.0) * (degrees - 32);
            }
        }
    }
}
