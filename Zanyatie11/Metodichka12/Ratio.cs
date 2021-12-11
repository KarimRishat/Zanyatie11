using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace Metodichka12
{
    class Ratio
    {
        public int numerator;
        public int denominator;
        public Ratio()
        {
            numerator = 0;
            denominator = 1;
        }
        public Ratio(int x)
        {
            numerator = 1;
            denominator = x;
        }
        public Ratio(int x, int y)
        {
            if (y==0)
            {
                throw new DivideByZeroException();
            }
            int nod = NOD(x, y);
            numerator = x / nod;
            denominator = y / nod;
        }

        public override bool Equals(object obj)
        {
            return obj is Ratio ratio &&
                   numerator == ratio.numerator &&
                   denominator == ratio.denominator;
        }

        public override int GetHashCode()
        {
            int hashCode = -671859081;
            hashCode = hashCode * -1521134295 + numerator.GetHashCode();
            hashCode = hashCode * -1521134295 + denominator.GetHashCode();
            return hashCode;
        }

        public static bool operator ==(Ratio x, Ratio y)
        {
            if (x.Equals(y) && y.Equals(x))
            {
                return true;
            }
            return false;
        }
        public static bool operator !=(Ratio x, Ratio y)
        {
            if (x.Equals(y) && y.Equals(x))
            {
                return false;
            }
            return true;
        }
        public static int NOD(int x, int y)
        {
            while (x != y)
            {
                if (x>y)
                {
                    x -= y;
                }
                else
                {
                    y -= x;
                }
            }
            return x;
        }
        public static bool operator <(Ratio x, Ratio y)
        {
            return x.numerator * y.denominator < x.denominator * y.numerator;
        }
        public static bool operator >(Ratio x, Ratio y)
        {
            return x.numerator * y.denominator > x.denominator * y.numerator;
        }
        public static bool operator <=(Ratio x, Ratio y)
        {
            return x<y || x==y;
        }
        public static bool operator >=(Ratio x, Ratio y)
        {
            return x > y || x == y;
        }
        public static Ratio operator +(Ratio x, Ratio y)
        {
            return new Ratio(x.numerator * y.denominator + y.numerator * x.denominator, y.denominator * x.denominator);
        }
        public static Ratio operator -(Ratio x, Ratio y)
        {
            return new Ratio(x.numerator * y.denominator - y.numerator * x.denominator, y.denominator * x.denominator);
        }
        public static Ratio operator --(Ratio x)
        {
            return new Ratio(x.numerator - 1, x.denominator);
        }
        public static Ratio operator ++(Ratio x)
        {
            return new Ratio(x.numerator + 1, x.denominator);
        }
        public override string ToString()
        {
            return $"{numerator}/{denominator}";
        }
        public static Ratio operator *(Ratio x, Ratio y)
        {
            return new Ratio(x.numerator * y.numerator, x.denominator * y.denominator);
        }

        public static Ratio operator /(Ratio x, Ratio y)
        {
            return new Ratio(x.numerator * y.denominator, x.denominator * y.numerator);
        }

        public static Ratio operator %(Ratio x, Ratio y)
        {
            return x - (Ratio)(int)(x / y) * y;
        }
        public static explicit operator Ratio(float x)
        {
            int factor = (int)Math.Pow(10, DecPow(x));
            return new Ratio(Convert.ToInt32(x * factor), factor);
        }
        public static int DecPow(float x)
        {
            string s = x.ToString();
            int num = s.IndexOf(',');
            if (num == -1)
            {
                return 0;
            }
            return s.Length - num - 1;
        }
        public static explicit operator Ratio(int x)
        {
            return new Ratio(x, 1);
        }
        public static explicit operator float(Ratio x)
        {
            return Convert.ToSingle(x.numerator) / x.denominator;
        }
        public static explicit operator int(Ratio x)
        {
            return x.numerator / x.denominator;
        }
    }
}
