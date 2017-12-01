using System;
namespace FractionalCalculator
{
    class Fraction
    {
        int numerator;
        int denumerator;

        public int Numerator
        {
            get
            {
                return numerator;
            }

            private set
            {
                numerator = value;
            }
        }
        public int Denumerator
        {
            get
            {
                return denumerator;
            }

            private set
            {
                if (value > 0)
                    denumerator = value;
                else if (value < 0)
                    denumerator = -1 * value;
                else
                    denumerator = 1;
            }
        }

        public Fraction()
        {
            Numerator = 0;
            Denumerator = 1;
        }

        public Fraction(int n, int d )
        {
            Numerator = n;
            Denumerator = d;
        }

        public static Fraction operator +(Fraction f1, Fraction f2)
        {
            return new Fraction(f1.Numerator * f2.Denumerator + f2.Numerator * f1.Denumerator, f1.Denumerator * f2.Denumerator);
        }

        public static Fraction operator -(Fraction f1, Fraction f2)
        {
            return new Fraction(f1.Numerator * f2.Denumerator - f2.Numerator * f1.Denumerator, f1.Denumerator * f2.Denumerator);
        }

        public static Fraction operator *(Fraction f1, Fraction f2)
        {
            return new Fraction(f1.Numerator * f2.Numerator, f1.Denumerator * f2.Denumerator);
        }

        public static Fraction operator /(Fraction f1, Fraction f2)
        {
            return new Fraction(f1.Numerator * f2.Denumerator, f1.Denumerator * f2.Denumerator);
        }

        public static bool operator >(Fraction f1, Fraction f2)
        {
            return f1.Numerator * f2.Denumerator > f2.Numerator * f1.Denumerator;
        }

        public static bool operator <(Fraction f1, Fraction f2)
        {
            return f1.Numerator * f2.Denumerator < f2.Numerator * f1.Denumerator;
        }

        public static bool operator ==(Fraction f1, Fraction f2)
        {
            bool answer = f1.Numerator * f2.Denumerator - f1.Denumerator * f2.Numerator == 0;
            return Answer(answer);
        }

        public static bool operator !=(Fraction f1, Fraction f2)
        {
            bool answer = f1.Numerator * f2.Denumerator - f1.Denumerator * f2.Numerator != 0;
            return Answer(answer);
        }

        public static bool operator >=(Fraction f1, Fraction f2)
        {
            bool answer = f1.Numerator * f2.Denumerator - f1.Denumerator * f2.Numerator >= 0;
            return Answer(answer);
        }

        public static bool operator <=(Fraction f1, Fraction f2)
        {
            bool answer = f1.Denumerator * f2.Denumerator - f1.Denumerator * f2.Numerator <= 0;
            return Answer(answer);
        }

        private static bool Answer(bool answer)
        {
            if (answer)
            {
                return (true);
            }
            else
            {
                return (false);
            }
        }

        public static void Compare(Fraction f1, Fraction f2)
        {
            if (f1 < f2)
                Console.WriteLine($"\n {f1} < {f2}");
            else if (f2 < f1)
                Console.WriteLine($"\n {f1} > {f2}");
            else if (f2 <= f1)
                Console.WriteLine($"\n {f1} <=  {f2}");
            else if (f2 >= f1)
                Console.WriteLine($"\n {f1} >= {f2}");
            else
                Console.WriteLine($"\n {f1} = {f2}");
        }

        public override bool Equals(object obj)
        {
            var fraction = obj as Fraction;
            return fraction != null &&
                   Numerator == fraction.Numerator &&
                   Denumerator == fraction.Denumerator;
        }

        public override int GetHashCode()
        {
            var hashCode = -1534900553;
            hashCode = hashCode * -1521134295 + Numerator.GetHashCode();
            hashCode = hashCode * -1521134295 + Denumerator.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            if (numerator == denumerator)
                return $"{numerator}";
            else if (numerator == 0)
                return $"{0}";
            else if (denumerator == 1)
                return $"{numerator}";
            else
            return $"{numerator}/{denumerator}";
        }

        public static Fraction Simplify(Fraction fraction)
        {
            int a = 1; int b;
            b = Math.Abs(fraction.numerator);
            if (b > fraction.denumerator)
                  b = fraction.denumerator;

            for (int i = 2; i <= b; i++)
            {
                if (fraction.numerator % i == 0 && fraction.denumerator % i == 0)
                    a = i;
            }

            return new Fraction(fraction.Numerator / a, fraction.denumerator / a);
        }
    }
}
