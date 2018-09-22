using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankObj;
using System.Collections.ObjectModel;
using System.IO;

namespace BankWPF.ViewModels
{
    class BeraterUebersichtViewViewModel : ViewModelBase
    {
        public ObservableCollection<Mitarbeiter> BeraterListe { get; set; }
        public KundeCol KundenListe { get; set; }
        public KreditCol KreditListe { get; set; }
        private Mitarbeiter selectedBerater;
        private Kunde selectedKunde;

        /* Konstruktor */
        public BeraterUebersichtViewViewModel()
        {
            BeraterListe = LoadBeraterData();
            KundenListe = new KundeCol();
            KreditListe = new KreditCol();
            KreditListe.Add(new BankObj.Kredit(775, 500, 12, 0, new DateTime(), 0, "wartend"));
            foreach (Kunde item in LoadKundenData())
            {
                KundenListe.Add(item);
            }
            //Neuen, leeren Berater als Default setzen
            SelectedBerater = new Berater();
        }

        /* SelectedBerater Getter und Setter */
        public Mitarbeiter SelectedBerater
        {
            get { return selectedBerater; }
            set
            {
                selectedBerater = value;
                KundenListe = new KundeCol();
                // Betanke Kundenliste nur mit den kuden, die den berater auch haben.
                foreach (Kunde item in LoadKundenData())
                {
                    if (item.Berater.Mitarrbeiternummer == selectedBerater.Mitarrbeiternummer)
                    {
                        KundenListe.Add(item);
                    }
                }

                // Damit das Property den Inotify Interface shit triggert und das UI es mitkriegt
                OnPropertyChanged("KundenListe");
                OnPropertyChanged("SelectedBerater");
            }
        }

        public Kunde SelectedKunde
        {
            get { return selectedKunde; }
            set
            {
                selectedKunde = value;
                
                OnPropertyChanged("SelectedKunde");
            }
        }

        /* Returnt die Berater */
        private ObservableCollection<Mitarbeiter> LoadBeraterData()
        {
            ObservableCollection<Mitarbeiter> beraterListe = new ObservableCollection<Mitarbeiter>();
            beraterListe = ReadCSV();
            return beraterListe;
        }

        private KundeCol LoadKundenData()
        {
            KundeCol kundenListe = new KundeCol();
            kundenListe = KundenAnlegenViewViewModel.ReadCSV(BeraterListe);
            return kundenListe;
        }

        public static ObservableCollection<Mitarbeiter> ReadCSV()
        {
            ObservableCollection<Mitarbeiter> bcol = new ObservableCollection<Mitarbeiter>();
            foreach (var file in (System.IO.Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory + "daten\\berater")))
            {
                var filepath = file;
                System.IO.StreamReader reader = new System.IO.StreamReader(filepath);
                string line;
                int row = 0;
                while ((line = reader.ReadLine()) != null)
                {
                    var tester = line;
                    if (row == 0)
                    {


                        if (line.Split(';')[3] == "0" && row == 0)
                        {
                            // Normaler Dude
                            Berater br = new Berater()
                            {
                                Mitarrbeiternummer = Convert.ToInt32(line.Split(';')[0]),
                                Name = line.Split(';')[1],
                                Filiale = line.Split(';')[2],

                            };
                            bcol.Add(br);

                        }
                        else if (line.Split(';')[3] == "1" && row == 0)
                        {
                            //GKDude
                            GKBerater br = new GKBerater()
                            {
                                Mitarrbeiternummer = Convert.ToInt32(line.Split(';')[0]),
                                Name = line.Split(';')[1],
                                Filiale = line.Split(';')[2],
                                Kredite = new ObservableCollection<Kredit>()
                            };
                            bcol.Add(br);
                        }
                    }
                    else if (row > 0)
                    {
                        var test = tester;
                        (bcol.LastOrDefault() as GKBerater).Kredite.Add(new Kredit()
                        {
                            Id = Convert.ToInt32(line.Split(';')[0]),
                            Betrag = Convert.ToInt32(line.Split(';')[1]),
                            LaufzeitMonate = Convert.ToInt32(line.Split(';')[2]),
                            Zinssatz = Convert.ToInt32(line.Split(';')[3]),
                            StartDatum = new DateTime(),
                            Status = line.Split(';')[6],
                            Tilgungsrate = Convert.ToDouble(line.Split(';')[5])
                        });


                    }
                    row++;

                }
                reader.Close();
                // Hier speichern
                ;
            }
            return bcol;
        }


        public static void SaveCSV(ObservableCollection<Mitarbeiter> mcol)
        {
            foreach (Mitarbeiter item in mcol)
            {
                using (StreamWriter sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "daten\\berater\\" + item.Mitarrbeiternummer + "_t.txt"))
                {


                    if (Object.ReferenceEquals(item.GetType(), new Berater().GetType()))
                    {
                        sw.WriteLine(item.Mitarrbeiternummer + ";" + item.Name + ";" + item.Filiale + ";0");
                        
                    }
                    if (Object.ReferenceEquals(item.GetType(), new GKBerater().GetType()))
                    {
                        sw.WriteLine(item.Mitarrbeiternummer + ";" + item.Name + ";" + item.Filiale + ";0");
                        foreach (Kredit subitem in (item as GKBerater).Kredite)
                        {
                            sw.WriteLine(subitem.Betrag + ";" + subitem.Betrag + ";" + subitem.StartDatum.Year + "." + subitem.StartDatum.Month + "." + subitem.StartDatum.Day + "." + subitem.StartDatum.Hour + "." + subitem.StartDatum.Minute);

                        }
                    }
                    sw.Close();
                }
            }

        }
    }
}