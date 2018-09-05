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
            Berater B = new Berater(1,"SchlipsKalle","Sparkasse Kiel");
            Kunde K1 = new Kunde(1,"Testkunde",18, new Konto(1), B);
            K1.Konto.TransaktionTaetigen("ein", 500);
            Console.WriteLine(K1.Konto.Kontostand);
            Console.WriteLine(K1.Adv.Name);

            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
