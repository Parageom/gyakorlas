using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region 1. Feladat
            //Adatok beolvasása
            List<Casino> jatekLista = new List<Casino>();

            try
            {
                string[] sor = File.ReadAllLines("nyeremenyek.txt");
                foreach (var item in sor)
                {
                    string[] ertek = item.Split(';');
                    Casino jatszmaObjektum = new Casino(ertek[0], ertek[1], ertek[2], ertek[3], ertek[4]);
                    jatekLista.Add(jatszmaObjektum);
                }
            }
            catch (IOException)
            {
                Console.WriteLine("A fájl nem található!");
                Environment.Exit(0);
            }

            #endregion

            #region 2. Feladat
            //2. Feladat - Játszma adatok bekért szám alapján
            Console.Write("Adj meg egy sorszámot 1-50-ig: ");
            string bekertSzam = Console.ReadLine();
            int bekertSorszam = 0;

            if (int.TryParse(bekertSzam, out bekertSorszam))
            {
                if (bekertSorszam > 0 && bekertSorszam <= 50)
                {
                    foreach (var item in jatekLista)
                    {
                        if (item.sorszam == bekertSorszam)
                        {
                            Console.WriteLine();
                            Console.WriteLine("2. Feladat - Játszma adatai: {0}, {1}, {2}, {3}, {4}",
                            item.sorszam, item.felhasznalonev, item.tet, item.szorzo, item.nyertes);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("A megadott érték nincs a tartományban!");
                }
            }
            else
            {
                Console.WriteLine("Nem megfelelő beviteli formátum!");
            }
            #endregion

            #region 3. Feladat
            //3. Feladat - Legtöbb játszma, összeg

            int maxJatszmak = 0;
            string legtobbJatekos = string.Empty;
            int osszKoltseg = 0;

            foreach (var item in jatekLista)
            {
                int jatekosJatszmak = 0;
                int jatekosKoltseg = 0;

                foreach (var value in jatekLista)
                {
                    if (item.felhasznalonev == value.felhasznalonev)
                    {
                        jatekosJatszmak++;
                        jatekosKoltseg += value.tet;
                    }
                }

                if (jatekosJatszmak > maxJatszmak)
                {
                    maxJatszmak = jatekosJatszmak;
                    legtobbJatekos = item.felhasznalonev;
                    osszKoltseg = jatekosKoltseg;
                }
            }
            Console.WriteLine();
            Console.WriteLine("3. Feladat: A legtöbb játszmát {0} db {1} felhasználó tette meg, összesen {2} költséggel.", maxJatszmak, legtobbJatekos, osszKoltseg);
            #endregion

            #region 4. Feladat
            //4. Feladat - nyertes játszmák száma
            int db = 0;

            foreach (var item in jatekLista)
            {
                db += (item.nyertes == "nyertes") ? 1 : 0;
            }
            Console.WriteLine();
            Console.WriteLine("4. Feladat: Nyertes játszmák száma: {0}", db);
            #endregion

            #region 5. Feladat
            //5. Feladat - Legkisebb nyeremény
            int legkisebbNyeremeny = int.MaxValue;
            Casino legkisebbNyeremenyJatszma = null;

            foreach (var item in jatekLista)
            {
                if (item.nyertes == "nyertes")
                {
                    int nyeremeny = item.tet * item.szorzo;
                    if (nyeremeny < legkisebbNyeremeny)
                    {
                        legkisebbNyeremeny = nyeremeny;
                        legkisebbNyeremenyJatszma = item;
                    }
                }
            }

            if (legkisebbNyeremenyJatszma != null)
            {
                Console.WriteLine();
                Console.WriteLine("5. Feladat: A legkisebb nyereményt adó játszma adatai: {0}, {1}, {2}, {3}, {4}",
                    legkisebbNyeremenyJatszma.sorszam, legkisebbNyeremenyJatszma.felhasznalonev, legkisebbNyeremenyJatszma.tet, legkisebbNyeremenyJatszma.szorzo, legkisebbNyeremenyJatszma.nyertes);
            }
            else
            {
                Console.WriteLine("Nincs olyan játszma, amely után nyereményt lehetett felvenni.");
            }
            #endregion

            #region 6. Feladat
            //6. Feladat - "a" betűvel kezdődő felhasználónevek
            int felhasznaloDb = 0;
            string[] nevek = new string[100];
            foreach (var item in jatekLista)
            {
                if (item.felhasznalonev.StartsWith("a"))
                {
                    felhasznaloDb++;
                    for (int i = 0; i < nevek.Length; i++)
                    {
                        if (nevek[i] == null)
                        {
                            nevek[i] = item.felhasznalonev;
                            break;
                        }
                    }
                }
            }
            Console.WriteLine();
            Console.WriteLine("6. Feladat: Összesen {0} db 'a' betűvel kezdődő felhasználónév van.", felhasznaloDb);

            foreach (var item in nevek)
            {
                if (item != null)
                {
                    Console.WriteLine(item);
                }
            }
            #endregion

            #region 7. Feladat
            //7. Feladat - Nyertes játszmák adatai
            Console.WriteLine();
            Console.WriteLine("7. Feladat");
            int jatszmaNyeremeny = 0;
            foreach (var item in jatekLista)
            {
                if (item.nyertes == "nyertes")
                {
                    jatszmaNyeremeny = item.tet * item.szorzo;
                    Console.WriteLine("{0}, {1}, {2}", item.sorszam, item.felhasznalonev, jatszmaNyeremeny);
                }
            }
            #endregion

            Console.ReadKey();
        }
    }
}
