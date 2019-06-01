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
            GraczLudzki gA = new GraczLudzki();
            GraczKomputerowy gB = new GraczKomputerowy();
            gA.Imie = "Uzytkownik";
            gB.Imie = "Komputer";
            gA.Znak = 'x';
            gB.zmak = 'o';
            char[,] plansza = new char[3, 3]
            {
                {'1','2','3' },
                {'4','5','6' },
                {'7','8','9' }
            };

            char[,] planszaKopia = plansza.Clone() as char[,];

            bool koniecGry = false;
            bool ruchGraczaA = true;
            for (int runda = 0; runda < plansza.Length; ++runda)
            {
                Console.Clear();
                rysujPlansze(plansza);

                if (ruchGraczaA)
                {
                    Console.WriteLine("Ruch wykonuje: " + gA.Imie);
                    koniecGry = gA.WykonajRuch(plansza, planszaKopia);
                    ruchGraczaA = false;
                }
                else
                {
                    Console.WriteLine("Ruch wykonuje: " + gB.Imie);
                    koniecGry = gB.WykonajRuch(plansza, planszaKopia);
                    ruchGraczaA = true;
                }
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
        interface IRuch
        {
            bool WykonajRuch(char[,] plansza, char[,] planszaKopia);
        }

        abstract class Gracz
        {
            public string Imie { get; set; }
            public char Znak { get; set; }

            public bool SprawdzCzyKoniecGry(char[,] plansza)
            {
                int wysokosc = plansza.GetLength(0);
                int szerokosc = plansza.GetLength(1);
                if (szerokosc != wysokosc)
                    throw new Exception("Plansza nie jest kwadratowa");

                for (int i = 0;i < wysokosc; ++i)
                {
                    int sumaWiersza = 0;
                    for (int j = 0; j < szerokosc; ++j)
                    {
                        if (plansza[i, j] == Znak)
                            ++sumaWiersza;
                    }
                    if (sumaWiersza == szerokosc)
                        return true;
                }

                for (int j = 0; j < szerokosc; ++j)
                {
                    int sumaWiersza = 0;
                    for (int j = 0; j < wysokosc; ++i)
                    {
                        if (plansza[i, j] == Znak)
                            ++sumaKolumny;
                    }
                    if (sumaKolumny == wysokosc)
                        return true;
                }

                int sumaPrzekatnejA = 0;
                int sumaPrzekatnejB = 0;
                for (int k = 0; k < szerokosc; k++)
                {
                    if (plansza[k, k] == Znak)
                        ++sumaPrzekatnejA;
                    if (plansza[k, szerokosc - 1 - k] == Znak)
                        ++sumaPrzekatnejB;
                }
                if (sumaPrzekatnejA == szerokosc || sumaPrzekatnejB == szerokosc)
                    return true;

                return false;

            }
        }

        class GraczLudzki : Gracz, IRuch
        {
            public bool WykonajRuch(char[,] plansza, char[,] planszaKopia)
            {
                return SprawdzCzyKoniecGry(plansza);
            }
        }

        class GraczKomputerowy : Gracz, IRuch
        {
            public bool WykonajRuch(char[,] plansza, char[,] planszaKopia)
            {
                return SprawdzCzyKoniecGry(plansza);
            }
        }

    }
}
