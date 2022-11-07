using System;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum AccountType { Checking, Deposit }
class CreateAccount
{
    static void Main()
    {
        BankAccount acc1, acc2, acc3, acc4;

        acc1 = new BankAccount();
        acc1.Deposit(200);
        acc1.Deposit(185);
        acc1.Deposit(160);
        acc1.Withdraw(100);
        acc1.Withdraw(150);

        acc2 = new BankAccount(AccountType.Deposit);
        acc2.Deposit(180);
        acc2.Deposit(189);
        acc2.Deposit(320);
        acc2.Withdraw(230);
        acc2.Withdraw(125);

        acc3 = new BankAccount(100);
        acc3.Deposit(246);
        acc3.Deposit(400);
        acc3.Deposit(135);
        acc3.Withdraw(325);
        acc3.Withdraw(70);

        acc4 = new BankAccount(AccountType.Deposit, 500);
        acc4.Deposit(500);
        acc4.Deposit(755);
        acc4.Deposit(278);
        acc4.Withdraw(500);
        acc4.Withdraw(198);

        Write(acc1);
        Write(acc2);
        Write(acc3);
        Write(acc4);
    }
    public static void TestDeposit(BankAccount acc)
    {
        Console.Write("Please enter ammount to deposit: ");
        decimal amount = decimal.Parse(Console.ReadLine());
        acc.Deposit(amount);
    }
    public static void TestWithdraw(BankAccount acc)
    {
        Console.Write("Please enter ammount to withdraw: ");
        decimal amount = decimal.Parse(Console.ReadLine());
        if (!acc.Withdraw(amount))
        {
            Console.WriteLine("Insufficient funds");
        }
    }
    static void Write(BankAccount acc)
    {
        Console.WriteLine("Account number is {0}", acc.Number());
        Console.WriteLine("Account balance is {0}", acc.Balance());
        Console.WriteLine("Account type is {0}", acc.Type());
        Console.WriteLine("Transactions: ");
        foreach (BankTransaction tran in acc.Transactions())
        {
            Console.WriteLine("Date/Time: {0}\tAmount: {1}", tran.When(), tran.Amount());
        }
        Console.WriteLine();
    }
}
class BankAccount
{
    public BankAccount() //создание первого конструктора 
    {
        accNo = NextNumber();
        accType = AccountType.Checking;
        accBal = 0;
    }
    public BankAccount(AccountType aType) //создание второго конструктора
    {
        accNo = NextNumber();
        accType = aType;
        accBal = 0;
    }
    public BankAccount(decimal aBal) //создание третьего конструктора 
    {
        accNo = NextNumber();
        accType = AccountType.Checking;
        accBal = aBal;
    }
    public BankAccount(AccountType aType, decimal aBal) //создание четвёртого конструктора 
    {
        accNo = NextNumber();
        accType = aType;
        accBal = aBal;
    }
    public long Number()
    {
        return accNo;
    }
    public decimal Balance()
    {
        return (decimal)accBal;
    }
    public string Type()
    {
        return accType.ToString();
    }
    private Queue tranQueue = new Queue();
    public Queue Transactions()
    {
        return tranQueue;
    }
    public decimal Deposit(decimal amount)
    {
        if (amount >= 0)
        {
            accBal += amount;
            BankTransaction tran = new BankTransaction(amount);
            tranQueue.Enqueue(tran);
            return accBal;
        }
        else
        {
            Console.WriteLine("This is a negative number!!!");
            return accBal;
        }
    }
    public bool Withdraw(decimal ammount)
    {
        bool sufficientFunds = accBal >= ammount;
        if (sufficientFunds)
        {
            accBal -= ammount;
            BankTransaction tran = new BankTransaction(-ammount);
            tranQueue.Enqueue(tran);
        }
        return sufficientFunds;
    }
    public void TransferFrom(BankAccount accFrom, decimal amount)
    {
        if (accFrom.Withdraw(amount))
            this.Deposit(amount);
    }
    private long accNo;
    private decimal accBal;
    private AccountType accType;

    private static long NextNumber()
    {
        return nextAccNo++;
    }
    private static long nextAccNo = 123;
}
