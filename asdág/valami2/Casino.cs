using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Casino
    {
        public int sorszam;
        public string felhasznalonev;
        public int tet;
        public int szorzo;
        public string nyertes;

        public Casino(string sorszam, string felhasznalonev, string tet, string szorzo, string nyertes)
        {
            this.sorszam = int.Parse(sorszam);
            this.felhasznalonev = Convert.ToString(felhasznalonev);
            this.tet = int.Parse(tet);
            this.szorzo = int.Parse(szorzo);
            this.nyertes = Convert.ToString(nyertes);
        }
    }
}
