using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankObj;

namespace BankObj
{
    public abstract class Mitarbeiter
    {
        int mitarbeiternummer;
        public int Mitarrbeiternummer { get; set; }
        String name;
        public String Name { get; set; }
        String filiale;
        public String Filiale { get; set; }


        protected Mitarbeiter(int manr, string name, string fil)
        {
            this.mitarbeiternummer = manr;
            this.name = name;
            this.filiale = fil;
        }
        public Mitarbeiter()
        {

        }



        public static MitarbeiterCol ReadCSV()
        {
            MitarbeiterCol bcol = new MitarbeiterCol();
            foreach (var file in (System.IO.Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory + "daten\\berater")))
            {
                var filepath = file;
                System.IO.StreamReader reader = new System.IO.StreamReader(filepath);
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.Split(';')[3] == "0")
                    {
                        // Normaler Dude
                        Berater br = new Berater()
                        {
                            Mitarrbeiternummer = Convert.ToInt32(line.Split(';')[0]),
                            Name = line.Split(';')[1],
                            Filiale = line.Split(';')[2],

                        };
                    }
                    else if (line.Split(';')[3] == "1")
                    {

                    }

                }
                reader.Close();
                // Hier speichern
                //bcol.Add(br);
            }
            return bcol;
        }



    }
}

