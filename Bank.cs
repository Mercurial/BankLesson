using System;
using System.Linq;
using System.Collections.Generic;
class Bank {
    public string Name { get; set; }
    private Account[] Accounts { get; set; }
    private int TotalAccounts { get; set; } = 0;
    private const int SLOTS_BEFORE_EXPANTION = 2;
    private const int SLOTS_TO_ADD = 4;
    private const int INITIAL_ACCOUNTS = 4;

    public Bank(string n)
    {
        Name = n;
        Accounts = new Account[INITIAL_ACCOUNTS]; // Object sa Memory -> 1234
        for(var x = 0; x < Accounts.Length; x++) Accounts[x] = new Account();
    }

    public string GetWelcomeMessage()
    {
        var totalUsers = CountTotalAccounts();
        return $"Welcome to {Name}, Total Registered Accounts: {totalUsers}";
    }

    public Guid Register(string username, string password)
    {
        var i = CountTotalAccounts();
        CheckForExpantion();
        Accounts[i].Username = username;
        Accounts[i].Password = password;
        Accounts[i].IsRegistered = true;
        return Accounts[i].Id;
    }

    public int CountTotalAccounts()
    {
        var registeredAccounts = from a in Accounts 
            where a.IsRegistered == true 
            select a;

        return registeredAccounts.Count();
    }

    public int CountSlotsLeft()
    {
        var i = CountTotalAccounts();
        return Accounts.Length - i;
    }

    public void CheckForExpantion()
    {
        if(CountSlotsLeft() <= SLOTS_BEFORE_EXPANTION)
        {
            var newAccounts = new Account[Accounts.Length + SLOTS_TO_ADD];
            for(int x = 0; x < newAccounts.Length; x++)
            {
                newAccounts[x] = new Account();
            }
            Accounts.CopyTo(newAccounts, 0);
            Accounts = newAccounts;
        }
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

    public Account FindById(Guid id)
    {
        foreach(Account a in Accounts)
        {
            if(a.Id == id)
            {
                return a;
            }
        }
        return null;
    }

    
}