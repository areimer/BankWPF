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

        public MitarbeiterCol BeraterListe { get; set; }
        public KundeCol KundenListe { get; set; }
        private Mitarbeiter selectedBerater;
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
        public Mitarbeiter SelectedBerater
        {
            get { return selectedBerater; }
            set
            {
                selectedBerater = value;
                this.KundenListe = new KundeCol();
                // Betanke Kundenliste nur mit den kuden, die den berater auch haben.
                foreach (Kunde item in LoadKundenData())
                {
                    if (item.Berater.Mitarrbeiternummer == selectedBerater.Mitarrbeiternummer)
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
        private MitarbeiterCol LoadBeraterData()
        {
            MitarbeiterCol beraterListe = new MitarbeiterCol();
            beraterListe = Mitarbeiter.ReadCSV();
            return beraterListe;
        }

        private KundeCol LoadKundenData()
        {
            KundeCol kundenListe = new KundeCol();
            kundenListe = Kunde.ReadCSV(BeraterListe);
            return kundenListe;
        }
    }
}
