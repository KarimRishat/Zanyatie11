using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Metduchk13
{
    public enum AccountType { Current, Saving, IncorrectInput };
    public class BankAccount
    {

        private readonly long number;
        private decimal balance;
        private readonly AccountType type;
        private static long genNum = 1;
        private Queue<BankTransaction> transactions;
        public BankTransaction this[int index]
        {
            get 
            {
                for (int i = 0; i < index-1; i++)
                {
                    transactions.Dequeue();
                }
                return transactions.Peek(); 
            }
        }
        private string nameHolder;
        public string NameHolder { get { return nameHolder; } set { nameHolder = value; } }

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
            return $"\nНомер счета: {number},\nТип счета: {type},\nБаланс счета: {balance}";
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
    }
}
