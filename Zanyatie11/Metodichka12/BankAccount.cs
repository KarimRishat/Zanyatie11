using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Metodichka12
{
    public enum AccountType { Current, Saving, IncorrectInput };
    public class BankAccount
    {

        private long number;
        private decimal balance;
        private AccountType type;
        private static long genNum = 1;
        private Queue<BankTransaction> transactions;
        public void GetInfo()
        {
            Console.WriteLine($"\nНомер счета: {number},\nТип счета: {type},\nБаланс счета: {balance}");
        }
        internal BankAccount() {  type = AccountType.Current; balance = 0; transactions = new Queue<BankTransaction>(); number = genNum++; }
        internal BankAccount(decimal sum) { type = AccountType.Current; balance = sum; transactions = new Queue<BankTransaction>(); number = genNum++; }
        internal BankAccount(int x) { type = (AccountType)x; balance = 0; transactions = new Queue<BankTransaction>(); number = genNum++; }
        internal BankAccount(int x, decimal sum) { type = (AccountType)x; balance = sum; transactions = new Queue<BankTransaction>(); number = genNum++; }
        public long Number()
        {
            return number;
        }
        public void Withdraw(decimal take)
        {
            if (balance - take < 0)
            {
                Console.WriteLine("Снять со счета эту сумму нельзя");
            }
            else
            {
                balance -= take;
                transactions.Enqueue(new BankTransaction(-take));
            }
        }
        public void AddMoney(decimal add)
        {
            balance += add;
            transactions.Enqueue(new BankTransaction(add));
        }
        public void TakeFrom(BankAccount account, decimal sum)
        {
            if (sum>account.balance)
            {
                Console.WriteLine("С этого аккаунта нельзя перевести такую сумму");
            }
            else
            {
                account.Withdraw(sum);
                AddMoney(sum);
            }
        }
        public override string ToString()
        {
            return $"Номер счета: {number},\nТип счета: {type},\nБаланс счета: {balance}\n";
        }
        
        public void Dispose(string file)
        {
            StreamWriter stream = new StreamWriter(file);
            foreach (BankTransaction item in transactions)
            {
                stream.WriteLine(item.ToString());
            }
            stream.Close();
            GC.SuppressFinalize(stream);
        }

        public override bool Equals(object obj)
        {
            return obj is BankAccount account &&
                   balance == account.balance &&
                   type == account.type;
        }

        public override int GetHashCode()
        {
            int hashCode = 1404600304;
            hashCode = hashCode * -1521134295 + balance.GetHashCode();
            hashCode = hashCode * -1521134295 + type.GetHashCode();
            return hashCode;
        }

        public static bool operator ==(BankAccount account1, BankAccount account2)
        {
            if (account1.Equals(account2) && account2.Equals(account1))
            {
                return true;
            }
            return false;
        }
        public static bool operator !=(BankAccount account1, BankAccount account2)
        {
            if (account1.Equals(account2) && account2.Equals(account2))
            {
                return false;
            }
            return true;
        }
        
    }
}
