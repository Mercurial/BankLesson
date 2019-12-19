using System;
class Account
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Username { get; set; }
    public string Password { get; set; }
    public float Balance { get; private set; } = 0.0f;

    public float Withdraw(float amount)
    { 
        if(amount <= Balance)
        {
            Balance -= amount;
        }
        return Balance;
    }

    public float Deposit(float amount)
    {
        Balance += amount;
        return Balance;
    }
}