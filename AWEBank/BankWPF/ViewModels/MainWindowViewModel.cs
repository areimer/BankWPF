using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using BankWPF.Views;
using System.Windows.Input;
using BankWPF.Commands;
using System.Drawing;


namespace BankWPF.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        /* MainWindow Properties */
        private UIElement _content = new MainView();
        public string Path { get; private set; }

        public ICommand ClickCustomerCreationCommand { get; set; }
        public ICommand ClickKundenUebersichtCommand { get; set; }
        public ICommand ClickBeraterCommand { get; set; }
        public ICommand ClickKundenLoginCommand { get; set; }
        public ICommand ClickBeraterUebersichtCommand { get; set; }
        public ICommand BackToMain { get; set; }

        /* Content Getter und Setter */
        public UIElement Content
        {
            get { return _content; }
            set { _content = value; OnPropertyChanged(nameof(Content)); }
        }

        /* MainWindow Konstruktor */
        public MainWindowViewModel()
        {
            ClickKundenLoginCommand = new ActionCommand(loadKundenLoginView, _ => Content is MainView);
            ClickCustomerCreationCommand = new ActionCommand(loadTeamView, _ => Content is MainView);            
            ClickKundenUebersichtCommand = new ActionCommand(loadKundenUebersichtView, _ => Content is MainView);
            ClickBeraterCommand = new ActionCommand(loadBeraterView, _ => Content is MainView);
            ClickBeraterUebersichtCommand = new ActionCommand(loadBeraterUebersichtView, _ => Content is MainView);
            BackToMain = new ActionCommand(_ => Content = new MainView(), _ => !(Content is MainView));
            Path = System.IO.Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.FullName + "\\Resources\\Background.png";
        }

        // Lädt die Kundenerstellungs-Ansicht in den Content 
        public void loadTeamView(Object param)
        {
            Content = new CustomerView();
        }      
        public void loadKundenUebersichtView(Object param)
        {
            Content = new KundenUebersichtView();
        }

        public void loadKundenLoginView(Object param)
        {
            Content = new KundenLoginView();
        }

        public void loadBeraterView(Object param)
        {
            Content = new BeraterView();
        }

        public void loadBeraterUebersichtView(Object param)
        {
            Content = new BeraterUebersichtView();
        }
    }
}