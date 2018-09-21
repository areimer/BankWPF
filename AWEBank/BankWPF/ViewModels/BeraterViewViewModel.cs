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
        public ICommand ClickCreateBerater { get; set; }
        private ObservableCollection<Mitarbeiter> mcol = new ObservableCollection<Mitarbeiter>();

        String n_name;
        public String N_name { get; set; }
        public String n_filiale;
        public String N_filiale { get; set; }
        public bool N_isgkb { get; set; }
        bool n_isgkb;

        public BeraterViewViewModel()
        {
            ClickCreateBerater = new ActionCommand(CreateNewBerater, OnAnlegenCanExecute);
            mcol = BeraterUebersichtViewViewModel.ReadCSV();
        }

        private bool OnAnlegenCanExecute(object arg)
        {
            return true;
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
            //Noch nicht von Otto implementiert scheiße
            //BeraterUebersichtViewViewModel.SaveCSV(mcol);
        }
    }
}
