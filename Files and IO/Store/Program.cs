using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace Store
{
    public class StoreItem
    {
        public int serialID, price;
        public string name, description;

        public StoreItem(int id, int price, string name, string description)
        {
            this.serialID = id;
            this.price = price;
            this.name = name;
            this.description = description;
        }

        public string GetDescription()
        {
            return $"|{serialID}| {name}; {description} - ${price}";
        }
    }

    public class Program
    {
        private static readonly string savePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\";
        private static StoreItem[] storeItems;
        private static Dictionary<StoreItem, int> cartItems = new Dictionary<StoreItem, int>();
        public static void Main()
        {
            LoadStore();
            LoadCart();

            Console.WriteLine("Welcome to my store!");
            Thread.Sleep(1000);
            MainMenu();
        }

        private static void MainMenu()
        {
            Console.Clear();
            int selection = ShowMenu("What would you like to do?", new[]
            {"Purchase items", "Checkout", "Save cart"
            });

            switch (selection)
            {
                case 0:
                    DisplayItems();
                    break;
                case 1:
                    Checkout();
                    break;
                case 2:
                    SaveCart();
                    Console.WriteLine("Cart saved.");
                    break;
                default:
                    Console.WriteLine("Invalid option selected");
                    break;
            }
        }

        private static int ReadInt(string prompt)
        {
            Console.Write(prompt);
            return int.Parse(Console.ReadLine());
        }

        private static void DisplayItems()
        {
            int counter = 0;
            string[] items = new string[storeItems.Length];
            foreach (StoreItem item in storeItems)
            {
                Console.Clear();
                items[counter] = item.GetDescription();
                counter++;
            }

            int itemToPurchase = ShowMenu("Select an item to purchase", items);
            Console.Clear();
            int amountToPurchase = ReadInt("How many would you like?: ");
            AddToCart(itemToPurchase, amountToPurchase);
        }

        private static void Checkout()
        {
            int totalCost = 0;
            foreach (KeyValuePair<StoreItem, int> pair in cartItems)
            {
                totalCost += (pair.Key.price * pair.Value);
            }

            Console.Clear();
            Console.WriteLine($"Order completed, total cost ${totalCost}:");
            foreach (KeyValuePair<StoreItem, int> pair in cartItems)
            {
                Console.WriteLine($"- {pair.Value}x {pair.Key.name}" + (pair.Value > 1 ? "s" : "") + " to cart" + $", at a total of ${(pair.Key.price * pair.Value)}");
            }

            cartItems = new Dictionary<StoreItem, int>();
            SaveCart();
        }

        private static void LoadStore()
        {
            if (File.Exists(savePath + "StoreItems.txt"))
            {
                string[] file = File.ReadAllLines(savePath + "StoreItems.txt");
                storeItems = new StoreItem[File.ReadLines(savePath + "StoreItems.txt").Count()];

                int counter = 0;
                foreach (string s in file)
                {
                    string[] fileEntries = s.Split(",");
                    storeItems[counter] = new StoreItem(int.Parse(fileEntries[0]), int.Parse(fileEntries[1]), fileEntries[2], fileEntries[3]);
                    counter++;
                }
            }
            else
            {
                Console.WriteLine("Save file does not exist!");
            }
        }

        private static void AddToCart(int index, int amount)
        {
            cartItems.Add(storeItems[index], amount);
            Console.WriteLine($"Added {amount}x {storeItems[index].name}" + (amount > 1 ? "s" : "") + " to cart");
            Thread.Sleep(1000);
            MainMenu();
        }

        private static void SaveCart()
        {
            string[] saveCart = new string[cartItems.Count];
            int counter = 0;
            foreach (KeyValuePair<StoreItem, int> pair in cartItems)
            {
                saveCart[counter] = $"{pair.Key.name},{pair.Value}";
                counter++;
            }

            File.WriteAllLines(savePath + "CartItems.txt", saveCart, Encoding.UTF8);
            Thread.Sleep(1000);
            Environment.Exit(0);
        }
        private static StoreItem GetItemInformation(string itemName)
        {
            int price = 0;
            int id = 0;
            string description = "";

            foreach (StoreItem item in storeItems)
            {
                if (item.name == itemName)
                {
                    price = item.price;
                    id = item.serialID;
                    description = item.description;
                    break;
                }
            }

            return new StoreItem(id, price, itemName, description);
        }

        private static void LoadCart()
        {
            string[] file = File.ReadAllLines(savePath + "CartItems.txt");
            foreach (string s in file)
            {
                string[] fileEntries = s.Split(",");
                cartItems.Add(GetItemInformation(fileEntries[0]), int.Parse(fileEntries[1]));
            }
        }

        public static int ShowMenu(string prompt, string[] options)
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
                    Console.WriteLine("- " + option);
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
            Console.CursorVisible = true;
            return selected;
        }
    }
}
