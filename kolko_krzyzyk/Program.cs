using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kolko_krzyzyk
{
    class Program
    {
        static void Main(string[] args)
        {
            string imieGraczaA = "";
            string imieGraczaB = "";
            char znakGraczaA = 'x';
            char znakGraczaB = 'o';
            char[,] plansza = new char[3, 3]
            {
                {'1','2','3' },
                {'4','5','6' },
                {'7','8','9' }
            };

            Console.Write("Wpisz imie gracza A: ");
            imieGraczaA = Console.ReadLine();
            Console.Write("Wpisz imie gracza B: ");
            imieGraczaB = Console.ReadLine();

            bool koniecGry = false;
            while (!koniecGry)
            {
                Console.Clear();
                rysujPlansze(plansza);

                Console.ReadKey();
            }
        }

        static void rysujPlansze(char[,] plansza)
        {
            int wysokosc = plansza.GetLength(0);
            int szerokosc = plansza.GetLength(1);

            for (int i = 0; i < wysokosc; ++i)
            {
                for (int j = 0; j < szerokosc; ++j)
                    Console.Write(plansza[i, j]);
                Console.WriteLine();
            }

            
            
        }

    }
}
