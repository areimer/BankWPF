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
<<<<<<< HEAD
        {

            // ClickTeamsCommand = new ActionCommand(loadTeamView, _ => Content is MainView);
            ClickGroupCommand = new ActionCommand(loadKundenUebersichtView, _ => Content is MainView);
            ClickPlanCommand = new ActionCommand(loadBeraterView, _ => Content is MainView);
            ClickTipCommand = new ActionCommand(loadBeraterUebersichtView, _ => Content is MainView);
            BackToMain = new ActionCommand(_ => Content = new MainView(), _ => !(Content is MainView));

            Path = System.IO.Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.FullName + "\\Resources\\Background.png";
        }

        // Lädt die Übersicht in den Content 

        public void loadKundenUebersichtView(Object param)
=======
        {      
            
            ClickCustomerCreationCommand = new ActionCommand(loadTeamView, _ => Content is MainView);
            /*
            ClickGroupCommand = new ActionCommand(loadGroupView, _ => Content is MainMenu);
            ClickPlanCommand = new ActionCommand(loadPlanView, _ => Content is MainMenu);
            ClickTipCommand = new ActionCommand(loadTipView, _ => Content is MainMenu);
            BackToMain = new ActionCommand(_ => Content = new MainMenu(), _ => !(Content is MainMenu));
            */
            Path = System.IO.Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.FullName + "\\Resources\\Background.png";
        }

        // Lädt die Kundenerstellungs-Ansicht in den Content 
        public void loadTeamView(Object param)
        {
            Content = new CustomerView();
        }
        /* Lädt die Gruppenansicht in den Content 
        public void loadGroupView(Object param)
>>>>>>> b5e93b5bd53464a07a1d43ee7eaeab4223240ed9
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

    }
}