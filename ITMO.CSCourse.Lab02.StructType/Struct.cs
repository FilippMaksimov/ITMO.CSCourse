using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITMO.CSCourse.Lab02.StructType
{
    public enum AccountType { Checking, Deposit }
    public struct BankAccount
    {
        public long accNo;
        public decimal accBal;
        public AccountType accType;
    }
    internal class Struct
    {
        static void Main(string[] args)
        {
            BankAccount goldAccount;
            goldAccount.accType = AccountType.Checking;
            goldAccount.accBal = (decimal)3200.00;
            goldAccount.accNo = 123;

            //Console.WriteLine("*** Account Summary #1 ***");
            // Console.WriteLine("Acct Number {0}", goldAccount.accNo); // remove such types of line
            Console.WriteLine("Enter account number:");
            goldAccount.accNo = long.Parse(Console.ReadLine()); //перед тем присвоить считанное значение переменной нужно преобразовать из типа string в long!(1)
            Console.WriteLine("*** Account Summary #1 ***");
            Console.WriteLine("Acct Type {0}", goldAccount.accType);
            Console.WriteLine("Acct Balance {0} $", goldAccount.accBal);
        }
    }
}
