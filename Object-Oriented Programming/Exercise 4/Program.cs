using System;
using System.Collections.Generic;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercise_4
{
    public class CustomList
    {
        int[] customArray = new int[10];

        public void Add(int value)
        {
            if (value != 0)
            {
                for (int i = 0; i < GetLength(); i++)
                {
                    if (customArray[i] == 0)
                    {
                        customArray[i] = value;
                        return;
                    }
                }
            }

            // If there were no free spaces aka 0's create a bigger array
            customArray = new int[GetLength() + 10];
        }

        public void Remove(int value)
        {
            int index = 0;
            for(int i = 0; i < GetLength(); i++)
            {
                if(customArray[i] == value)
                {
                    index = i;
                    break;
                }
            }

            for (int i = index; i < GetLength() - 1; i++)
            {
                customArray[i] = customArray[i + 1];
            }

            Array.Resize(ref customArray, GetLength() - 1);
        }

        public int GetValue(int index)
        {
            return customArray[index];
        }


        public int GetLength()
        {
            return customArray.Length;
        }
    }

    public class Program
    {
        public static void Main()
        {
            // We need this to make sure we can always use periods for decimal points.
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            CustomList myList = new CustomList();
            for (int i = 0; i < 2; i++)
            {
                myList.Add(ReadInt("Enter a number to add: "));
            }
            myList.Remove(ReadInt("Enter a number to remove: "));

            int valueAtIndex = myList.GetValue(ReadInt("Get value at index: "));
            Console.WriteLine("The value at the selected index is: " + valueAtIndex);
        }

        public static int ReadInt(string prompt)
        {
            Console.Write(prompt);
            return int.Parse(Console.ReadLine());
        }
    }
}
