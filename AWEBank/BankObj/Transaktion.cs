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

        public Transaktion(long betrag, String art, string datum)
        {
            this.Betrag = betrag; // immer positiv, +/- aus Art
            this.Art = art; //ein, aus, uber
            this.Datum = new DateTimeOffset(Convert.ToInt32(datum.Split('.')[0]), Convert.ToInt32(datum.Split('.')[1]), Convert.ToInt32(datum.Split('.')[2]), Convert.ToInt32(datum.Split('.')[3]), Convert.ToInt32(datum.Split('.')[4]), 0, new TimeSpan(0));

        }
        public Transaktion()
        {

        }
    }
}
