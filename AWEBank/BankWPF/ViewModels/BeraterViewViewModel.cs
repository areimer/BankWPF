using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankObj;
using System.Collections.ObjectModel;
using BankWPF.Commands;
using System.Windows.Input;
using System.Windows;

namespace BankWPF.ViewModels
{
    class BeraterViewViewModel : ViewModelBase
    {
        private ObservableCollection<Mitarbeiter> mcol = new ObservableCollection<Mitarbeiter>();
        String n_name;
        bool n_isgkb;
        public String N_name { get; set; }
        public String N_filiale { get; set; }
        public bool N_isgkb { get; set; }
        public ICommand ClickCreateBerater { get; set; }


        public BeraterViewViewModel()
        {
            ClickCreateBerater = new ActionCommand(CreateNewBerater, OnAnlegenCanExecute);
            mcol = BeraterUebersichtViewViewModel.ReadCSV();
        }

        private int GetLastID(ObservableCollection<Mitarbeiter> mcol)
        {
            int temp = -1;
            foreach (Mitarbeiter item in mcol)
            {
                if (item.Mitarrbeiternummer > temp)
                {
                    temp = item.Mitarrbeiternummer;
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


        // Anlegen BUtton
        private bool OnAnlegenCanExecute(object arg)
        {
            if (N_filiale != "" && N_name != null)
            {
                return true;
            }
            return false;
        }
        private void CreateNewBerater(object obj)
        {
            // Button Logik
            int nextID = GetLastID(mcol) + 1;
            var test = N_name;

            if (N_isgkb)
            {
                Mitarbeiter neuerGkb = new GKBerater()
                {
                    Name = N_name,
                    Filiale = N_filiale,
                    Mitarrbeiternummer = nextID,
                    IsGKB = true,
                };
                mcol.Add(neuerGkb);

            }
            else
            {

                Mitarbeiter neuerB = new Berater()
                {
                    Name = N_name,
                    Filiale = N_filiale,
                    Mitarrbeiternummer = nextID,
                    IsGKB = false,
                };
                mcol.Add(neuerB);
            }
            N_name = "";
            N_filiale = "";
            N_isgkb = false;
            OnPropertyChanged("N_name");
            OnPropertyChanged("n_filiale");
            OnPropertyChanged("N_isgkb");
            BeraterUebersichtViewViewModel.SaveCSV(mcol);
        }
    }
}
