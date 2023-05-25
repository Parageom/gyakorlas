using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1. Feladat
            List<Lotto> lotto_list = new List<Lotto>();
            string[] lines = File.ReadAllLines("sorsolas.txt");
            foreach (var item in lines)
            {
                string[] values = item.Split(';');
                Lotto lotto_object = new Lotto(values[0], values[1], values[2], values[3], values[4], values[5]);
                lotto_list.Add(lotto_object);
            }

            int number = 0;
            bool start = true;

            //2.Feladat
            while (start)
            {
                Console.WriteLine("Adjon meg egy számot 1-52 között: ");
                string bekert_szam = Console.ReadLine();
                if (int.TryParse(bekert_szam, out number))
                {
                    if (number > 0 && number < 53)
                    {
                        foreach (var item in lotto_list)
                        {
                            if (number == item.sorszam)
                            {
                                Console.WriteLine($"2.Feladat, a {number}. heti nyerőszámok: {item.szam1} {item.szam2} {item.szam3}  {item.szam4}  {item.szam5}");
                            }
                        }
                        start = false;
                    }
                    else
                        Console.WriteLine("A megadott szám nincs a tartományban");
                }
                else
                    Console.WriteLine("Számot adjon meg");
            }

            //3. Feladat
            List<Sorsolas> sorsolas_list = new List<Sorsolas>();
            int db = 0;
            for (int i = 1; i < 92; i++)
            {
                foreach (var item in lotto_list)
                {
                    if (i == item.szam1)
                        db++;
                    if (i == item.szam2)
                        db++;
                    if (i == item.szam3)
                        db++;
                    if (i == item.szam4)
                        db++;
                    if (i == item.szam5)
                        db++;
                }
                Sorsolas sorsolas_object = new Sorsolas(i, db);
                sorsolas_list.Add(sorsolas_object);
                db = 0;
            }

            int minDB = int.MaxValue;
            int minSzam = 0;
            foreach (var item in sorsolas_list)
            {
                if (minDB > item.db)
                {
                    minDB = item.db;
                    minSzam = item.szam;
                }

            }
            Console.WriteLine($"3.Feladat - legkevesebbszer kihúzott szám: {minDB};{minSzam} ");

            //4. Feladat
            int parosDB = 0;
            foreach (var item in sorsolas_list)
            {
                if (item.szam % 2 == 0)
                {
                    parosDB += item.db;
                }
            }

            Console.WriteLine($"4.Feladat - Hányszor húztak páros számot: {parosDB}");

            //5 - 6. Feladat
            int db5 = 0;
            int db46 = 0;

            foreach (var item in sorsolas_list)
            {
                if (item.szam == 5)
                {
                    db5 += item.db;
                }
                if (item.szam == 46)
                {
                    db46 += item.db;
                }
            }

            Console.WriteLine($"5. Feladat - Hányszor húzták ki az ötös számot: {db5}");
            Console.WriteLine($"6. Feladat - Hányszor húzták ki a 46-os számot: {db46}");

            //7. Feladat
            foreach (var item in sorsolas_list)
            {
                Console.WriteLine($"{item.szam}; {item.db}");
            }
            Console.ReadKey();

        }
    }
}
