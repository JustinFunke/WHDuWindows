using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WHDuWindows
{
    /// <summary>
    /// Interaktionslogik für ErstellenSerie.xaml
    /// </summary>
    public partial class ErstellenSerie : Window
    {
        BitmapImage sternLeer;
        BitmapImage sternVoll;
        int sterne = 0;
        int datum = 0;
        int fertig = 0;
        string user;
        DatenbankMedien db = new DatenbankMedien();
        private Datensaetze satz;

        public ErstellenSerie()
        {
            InitializeComponent();
        }
        public void setUser(string user)
        {
            this.user = user;
        }
        public void setDatensatz(Datensaetze satz)
        {
            this.satz = satz;
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void cmdClose_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
            Close();
        }

        private void Stern1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Stern1.Source = sternVoll;
            Stern2.Source = sternLeer;
            Stern3.Source = sternLeer;
            Stern4.Source = sternLeer;
            Stern5.Source = sternLeer;
            sterne = 1;
        }

        private void Stern2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Stern1.Source = sternVoll;
            Stern2.Source = sternVoll;
            Stern3.Source = sternLeer;
            Stern4.Source = sternLeer;
            Stern5.Source = sternLeer;
            sterne = 2;
        }

        private void Stern3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Stern1.Source = sternVoll;
            Stern2.Source = sternVoll;
            Stern3.Source = sternVoll;
            Stern4.Source = sternLeer;
            Stern5.Source = sternLeer;
            sterne = 3;
        }

        private void Stern4_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Stern1.Source = sternVoll;
            Stern2.Source = sternVoll;
            Stern3.Source = sternVoll;
            Stern4.Source = sternVoll;
            Stern5.Source = sternLeer;
            sterne = 4;
        }

        private void Stern5_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Stern1.Source = sternVoll;
            Stern2.Source = sternVoll;
            Stern3.Source = sternVoll;
            Stern4.Source = sternVoll;
            Stern5.Source = sternVoll;
            sterne = 5;
        }

        private void cmdHinzufuegen_Click(object sender, RoutedEventArgs e)
        {
            
            
            if (txtTitel.Text.Equals("") )
            {
                MessageBox.Show("Sie müssen den Titel ausfüllen");
                return;
            }
            if (!(txtDatum.Text.Equals("")))
                datum = Int32.Parse(txtDatum.Text);
            if (chkCheckBox.IsChecked == true)
            {
                fertig = 1;
            }
            if (cBoxAnbieter.SelectedItem == null)
            {
                MessageBox.Show("Sie müssen einem Anbieter auswählen");
                return;
            }

            Serie serie = new Serie(txtTitel.Text, Int32.Parse(txtFolge.Text), Int32.Parse(txtStaffel.Text), sterne, datum, cBoxAnbieter.Text,fertig);            
            db.SerieHinzufuegen(serie,user);

            fertig = 0;
            datum = 0;
            
            txtDatum.Text = "";
            txtFolge.Text = "";
            txtStaffel.Text = "";
            txtTitel.Text = "";
            sterne = 0;
            Stern1.Source = sternLeer;
            Stern2.Source = sternLeer;
            Stern3.Source = sternLeer;
            Stern4.Source = sternLeer;
            Stern5.Source = sternLeer;
            satz.datenbankSerieFuellen(user);
            satz.Neu = true;
            satz.NeuWas = "Serie";
        }

        private void pruefenObZahl(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            sternLeer = db.getSternLeer();
            sternVoll = db.getSternVoll();
            Stern1.Source = sternLeer;
            Stern2.Source = sternLeer;
            Stern3.Source = sternLeer;
            Stern4.Source = sternLeer;
            Stern5.Source = sternLeer;

            cBoxAnbieter.Items.Add("Disney+");
            cBoxAnbieter.Items.Add("Netflix");
            cBoxAnbieter.Items.Add("PC");
            cBoxAnbieter.Items.Add("Prime");            
            cBoxAnbieter.Items.Add("Sky");
            cBoxAnbieter.Items.Add("Sonstiges");
        }

        private void cBoxAnbieter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
    
}
