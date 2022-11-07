using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITMO.CSCourse.Lab07.Bank
{
    public enum AccountType { Checking, Deposit }
    //class CreateAccount
    //{
    //    static void Main()
    //    {
    //        BankAccount berts = NewBankAccount();
    //        Write(berts);
    //        TestDeposit(berts);
    //        Write(berts);
    //        TestWithdraw(berts);
    //        Write(berts);

    //        BankAccount freds = NewBankAccount();
    //        Write(freds);
    //        TestDeposit(freds);
    //        Write(freds);
    //        TestWithdraw(freds);
    //        Write(freds);
    //    }
    //    static BankAccount NewBankAccount()
    //    {
    //        BankAccount created = new BankAccount();

    //        Console.Write("Please enter the balance");
    //        decimal balance = decimal.Parse(Console.ReadLine());
    //        created.Populate(balance);

    //        return created;
    //    }
    //    public static void TestDeposit(BankAccount acc)
    //    {
    //        Console.Write("Please enter ammount to deposit: ");
    //        decimal amount = decimal.Parse(Console.ReadLine());
    //        acc.Deposit(amount);
    //    }
    //    public static void TestWithdraw(BankAccount acc)
    //    {
    //        Console.Write("Please enter ammount to withdraw: ");
    //        decimal amount = decimal.Parse(Console.ReadLine());
    //        if (!acc.Withdraw(amount))
    //        {
    //            Console.WriteLine("Insufficient funds");
    //        }
    //    }
    //    static void Write(BankAccount toWrite)
    //    {
    //        Console.WriteLine("Account number is {0}", toWrite.Number());
    //        Console.WriteLine("Account balance is {0}", toWrite.Balance());
    //        Console.WriteLine("Account type is {0}", toWrite.Type());
    //    }
    //}
    class BankAccount
    {
        public void Populate(decimal balance)
        {
            accNo = NextNumber();
            accBal = balance;
            accType = AccountType.Checking;
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
        public decimal Deposit(decimal amount)
        {
            if (amount >= 0)
            {
                accBal += amount;
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
            }
            return sufficientFunds;
        }
        public void TransferFrom(BankAccount accFrom, decimal amount)
        {
            if (accFrom.Withdraw(amount)) //списание с одного счета 
                this.Deposit(amount); //перевод на депозит другого счета
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
}
