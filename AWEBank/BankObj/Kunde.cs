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
            //this.Adv = b;
        }








        public static KundeCol ReadCSV(ObservableCollection<Mitarbeiter> mcol)
        {
            KundeCol kcol = new KundeCol();
            foreach (var file in (System.IO.Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory + "daten\\kunden")))
            {
                var filepath = file;
                System.IO.StreamReader reader = new System.IO.StreamReader(filepath);
                string line;
                int row = 0;
                while ((line = reader.ReadLine()) != null)
                {
                    if (row > 0) { continue; }
                    if (line.Split(';')[4] == "0" && row == 0)
                    {
                        // Normaler Dude
                        Kunde br = new Kunde()
                        {
                            Kundennummer = Convert.ToInt32(line.Split(';')[0]),
                            Name = line.Split(';')[1],
                            Alter = Convert.ToInt32(line.Split(';')[2]),
                            Berater = mcol.Where(X => X.Name == line.Split(';')[3]).FirstOrDefault(),
                            Konto = new Konto(Convert.ToInt32(line.Split(';')[0]))

                        };
                        kcol.Add(br);
                        row++;
                    }
                    else if (line.Split(';')[4] == "1" && row == 0)
                    {
                        GKunde br = new GKunde()
                        {
                            Kundennummer = Convert.ToInt32(line.Split(';')[0]),
                            Name = line.Split(';')[1],
                            Alter = Convert.ToInt32(line.Split(';')[2]),
                            Berater = mcol.Where(X => X.Name == line.Split(';')[3]).FirstOrDefault(),
                            Konto = new Konto(Convert.ToInt32(line.Split(';')[0]))


                        };
                        kcol.Add(br);
                        row++;
                    }

                }
                reader.Close();
                // Hier speichern
                ;
            }
            return kcol;
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
