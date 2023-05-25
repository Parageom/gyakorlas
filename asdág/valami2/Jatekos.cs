using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Jatekos
    {
        public int darab;
        public string jatekos;
        public int jatekosTet;

        public Jatekos(string darab, string jatekos, string jatekosTet)
        {
            this.darab = int.Parse(darab);
            this.jatekos = jatekos;
            this.jatekosTet = int.Parse(jatekosTet);
        }
    }
}
