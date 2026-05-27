// internal class TrafficLight
// {
//     private int _phase;
//
//     public TrafficLight(int phase = 0)
//     {
//         public void NextPhase()
//         {
//             _phase = _phase < 3 ? _phase + 1 : 0;
//         }
//
//         public void show()
//         {
//             
//         }
//     }
// }

internal class BankAccount
{
    private double _balance;

    public BankAccount(double initialBalance)
    {
        if (initialBalance >= 0)
        {
            _balance = initialBalance;
        }
    }

    public double CurrentBalance
    {
        get { return _balance }
    }

    public void Deposit(double amount)
    {
        if (amount > 0)
        {
            _balance += amount;
            Console.WriteLine($"Deposited {amount}. New balance: {_balance}");
        }
        else
        {
            Console.WriteLine($"Deposit failed: Amount must be positive");
        }
    }

    public void Withdraw(double amount)
    {
        if (amount > 0)
        {
            _balance -= amount;
            Console.WriteLine($"Withdrawn {amount}. New balance: {_balance}");
        }
        else
        {
            Console.WriteLine($"Withdrawn failed: try inserting a number lower or equal to Your balance.");
        }
    }
}

