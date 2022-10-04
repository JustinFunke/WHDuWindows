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
    /// Interaktionslogik für AendernSerie.xaml
    /// </summary>
    public partial class AendernSerie : Window
    {
        private string user;
        private string titel;
        private string staffel;
        private string folge;
        private string anbieter;
        private bool durchgeguckt;
        private string jahr;
        private int sterne;

        private BitmapImage sternLeer;
        private BitmapImage sternVoll;
        private DatenbankMedien db = new DatenbankMedien();
        private Datensaetze satz;


        public void setSerie(string titel, string staffel, string folge, string anbieter, string jahr, string durchgeguckt, string bewertung, Datensaetze satz,string user)
        {
            this.satz = satz;
            this.user = user;
            this.titel = titel;
            this.staffel = staffel;
            this.folge = folge;
            this.anbieter = anbieter;
            if(durchgeguckt.Equals("Ja"))
                this.durchgeguckt = true;
            if (!(jahr.Equals("Unbekannt")))
                this.jahr = jahr;
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

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void cmdClose_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            satz.datenbankSerieFuellen(user);
            satz.Neu = true;
            satz.NeuWas = "Serie";
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
            int datum = 0;
            int fertig =0;
            if (txtTitel.Text.Equals(""))
            {
                MessageBox.Show("Sie müssen den Titel ausfüllen");
                return;
            }
            if (!(txtDatum.Text.Equals("")))
                datum = Int32.Parse(txtDatum.Text);
            if (cBoxAnbieter.SelectedItem == null)
            {
                MessageBox.Show("Sie müssen einem Anbieter auswählen");
                return;
            }
            if (chkCheckBox.IsChecked==true)
                fertig = 1;
            Console.WriteLine(txtFolge.Text);
            Serie serie = new Serie(txtTitel.Text, Int32.Parse(txtFolge.Text), Int32.Parse(txtStaffel.Text), sterne, datum, cBoxAnbieter.Text, fertig);
            db.UpdateSerie(serie, user, titel, anbieter);
            satz.datenbankSerieFuellen(user);
            satz.Neu = true;
            satz.NeuWas = "Serie";
            

            //if (txtTitel.Text.Equals(""))
            //{
            //    MessageBox.Show("Sie müssen den Titel ausfüllen");
            //    return;
            //}
            //if (!(txtDatum.Text.Equals("")))
            //    datum = Int32.Parse(txtDatum.Text);
            //if (chkCheckBox.IsChecked == true)
            //{
            //    fertig = 1;
            //}
            //if (cBoxAnbieter.SelectedItem == null)
            //{
            //    MessageBox.Show("Sie müssen einem Anbieter auswählen");
            //    return;
            //}

            //Serie serie = new Serie(txtTitel.Text, Int32.Parse(txtFolge.Text), Int32.Parse(txtStaffel.Text), sterne, datum, cBoxAnbieter.Text, fertig);
            //db.SerieHinzufuegen(serie, user);

            //fertig = 0;
            //datum = 0;

            //txtDatum.Text = "";
            //txtFolge.Text = "";
            //txtStaffel.Text = "";
            //txtTitel.Text = "";
            //sterne = 0;
            //Stern1.Source = sternLeer;
            //Stern2.Source = sternLeer;
            //Stern3.Source = sternLeer;
            //Stern4.Source = sternLeer;
            //Stern5.Source = sternLeer;
        }

        

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            cBoxAnbieter.Items.Add("Disney+");
            cBoxAnbieter.Items.Add("Netflix");
            cBoxAnbieter.Items.Add("PC");
            cBoxAnbieter.Items.Add("Prime");
            cBoxAnbieter.Items.Add("Sky");
            cBoxAnbieter.Items.Add("Sonstiges");
            sternLeer = db.getSternLeer();
            sternVoll = db.getSternVoll();

            switch(anbieter)
            {
                case "Disney+":
                    cBoxAnbieter.SelectedIndex = 0;
                break;
                case "Netflix":                   
                    cBoxAnbieter.SelectedIndex = 1;
                break;
                case "PC":
                    cBoxAnbieter.SelectedIndex = 2;
                break;
                case "Prime":
                    cBoxAnbieter.SelectedIndex = 3;
                break;
                case "Sky":
                    cBoxAnbieter.SelectedIndex = 4;
                break;
                case "Sonstiges":
                    cBoxAnbieter.SelectedIndex = 5;
                break;

            }
            setSterne();
            txtTitel.Text = titel;
            txtFolge.Text = folge;
            txtStaffel.Text = staffel;
            txtDatum.Text = jahr;
            if (durchgeguckt)
                chkCheckBox.IsChecked = true;
            

        }


        //Sonstiges
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
        private void cBoxAnbieter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        public AendernSerie()
        {
            InitializeComponent();
        }
    }
}
