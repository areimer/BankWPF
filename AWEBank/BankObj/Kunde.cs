using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankObj
{
    public class Kunde
    {
        int kundennummer;
        public int Kundennummer { get; set; }
        String name;
        public String Name { get; set; }
        int alter;
        public int Alter { get; set; }
        Konto konto;
        public Konto Konto { get; set; }
        Berater berater;
        public Berater Adv { get; set; }


        public Kunde() { }

        public Kunde(int kdnr,String name,int alter, Konto k, Berater b)
        {
            this.Kundennummer = kdnr;
            this.Name = name;
            this.Alter = alter;
            this.Konto = k;
            this.Adv = b;
        }
        public Kunde(int kdnr, String name, int alter, Konto k) {
            this.Kundennummer = kdnr;
            this.Name = name;
            this.Alter = alter;
            this.Konto = k;
        }


    }

    public class GKunde:Kunde
    {
        Boolean bonitaet;
        Boolean Bonitaet { get; set; }
        List<Kredit> kredite;
        public List<Kredit> Kredite { get; set; }
        new GKBerater Adv;

        public GKunde() :base() { }

        public GKunde(int kdnr, String name, int alter,bool boni, Konto k, GKBerater b):base(kdnr, name, alter,k)
        {
            this.Bonitaet = boni;
            this.Adv = b;
        }

        public void KreditAnfordern(long betrag, int laufzeitMonate, DateTimeOffset start)
        {
            // id generieren
            int tId = 0;
            this.Adv.Kredite.Add(new Kredit(tId, betrag,0, laufzeitMonate, start,0,"wartend"));
        }
    }

}
