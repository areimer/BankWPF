using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankObj;

namespace BankObj
{
    public abstract class Mitarbeiter
    {
        int mitarbeiternummer;
        public int Mitarrbeiternummer { get; set; }
        String name;
        public String Name { get; set; }
        String filiale;
        public String Filiale { get; set; }



        protected Mitarbeiter(int manr, string name, string fil)
        {
            this.mitarbeiternummer = manr;
            this.name = name;
            this.filiale = fil;
        }

        public Mitarbeiter()
        {

        }
    }
}

