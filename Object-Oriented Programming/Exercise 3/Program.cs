using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercise_3
{
    public class Company
    {
        string name, city;
        int foundedYear;

        public Company(string name, string city, int foundedYear)
        {
            this.name = name;
            this.city = city;
            this.foundedYear = foundedYear;
        }

        public static Company CombineCompanies(Company c1, Company c2)
        {
            Random rand = new Random();
            string newName = c1.name + "-" + c2.name;
            string newCity = (rand.Next(1, 2) is 1 ? c1.city : c2.city);

            return new Company(newName, newCity, 2020);
        }

        public void PrintInformation()
        {
            Console.Write(name + ", a company from " + city + ", established in " + foundedYear);
        }
    }

    public class Program
    {
        public static void Main()
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            Company c1 = GetCompanyInput();
            Company c2 = GetCompanyInput();
            Company c3 = Company.CombineCompanies(c1, c2);
            c3.PrintInformation();
        }

        public static Company GetCompanyInput()
        {
            string name = ReadString("Enter your company name: ");
            string city = ReadString("In what city is your company located?: ");
            int age = ReadInt("When was your company founded?: ");

            return new Company(name, city, age);
        }

        public static int ReadInt(string prompt)
        {
            Console.Write(prompt);
            return int.Parse(Console.ReadLine());
        }

        public static string ReadString(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }
    }
}
