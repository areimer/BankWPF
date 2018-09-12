using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankObj;

namespace BankObj
{
    public class Berater
    {
        int mitarbeiternummer;
        public int Mitarrbeiternummer { get; set; }
        String name;
        public String Name { get; set; }
        String filiale;
        public String Filiale { get; set; }

        public Berater() { }
        
        public Berater(int manr, String name, String fil)
        {
            this.Mitarrbeiternummer = manr;
            this.Name = name;
            this.Filiale = fil;
        }

    }

    public class GKBerater : Berater
    {
        List<Kredit> kredite;
        public List<Kredit> Kredite { get; set; }
        
        public GKBerater() :base()  { }

        public GKBerater(int manr, String name, String fil) : base(manr,name,fil) {
            this.Kredite = new List<Kredit>();
        }

        public void KreditVergeben(int kreditId, Boolean genehmigt)
        {
            //finde Kredit in Kreditliste mit id=kredit.id
            // lege Zinssatz fest
            double zins=0.2;
            //lege Tilgung fest
            double tilgung=20.5;
                for (int i = 0; i < this.Kredite.Count(); i++)
                {
                if (Kredite[i].Id == kreditId)
                {
                    if (genehmigt)
                    {
                        Kredite[i].Status = "genehmigt";
                        Kredite[i].Zinssatz = zins;
                        Kredite[i].Tilgungsrate = tilgung;
                    }
                    else
                    {
                        Kredite[i].Status = "abgelehnt";
                    }
                }
                }
        }

    }
}
