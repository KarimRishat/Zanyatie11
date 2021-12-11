using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Metodichka12
{
    public class Bank
    {
        public Hashtable accounts = new Hashtable();
        public long CreateAccount()
        {
            BankAccount opened = new BankAccount();
            accounts[opened.Number()] = opened;
            return opened.Number();
        }
        public long CreateAccount(decimal sum)
        {
            BankAccount opened = new BankAccount(sum);
            accounts[opened.Number()] = opened;
            return opened.Number();
        }
        public long CreateAccount(int x)
        {
            BankAccount opened = new BankAccount(x);
            accounts[opened.Number()] = opened;
            return opened.Number();
        }
        public long CreateAccount(int x, decimal sum)
        {
            BankAccount opened = new BankAccount(x,sum);
            accounts[opened.Number()] = opened;
            return opened.Number();
        }
        public void ShowAccs()
        {
            foreach (DictionaryEntry acc in accounts)
            {
                Console.WriteLine($"    {acc.Key}:  {acc.Value}");
            }
        }
        
        public void DeleteAccount(long num)
        {
            accounts.Remove(num);
        }
    }
}
