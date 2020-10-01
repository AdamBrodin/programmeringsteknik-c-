using System;
using System.Globalization;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Console_Blog
{
    public class Program
    {
        public static void Main()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\";

            Console.WriteLine("Hello and welcome to your very own console-blog!");
            string blogPost = ReadString("Write a new post: ");
            string title = ReadString("Enter a title for the post: ");

            File.WriteAllText(path + title + ".txt", title + ": " + blogPost);

            Console.WriteLine("Blog post saved to " + path.Substring(0, path.LastIndexOf(@"\")));
        }

        private static string ReadString(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }
    }
}
