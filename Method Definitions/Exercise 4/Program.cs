using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercise_4
{
    public class Program
    {
        public static void Main()
        {
            // We need this to make sure we can always use periods for decimal points.
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            FlowchartLoop();
        }

        public static bool YesOrNo(string prompt)
        {
            while (true)
            {
                string input = ReadString(prompt);
                if (input == "Yes" || input == "yes" || input == "Y" || input == "y")
                {
                    return true;
                }
                else if (input == "No" || input == "no" || input == "N" || input == "n")
                {
                    return false;
                }
            }
        }

        public static void ItemIsFixed()
        {
            Console.WriteLine("Good, don't touch it!");
        }

        public static void PressRandomButton()
        {
            while(true)
            {
                if (YesOrNo("Press a random button, is it working?: "))
                {
                    ItemIsFixed();
                    break;
                }
            }
        }

        public static void FlowchartLoop()
        {
            if (YesOrNo("Is it broken?: "))
            {
                if (YesOrNo("Can a friend fix it?: "))
                {
                    ItemIsFixed();
                }
                else
                {
                    PressRandomButton();
                }
            }
            else
            {
                ItemIsFixed();
            }
        }

        public static string ReadString(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }
    }
}
