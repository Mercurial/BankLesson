using System;

namespace ClarkBank
{
    class Program
    {
        static void Main(string[] args)
        {
            var bank = new Bank("Union Bank");

            string username = string.Empty;
            string password = string.Empty;
            bool shouldContinue = true;
            while (shouldContinue)
            {
                Console.Clear();
                Console.WriteLine(bank.GetWelcomeMessage());
                Console.WriteLine("Enter 1 to Login, Enter 2 to Register");
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("[LOGIN]");
                        Console.WriteLine("Enter Username: ");
                        username = Console.ReadLine();
                        Console.WriteLine("Enter Password: ");
                        password = Console.ReadLine();
                        var account = bank.Login(username, password);
                        if (account != null)
                        {
                            Console.Clear();
                            Console.WriteLine($"Welcome back, {account.Username}");
                            Console.WriteLine($"Account Id, {account.Id}");
                            Console.WriteLine($"Your balance is: ${account.Balance}");
                            Console.ReadKey();
                            
                        }
                        else
                        {
                            Console.WriteLine("Invalid Username or Password, press any key to continue..");
                            Console.ReadKey();
                        }
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("[REGISTER]");
                        Console.WriteLine("Enter Username: ");
                        username = Console.ReadLine();
                        Console.WriteLine("Enter Password: ");
                        password = Console.ReadLine();
                        var id = bank.Register(username, password);
                        Console.WriteLine($"Congratulations, you have succesfully registered! {id}");
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid Option, press any key to continue...");
                        break;
                }
            }

            Console.ReadKey();
        }
    }
}
