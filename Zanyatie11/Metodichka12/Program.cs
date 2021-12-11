using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metodichka12
{
    class Program
    {
        static void Main(string[] args)
        {
            //Task12.1
            BankAccount account1 = new BankAccount(0,1m);
            BankAccount account2 = new BankAccount(0, 1m);
            Console.WriteLine($"{account1}{account2}");
            Console.WriteLine("Они равны?   " + account1.Equals(account2));
            Console.WriteLine($"Они не равны? { account2 != account1}");

            //Tasl12.2

        }
    }
}
