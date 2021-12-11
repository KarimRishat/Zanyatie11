using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metodichka12
{
    class Complex
    {
        public double Real;
        public double Imaginary;
        public Complex(double real, double imaginary)
        {
            Real = real;
            Imaginary = imaginary;
        }
        public Complex()
        {
            Real = 0;
            Imaginary = 0;
        }
        public Complex(double imaginary)
        {
            Real = 0;
            Imaginary = imaginary;
        }

        public override bool Equals(object obj)
        {
            return obj is Complex complex &&
                   Real == complex.Real &&
                   Imaginary == complex.Imaginary;
        }

        public override int GetHashCode()
        {
            int hashCode = -837395861;
            hashCode = hashCode * -1521134295 + Real.GetHashCode();
            hashCode = hashCode * -1521134295 + Imaginary.GetHashCode();
            return hashCode;
        }
        public static bool operator ==(Complex x, Complex y)
        {
            return x.Real == y.Real && x.Imaginary == y.Imaginary;
        }

        public static bool operator !=(Complex x, Complex y)
        {
            return !(x.Real == y.Real && x.Imaginary == y.Imaginary);
        }
        public static Complex operator +(Complex x, Complex y)
        {
            return new Complex(x.Real + y.Real, x.Imaginary + y.Imaginary);
        }

        public static Complex operator -(Complex x, Complex y)
        {
            return new Complex(x.Real - y.Real, x.Imaginary - y.Imaginary);
        }
        public static Complex operator *(Complex x, Complex y)
        {
            return new Complex(x.Real * y.Real - x.Imaginary * y.Imaginary,
                x.Real * y.Imaginary + x.Imaginary * y.Real);
        }
        public override string ToString()
        {
            if (Imaginary == 0)
            {
                return $"{Real}";
            }
            if (Real == 0)
            {
                return $"{Imaginary}i";
            }
            if (Imaginary < 0)
            {
                return $"{Real}-{Imaginary}i";
            }
            return $"{Real}+{Imaginary}i";
        }
    }
}
