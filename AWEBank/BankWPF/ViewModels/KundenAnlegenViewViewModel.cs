using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using BankObj;
using System.Windows.Input;
using System.Windows;
using System.Collections.ObjectModel;
using System.ComponentModel.Design;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Controls;
using System.Threading;
using BankWPF.ViewModels;
using BankWPF.Commands;

namespace BankWPF.ViewModels
{
    class KundenAnlegenViewViewModel : ViewModelBase
    {
        Berater newAdvisor = new Berater();
        GKBerater newGAdvisor = new GKBerater();
        Kunde newKunde = new Kunde();
        GKunde newGKunde = new GKunde();
        Mitarbeiter n_mitarbeiter;
        Boolean gKunde;
        String n_name;
        Boolean n_gk;
        Boolean n_bon;
        string n_ergebnis;
        int n_alter;
        public ObservableCollection<Mitarbeiter> MitarbeiterListe { get; set; }
        public KundeCol KundenListe { get; set; }
        public ICommand AnlegenCommand { get; private set; }
        public Boolean GKunde {
            get { return gKunde; }
            set
            {
                
                gKunde = value;
                if (GKunde)
                {
                    MitarbeiterListe = new ObservableCollection<Mitarbeiter>();
                    foreach (Mitarbeiter item in BeraterUebersichtViewViewModel.ReadCSV().Where(x => x.IsGKB == true))
                    {
                        MitarbeiterListe.Add(item);
                    }
                    N_mitarbeiter = MitarbeiterListe.FirstOrDefault();
                    OnPropertyChanged("N_mitarbeiter");
                }
                else
                {
                    MitarbeiterListe = new ObservableCollection<Mitarbeiter>();
                    foreach (Mitarbeiter item in BeraterUebersichtViewViewModel.ReadCSV().Where(x => x.IsGKB == false))
                    {
                        MitarbeiterListe.Add(item);
                    }
                    N_mitarbeiter = MitarbeiterListe.FirstOrDefault();
                    OnPropertyChanged("N_mitarbeiter");
                }
                OnPropertyChanged("MitarbeiterListe");
                OnPropertyChanged("GKunde");
            }
        }
        public string N_ergebnis
        {
            get { return n_ergebnis; }
            set
            {
                n_ergebnis = value;
                OnPropertyChanged("N_ergebnis");
            }
        }
        public String N_name { get; set; }
        public int N_alter { get; set; }
        public Mitarbeiter N_mitarbeiter { get; set; }
        public Boolean N_gk { get; set; }
        public Boolean N_bon { get; set; }





        public KundenAnlegenViewViewModel()
        {
            MitarbeiterListe = new ObservableCollection<Mitarbeiter>();
            AnlegenCommand = new ActionCommand(OnAnlegenExecuted, OnAnlegenCanExecute);
            KundenListe = new KundeCol();
            GKunde = false;
            OnPropertyChanged("N_mitarbeiter");
            KundenListe = ReadCSV(MitarbeiterListe);
            N_ergebnis = "";
        }

        private int GetLastID(KundeCol mcol)
        {
            int temp = -1;
            foreach (Kunde item in mcol)
            {
                if (item.Kundennummer > temp)
                {
                    temp = item.Kundennummer;
                }
            }
            if (temp == -1)
            {
                return 0;
            }
            else
            {
                return temp;
            }
        }

        // Löschen Button
        private bool OnAnlegenCanExecute(object arg)
        {
            if (N_alter > 0 && N_mitarbeiter != null && N_name != "")
            {
                return true;
            }
            return false;
        }
        private void OnAnlegenExecuted(object obj)
        {
            // Button Logik
            int nextID = GetLastID(KundenListe) + 1;
            var test = N_name;
            test = N_name;


            if (!GKunde)
            {


                Kunde neuer = new Kunde()
                {
                    Alter = N_alter,
                    Name = N_name,
                    Kundennummer = nextID,
                    Konto = new Konto() { ID = nextID },
                    // Austauschen mit func
                    Berater = N_mitarbeiter
                };
                KundenListe.Add(neuer);
                N_ergebnis = neuer.ToString();
            }
            else
            {
                GKunde neuer = new GKunde()
                {
                    Alter = N_alter,
                    Name = N_name,
                    Kundennummer = nextID,
                    Konto = new Konto() { ID = nextID },
                    // Austauschen mit func
                    Berater = N_mitarbeiter
                };


                KundenListe.Add(neuer);
                N_ergebnis = neuer.ToString();
            }



            SaveCSV(KundenListe);



        }



