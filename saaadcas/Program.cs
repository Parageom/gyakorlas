using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gyakorlas_console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Casino> casino_list = new List<Casino>();
            string[] lines = File.ReadAllLines("nyeremenyek.txt");
            foreach (var item in lines)
            {
                string[] values = item.Split(';');
                Casino casino_object = new Casino(values[0], values[1], values[2], values[3], values[4]);
                casino_list.Add(casino_object);
            }

            /* foreach (var item in casino_list)
             {
                 Console.WriteLine($"{item.sorszam} {item.felh_nev} {item.tet} {item.szorzo} {item.eredmeny}");
             }
            */
            //2.Feladat

            Console.WriteLine("Kérem adjon meg egy számot: ");
            string input = Console.ReadLine();
            int number = 0;
            if(int.TryParse(input, out number)) {
           
                foreach (var item in casino_list)
                {
                    if(item.sorszam == number)
                    {
                        Console.WriteLine($"{item.sorszam} {item.felh_nev} {item.tet} {item.szorzo} {item.eredmeny}");
                    }
                }
            }
           
            //3.Feladat
            Dictionary<string, int> felhasznalo = new Dictionary<string, int>();
            foreach (var item in casino_list)
            {
                if (felhasznalo.ContainsKey(item.felh_nev))
                    felhasznalo[item.felh_nev]++;
                else { felhasznalo.Add(item.felh_nev, 1); }
            }
            var legtobbetSzereploFelhasznalo = felhasznalo.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;

            Console.WriteLine($"Legtöbbet szereplő felhasználó: {legtobbetSzereploFelhasznalo}");
            int osszeg = 0;
            foreach ( var item in casino_list)
            {
                if(item.felh_nev == legtobbetSzereploFelhasznalo)
                {
                    osszeg += item.tet;
                }
            }

            Console.WriteLine($"{osszeg}");

            //4.Feladat
            int db = 0;
            foreach ( var item in casino_list)
            {
                if(item.eredmeny == "nyertes")
                {
                    db++;
                }
            }
            Console.WriteLine(db);
            //5.Feladat
            int minDB = int.MaxValue;
            var minSzam = casino_list[0];
            foreach ( var item in casino_list)
            {
                int result = item.tet * item.szorzo;
                if(item.eredmeny == "nyertes")
                {
                    if(minDB > result)
                    {
                        minDB = result;
                        minSzam = item;
                    }
                }
            }
           Console.WriteLine($"{minSzam.felh_nev}; {minDB}; {minSzam.sorszam}");

            //6.Feladat
            int a = 0;
            int kiirando = 0;

            foreach ( var item in casino_list)
            {
                if (item.felh_nev.StartsWith("t"))
                {
                    kiirando++;
                    if(kiirando <= 5)
                    {
                        Console.WriteLine(item.felh_nev);
                    }
                    a++;
                }
               
            }
            Console.WriteLine(a);
            //7.Feladat
            List <Tuple<int, string, int, int>>nyertesek = new List<Tuple<int, string, int, int>> ();
            foreach ( var item in casino_list)
            {
                if(item.eredmeny == "nyertes")
                {
                    nyertesek.Add(new Tuple <int, string, int, int>(item.sorszam, item.felh_nev, item.tet, item.szorzo));

                }
            }
            foreach (var item in nyertesek)
            {
                Console.WriteLine($"{item.Item1}; {item.Item2}; {item.Item3 * item.Item4}");
            }

           
            Console.ReadKey();
        }
    }
}
