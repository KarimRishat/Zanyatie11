using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metduchk13
{
    class Program
    {
        static void Main(string[] args)
        {
            BankAccount bankAccount = new BankAccount(1, 1m);
            bankAccount.AddMoney(12313123m);
            Console.WriteLine(bankAccount[1]);
        }
    }
}
