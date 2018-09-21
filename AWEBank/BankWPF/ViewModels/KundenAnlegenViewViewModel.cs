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
        KundeCol kcol = new KundeCol();




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
            KundenListe = Kunde.ReadCSV(MitarbeiterListe);
            kcol = Kunde.ReadCSV(BeraterUebersichtViewViewModel.ReadCSV());
            N_ergebnis = "test";


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
            int nextID = GetLastID(kcol) + 1;
            var test = N_name;
            test = N_name;


            Kunde neuer = new Kunde()
            {
                Alter = N_alter,
                Name = N_name,
                Kundennummer = nextID,
                Konto = new Konto() { ID = nextID },
                // Austauschen mit func
                Berater = new Berater()
                {
                    Name="Test Ber",
                    Filiale="HH",
                    Mitarrbeiternummer=4679
                }
                
            };



            N_ergebnis = neuer.ToString();






            //if (CustomerBusinessBox.IsChecked == true)
            //{
            //    int cnr = nextID; //naechste freie KDNR waehlen
            //    int cage = Convert.ToInt32(CustomerAgeBox.Text); //Falscheingaben abfangen
            //    bool cboni = false;
            //    //newGAdvisor= Berater-ID aus menu lesen, GKunde nur mit GKBerater, zuweisen
            //    if (CustomerBoniBox.IsChecked == true) { cboni = true; } else { cboni = false; } //Auswertung Bonitaet Checkbox

            //    newGKunde = new GKunde(cnr, CustomerNameBox.Text, cage, cboni, new Konto(), newGAdvisor);
            //    customerMessageBox.Text = newGKunde.ToString();
            //}
            //else
            //{
            //    int cnr = nextID; //naechste freie KDNR waehlen
            //    int cage = Convert.ToInt32(CustomerAgeBox.Text); //Falscheingaben abfangen
            //    newKunde = new Kunde(cnr, CustomerNameBox.Text, cage, new Konto(42)); //KontoID im Konto-Constructor automatisch
            //    customerMessageBox.Text = newKunde.ToString();
            //}
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



    }
    }

