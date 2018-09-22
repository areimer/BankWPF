using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankObj
{
    public class Transaktion
    {
        long betrag;
        public long Betrag { get; set; }
        String art;
        public String Art { get; set; }
        DateTimeOffset datum;
        public DateTimeOffset Datum { get; set; }
        String cleandate;
            public string Cleandate { get; set; }

        public Transaktion(long betrag, String art, string datum)
        {
            this.Betrag = betrag; // immer positiv, +/- aus Art
            this.Art = art; //Einzahlung, Auszahlung, Überweisung
            this.Datum = new DateTimeOffset(Convert.ToInt32(datum.Split('.')[0]), Convert.ToInt32(datum.Split('.')[1]), Convert.ToInt32(datum.Split('.')[2]), Convert.ToInt32(datum.Split('.')[3]), Convert.ToInt32(datum.Split('.')[4]), 0, new TimeSpan(0));

            // Damit die Null bei MInute aufgefüllt wrd
            if (this.Datum.Minute.ToString().Length < 2)
            {
                Cleandate = this.Datum.Year + "." + this.Datum.Month + "." + this.Datum.Day + "  " + this.Datum.Hour + ":0" + this.Datum.Minute;
            }
            else
            {
                        Cleandate = this.Datum.Year + "." + this.Datum.Month + "." + this.Datum.Day + "  " + this.Datum.Hour + ":" + this.Datum.Minute;
            }
        }
        public Transaktion(long betrag, String art)
        {
            this.Betrag = betrag; // immer positiv, +/- aus Art
            this.Art = art; //Einzahlung, Auszahlung, Überweisung
            Datum = DateTimeOffset.Now;
            if (this.Datum.Minute.ToString().Length < 2)
            {
                Cleandate = this.Datum.Year + "." + this.Datum.Month + "." + this.Datum.Day + "  " + this.Datum.Hour + ":0" + this.Datum.Minute;
            }
            else
            {
                Cleandate = this.Datum.Year + "." + this.Datum.Month + "." + this.Datum.Day + "  " + this.Datum.Hour + ":" + this.Datum.Minute;
            }
        }
    }
}
