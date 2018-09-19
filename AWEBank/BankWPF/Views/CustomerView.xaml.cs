using BankObj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BankWPF.Views
{
    /// <summary>
    /// Interaktionslogik für CustomerView.xaml
    /// </summary>
    public partial class CustomerView : UserControl
    {
        Berater newAdvisor = new Berater();
        GKBerater newGAdvisor = new GKBerater();
        Kunde newKunde = new Kunde();
        GKunde newGKunde = new GKunde();

        public CustomerView()
        {
            InitializeComponent();
        }

        //Bei Klick auf Speichern neuen Kunden bzw Geschaeftskunden anlegen
        private void CustomerCreationSaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (CustomerBusinessBox.IsChecked==true)
            {
                int cnr = 666; //naechste freie KDNR waehlen
                int cage = Convert.ToInt32(CustomerAgeBox.Text); //Falscheingaben abfangen
                bool cboni = false;
                //newGAdvisor= Berater-ID aus menu lesen, GKunde nur mit GKBerater, zuweisen
                if (CustomerBoniBox.IsChecked == true) { cboni = true; }else { cboni = false; } //Auswertung Bonitaet Checkbox

                newGKunde = new GKunde(cnr, CustomerNameBox.Text, cage, cboni, new Konto(), newGAdvisor);
                customerMessageBox.Text = newGKunde.ToString();
            }
            else
            {
                int cnr = 666; //naechste freie KDNR waehlen
                int cage = Convert.ToInt32(CustomerAgeBox.Text); //Falscheingaben abfangen
                newKunde = new Kunde(cnr, CustomerNameBox.Text, cage, new Konto(42),newAdvisor); //KontoID im Konto-Constructor automatisch
                customerMessageBox.Text = newKunde.ToString();
            }
        }
    }
}
