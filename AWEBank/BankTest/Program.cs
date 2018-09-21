using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankObj;

namespace BankTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //Testobjekte anlegen (Berater, Grosskundenberate, Kunde, Grosskunde)
            Berater B = new Berater(1,"SchlipsStefan","Sparkasse Kiel");
            GKBerater GKB = new GKBerater(2, "KrawattenKalle", "Sparkasse Kiel");
            Kunde K = new Kunde(1,"Testkunde",18, new Konto(1), B);
            GKunde GK = new GKunde(2, "TestGrosskunde", 19, true, new Konto(2), GKB);

            // Transaktion durchführen und Kontostand ausgeben
            K.Konto.TransaktionTaetigen("ein", 500);
            Console.WriteLine(K.Konto.Kontostand);
            //Beraternamen des Kunden K ausgeben
            Console.WriteLine(K.Berater.Name);
            //GKunde GK Kreditanfordern und ausgeben
            GK.KreditAnfordern(1000, 12,new DateTimeOffset());
            Console.WriteLine(GKB.Kredite[0]);
            //GKBerater von GK kredit genehmigen und ausgeben
            GKB.KreditVergeben(0, true);
            Console.WriteLine(GKB.Kredite[0]);
            //blablabla

            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
