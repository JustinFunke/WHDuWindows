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
    /// Interaktionslogik für AendernGames.xaml
    /// </summary>
    public partial class AendernGames : Window
    {
        private string user;
        private string title;
        private string jahr;
        private int sterne;

        BitmapImage sternLeer;
        BitmapImage sternVoll;            
        private Datensaetze satz;
        private DatenbankMedien db = new DatenbankMedien();

        public void setGame(string title, string jahr, string bewertung, Datensaetze satz, string user)
        {
            this.satz = satz;
            this.title = title;
            if (!(jahr.Equals("Unbekannt")))
                this.jahr = jahr;
            this.user = user;

            if (bewertung == "Ausgezeichnet")
                this.sterne = 5;
            else if (bewertung == "Gut")
                this.sterne = 4;
            else if (bewertung == "Mittelmäßig")
                this.sterne = 3;
            else if (bewertung == "Schlecht")
                this.sterne = 2;
            else
                this.sterne = 1;
        }

        public AendernGames()
        {
            InitializeComponent();
        }




        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void cmdCloseRegistrieren_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
            Close();
        }

        private void cmdHinzufuegen_Click(object sender, RoutedEventArgs e)
        {
            int datum = 0;
            try
            {
                if (!(txtDatum.Text.Equals("")))
                    datum = Int32.Parse(txtDatum.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Beim Jahr dürfen nur Zahlen angegeben werden");
                Console.WriteLine(ex);
                return;
            }

            if (txtTitel.Text.Equals(""))
            {
                MessageBox.Show("Sie müssen den Titel ausfüllen");
                return;
            }


            Games game = new Games(txtTitel.Text, sterne, datum);
            db.UpdateGame(game, user, title);
            satz.datenbankGamesFuellen(user);
            satz.Neu = true;
            satz.NeuWas = "Game";
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


        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            sternLeer = db.getSternLeer();
            sternVoll = db.getSternVoll();

            txtTitel.Text = title;
            txtDatum.Text = jahr;
            setSterne();
        }
        private void setSterne()
        {
            if (sterne == 1)
            {
                Stern1.Source = sternVoll;
                Stern2.Source = sternLeer;
                Stern3.Source = sternLeer;
                Stern4.Source = sternLeer;
                Stern5.Source = sternLeer;
            }
            else if (sterne == 2)
            {
                Stern1.Source = sternVoll;
                Stern2.Source = sternVoll;
                Stern3.Source = sternLeer;
                Stern4.Source = sternLeer;
                Stern5.Source = sternLeer;
            }
            else if (sterne == 3)
            {
                Stern1.Source = sternVoll;
                Stern2.Source = sternVoll;
                Stern3.Source = sternVoll;
                Stern4.Source = sternLeer;
                Stern5.Source = sternLeer;
            }
            else if (sterne == 4)
            {
                Console.WriteLine("Bin in Gut");
                Stern1.Source = sternVoll;
                Stern2.Source = sternVoll;
                Stern3.Source = sternVoll;
                Stern4.Source = sternVoll;
                Stern5.Source = sternLeer;
            }
            else if (sterne == 5)
            {
                Stern1.Source = sternVoll;
                Stern2.Source = sternVoll;
                Stern3.Source = sternVoll;
                Stern4.Source = sternVoll;
                Stern5.Source = sternVoll;
            }
        }

        private void pruefenObZahl(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);

        }
    }
}

