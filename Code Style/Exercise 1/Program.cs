using System;

namespace CodeStyle
{
    public class Person // Changed persons to Person (capital letter for classes & fixed grammar mistake)
    {
        public string firstName; // first_name to firstName
        public string lastName;
        public int age; // AGE to age (shouldn't be caps)
    }

    public class Program
    {
        public static void Main()
        {
            Console.Write("First name: ");
            string firstName = Console.ReadLine(); // unneccessary to name str (strFirstName -> firstName)

            Console.Write("Last name: ");
            string lastName = Console.ReadLine();

            Console.Write("Age: ");
            int age = int.Parse(Console.ReadLine()); // confusing variable name (x -> age)

            Person p = new Person
            {
                firstName = firstName,
                lastName = lastName,
                age = age
            };

            if (p.age == 20)
            {
                Console.WriteLine("You are 20");
            }
            else // else if to else, unneccessarily long expression
            {
                Console.WriteLine("You are not 20");
            }
        }
    }
}