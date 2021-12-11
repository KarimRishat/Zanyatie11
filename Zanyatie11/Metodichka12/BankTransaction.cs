using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metodichka12
{
    class BankTransaction
    {
        private readonly decimal sum;
        private readonly DateTime date;
        public BankTransaction (decimal sum)
        {
            this.sum = sum;
            date = new DateTime();
            date = DateTime.Now;
        }
        public override string ToString()
        {
            return $"{date} {sum}\n";
        }
    }
}
