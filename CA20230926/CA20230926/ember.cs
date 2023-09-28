using System;
using System.Collections.Generic;
using System.Text;

namespace CA20230926
{
    class ember
    {
        public int Ora { get; set; }
        public int Perc { get; set; }
        public int AdasDB { get; set; }
        public string Nev { get; set; }
        public int Atvaltott { get; set; }

        public ember(string sor)
        {
            var atmeneti = sor.Split(';');
            Ora = int.Parse(atmeneti[0]);
            Perc = int.Parse(atmeneti[1]);
            AdasDB = int.Parse(atmeneti[2]);
            Nev = atmeneti[3];
        }
    }
}
