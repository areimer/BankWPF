using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] deutsch = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n','o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',' ' };
            String[] code = new String[26];
            int[] counter = new int[27];
            int Sl = 0;
            int countSum = 0;
            String inString = "xdy ikjkahmcalyqdpecy syopechryppyhrjb dpq di wydqahqyo xyp ekimrqyop jdecq iyco agqryhh pdy dpq sdyh wr ydjzaec wr gjaegyj rjx pkido zryo xyj pdecyoyj xaqyjarpqarpec jdecq byydbjyo";
            Sl = inString.Length;
            for (int i = 0; i < 27; i++)
            {
                counter[i] = 0;
            }

            foreach (char c in inString)
            {
                if (c != ' ')
                {
                    counter[Array.IndexOf(deutsch, c)] = counter[Array.IndexOf(deutsch, c)] + 1;
                }
            }

            for (int j = 0; j < 27; j++)
            {
                countSum = countSum + counter[j];
                if (counter[j] == 0)
                {
                    Console.WriteLine(0);
                }
                else
                {
                    Console.WriteLine((Sl/100) *counter[j]);
                    Sl++;
                }
            }
            Console.WriteLine();
            Console.WriteLine(countSum);
            Console.ReadKey();


        }
    }
}
