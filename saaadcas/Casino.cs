using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gyakorlas_console
{
    internal class Casino
    {
        public int sorszam;
        public string felh_nev;
        public int tet;
        public int szorzo;
        public string eredmeny;

        public Casino(string sorszam, string felh_nev, string tet, string szorzo, string eredmeny)
        {
            this.sorszam = int.Parse(sorszam);
            this.felh_nev = felh_nev;
            this.tet =int.Parse(tet);
            this.szorzo = int.Parse( szorzo);
            this.eredmeny = eredmeny;
        }
    }
}
