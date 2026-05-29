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

using System.Text.Json;

internal class BankAccountDto
{
    public double Balance { get; set; }
    public string Status { get; set; } = "";
}

class Program
{
    static void Main(string[] args)
    {
        const string file = "account.json";
        double startingBalance = 500;

        if (File.Exists(file))
        {
            string json = File.ReadAllText(file);
            BankAccountDto? dto = JsonSerializer.Deserialize<BankAccountDto>(json);
            if (dto != null) startingBalance = dto.Balance;
            Console.WriteLine($"Welcome back! Loaded balance: {dto?.Balance} .");
        }
        else
        {
            Console.WriteLine("First time setup! Starting balance: 500");
        }

        BankAccount myAccount = new BankAccount(initialBalance: startingBalance);
        
        while (true)
        {
            Console.WriteLine($"\nBalance: {myAccount.CurrentBalance}");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Exit");
            string? choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.Write("How much to deposit? ");
                double amount = double.Parse(Console.ReadLine() ?? "0");
                Console.WriteLine($"Very well, Your new deposit is {myAccount.CurrentBalance + amount}");
                break;
            }
            else if (choice == "2")
            {
                Console.Write("How much to withdraw? ");
                double amount = double.Parse(Console.ReadLine() ?? "0");
                Console.WriteLine($"Very well, Your new deposit is {myAccount.CurrentBalance - amount}");
                break;
            }
            else if (choice == "3")
            {
                break;
            }

            string savedJson = JsonSerializer.Serialize(saveDto);
            File.WriteAllText("account.json", savedJson);
            Console.WriteLine("Saved: " + savedJson);

        }

        
        // myAccount.Withdraw(100);
        // myAccount.Withdraw(700);

        var saveDto = new BankAccountDto
        {
            Balance = myAccount.CurrentBalance,
            Status = "GoodScore"
        };
        
        string savedJson = JsonSerializer.Serialize(saveDto);
        File.WriteAllText("account.json", savedJson);
        Console.WriteLine("Saved: " + savedJson);
        
    }
    

}

internal class MyConsole
{
    public static bool AskForBool(string question)
    {
        Console.Write(question + " ");
        string? answer = Console.ReadLine();

        if (answer == null)
        {
            return false;
        }

        answer = answer.Trim().ToLower();
        return answer == "y" || answer == "yes";
    }
}

internal enum AccountStatus
{
    GoodScore,
    Debt
}

internal class BankAccount
{
    private double _balance;
    private AccountStatus _status = AccountStatus.GoodScore;

    public BankAccount(double initialBalance)
    {
        if (initialBalance >= 0)
        {
            _balance = initialBalance;
        }
    }

    public double CurrentBalance
    {
        get { return _balance; }
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
        //     if (amount > 0) 
        //     { 
        //         _balance -= amount; 
        //         Console.WriteLine("Withdrawn {amount}. New balance: {_balance}");
        //     }
        //     
        //     else
        //     {
        //         Console.WriteLine("Withdrawn failed: try inserting a number lower or equal to Your balance.");
        //     }
        // }
    
        if (amount <= 0)
        {
            Console.WriteLine("Withdrawn failed: insert a positive number, no negatives or 0");
            return;
        }

        if (amount <= CurrentBalance)
        {
            _balance -= amount;
            Console.WriteLine($"Successfully withdrawm {amount} , New balance: {_balance}");
            return;
        }
        
        if (amount > CurrentBalance)
        {
            // Console.WriteLine($"Withdrawn failed: try inserting a number lower or equal to Your balance.");
            bool readyForDebt = MyConsole.AskForBool($"WARNING! After withdrawing, your account will be in the negatives, {CurrentBalance - amount} , are you sure you want to accept the debt? (Y/n)");
            if (readyForDebt)
            {
                _balance -= amount;
                // Console.WriteLine($"your current balance is {_balance}");
                Console.WriteLine($"Successfully withdrawm {amount} , New balance: {_balance}");
                return;
            }
            else
            {
                return;
            }
        }
        
        
        // in this part here i was taking away the money twice... whoopsie!
        // else if (amount < CurrentBalance)
        // {
        //         _balance -= amount;
        //         Console.WriteLine($"your current balance is {_balance}");
        // }
        
        // _balance -= amount;
        
        
        // Console.WriteLine($"Withdrawn {amount}. New balance: {_balance}. Your credit score is: {_status}");
    }
}

