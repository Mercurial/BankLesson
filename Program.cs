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
            float amount = 0.0f;
            float finalBalance = 0.0f;
            while (true)
            {
                Console.Clear();
                Console.WriteLine(bank.GetWelcomeMessage());
                Console.WriteLine("1.) Login");
                Console.WriteLine("2.) Register");
                Console.WriteLine("3.) Exit");
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
                            bool accountLoop = true;
                            while (accountLoop)
                            {
                                Console.Clear();
                                Console.WriteLine($"Welcome back, {account.Username}");
                                Console.WriteLine($"Account Id, {account.Id}");
                                Console.WriteLine($"Your balance is: ${account.Balance}");
                                Console.WriteLine("1.) Deposit");
                                Console.WriteLine("2.) Withdraw");
                                Console.WriteLine("3.) Transfer to another account");
                                Console.WriteLine("4.) Go Back");
                                switch (Console.ReadLine())
                                {
                                    case "1":
                                        Console.Clear();
                                        Console.WriteLine("[Deposit]");
                                        Console.WriteLine("Enter the amount you want to deposit: ");
                                        amount = float.Parse(Console.ReadLine());
                                        finalBalance = account.Deposit(amount);
                                        Console.WriteLine($"Final Balance = {finalBalance}");
                                        break;
                                    case "2":
                                        Console.Clear();
                                        Console.WriteLine("[Withdraw]");
                                        Console.WriteLine("Enter the amount you want to deposit: ");
                                        amount = float.Parse(Console.ReadLine());
                                        finalBalance = account.Withdraw(amount);
                                        Console.WriteLine($"Final Balance = ${finalBalance}");
                                        break;
                                    case "3":
                                        Console.Clear();
                                        Console.WriteLine("[Transfer to another account]");
                                        Console.WriteLine("Enter the Id of the account you want to transfer to: ");
                                        Guid toId = Guid.Parse(Console.ReadLine());
                                        Console.WriteLine("Enter the amount you want to transfer: ");
                                        amount = float.Parse(Console.ReadLine());
                                        var receiverAccount = bank.FindById(toId);
                                        finalBalance = account.Withdraw(amount);
                                        receiverAccount.Deposit(amount);
                                        Console.WriteLine($"Final Balance = ${finalBalance}");
                                        break;
                                    case "4":
                                        Console.Clear();
                                        Console.WriteLine("Going back to main menu, press any key to continue...");
                                        accountLoop = false;
                                        break;
                                    default:
                                        Console.WriteLine("Please choose 1 or 2, press any key to continue...");
                                        break;
                                }
                                Console.ReadKey();
                            }
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
                    case "3":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid Option, press any key to continue...");
                        break;
                }
            }
        }
    }
}
