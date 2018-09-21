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
        ObservableCollection<Kunde> kcol;



        public KundenLoginViewViewModel()
        {
            L_password = "";
            L_name = "";
            Vorlogin = "Visible";
            Nachlogin = "Hidden";
            Kcol = KundenAnlegenViewViewModel.ReadCSV(BeraterUebersichtViewViewModel.ReadCSV());
            Kunde = Kcol.FirstOrDefault();
            LoginCommand = new ActionCommand(OnLoginExecuted, OnLoginCanExecute);
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


        public string L_password
        {
            get { return l_password; }
            set
            {
                l_password = value;
                OnPropertyChanged("L_password");
            }
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
