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
    class MainWindowViewModel : ViewModelBase
    {
        /* MainWindow Properties */
        private UIElement _content = new MainView();
        public string Path { get; private set; }
        public ICommand ClickCustomerCreationCommand { get; set; }
        public ICommand ClickKundenUebersichtCommand { get; set; }
        public ICommand ClickBeraterCommand { get; set; }
        public ICommand ClickBeraterUebersichtCommand { get; set; }
        public ICommand ClickGroupCommand { get; set; }
        public ICommand ClickPlanCommand { get; set; }
        public ICommand ClickTipCommand { get; set; }
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
            
            ClickCustomerCreationCommand = new ActionCommand(loadTeamView, _ => Content is MainView);            
            ClickKundenUebersichtCommand = new ActionCommand(loadKundenUebersichtView, _ => Content is MainView);
            ClickBeraterCommand = new ActionCommand(loadKundenUebersichtView, _ => Content is MainView);
            ClickBeraterUebersichtCommand = new ActionCommand(loadBeraterView, _ => Content is MainView);
            BackToMain = new ActionCommand(_ => Content = new MainView(), _ => !(Content is MainView));
                        /*
            ClickGroupCommand = new ActionCommand(loadGroupView, _ => Content is MainMenu);
            ClickPlanCommand = new ActionCommand(loadPlanView, _ => Content is MainMenu);
            ClickTipCommand = new ActionCommand(loadTipView, _ => Content is MainMenu);
            BackToMain = new ActionCommand(_ => Content = new MainMenu(), _ => !(Content is MainMenu));
            */            Path = System.IO.Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.FullName + "\\Resources\\Background.png";
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
     
        public void loadBeraterView(Object param)
        {
            Content = new BeraterView();
        }

        public void loadBeraterUebersichtView(Object param)
        {
            Content = new BeraterUebersichtView();
        }
                /* Lädt die Gruppenansicht in den Content 
        public void loadGroupView(Object param)
        {
            Content = new GroupView();
        }
        /* Lädt den Spielplan in den Content 
        public void loadPlanView(Object param)
        {
            Content = new PlanView();
        }
        /* Lädt den Tipper in den Content 
        public void loadTipView(Object param)
        {
            Content = new TipView();
        }
        */
    }
}