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
        public ICommand LoginCommand { get; private set; }
        String vorlogin;
        String nachlogin;
        Kunde kunde;
        String selectedAction;
        ObservableCollection<Kunde> kcol;
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
        public ObservableCollection<Kunde> Kcol
        {
            get { return kcol; }
            set
            {
                kcol = value;
                OnPropertyChanged("Kcol");
            }
        }
        public Kunde Kunde
        {
            get { return kunde; }
            set
            {
                kunde = value;
                OnPropertyChanged("Kunde");
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
                }
                if (SelectedAction.Contains("Auszahlen"))
                {
                    ShowActionAuszahlen = "Visible";
                    ShowActionEinzahlen = "Hidden";
                    ShowActionÜberweisen = "Hidden";
                }
                if (SelectedAction.Contains("Überweisen"))
                {
                    ShowActionAuszahlen = "Hidden";
                    ShowActionEinzahlen = "Hidden";
                    ShowActionÜberweisen = "Visible";
                }
                OnPropertyChanged("ShowActionEinzahlen");
                OnPropertyChanged("ShowActionÜberweisen");
                OnPropertyChanged("ShowActionAuszahlen");
            }
        }
       String showActionAuszahlen;
       String showActionÜberweisen;
       String showActionEinzahlen;



        public KundenLoginViewViewModel()
        {
            L_password = "";
            L_name = "";
            Vorlogin = "Visible";
            Nachlogin = "Hidden";
            ShowActionAuszahlen = "Hidden";
            ShowActionÜberweisen = "Hidden";
            ShowActionEinzahlen = "Hidden";
            Kcol = KundenAnlegenViewViewModel.ReadCSV(BeraterUebersichtViewViewModel.ReadCSV());
            Kunde = Kcol.FirstOrDefault();
            LoginCommand = new ActionCommand(OnLoginExecuted, OnLoginCanExecute);
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
