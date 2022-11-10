
using System.Collections;
using System.Runtime.Remoting.Messaging;
using System.Security.AccessControl;

public class Bank
{
    public static long CreateAccount()
    {
        BankAccount newAcc = new BankAccount();
        long accNo = newAcc.Number();
        accounts[accNo] = newAcc;
        return accNo;
    }
    public static long CreateAccount(AccountType aType)
    {
        BankAccount newAcc = new BankAccount(aType);
        long accNo = newAcc.Number();
        accounts[accNo] = newAcc;
        return accNo;
    }
    public static long CreateAccount(decimal aBal)
    {
        BankAccount newAcc = new BankAccount(aBal);
        long accNo = newAcc.Number();
        accounts[accNo] = newAcc;
        return accNo;
    }
    public static long CreateAccount(AccountType aType, decimal aBal)
    {
        BankAccount newAcc = new BankAccount(aType, aBal);
        long accNo = newAcc.Number();
        accounts[accNo] = newAcc;
        return accNo;
    }

    public static bool CloseAccount(long accNo)
    {
        BankAccount closing = (BankAccount)accounts[accNo];
        if (closing != null)
        {
            accounts.Remove(accNo);
            closing.Dispose();
            return true;
        }
        else
        {
            return false;   
        }
    }
    public static BankAccount GetAccount(long AccNo)
        { return (BankAccount)accounts[AccNo]; }
    private static Hashtable accounts = new Hashtable();
    private Bank() { } //закрытый конструктор для предотвращения создания объектов класса Bank!!!
}
