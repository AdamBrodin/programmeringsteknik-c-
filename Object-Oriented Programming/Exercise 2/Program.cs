using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercise_2
{

    public class Person
    {
        string name;
        int wealth, salary, age;

        public Person(string name, int wealth, int salary, int age)
        {
            this.name = name;
            this.wealth = wealth;
            this.salary = salary;
            this.age = age;
        }

        public void PaySalary()
        {
            wealth += salary;
        }
        
        public void WinLottery(int prizeAmount)
        {
            wealth += prizeAmount;
        }

        public void CelebrateBirthday()
        {
            wealth += 50;
        }

        public void Show()
        {
            Console.WriteLine(name + ", " + age + ", has a salary of $" + salary + "/month and also $" + wealth + " in the bank");
        }
    }
    public class Program
    {
        public static void Main()
        {
            // We need this to make sure we can always use periods for decimal points.
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            Person p = new Person("Bill Gates", 256, 4096, 64);
            p.PaySalary();
            p.WinLottery(1337);
            p.Show();
        }
    }
}
