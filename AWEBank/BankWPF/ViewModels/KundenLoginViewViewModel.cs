using BankWPF.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using BankWPF.Views;
using BankObj;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace BankWPF.ViewModels
{
    class KundenLoginViewViewModel : ViewModelBase
    {
        String l_name;
        String l_password;
        String vorlogin;
        String nachlogin;
        public Kunde Kunde
        {
            get { return kunde; }
            set
            {
                kunde = value;
                OnPropertyChanged("Kunde");
            }
        }
        Kunde kunde;
        public ObservableCollection<Kunde> Kcol
        {
            get { return kcol; }
            set
            {
                kcol = value;
                OnPropertyChanged("Kcol");
            }
        }
        ObservableCollection<Kunde> kcol;
        ObservableCollection<Mitarbeiter> mcol;
        public string L_password
        {
            get { return l_password; }
            set
            {
                l_password = value;
                OnPropertyChanged("L_password");
            }
        }
        public string L_name
        {
            get { return l_name; }
            set
            {
                l_name = value;
                OnPropertyChanged("L_name");
            }
        }
        public String Vorlogin
        {
            get { return vorlogin; }
            set
            {
                vorlogin = value;
                OnPropertyChanged("Vorlogin");
            }
        }
        public String Nachlogin
        {
            get { return nachlogin; }
            set
            {
                nachlogin = value;
                OnPropertyChanged("Nachlogin");
            }
        }
        public String ShowActionAuszahlen
        {
            get { return showActionAuszahlen; }
            set
            {
                showActionAuszahlen = value;
                OnPropertyChanged("ShowActionAuszahlen");
            }
        }
        public String ShowActionEinzahlen
        {
            get { return showActionEinzahlen; }
            set
            {
                showActionEinzahlen = value;
                OnPropertyChanged("ShowActionEinzahlen");
            }
        }
        public String ShowActionÜberweisen
        {
            get { return showActionÜberweisen; }
            set
            {
                showActionÜberweisen = value;
                OnPropertyChanged("ShowActionÜberweisen");
            }
        }
        public String ShowActionKreditBeantragen
        {
            get { return showActionKreditBeantragen; }
            set
            {
                showActionKreditBeantragen = value;
                OnPropertyChanged("ShowActionKreditBeantragen");
            }
        }
        public String ShowActionKreditBeantragenGehtNicht
        {
            get { return showActionKreditBeantragenGehtNicht; }
            set
            {
                showActionKreditBeantragenGehtNicht = value;
                OnPropertyChanged("ShowActionKreditBeantragenGehtNicht");
            }
        }
        public String SelectedAction
        {
            get { return selectedAction; }
            set
            {
                selectedAction = value;
                OnPropertyChanged("SelectedAction");
                if (SelectedAction.Contains("Einzahlen"))
                {
                    ShowActionAuszahlen = "Hidden";
                    ShowActionEinzahlen = "Visible";
                    ShowActionÜberweisen = "Hidden";
                    ShowActionKreditBeantragen = "Hidden";
                    ShowActionKreditBeantragenGehtNicht = "Hidden";
                }
                if (SelectedAction.Contains("Auszahlen"))
                {
                    ShowActionAuszahlen = "Visible";
                    ShowActionEinzahlen = "Hidden";
                    ShowActionÜberweisen = "Hidden";
                    ShowActionKreditBeantragen = "Hidden";
                    ShowActionKreditBeantragenGehtNicht = "Hidden";
                }
                if (SelectedAction.Contains("Überweisen"))
                {
                    ShowActionAuszahlen = "Hidden";
                    ShowActionEinzahlen = "Hidden";
                    ShowActionÜberweisen = "Visible";
                    ShowActionKreditBeantragen = "Hidden";
                    ShowActionKreditBeantragenGehtNicht = "Hidden";
                }
                if (SelectedAction.Contains("Kredit") && Kunde.Berater.IsGKB)
                {
                    ShowActionAuszahlen = "Hidden";
                    ShowActionEinzahlen = "Hidden";
                    ShowActionÜberweisen = "Hidden";
                    ShowActionKreditBeantragen = "Visible";
                    ShowActionKreditBeantragenGehtNicht = "Hidden";
                }
                if (SelectedAction.Contains("Kredit") && !Kunde.Berater.IsGKB)
                {
                    ShowActionAuszahlen = "Hidden";
                    ShowActionEinzahlen = "Hidden";
                    ShowActionÜberweisen = "Hidden";
                    ShowActionKreditBeantragen = "Hidden";
                    ShowActionKreditBeantragenGehtNicht = "Visible";
                }
                OnPropertyChanged("ShowActionEinzahlen");
                OnPropertyChanged("ShowActionÜberweisen");
                OnPropertyChanged("ShowActionAuszahlen");
                OnPropertyChanged("ShowActionKreditBeantragen");
            }
        }
        public String SelectedEinzahlenBetrag
        {
            get { return selectedEinzahlenBetrag; }
            set
            {
                selectedEinzahlenBetrag = value;
                OnPropertyChanged("SelectedEinzahlenBetrag");
            }
        }
        public String SelectedAuszahlenBetrag
        {
            get { return selectedAuszahlenBetrag; }
            set
            {
                selectedAuszahlenBetrag = value;
                OnPropertyChanged("SelectedAuszahlenBetrag");
            }
        }
        public Double SelectedÜberweisenBetrag
        {
            get { return selectedÜberweisenBetrag; }
            set
            {
                selectedÜberweisenBetrag = value;
                OnPropertyChanged("SelectedÜberweisenBetrag");
            }
        }
        public String SelectedÜberweisenEmpfänger
        {
            get { return selectedÜberweisenEmpfänger; }
            set
            {
                selectedÜberweisenEmpfänger = value;
                OnPropertyChanged("SelectedÜberweisenEmpfänger");
            }
        }
        public int SelectedKreditBetrag
        {
            get { return selectedKreditBetrag; }
            set
            {
                selectedKreditBetrag = value;
                OnPropertyChanged("SelectedKreditBetrag");
                SelectedKreditLaufzeit = SelectedKreditLaufzeit;
            }
        }
        public int SelectedKreditLaufzeit
        {
            get { return selectedKreditLaufzeit; }
            set
            {
                selectedKreditLaufzeit = value;
                SelectedKreditZinzsatz = 6;
                if (SelectedKreditLaufzeit > 5)
                {
                    SelectedKreditZinzsatz = 8;
                }
                if (SelectedKreditLaufzeit > 11)
                {
                    SelectedKreditZinzsatz = 10;
                }
                if (SelectedKreditLaufzeit > 23)
                {
                    SelectedKreditZinzsatz = 12;
                }
                if (SelectedKreditLaufzeit > 47)
                {
                    SelectedKreditZinzsatz = 14;
                }
                OnPropertyChanged("SelectedKreditZinzsatz");
                OnPropertyChanged("SelectedKreditLaufzeit");
            }
        }
        public Double SelectedKreditTilgungsrate
        {
            get { return selectedKreditTilgungsrate; }
            set
            {
                selectedKreditTilgungsrate = value;
                OnPropertyChanged("SelectedKreditTilgungsrate");
            }
        }
        public int SelectedKreditZinzsatz
        {
            get { return selectedKreditZinzsatz; }
            set
            {
                selectedKreditZinzsatz = value;
                SelectedKreditTilgungsrate = ((SelectedKreditBetrag * (1 + (Convert.ToDouble(SelectedKreditZinzsatz) / 100))) / SelectedKreditLaufzeit);
                OnPropertyChanged("SelectedKreditZinzsatz");
                OnPropertyChanged("SelectedKreditTilgungsrate");
            }
        }
        String showActionAuszahlen;
        String showActionÜberweisen;
        String showActionEinzahlen;
        String showActionKreditBeantragen;
        String showActionKreditBeantragenGehtNicht;
        String selectedAction;
        String selectedEinzahlenBetrag;
        String selectedAuszahlenBetrag;
        Double selectedÜberweisenBetrag;
        String selectedÜberweisenEmpfänger;
        int selectedKreditBetrag;
        int selectedKreditLaufzeit;
        Double selectedKreditTilgungsrate;
        int selectedKreditZinzsatz;
        public ICommand LoginCommand { get; private set; }
        public ICommand ActionCommandEinzahlen { get; set; }
        public ICommand ActionCommandAuszahlen { get; set; }
        public ICommand ActionCommandÜberweisen { get; set; }
        public ICommand ActionCommandKreditBeantragen { get; set; }

        public KundenLoginViewViewModel()
        {
            mcol = BeraterUebersichtViewViewModel.ReadCSV();
            Kcol = KundenAnlegenViewViewModel.ReadCSV(mcol);
            Kunde = Kcol.FirstOrDefault();
            ActionCommandÜberweisen = new ActionCommand(OnÜberweisenExecute, OnÜberweisenCanExecute);
            ActionCommandAuszahlen = new ActionCommand(OnAuszahlenExecute, OnAuszahlenCanExecute);
            ActionCommandEinzahlen = new ActionCommand(OnEinzahlenExecute, OnEinzahlenCanExecute);
            ActionCommandKreditBeantragen = new ActionCommand(OnKreditBeantrageExecute, OnKreditBeantragenCanExecute);
            LoginCommand = new ActionCommand(OnLoginExecuted, OnLoginCanExecute);
            L_password = "1234";
            L_name = "Otto Herrmann";
            Vorlogin = "Visible";
            Nachlogin = "Hidden";
            ShowActionAuszahlen = "Hidden";
            ShowActionÜberweisen = "Hidden";
            ShowActionEinzahlen = "Hidden";
            ShowActionKreditBeantragenGehtNicht = "Hidden";
            showActionKreditBeantragen = "Hidden";
            SelectedKreditBetrag = 500;
            SelectedKreditLaufzeit = 12;
        }



        // KreditBeantragen Button
        private bool OnKreditBeantragenCanExecute(object arg)
        {
            foreach (Mitarbeiter item in mcol)
            {
                if (Object.ReferenceEquals(item.GetType(), new GKBerater().GetType()))
                {
                    if (((GKBerater)item).Kredite.Count(x => x.Id == Kunde.Kundennummer && x.Status == "wartend") > 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        private void OnKreditBeantrageExecute(object obj)
        {
            GKBerater SollteEinGKBeraterSein = (GKBerater)mcol.Where(y => y.Mitarrbeiternummer == Kunde.Berater.Mitarrbeiternummer).First();
            SollteEinGKBeraterSein.Kredite.Add(new Kredit(Kunde.Kundennummer, SelectedKreditBetrag, SelectedKreditLaufzeit, SelectedKreditZinzsatz, DateTime.Now, SelectedKreditTilgungsrate, "wartend"));
            OnPropertyChanged("Kunde");
            KundenAnlegenViewViewModel.SaveCSV(kcol);
            BeraterUebersichtViewViewModel.SaveCSV(mcol);
        }
        // Überweisen Button
        private bool OnÜberweisenCanExecute(object arg)
        {
            //foreach (Mitarbeiter item in mcol)
            //{
            //   if (Object.ReferenceEquals(item.GetType(), new GKBerater().GetType()))
            //   {
            //        if (((GKBerater)item).Kredite.Count(x => x.Id == Kunde.Kundennummer && x.Status == "wartend") > 0)
            //        {
            //            return false;
            //        }
            //   }
            //}
            if (selectedÜberweisenEmpfänger == null || SelectedÜberweisenBetrag < 0)
            {
                return false;
            }
            if (Kunde.Konto.Kontostand >= Convert.ToDouble(SelectedÜberweisenBetrag))
            {
                if (kcol.Count(x => x.Name == SelectedÜberweisenEmpfänger) > 0)
                {
                    return true;
                }
            }

            return false;
        }
        private void OnÜberweisenExecute(object obj)
        {
            Transaktion trans = new Transaktion(Convert.ToInt64(SelectedÜberweisenBetrag), "Überwiesen");
            Transaktion trans_empf = new Transaktion(Convert.ToInt64(SelectedÜberweisenBetrag), "Überwiesen");
            Kunde.Konto.Transaktionen.Add(trans);
            Kcol.Where(x => x.Name == selectedÜberweisenEmpfänger).FirstOrDefault().Konto.Transaktionen.Add(trans_empf);
            Kcol.Where(x => x.Name == selectedÜberweisenEmpfänger).FirstOrDefault().Konto.Kontostand += Convert.ToInt64(SelectedÜberweisenBetrag);
            Kunde.Konto.Kontostand -= Convert.ToInt64(SelectedÜberweisenBetrag);
            OnPropertyChanged("Kunde");
            KundenAnlegenViewViewModel.SaveCSV(kcol);
        }
        // Auszahlen Button
        private bool OnAuszahlenCanExecute(object arg)
        {
            //foreach (Mitarbeiter item in mcol)
            //{
            //   if (Object.ReferenceEquals(item.GetType(), new GKBerater().GetType()))
            //   {
            //        if (((GKBerater)item).Kredite.Count(x => x.Id == Kunde.Kundennummer && x.Status == "wartend") > 0)
            //        {
            //            return false;
            //        }
            //   }
            //}
            if (Kunde.Konto.Kontostand >= Convert.ToInt32(SelectedAuszahlenBetrag.Split(':')[1]))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void OnAuszahlenExecute(object obj)
        {
            Transaktion trans = new Transaktion(Convert.ToInt64(SelectedAuszahlenBetrag.Split(':')[1]), "Ausgezahlt");
            Kunde.Konto.Transaktionen.Add(trans);
            Kunde.Konto.Kontostand -= Convert.ToInt64(SelectedAuszahlenBetrag.Split(':')[1]);
            OnPropertyChanged("Kunde");
            KundenAnlegenViewViewModel.SaveCSV(kcol);
        }
        // Einzahlen Button
        private bool OnEinzahlenCanExecute(object arg)
        {
            return true;
        }
        private void OnEinzahlenExecute(object obj)
        {
            Transaktion trans = new Transaktion(Convert.ToInt64(SelectedEinzahlenBetrag.Split(':')[1]), "Eingezahlt");
            Kunde.Konto.Transaktionen.Add(trans);
            Kunde.Konto.Kontostand += Convert.ToInt64(SelectedEinzahlenBetrag.Split(':')[1]);
            OnPropertyChanged("Kunde");
            KundenAnlegenViewViewModel.SaveCSV(kcol);
        }
        // Löschen Button
        private bool OnLoginCanExecute(object arg)
        {
            if (l_name == "" || l_password == "") { return false; } else { return true; }
        }
        private void OnLoginExecuted(object obj)
        {
            Kcol = KundenAnlegenViewViewModel.ReadCSV(BeraterUebersichtViewViewModel.ReadCSV());
            if (Kcol.Where(x => x.Name == l_name).Count() == 0)
            {

            }
            else
            {
                Kunde = Kcol.Where(x => x.Name == l_name).FirstOrDefault();
                Vorlogin = "Hidden";
                OnPropertyChanged("Vorlogin");
                Nachlogin = "Visible";
                OnPropertyChanged("Nachlogin");
            }
        }
    }
}
