using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITMO.CSCourse.Lab06.UniqueNumbers
{
    public enum AccountType { Checking, Deposit }
    class CreateAccount
    {
        static void Main()
        {
            BankAccount berts = NewBankAccount();
            Write(berts);
            BankAccount bank = NewBankAccount();
            Write(bank);
        }
        static BankAccount NewBankAccount()
        {
            BankAccount created = new BankAccount();

            //Console.Write("Please enter the account number: ");
            //long number = long.Parse(Console.ReadLine());
            //long number = BankAccount.NextNumber(); //после инкапсуляции (изменения переменной в классе BankAccount) нельзя ссылаться на NextNumber() 
            Console.Write("Please enter the ballance: ");
            decimal balance = decimal.Parse(Console.ReadLine());
            created.Populate(balance);

            return created;
        }
        static void Write(BankAccount toWrite)
        {
            Console.WriteLine("Account number is {0}", toWrite.Number());
            Console.WriteLine("Account balance is {0}", toWrite.Balance());
            Console.WriteLine("Account type is {0}", toWrite.Type());
        }
    }
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