        // Save CSV
        public static void SaveCSV(ObservableCollection<Kunde> col)
        {
            foreach (Kunde item in col)
            {
                using (StreamWriter sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "daten\\kunden\\" + item.Kundennummer + ".txt"))
                {


                    if (Object.ReferenceEquals(item.GetType(), new Kunde().GetType()))
                    {
                        sw.WriteLine(item.Kundennummer + ";" + item.Name + ";" + item.Alter + ";" + item.Berater.Name + ";0");
                        sw.WriteLine(item.Konto.ID + ";" + item.Konto.Kontostand);
                        if (item.Konto.Transaktionen != null)
                        {


                            foreach (Transaktion subitem in item.Konto.Transaktionen)
                            {
                                sw.WriteLine(subitem.Betrag + ";" + subitem.Art + ";" + subitem.Datum.Year + "." + subitem.Datum.Month + "." + subitem.Datum.Day + "." + subitem.Datum.Hour + "." + subitem.Datum.Minute);
                            }
                        }
                    }
                    if (Object.ReferenceEquals(item.GetType(), new GKunde().GetType()))
                    {
                        sw.WriteLine(item.Kundennummer + ";" + item.Name + ";" + item.Alter + ";" + item.Berater.Name + ";1");
                        sw.WriteLine(item.Konto.ID + ";" + item.Konto.Kontostand);
                        if (item.Konto.Transaktionen == null)
                        {

                        }
                        else
                        {


                            foreach (Transaktion subitem in item.Konto.Transaktionen)
                            {
                                sw.WriteLine(subitem.Betrag + ";" + subitem.Art + ";" + subitem.Datum.Year + "." + subitem.Datum.Month + "." + subitem.Datum.Day + "." + subitem.Datum.Hour + "." + subitem.Datum.Minute);

                            }
                        }
                    }
                    sw.Close();
                }
            }
        }
        // ReadCSV
        public static KundeCol ReadCSV(ObservableCollection<Mitarbeiter> mcol)
        {
            KundeCol kcol = new KundeCol();
            foreach (var file in (System.IO.Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory + "daten\\kunden")))
            {
                var filepath = file;
                System.IO.StreamReader reader = new System.IO.StreamReader(filepath);
                string line;
                int row = 0;
                bool isGK = false;
                while ((line = reader.ReadLine()) != null)
                {

                    if (row == 1 && kcol.LastOrDefault().Kundennummer == Convert.ToInt32(filepath.Split('\\').Where(x => x.Contains('.')).LastOrDefault().Split('.').FirstOrDefault()))
                    {
                        kcol.LastOrDefault().Konto.ID = kcol.LastOrDefault().Kundennummer;
                        kcol.LastOrDefault().Konto.Kontostand = (long)Convert.ToDouble(line.Split(';').LastOrDefault());


                    }
                    if (row > 1 && kcol.LastOrDefault().Kundennummer == Convert.ToInt32(filepath.Split('\\').Where(x => x.Contains('.')).LastOrDefault().Split('.').FirstOrDefault()))
                    {
                        kcol.LastOrDefault().Konto.Transaktionen.Add(new Transaktion(Convert.ToInt32(line.Split(';')[0]), line.Split(';')[1], line.Split(';')[2]));
                    }
                    if (row == 0)
                    {


                        if (line.Split(';')[4] == "0" && row == 0)
                        {
                            // Normaler Dude
                            Kunde br = new Kunde()
                            {
                                Kundennummer = Convert.ToInt32(line.Split(';')[0]),
                                Name = line.Split(';')[1],
                                Alter = Convert.ToInt32(line.Split(';')[2]),
                                Berater = mcol.Where(X => X.Name == line.Split(';')[3]).FirstOrDefault(),
                                Konto = new Konto(Convert.ToInt32(line.Split(';')[0]))

                            };
                            br.Konto.Transaktionen = new ObservableCollection<Transaktion>();
                            kcol.Add(br);

                        }
                        else if (line.Split(';')[4] == "1" && row == 0)
                        {

                            GKunde kbr = new GKunde(Convert.ToInt32(line.Split(';')[0]), line.Split(';')[1], Convert.ToInt32(line.Split(';')[2]), BeraterUebersichtViewViewModel.ReadCSV().Where(X => X.Name == line.Split(';')[3]).FirstOrDefault(), new Konto(Convert.ToInt32(line.Split(';')[0])));

                            //GKunde kbr = new GKunde()
                            //{
                            //    Kundennummer = Convert.ToInt32(line.Split(';')[0]),
                            //    Name = line.Split(';')[1],
                            //    Alter = Convert.ToInt32(line.Split(';')[2]),
                            //    Berater = mcol.Where(X => X.Name == line.Split(';')[3]).FirstOrDefault(),
                            //    Konto = new Konto(Convert.ToInt32(line.Split(';')[0])),
                                

                            //};
                            isGK = true;
                            
                            kbr.Konto.Transaktionen = new ObservableCollection<Transaktion>();

                            kcol.Add(kbr);

                        }
                    }


                    row++;

                }
                reader.Close();
                // Hier speichern
                ;
            }
            return kcol;
        }
    }
}

