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

        public BeraterCol BeraterListe { get; set; }
        public KundeCol KundenListe { get; set; }
        private Berater selectedBerater;
        private Kunde selectedKunde;

        /* Konstruktor */
        public BeraterUebersichtViewViewModel()
        {
            BeraterListe = LoadBeraterData();
            KundenListe = new KundeCol();
            foreach (Kunde item in LoadKundenData())
            {
                KundenListe.Add(item);
            }


            // Explain this shit to me lukas

            //var types = new HashSet<string>(KundenListe.Select(aa => aa.Adv.Name));
            //if (types.Count < KundenListe.Count)
            //{
            //    // You have a duplicate...
            //    // ...not necessarily easy to know WHO is the duplicate
            //}
        }

        /* SelectedBerater Getter und Setter */
        public Berater SelectedBerater
        {
            get { return selectedBerater; }
            set
            {
                selectedBerater = value;
                this.KundenListe = new KundeCol();
                // Betanke Kundenliste nur mit den kuden, die den berater auch haben.
                foreach (Kunde item in LoadKundenData())
                {
                    if (item.Adv.Mitarrbeiternummer == selectedBerater.Mitarrbeiternummer)
                    {
                        this.KundenListe.Add(item);
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
        private BeraterCol LoadBeraterData()
        {
            BeraterCol beraterListe = new BeraterCol();

            beraterListe.Add(new Berater()
            {
                Name = "Hans Wurst",
                Mitarrbeiternummer = 1,
                Filiale = "Kiel Gaarden",
            });

            beraterListe.Add(new Berater()
            {
                Name = "Fred Feuerstein",
                Mitarrbeiternummer = 2,
                Filiale = "Kiel Elmschenhagen"
            });
            return beraterListe;
        }

        private List<Kunde> LoadKundenData()
        {
            List<Kunde> kundenListe = new List<Kunde>();

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
