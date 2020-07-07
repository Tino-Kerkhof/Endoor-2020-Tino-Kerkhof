using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Calculator_Part_1
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    class Fraction
    {
        private int _numerator;
        private int _denominator;

        /// <summary>Gets the numerator.</summary>
        /// <value>The numerator.</value>
        public int Numerator
        {
            get { return _numerator; }
        }

        /// <summary>Gets the denominator.</summary>
        /// <value>The denominator.</value>
        public int Denominator
        {
            get { return _denominator; }
        }

        /// <summary>Initializes a new instance of the <see cref="Fraction" /> class.</summary>
        /// <param name="numerator">The numerator.</param>
        /// <param name="denominator">The denominator.</param>
        /// <exception cref="ArgumentException">You cannot divide by zero</exception>
        public Fraction(int numerator, int denominator)
        {
            if (denominator == 0)
                throw new ArgumentException("You cannot divide by zero");

            if (denominator < 0)
            {
                numerator *= -1;
                denominator *= -1;
            }
            _numerator = numerator;
            _denominator = denominator;
        }
        /// <summary>Initializes a new instance of the <see cref="Fraction" /> class.</summary>
        /// <param name="numerator">The numerator.</param>
        public Fraction(int numerator) : this(numerator, 1)
        {

        }
        public Fraction GetNumerator(int)
        {

        }

        public Fraction GetDenominator(int)
        {

        }

        public Fraction ToString(String)
        {

        }

        public Fraction ToDouble(double)
        {

        }

        public Fraction Add(Fraction fraction)
        {

        }

        public Fraction Subtract(Fraction fraction)
        {

        }

        public Fraction Multiply(Fraction fraction)
        {
            int num = fraction.Numerator * Numerator;
            int den = fraction.Denominator * Denominator;
            return new Fraction(num, den);
        }

        public Fraction Divide(Fraction fraction)
        {

        }

        public Fraction Equals(boolean)
        {

        }

        public ToLowestTerms()
        {

        }

        public Gcd(int num, int den)
        {

        }
    }
}
