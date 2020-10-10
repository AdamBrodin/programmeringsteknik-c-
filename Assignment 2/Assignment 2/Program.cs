using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExpenseCalculator
{
    public class Utils
    {
        public static String ReadString(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }

        public static Decimal ReadDecimal(string prompt)
        {
            Console.Write(prompt);
            decimal readValue;
            Decimal.TryParse(Console.ReadLine(), NumberStyles.Float, CultureInfo.InvariantCulture, out readValue);
            return readValue;
        }

        public static void UserBackPrompt()
        {
            Console.WriteLine("\nPress any key to go back!");
            Console.ReadKey();
            Console.Clear();
        }
    }

    public class Category
    {
        public enum Type
        {
            Food,
            Entertainment,
            Other,
        }

        public static String[] GetCategoryTypes()
        {
            return Enum.GetNames(typeof(Type)).ToArray();
        }

        public static Type ParseCategory(String category)
        {
            Object something;
            Type.TryParse(typeof(Type), category, true, out something);
            return (Type)something;
        }
    }

    public class Expense
    {
        public String name { get; set; }
        public Decimal price { get; set; }
        public Category.Type category { get; set; }

        public Expense(String name, Decimal price, Category.Type category)
        {
            this.name = name;
            this.price = price;
            this.category = category;
        }
    }

    public class ExpenseCalculator
    {
        public List<Expense> expenses;

        public ExpenseCalculator()
        {
            this.expenses = new List<Expense>();
        }

        public void AddExpense()
        {
            Console.WriteLine("Add expense:");
            String name = Utils.ReadString("Name: ");

            Decimal price = Utils.ReadDecimal("Price: ");
            var selectedCategory = Program.ShowMenu("Select category!", Category.GetCategoryTypes());
            var expense = new Expense(name, price, Category.ParseCategory(selectedCategory));
            this.expenses.Add(expense);

            Console.WriteLine("Expense added");
        }

        private Decimal SumExpenses(Category.Type? category = null)
        {
            decimal sum = 0;
            foreach (Expense e in this.expenses)
            {
                if (category == null)
                {
                    // Shows all expenses
                    Console.WriteLine($" - {e.name}: {e.price} SEK ({e.category})");
                    sum += e.price;
                }
                else if (e.category == category)
                {
                    // Shows the sum of all the expenses in a specified category
                    sum += e.price;
                }
                else
                {
                    System.Console.WriteLine("An error occurred, no category found.");
                }
            }
            return sum;
        }

        public void ShowAllExpenses()
        {
            System.Console.WriteLine($"All expenses:");
            decimal sum = SumExpenses();
            System.Console.WriteLine($" Sum: {sum} SEK");
            Utils.UserBackPrompt();
        }

        public void ShowSumByCategory()
        {
            System.Console.WriteLine($"Sum by category:");
            var categorySums = new Dictionary<Category.Type, Decimal>();

            foreach (Expense e in this.expenses)
            {
                if (categorySums.ContainsKey(e.category))
                {
                    categorySums[e.category] += e.price;
                    continue;
                }

                categorySums.Add(e.category, e.price);
            }

            foreach (KeyValuePair<Category.Type, Decimal> kvp in categorySums)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value} SEK");
            }

            Utils.UserBackPrompt();
        }

        public void RemoveExpense()
        {
            String[] availableExpenses = new String[expenses.Count];
            for (int i = 0; i < expenses.Count; i++)
            {
                availableExpenses[i] = expenses[i].name;
            }

            String selection = Program.ShowMenu("Select an expense to remove:", availableExpenses);
            for (int i = 0; i < expenses.Count; i++)
            {
                if (selection == expenses[i].name)
                {
                    expenses.Remove(this.expenses[i]);
                    return;
                }
            }
        }

        public void RemoveAllExpenses()
        {
            String input = Utils.ReadString("Are you sure you want to remove all your expenses? (Yes/No): ");
            if (input.ToLower() == "yes" || input.ToLower() == "y")
            {
                expenses.Clear();
            }
        }
    }

    public class Program
    {
        private static ExpenseCalculator _expenseCalculator = new ExpenseCalculator();
        private static String[] Options = new String[] { "Add expenses", "Show all expenses", "Show Sum by Category", "Remove Expense", "Remove all Expenses", "Exit program" };
        public static void Main()
        {
            Boolean isRunning = true;
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            Console.WriteLine("Welcome to expense calculator");
            while (isRunning)
            {
                var selected = ShowMenu("Please choose an option!", Options);

                switch (selected)
                {
                    case "Add expenses":
                        _expenseCalculator.AddExpense();
                        break;
                    case "Show all expenses":
                        _expenseCalculator.ShowAllExpenses();
                        break;
                    case "Show Sum by Category":
                        _expenseCalculator.ShowSumByCategory();
                        break;
                    case "Remove Expense":
                        _expenseCalculator.RemoveExpense();
                        break;
                    case "Remove all Expenses":
                        _expenseCalculator.RemoveAllExpenses();
                        break;
                    case "Exit program":
                        isRunning = false;
                        break;
                }
            }
        }

        public static string ShowMenu(string prompt, string[] options)
        {
            if (options == null || options.Length == 0)
            {
                throw new ArgumentException("Cannot show a menu for an empty array of options.");
            }

            Console.WriteLine(prompt);

            int selected = 0;

            // Hide the cursor that will blink after calling ReadKey.
            Console.CursorVisible = false;

            ConsoleKey? key = null;
            while (key != ConsoleKey.Enter)
            {
                // If this is not the first iteration, move the cursor to the first line of the menu.
                if (key != null)
                {
                    Console.CursorLeft = 0;
                    Console.CursorTop = Console.CursorTop - options.Length;
                }

                // Print all the options, highlighting the selected one.
                for (int i = 0; i < options.Length; i++)
                {
                    var option = options[i];
                    if (i == selected)
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    Console.WriteLine("* " + option);
                    Console.ResetColor();
                }

                // Read another key and adjust the selected value before looping to repeat all of this.
                key = Console.ReadKey().Key;
                if (key == ConsoleKey.DownArrow)
                {
                    selected = Math.Min(selected + 1, options.Length - 1);
                }
                else if (key == ConsoleKey.UpArrow)
                {
                    selected = Math.Max(selected - 1, 0);
                }
            }

            // Reset the cursor and return the selected option.
            Console.Clear();
            Console.CursorVisible = true;
            return options[selected];
        }
    }

    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void ExampleTest()
        {
        }
    }
}

