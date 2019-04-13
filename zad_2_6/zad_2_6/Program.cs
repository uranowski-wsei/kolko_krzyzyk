using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad_2_6
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            Console.Write("Podaj wartosc n: ");
            string text = Console.ReadLine();
            if (!Int32.TryParse(text, out n))
                throw new ArgumentException("n nie jest liczba całkowita");

            int silnia = Factorial(n);
            Console.WriteLine("Silnia liczby {0} wynosi {1}", n, silnia);
            Console.ReadKey();
        }

        static int Factorial(int nn)
        {
            int i = 1;
            int wynik = 1;
            while (i <= nn)
                wynik *= i++;

            return wynik;
        }
    }
}
