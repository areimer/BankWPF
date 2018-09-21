using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

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
        Mitarbeiter berater;
        public Mitarbeiter Berater { get; set; }


        public Kunde() { }

        public Kunde(int kdnr,String name,int alter, Konto k, Berater b)
        {
            this.Kundennummer = kdnr;
            this.Name = name;
            this.Alter = alter;
            this.Konto = k;
            this.Berater = b;
        }








        










        public Kunde(int kdnr, String name, int alter, Konto k) {
            this.Kundennummer = kdnr;
            this.Name = name;
            this.Alter = alter;
            this.Konto = k;
        }

        public override String ToString()
        {
            return "Kunde " + this.Kundennummer + " " + this.Name + " beraten durch " + this.Berater.Name + "\n" + "Kontonummer " + this.Konto.ID;
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

        //GKunde fordert Kredit an und legt ihn als "wartend" bei seinem Berater ab
        public void KreditAnfordern(long betrag, int laufzeitMonate, DateTimeOffset start)
        {
            // id generieren
            int tId = 0;
            //Kredit beim zustaendigen Berater einlisten
            this.Adv.Kredite.Add(new Kredit(tId, betrag,0, laufzeitMonate, start,0,"wartend"));
        }

        public override String ToString()
        {
            return "Geschäftskunde "+this.Kundennummer+" "+this.Name+" beraten durch "+this.Berater.Name+"\n"+"Kontonummer "+this.Konto.ID;
        }
    }

}
