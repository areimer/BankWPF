using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankObj
{
    public class Konto
    {
        int id;
        public int ID { get; set; }
        List<Transaktion> transaktionen;
        public List<Transaktion> Transaktionen { get; set; }
        long kontostand;
        public long Kontostand { get; set; }

        public Konto() { }

        public Konto(int id)
        {
            this.ID = id;
            this.transaktionen = new List<Transaktion>();
            this.kontostand = 0;
        }

        //Transaktion einlisten
        //erlaubte Transaktionen "ein", "aus", "uber"
        public void TransaktionTaetigen(String art, long betrag)
        {
            transaktionen.Add(new Transaktion(betrag, art));
            switch (art)
            {
                case "ein":
                    this.Kontostand = this.Kontostand + betrag;
                    break;

                case "aus":
                    this.Kontostand = this.Kontostand - betrag;
                    break;

                case "uber":
                    break;

                default:
                    break;
            }
        }
    }
}
