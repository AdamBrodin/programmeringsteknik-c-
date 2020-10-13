using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercise_1
{
    public class Program
    {
        private static List<double> numbers;
        public static void Main()
        {
            numbers = new List<double>();
            string input = ReadString("Enter a number: ");
            while (input != "")
            {
                double.TryParse(input, out double inputNumber);
                numbers.Add(inputNumber);
                input = ReadString("Enter a number: ");
            }


            DisplayNumberStats();
        }

        private static void DisplayNumberStats()
        {
            if (numbers.Count > 0)
            {
                // LINQ Functions

                // Sum of the numbers
                double numbersSum = numbers.Sum();
                Console.WriteLine($"Sum: {numbersSum}");

                // The highest number
                double highestNumber = numbers.Max();
                Console.WriteLine($"Highest number: {highestNumber}");

                // The lowest number
                double lowestNumber = numbers.Min();
                Console.WriteLine($"Lowest number: {lowestNumber}");

                // The average number
                double averageNumber = numbers.Average();
                Console.WriteLine($"Average number: {averageNumber}");

                // All numbers above 10
                List<double> numbersAboveTen = numbers.Where(num => num >= 10).ToList();
                Console.WriteLine($"Numbers equal to or above ten: {string.Join(", ", numbersAboveTen)}");

                // All numbers between 10 and 20
                List<double> numbersBetweenTenAndTwenty = numbers.Where(num => num >= 10 && num <= 20).ToList();
                Console.WriteLine($"Numbers between ten and twenty: {string.Join(", ", numbersBetweenTenAndTwenty)}");

                // Sum of the numbers between 10 and 20
                Console.WriteLine($"Sum of the numbers between ten and twenty: {numbersBetweenTenAndTwenty.Sum()}");

                // Square root of numbers
                var squaredNumbers = numbers.Select(num => (num * num));
                Console.WriteLine($"The numbers, squared are: {string.Join(", ", squaredNumbers)}");


                // Numbers in ascending order
                numbers = numbers.OrderBy(num => num).ToList();
                Console.WriteLine($"Numbers from lowest to highest: {string.Join(", ", numbers)}");
            }
            else
            {
                Console.WriteLine("No numbers were inputted.");
            }
        }

        public static string ReadString(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }
    }
}
