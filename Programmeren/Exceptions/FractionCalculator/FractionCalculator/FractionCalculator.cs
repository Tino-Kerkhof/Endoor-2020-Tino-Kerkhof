using System;
using System.ComponentModel;

namespace FractionCalculator
{
    class FractionCalculator
    {
        static void Main(string[] args)
        {
            Welcome();
            string operation;
            Fraction fraction1, fraction2;

            while (true)
            {
                operation = GetOperation();
                if (operation.Equals("Q")) { Console.WriteLine("Goodbye!"); break; }
                fraction1 = GetFraction();
                fraction2 = GetFraction();

                if (operation.Equals("+"))
                {
                    Console.WriteLine("{0} + {1} = {2}", fraction1.ShowFraction(), fraction2.ShowFraction(), 
                        fraction1.Add(fraction2).ShowFraction());
                }
                else if (operation.Equals("-"))
                {
                    Console.WriteLine("{0} - {1} = {2}", fraction1.ShowFraction(), fraction2.ShowFraction(), 
                        fraction1.Subtract(fraction2).ShowFraction());
                }
                else if (operation.Equals("*"))
                {
                    Console.WriteLine("{0} * {1} = {2}", fraction1.ShowFraction(), fraction2.ShowFraction(), 
                        fraction1.Multiply(fraction2).ShowFraction());
                }
                else if (operation.Equals("/"))
                {
                    Console.WriteLine("{0} / {1} = {2}", fraction1.ShowFraction(), fraction2.ShowFraction(), 
                        fraction1.Devide(fraction2).ShowFraction());
                }
                else if (operation.Equals("="))
                {
                    Console.WriteLine("{0} = {1} = {2}", fraction1.ShowFraction(), fraction2.ShowFraction(), 
                        fraction1.Equals(fraction2));
                }
            }
        }

        public static void Welcome()
        {
            Console.WriteLine(
                "Welcome to the Fraction Calculator\n" +
                "It will add, subtract, multiply and devide fractions untill you type Q to quit.\n" +
                "Please enter your fractions in the form a/b where a and b are both intergers.\n" +
                "-------------------------------------------------------------------\n"
                );
        }

        public static string GetOperation()
        {
            string userInput;
            Console.Write("Please enter an operation (+, -, *, /, = or (Q)uit): ");
            do
            {
                userInput = Console.ReadLine();
                if (userInput.Equals("q")) { userInput = "Q"; }
                if (userInput.Equals("+") || userInput.Equals("-") || userInput.Equals("*") ||
                    userInput.Equals("/") || userInput.Equals("=") || userInput.Equals("Q"))
                {
                    return userInput;
                }
                Console.Write("Invalid input (+, -, *, /, = or (Q)uit: ");
            } while (true);
        }

        public static Fraction GetFraction()
        {
            string userInput;
            string[] userInputArray;
            bool validInput;
            int a, b;

            Console.Write("Please enter a fraction (a/b) or interger (a): ");
            do
            {
                userInput = Console.ReadLine();
                userInputArray = userInput.Split('/');
                if (userInputArray.Length == 1)
                {
                    if (Int32.TryParse(userInputArray[0], out a))
                    {
                        return new Fraction(a);
                    }
                }
                else if (userInputArray.Length == 2)
                {
                    if (Int32.TryParse(userInputArray[0], out a) &&
                        Int32.TryParse(userInputArray[1], out b) &&
                        b != 0)
                    {
                        return new Fraction(a, b);
                    }
                }
                Console.Write("Invalid input. Please enter (a/b) or (a), where a and b are intergers and b is not zero: ");
            } while (true);
        }
    }

    class Fraction
    {
        int numerator;
        int denominator;

        public Fraction(int numerator, int denominator)
        {
            if (denominator == 0)
            {
                throw new ArgumentException(string.Format("You cannot devide by zero."), "denominator");
            }

            if (denominator < 0)
            {
                this.numerator = 0 - numerator;
                this.denominator = 0 - denominator;
            }
            else
            {
                this.numerator = numerator;
                this.denominator = denominator;
            }
        }
        public Fraction(int numerator) : this(numerator, 1) { }
        public Fraction() : this(0, 1) { }

        public int GetNumerator() { return this.numerator; }
        public int GetDenominator() { return this.denominator; }
        public string ShowFraction()
        {
            if (this.denominator == 1) { return (this.numerator).ToString(); }
            return this.numerator + "/" + this.denominator;
        }

#pragma warning disable CS0114 // Member hides inherited member; missing override keyword
        public string ToString()
#pragma warning restore CS0114 // Member hides inherited member; missing override keyword
        {
            if (this.denominator == 1) { return this.numerator.ToString(); }
            else { return this.numerator.ToString() + "/" + this.denominator.ToString(); }
        }

        public double ToDouble() { return (double)this.numerator / (double)this.denominator; }

        public Fraction Add(Fraction other)
        {
            int numerator = this.numerator * other.denominator + other.numerator * this.denominator;
            int denominator = this.denominator * other.denominator;
            return new Fraction(numerator, denominator).ToLowerTerms();
        }

        public Fraction Subtract(Fraction other)
        {
            int numerator = this.numerator * other.denominator - other.numerator * this.denominator;
            int denominator = this.denominator * other.denominator;
            return new Fraction(numerator, denominator).ToLowerTerms();
        }

        public Fraction Multiply(Fraction other)
        {
            int numerator = this.numerator * other.numerator;
            int denominator = this.denominator * other.denominator;
            return new Fraction(numerator, denominator).ToLowerTerms();
        }

        public Fraction Devide(Fraction other)
        {
            if (other.numerator == 0)
            {
                throw new ArgumentException(string.Format("You cannot devide by zero."), "other.nominator");
            }
            int numerator = this.numerator * other.denominator;
            int denominator = this.denominator * other.numerator;
            return new Fraction(numerator, denominator).ToLowerTerms();
        }

        public bool Equals(Fraction other)
        {
            return (this.ToLowerTerms().numerator == other.ToLowerTerms().numerator &&
                this.ToLowerTerms().denominator == other.ToLowerTerms().denominator);
        }

        public Fraction ToLowerTerms()
        {
            int a = this.numerator;
            int b = this.denominator;
            int gcd;

            if (this.numerator < 0) { a *= -1; }
            do
            {
                gcd = Gcd(a, b);
                a /= gcd;
                b /= gcd;
            } while (gcd != 1);

            if (this.numerator < 0) { a *= -1; }
            return new Fraction(a, b);
        }
        private static int Gcd(int a, int b)
        {
            int mod;
            while (a != 0 && b != 0)
            {
                mod = a % b;
                a = b;
                b = mod;
            }
            return a;
        }
    }
}
