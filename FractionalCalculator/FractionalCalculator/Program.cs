using System;
using static System.Console;
using static FractionalCalculator.Fraction;

namespace FractionalCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo key = new ConsoleKeyInfo();
            do
            {
                WriteLine(" 1 - Calc \n 2 - Exit\n");
                key = ReadKey();

               if(key.Key == ConsoleKey.D1)
                {
                    Fraction f1 = Input();
                    Fraction f2 = Input();

                    do
                    {
                        WriteLine($"\n\n\n{!(f1)} @ {!(f2)} ");

                        WriteLine("Choose operation @:" +
                            "\n1. +\n2. -\n3. *" +
                            "\n4. /\n5. Compare\nEsc. Exit\n");
                        key =  ReadKey();
                        switch (key.Key)
                        {

                            case ConsoleKey.Escape:
                                break;
                            case ConsoleKey.D1:
                                WriteLine($"\n{!(f1)} + {!(f2)} = {!(f1+f2)}");
                                break;
                            case ConsoleKey.D2:
                                WriteLine($"\n{!(f1)} - {!(f2)} = {!(f1 - f2)}");
                                break;
                            case ConsoleKey.D3:
                                WriteLine($"\n{!(f1)} * {!(f2)} = {!(f1 * f2)}");
                                break;
                            case ConsoleKey.D4:
                                WriteLine($"\n{!(f1)} / {!(f2)} = {!(f1 / f2)}");
                                break;
                            case ConsoleKey.D5:
                                Compare(f1,f2);
                                break;
                            case ConsoleKey.Add:
                                goto case ConsoleKey.D1;
                            case ConsoleKey.Subtract:
                                goto case ConsoleKey.D2;
                            case ConsoleKey.Multiply:
                                goto case ConsoleKey.D3;
                            case ConsoleKey.Divide:
                                goto case ConsoleKey.D4;
                            default:
                                break;
                        }

                    } while (key.Key != ConsoleKey.Escape);
                }

            } while (key.Key!=ConsoleKey.D2);
        }
        private static Fraction Input()
        {
            WriteLine("\nInput numerator.");
            int.TryParse(ReadLine(), out int n);

            WriteLine("Input denumerator.");
            int.TryParse(ReadLine(), out int d);

            var f = new Fraction(n,d);
            WriteLine($"{!(f)}");
            return f;
        }
    }
}
