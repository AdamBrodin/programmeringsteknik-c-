using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercise_2
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("HideString asd: " + HideString("asd"));
            Console.WriteLine("HideString asd, x: " + HideString("asd", "x"));
        }


        private static string HideString(string str)
        {
            string returnStr = "";

            foreach (char c in str)
            {
                returnStr += "*";
            }

            return returnStr;
        }

        private static string HideString(string str, string replacement)
        {
            string returnStr = "";

            foreach (char c in str)
            {
                returnStr += replacement;
            }

            return returnStr;
        }
    }
}
