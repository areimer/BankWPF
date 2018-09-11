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
        public ICommand ClickTeamsCommand { get; set; }
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

            // ClickTeamsCommand = new ActionCommand(loadTeamView, _ => Content is MainView);
            ClickGroupCommand = new ActionCommand(loadKundenUebersichtView, _ => Content is MainView);
            ClickPlanCommand = new ActionCommand(loadBeraterView, _ => Content is MainView);
            ClickTipCommand = new ActionCommand(loadBeraterUebersichtView, _ => Content is MainView);
            BackToMain = new ActionCommand(_ => Content = new MainView(), _ => !(Content is MainView));

            Path = System.IO.Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.FullName + "\\Resources\\Background.png";
        }

        // Lädt die Übersicht in den Content 

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

    }
}