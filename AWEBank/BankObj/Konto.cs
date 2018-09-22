using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;


namespace BankObj
{
    public class Konto
    {
        int id;
        public int ID { get; set; }
        List<Transaktion> transaktionen;
        public ObservableCollection<Transaktion> Transaktionen { get; set; }
        long kontostand;
        public long Kontostand { get; set; }

        public Konto()
        {
            this.Transaktionen = new ObservableCollection<Transaktion>();
            this.kontostand = 0;
        }

        public Konto(int id)
        {
            this.ID = id;
            this.Transaktionen = new ObservableCollection<Transaktion>();
            this.kontostand = 0;
        }

        //Transaktion einlisten
        //erlaubte Transaktionen "ein", "aus", "uber"
        public void TransaktionTaetigen(String art, long betrag)
        {
            transaktionen.Add(new Transaktion(betrag, art,"2018.2.3.1.2"));
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
