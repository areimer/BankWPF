using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankObj
{
    public class Kredit
    {
        int id;
        public int Id { get; set; }
        long betrag;
        public long Betrag { get; set; }
        int laufzeitMonate;
        public int LaufzeitMonate { get; set; }
        double zinssatz;
        public double Zinssatz { get; set; }
        DateTimeOffset startDatum;
        public DateTimeOffset StartDatum { get; set; }
        double tilgungsrate;
        public double Tilgungsrate { get; set; }
        String status;
        public String Status {get;set;}

        public Kredit() { }
        
        public Kredit(int id, long betrag, int laufzeit, double zinssatz, DateTimeOffset start,double tilgung,String stat)
        {
            this.Id = id;
            this.Betrag = betrag;
            this.LaufzeitMonate = laufzeit;
            this.Zinssatz = zinssatz;
            this.StartDatum = start;
            this.Tilgungsrate = tilgung;
            this.status = stat;
        }
    }
}
