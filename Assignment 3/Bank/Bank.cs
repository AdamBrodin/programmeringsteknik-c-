using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace ImperativeToObjectOriented
{
    public class Account
    {
        public string Name;
        public int Balance;

        public void Withdraw(int amount)
        {
            if (this.Balance >= amount)
            {
                this.Balance -= amount;
                Console.WriteLine("Money withdrawn");
            }
            else
            {
                Console.WriteLine("Balance too low to withdraw");
            }
        }

        public void Deposit(int amount)
        {
            this.Balance += amount;
            Console.WriteLine("Money deposited");
        }

        public void Deposit(Account account, int amount)
        {
            account.Balance += amount;
            Console.WriteLine("Money deposited");
        }

        public void Transfer(Account toAccount, int amount)
        {
            if (this.Balance >= amount)
            {
                this.Withdraw(amount);
                this.Deposit(toAccount, amount);
                Console.WriteLine("Money transfered");
            }
            else
            {
                Console.WriteLine("Balance too low to transfer");
            }
        }
    }

    public class Share
    {
        public string Company;
        public int Amount;
        public int Price;

        public void BuyShare(int amount, Account account)
        {
            int totalPrice = this.Price * amount;
            if (account.Balance >= totalPrice)
            {
                account.Withdraw(totalPrice);
                this.Amount += amount;
                Console.WriteLine("Shares bought");
            }
            else
            {
                Console.WriteLine("Balance too low to buy shares");
            }
        }

        public void SellShare(int amount, Account account)
        {
            if (amount <= this.Amount)
            {
                int totalPrice = this.Price * amount;
                account.Deposit(totalPrice);
                this.Amount -= amount;
                Console.WriteLine("Shares sold");
            }
            else
            {
                Console.WriteLine("Number of shares too low to sell");
            }
        }
    }

    public class Bank
    {
        public static void Main()
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            Account[] accounts =
            {
                new Account
                {
                    Name = "Spar",
                    Balance = 90000
                },
                new Account
                {
                    Name = "Kort",
                    Balance = 5000
                },
                new Account
                {
                    Name = "Resor",
                    Balance = 22000
                }
            };

            Share[] shares =
            {
                new Share
                {
                    Company = "Ericsson",
                    Price = 72,
                    Amount = 20
                },
                new Share
                {
                    Company = "H&M",
                    Price = 129,
                    Amount = 50
                },
                new Share
                {
                    Company = "AstraZeneca",
                    Price = 713,
                    Amount = 5
                }
            };

            while (true)
            {
                Prompt(accounts, shares);
                Console.WriteLine();
            }
        }

        public static void Prompt(Account[] accounts, Share[] shares)
        {
            Console.WriteLine("What do you want to do?");

            Console.WriteLine();
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Transfer");
            Console.WriteLine("4. Buy shares");
            Console.WriteLine("5. Sell shares");
            Console.WriteLine("6. Exit");

            Console.WriteLine();
            Console.Write("Select option: ");
            int option = int.Parse(Console.ReadLine());
            Console.WriteLine();

            if (option == 1)
            {
                ShowAccounts(accounts);

                Console.WriteLine();
                Console.Write("Select account: ");
                int accountNumber = int.Parse(Console.ReadLine());
                Account account = accounts[accountNumber - 1];

                Console.Write("Select amount: ");
                int amount = int.Parse(Console.ReadLine());

                Console.Clear();
                account.Deposit(amount);

                Console.WriteLine();
                ShowAccounts(accounts);
            }
            else if (option == 2)
            {
                ShowAccounts(accounts);

                Console.WriteLine();
                Console.Write("Select account: ");
                int accountNumber = int.Parse(Console.ReadLine());
                Account account = accounts[accountNumber - 1];

                Console.Write("Select amount: ");
                int amount = int.Parse(Console.ReadLine());

                Console.Clear();
                account.Withdraw(amount);

                Console.WriteLine();
                ShowAccounts(accounts);
            }
            else if (option == 3)
            {
                ShowAccounts(accounts);

                Console.WriteLine();
                Console.Write("Select 'from' account: ");
                int fromNumber = int.Parse(Console.ReadLine());
                Account fromAccount = accounts[fromNumber - 1];

                Console.Write("Select 'to' account: ");
                int toNumber = int.Parse(Console.ReadLine());
                Account toAccount = accounts[toNumber - 1];

                Console.Write("Select amount: ");
                int amount = int.Parse(Console.ReadLine());

                Console.Clear();
                fromAccount.Transfer(toAccount, amount);

                Console.WriteLine();
                ShowAccounts(accounts);
            }
            else if (option == 4)
            {
                ShowShares(shares);

                Console.WriteLine();
                Console.Write("Select share to buy: ");
                int shareNumber = int.Parse(Console.ReadLine());
                Share share = shares[shareNumber - 1];

                Console.Write("Select amount to buy: ");
                int shareAmount = int.Parse(Console.ReadLine());

                Console.WriteLine();
                ShowAccounts(accounts);

                Console.WriteLine();
                Console.Write("Select account to buy with: ");
                int accountNumber = int.Parse(Console.ReadLine());
                Account account = accounts[accountNumber - 1];

                Console.Clear();
                share.BuyShare(shareAmount, account);

                Console.WriteLine();
                ShowShares(shares);

                Console.WriteLine();
                ShowAccounts(accounts);
            }
            else if (option == 5)
            {
                ShowShares(shares);

                Console.WriteLine();
                Console.Write("Select share to sell: ");
                int shareNumber = int.Parse(Console.ReadLine());
                Share share = shares[shareNumber - 1];

                Console.Write("Select amount to sell: ");
                int shareAmount = int.Parse(Console.ReadLine());

                Console.WriteLine();
                ShowAccounts(accounts);

                Console.WriteLine();
                Console.Write("Select account to deposit to: ");
                int accountNumber = int.Parse(Console.ReadLine());
                Account account = accounts[accountNumber - 1];

                Console.Clear();
                share.SellShare(shareAmount, account);

                Console.WriteLine();
                ShowShares(shares);

                Console.WriteLine();
                ShowAccounts(accounts);
            }
            else if (option == 6)
            {
                Environment.Exit(0);
            }
        }

        public static void ShowAccounts(Account[] accounts)
        {
            Console.WriteLine("Your accounts: ");
            Console.WriteLine();

            for (int i = 0; i < accounts.Length; i++)
            {
                Account account = accounts[i];
                Console.WriteLine((i + 1) + ": " + account.Name + " (" + account.Balance + " kr)");
            }
        }

        public static void ShowShares(Share[] shares)
        {
            Console.WriteLine("Your shares: ");
            Console.WriteLine();

            for (int i = 0; i < shares.Length; i++)
            {
                Share share = shares[i];
                Console.WriteLine((i + 1) + ": " + share.Company + " (" + share.Amount + " at " + share.Price + " kr)");
            }
        }
    }
}