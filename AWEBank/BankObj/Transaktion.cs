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
        long Betrag { get; set; }
        String art;
        String Art { get; set; }
        DateTimeOffset datum;
        DateTimeOffset Datum { get; set; }

        public Transaktion(long betrag, String art)
        {
            this.Betrag = betrag; // immer positiv, +/- aus Art
            this.Art = art; //ein, aus, uber
        }
    }
}
