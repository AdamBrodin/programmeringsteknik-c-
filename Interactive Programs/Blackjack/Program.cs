using System;
using System.Globalization;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Blackjack
{
    public class Program
    {
        private static bool gameIsRunning = true;
        private static Random rand;
        private static int dealerCount, playerCount, cardsTaken, dealerStopsAt = 17;
        public static void Main()
        {
            // We need this to make sure we can always use periods for decimal points.
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
            rand = new Random();
            GameLoop();
        }

        private static string ReadString(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }

        private static bool YesOrNo(string prompt)
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

        private static int RollACard()
        {
            return rand.Next(1, 11);
        }

        private static String GetGameStatus()
        {
            return "PLAYER: " + playerCount + " - DEALER: " + dealerCount;
        }

        private static void CheckForWin()
        {
            if (playerCount > 21)
            {
                Console.WriteLine("Player is over 21, dealer wins!");
            }
            else if (dealerCount > 21 && playerCount < 21)
            {
                Console.WriteLine("Dealer is over 21, player wins!");
            }
            else if(dealerCount > 21 && playerCount > 21 || dealerCount == playerCount)
            {
                Console.WriteLine("Dealer & player have the same count, it's a tie!");
            }
        }

        private static void GameTurns()
        {
            while (gameIsRunning)
            {
                Console.WriteLine(GetGameStatus());

                // Player gets asked to roll
                if (YesOrNo("Would you like a card? (Y/n/N/n): ") && cardsTaken <= 2)
                {
                    int rolledCard = RollACard();
                    playerCount += rolledCard;
                    cardsTaken++;
                    Console.WriteLine("You rolled a " + rolledCard + "!");
                }

                if (dealerCount < dealerStopsAt)
                {
                    int rolledCard = RollACard();
                    dealerCount += rolledCard;
                }

                CheckForWin();

            }
        }

        private static void GameLoop()
        {
            Console.WriteLine("Welcome to a game of blackjack!");
            Thread.Sleep(1000);
            while (true)
            {
                if (YesOrNo("I will act as your dealer, the person closest to 21 wins, are you ready?: "))
                {
                    Console.Clear();
                    break;
                }
            }

            GameTurns();
        }
    }

    [TestClass]
    public class ProgramTests
    {
        [DataTestMethod]
        [DataRow]
        public void ExampleTest()
        {
            using FakeConsole console = new FakeConsole("First input", "Second input");
            Program.Main();
            Assert.AreEqual("Hello!", console.Output);
        }
    }
}
