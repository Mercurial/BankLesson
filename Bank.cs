using System;

class Bank {
    public string Name { get; set; }
    public Account[] Accounts { get; private set; }
    private int TotalAccounts { get; set; } = 0;

    public Bank(string name)
    {
        Name = name;
        Accounts = new Account[10];
        for(var x = 0; x < Accounts.Length; x++) Accounts[x] = new Account();
    }

    public string GetWelcomeMessage()
    {
        return $"Welcome to {Name}";
    }

    public Guid Register(string username, string password)
    {
        Accounts[TotalAccounts].Username = username;
        Accounts[TotalAccounts].Password = password;
        TotalAccounts++;

        return Accounts[TotalAccounts].Id;
    }

    public Account Login(string username, string password)
    {
        foreach(Account a in Accounts)
        {
            if(a.Username == username && a.Password == password)
            {
                return a;
            }
        }

        return null;
    }

    
}