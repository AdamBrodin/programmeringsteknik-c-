using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Conditional_Operators
{
    public class Program
    {
        public static void Main()
        {
            /*double temperature = 50;
            string message;
            if (temperature >= 100)
            {
                message = "Boiling";
            }
            else
            {
                message = "Normal";
            }*/

            // ^ rewritten as conditional operator

            double temperature = 50;
            string message = temperature >= 100 ? "Boiling" : "Normal";





            /*double temperature = 50;
            string message;
            if (temperature >= 100)
            {
                message = "Boiling";
            }
            else if (temperature <= 0)
            {
                message = "Freezing";
            }
            else
            {
                message = "Normal";
            }*/

            // ^ rewritten as conditional operator

            double temp = 50;
            string msg = temp >= 100 ? "Boiling" : temp <= 0 ? "Freezing": "Normal";
        }
    }
}
