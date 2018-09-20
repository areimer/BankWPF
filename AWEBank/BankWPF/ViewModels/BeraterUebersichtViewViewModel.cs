using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankObj;
using System.Collections.ObjectModel;

namespace BankWPF.ViewModels
{
    class BeraterUebersichtViewViewModel : ViewModelBase
    {

        public ObservableCollection<Berater> BeraterListe { get; set; }
        public ObservableCollection<Kunde> KundenListe { get; set; }
        private Berater selectedBerater;
        private Kunde selectedKunde;

        /* Konstruktor */
        public BeraterUebersichtViewViewModel()
        {
            BeraterListe = LoadBeraterData();
            KundenListe = LoadKundenData();
        }

        /* SelectedBerater Getter und Setter */
        public Berater SelectedBerater
        {
            get { return selectedBerater; }
            set
            {
                selectedBerater = value;
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
        private ObservableCollection<Berater> LoadBeraterData()
        {
            ObservableCollection<Berater> beraterListe = new ObservableCollection<Berater>();

            beraterListe.Add(new Berater()
            {
                Name = "Hans Wurst",
                Mitarbeiternummer = 1,
                Filiale = "Kiel Gaarden",
            });

            beraterListe.Add(new Berater()
            {
                Name = "Fred Feuerstein",
                Mitarbeiternummer = 2,
                Filiale = "Kiel Elmschenhagen"
            });
            return beraterListe;
        }

        private ObservableCollection<Kunde> LoadKundenData()
        {
            ObservableCollection<Kunde> kundenListe = new ObservableCollection<Kunde>();

            kundenListe.Add(new Kunde()
            {
                Kundennummer = 1,
                Name = "Max Mustermann",
                Alter = 22,
                Konto = new Konto(),
                Adv = BeraterListe[0]
            });

            kundenListe.Add(new Kunde()
            {
                Kundennummer = 2,
                Name = "Hans Kackwurst",
                Alter = 47,
                Konto = new Konto(),
                Adv = BeraterListe[1]
            });

            kundenListe.Add(new Kunde()
            {
                Kundennummer = 3,
                Name = "Klaus Kleber",
                Alter = 34,
                Konto = new Konto(),
                Adv = BeraterListe[0]
            });

            kundenListe.Add(new Kunde()
            {
                Kundennummer = 4,
                Name = "Josef Stalin",
                Alter = 139,
                Konto = new Konto(),
                Adv = BeraterListe[0]
            });

            return kundenListe;
        }
    }
}
