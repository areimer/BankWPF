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
        public ObservableCollection<Mitarbeiter> MitarbeiterListe { get; set; }
        public KundeCol KundenListe { get; set; }
        public ICommand AnlegenCommand { get; private set; }
        Berater newAdvisor = new Berater();
        GKBerater newGAdvisor = new GKBerater();
        Kunde newKunde = new Kunde();
        GKunde newGKunde = new GKunde();





        String n_name;
        public String N_name { get; set; }
        int n_alter;
        public int N_alter { get; set; }
        Mitarbeiter n_mitarbeiter;
        public Mitarbeiter N_mitarbeiter { get; set; }
        Boolean n_gk;
        public Boolean N_gk { get; set; }
        Boolean n_bon;
        public Boolean N_bon { get; set; }
        string n_ergebnis;
       




        public  KundenAnlegenViewViewModel()
        {
            AnlegenCommand = new ActionCommand(OnAnlegenExecuted, OnAnlegenCanExecute);
            KundenListe = new KundeCol();
            MitarbeiterListe = BeraterUebersichtViewViewModel.ReadCSV();
            KundenListe = ReadCSV(MitarbeiterListe);
            N_ergebnis = "test";
            N_mitarbeiter = MitarbeiterListe.FirstOrDefault();

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
            return true;
        }
        private void OnAnlegenExecuted(object obj)
        {
            // Button Logik
            int nextID = GetLastID(KundenListe) + 1;
            var test = N_name;
            test = N_name;
            

            if (!N_gk)
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

        private void SaveCSV(KundeCol col)
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

        public string N_ergebnis
        {
            get { return n_ergebnis; }
            set
            {
                n_ergebnis = value;
                OnPropertyChanged("N_ergebnis");
            }
        }





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
                                GKunde br = new GKunde()
                                {
                                    Kundennummer = Convert.ToInt32(line.Split(';')[0]),
                                    Name = line.Split(';')[1],
                                    Alter = Convert.ToInt32(line.Split(';')[2]),
                                    Berater = mcol.Where(X => X.Name == line.Split(';')[3]).FirstOrDefault(),
                                    Konto = new Konto(Convert.ToInt32(line.Split(';')[0]))


                                };
                                isGK = true;
                                br.Konto.Transaktionen = new ObservableCollection<Transaktion>();

                                kcol.Add(br);

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

