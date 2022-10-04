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

namespace WHDuWindows
{
    /// <summary>
    /// Interaktionslogik für ErstellenBuecher.xaml
    /// </summary>
    public partial class ErstellenBuecher : Window
    {
        BitmapImage sternLeer;
        BitmapImage sternVoll;
        int sterne = 0;
        int datum = 0;
        string user;
        DatenbankMedien db = new DatenbankMedien();
        Datensaetze satz;
        public ErstellenBuecher()
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

        private void cmdCloseRegistrieren_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
            Close();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        } 

        private void cmdHinzufuegen_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!(txtDatum.Text.Equals("")))
                    datum = Int32.Parse(txtDatum.Text);
            }catch(Exception ex)
            {
                MessageBox.Show("Beim Jahr dürfen nur Zahlen angegeben werden");
                Console.WriteLine(ex);
                return;
            }
            if ((txtAutor.Text.Equals("") || txtTitel.Text.Equals("")))
            {
                MessageBox.Show("Sie müssen Autor Titel ausfüllen");
                return;
            }
            if (sterne ==0)
            {
                MessageBox.Show("Sie müssen das Buch bewerten");
                return;
            }
            
            Buecher buch = new Buecher(txtTitel.Text,txtAutor.Text,sterne,datum);
            db.BuchHinzufuegen(buch,user);
            txtAutor.Text = "";
            txtDatum.Text = "";
            txtTitel.Text = "";
            sterne = 0;
            datum = 0;
            Stern1.Source = sternLeer;
            Stern2.Source = sternLeer;
            Stern3.Source = sternLeer;
            Stern4.Source = sternLeer;
            Stern5.Source = sternLeer;
            satz.datenbankBuchFuellen(user);
            satz.Neu = true;
            satz.NeuWas = "Buch";


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

        private void Stern5_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Stern1.Source = sternVoll;
            Stern2.Source = sternVoll;
            Stern3.Source = sternVoll;
            Stern4.Source = sternVoll;
            Stern5.Source = sternVoll;
            sterne = 5;
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

        private void Stern2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Stern1.Source = sternVoll;
            Stern2.Source = sternVoll;
            Stern3.Source = sternLeer;
            Stern4.Source = sternLeer;
            Stern5.Source = sternLeer;
            sterne = 2;
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
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            sternLeer = db.getSternLeer();
            sternVoll = db.getSternVoll();
            Stern1.Source = sternLeer;
            Stern2.Source = sternLeer;
            Stern3.Source = sternLeer;
            Stern4.Source = sternLeer;
            Stern5.Source = sternLeer;
        }
        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
