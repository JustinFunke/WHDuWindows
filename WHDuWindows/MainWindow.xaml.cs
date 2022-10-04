using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WHDuWindows
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Boolean maxSize = false;
        string user;
        byte type = 0;
        Datensaetze satz = new Datensaetze();
        DatenbankMedien db = new DatenbankMedien();
        BitmapImage logoImg;

        public MainWindow()
        {
            InitializeComponent();


        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            logoImg = db.getPB();
            logo.Source = logoImg;
            pb.Source = logoImg;

            Console.WriteLine("Username: " + this.user);
            lblUsername.Content = this.user;
            satz.datenbankListenFuellen(user);
            cBoxAnbieter.Items.Add("Alle");
            cBoxAnbieter.Items.Add("Disney+");
            cBoxAnbieter.Items.Add("Netflix");
            cBoxAnbieter.Items.Add("PC");
            cBoxAnbieter.Items.Add("Prime");
            cBoxAnbieter.Items.Add("Sky");
            cBoxAnbieter.Items.Add("Sonstiges");
            cBoxAnbieter.SelectedIndex = 0;

        }
        public void setUser(string user)
        {
            this.user = user;
        }



        private void cmdBuecher_Click(object sender, RoutedEventArgs e)
        {
            if (!(type == 1))
            {
                type = 1;
                IsCheckedButton();
                buchHeaderErstellen();
                buecherAnzeigen();
            }
        }

        private void CmdFilme_Click(object sender, RoutedEventArgs e)
        {
            if (!(type == 3))
            {
                type = 3;                
                IsCheckedButton();
                filmHeaderErstellen();
                filmAnzeigen();
            }

        }

        private void CmdGames_Click(object sender, RoutedEventArgs e)
        {
            if (!(type == 4))
            {
                type = 4;
                IsCheckedButton();
                gamesHeaderErstellen();
                gamesAnzeigen();

            }

        }
        private void CmdSerie_Click(object sender, RoutedEventArgs e)
        {
            if (!(type == 2))
            {
                type = 2;
                IsCheckedButton();
                serienHeaderErstellen();
                serieAnzeigen();
            }

        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void cmdClose_Click(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void cmdMaxMin_Click(object sender, MouseButtonEventArgs e)
        {
            if (!maxSize)
            {
                maxSize = true;
                this.WindowState = WindowState.Maximized;
            }
            else
            {
                maxSize = false;
                this.WindowState = WindowState.Normal;
            }
        }

        private void CmdBald_Click(object sender, RoutedEventArgs e)
        {
            if (!(type == 5))
            {
                type = 5;
                IsCheckedButton();
                dataGridContent.Columns.Clear();
                dataGridContent.Items.Clear();
            }

        }

        private void IsCheckedButton()
        {
            BrushConverter bc = new BrushConverter();

            if (type == 1)
            {
                cmdBuecher.Background = (Brush)bc.ConvertFrom("#00C0C0");
                chkFertig.Visibility = System.Windows.Visibility.Hidden;
                cBoxAnbieter.Visibility = System.Windows.Visibility.Hidden;
                lblAnbieter.Visibility = System.Windows.Visibility.Hidden;
                cmdSerie.Background = Brushes.Transparent;
                cmdFilme.Background = Brushes.Transparent;
                cmdGames.Background = Brushes.Transparent;
                cmdBald.Background = Brushes.Transparent;
            }
            else if (type == 2)
            {
                chkFertig.Visibility = System.Windows.Visibility.Visible;
                cBoxAnbieter.Visibility = System.Windows.Visibility.Visible;
                lblAnbieter.Visibility = System.Windows.Visibility.Visible;
                cmdSerie.Background = (Brush)bc.ConvertFrom("#00C0C0");
                cmdBuecher.Background = Brushes.Transparent;
                cmdFilme.Background = Brushes.Transparent;
                cmdGames.Background = Brushes.Transparent;
                cmdBald.Background = Brushes.Transparent;
            }
            else if (type == 3)
            {
                cmdFilme.Background = (Brush)bc.ConvertFrom("#00C0C0");
                cBoxAnbieter.Visibility = System.Windows.Visibility.Visible;
                lblAnbieter.Visibility = System.Windows.Visibility.Visible;
                chkFertig.Visibility = System.Windows.Visibility.Hidden;
                cmdBuecher.Background = Brushes.Transparent;
                cmdSerie.Background = Brushes.Transparent;
                cmdGames.Background = Brushes.Transparent;
                cmdBald.Background = Brushes.Transparent;
            }
            else if (type == 4)
            {
                cmdGames.Background = (Brush)bc.ConvertFrom("#00C0C0");
                chkFertig.Visibility = System.Windows.Visibility.Hidden;
                cBoxAnbieter.Visibility = System.Windows.Visibility.Hidden;
                lblAnbieter.Visibility = System.Windows.Visibility.Hidden;
                cmdBuecher.Background = Brushes.Transparent;
                cmdSerie.Background = Brushes.Transparent;
                cmdFilme.Background = Brushes.Transparent;
                cmdBald.Background = Brushes.Transparent;
            }
            else if (type == 5)
            {
                cmdBald.Background = (Brush)bc.ConvertFrom("#00C0C0");
                chkFertig.Visibility = System.Windows.Visibility.Hidden;
                cmdBuecher.Background = Brushes.Transparent;
                cmdSerie.Background = Brushes.Transparent;
                cmdFilme.Background = Brushes.Transparent;
                cmdGames.Background = Brushes.Transparent;
            }
        }



        private void cmdAdd_Click(object sender, RoutedEventArgs e)
        {
            txtSuche.Text = "";
            chkFertig.IsChecked = false;
            if (type == 1)
            {               
                ErstellenBuecher window = new ErstellenBuecher();
                window.setUser(user);
                window.setDatensatz(satz);
                window.Show();
            }
            else if (type == 2)
            {                
                ErstellenSerie window = new ErstellenSerie();
                window.setUser(user);
                window.setDatensatz(satz);
                window.Show();

            }
            else if (type == 3)
            {                
                ErstellenFilme window = new ErstellenFilme();
                window.setUser(user);
                window.setDatensatz(satz);
                window.Show();

            }
            else if (type == 4)
            {                
                ErstellenGames window = new ErstellenGames();
                window.setUser(user);
                window.setDatensatz(satz);
                window.Show();


            }
            else if (type == 5)
            {
                //Wunschliste
            }

        }

        private void cmdAendern_Click(object sender, RoutedEventArgs e)
        {
            
            if (dataGridContent.SelectedItem != null)
            {
                if (type == 1)
                {                    
                    AendernBuecher window = new AendernBuecher();                    
                    buchData data = (buchData)dataGridContent.SelectedItem;
                    window.setBuch(data.titleColumn2, data.autorColumn2, data.datumColumn2, data.bewertungColumn2, satz,user);                    
                    window.Show();
                    txtSuche.Text = "";
                    chkFertig.IsChecked = false;
                }
                else if(type == 2)
                {
                    AendernSerie window = new AendernSerie();
                    serieData data = (serieData)dataGridContent.SelectedItem;
                    window.setSerie(data.titleColumn2,data.staffelColumn2,data.folgeColumn2,data.anbieterColumn2,data.datumColumn2,data.beendetColumn2,data.bewertungColumn2,satz,user);
                    window.Show();
                    txtSuche.Text = "";
                    chkFertig.IsChecked = false;
                }
                else if(type == 3)
                {
                    AendernFilme window = new AendernFilme();
                    filmData data = (filmData)dataGridContent.SelectedItem;
                    window.setFilm(data.titleColumn2, data.anbieterColumn2, data.datumColumn2, data.bewertungColumn2, satz, user);
                    window.Show();
                    txtSuche.Text = "";
                    chkFertig.IsChecked = false;
                }
                else if(type == 4)
                {
                    AendernGames window = new AendernGames();
                    gamesData data = (gamesData)dataGridContent.SelectedItem;
                    window.setGame(data.titleColumn2, data.datumColumn2, data.bewertungColumn2, satz, user);
                    window.Show();
                    txtSuche.Text = "";
                    chkFertig.IsChecked = false;
                }
            }
            
        }

        private void cmdDel_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridContent.SelectedItem != null)
            {
                if (type == 1)
                {
                    buchData data = (buchData)dataGridContent.SelectedItem;
                    db.DelBuch(data.titleColumn2, data.autorColumn2, user);
                    satz.datenbankBuchFuellen(user);
                    buecherAnzeigen();
                    txtSuche.Text = "";
                    chkFertig.IsChecked = false;
                }
                else if (type == 2)
                {
                    serieData data = (serieData)dataGridContent.SelectedItem;
                    db.DelSerie(data.titleColumn2, data.anbieterColumn2, user);
                    satz.datenbankSerieFuellen(user);
                    serieAnzeigen();
                    txtSuche.Text = "";
                    chkFertig.IsChecked = false;
                }
                else if (type == 3)
                {
                    filmData data = (filmData)dataGridContent.SelectedItem;
                    db.DelFilm(data.titleColumn2, data.anbieterColumn2, user);
                    satz.datenbankFilmFuellen(user);
                    filmAnzeigen();
                    txtSuche.Text = "";
                    chkFertig.IsChecked = false;
                }
                else if (type == 4)
                {
                    gamesData data = (gamesData)dataGridContent.SelectedItem;
                    db.DelGame(data.titleColumn2, user);
                    satz.datenbankGamesFuellen(user);
                    gamesAnzeigen();
                    txtSuche.Text = "";
                    chkFertig.IsChecked = false;
                }
            }
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (satz.Neu)
            {
                if (satz.NeuWas.Equals("Game"))
                {
                    gamesAnzeigen();
                    satz.Neu = false;
                }
                else if (satz.NeuWas.Equals("Buch"))
                {
                    buecherAnzeigen();
                    satz.Neu = false;
                }
                else if (satz.NeuWas.Equals("Film"))
                {
                    filmAnzeigen();
                    satz.Neu = false;
                }
                else if (satz.NeuWas.Equals("Serie"))
                {
                    serieAnzeigen();
                    satz.Neu = false;
                }

            }

        }
        //Meiden anzeigen
        private void gamesAnzeigen()
        {

            dataGridContent.Items.Clear();
            if (!(satz.gameTitel.Count == 0))
            {
                for (int i = 0; i < satz.gameTitel.Count; i++)
                {
                    gamesData gamesData = new gamesData();
                    gamesData.titleColumn2 = satz.gameTitel[i] + "";
                    gamesData.datumColumn2 = satz.gameDatum[i] + "";
                    gamesData.bewertungColumn2 = satz.gameBewertung[i] + "";
                    dataGridContent.Items.Add(gamesData);
                }
            }
        }
        private void buecherAnzeigen()
        {
            dataGridContent.Items.Clear();
            //Bücher in die Liste anzeigen
            if (!(satz.buchTitel.Equals(null)))
            {
                for (int i = 0; i < satz.buchTitel.Count; i++)
                {
                    buchData buchData = new buchData();
                    buchData.titleColumn2 = satz.buchTitel[i] + "";
                    buchData.autorColumn2 = satz.buchAutor[i] + "";
                    buchData.datumColumn2 = satz.buchDatum[i] + "";
                    buchData.bewertungColumn2 = satz.buchBewertung[i] + "";
                    dataGridContent.Items.Add(buchData);
                    
                }
            }
        }
        private void filmAnzeigen()
        {
            dataGridContent.Items.Clear();
            if (!(satz.filmTitel.Equals(null)))
            {
                for (int i = 0; i < satz.filmTitel.Count; i++)
                {
                    filmData filmData = new filmData();
                    filmData.titleColumn2 = satz.filmTitel[i] + "";
                    filmData.anbieterColumn2 = satz.filmAnbieter[i] + "";
                    filmData.bewertungColumn2 = satz.filmBewetung[i] + "";
                    filmData.datumColumn2 = satz.filmDatum[i] + "";
                    dataGridContent.Items.Add(filmData);
                }
            }

        }
        private void serieAnzeigen()
        {
            dataGridContent.Items.Clear();
            
            if (!(satz.serieTitel.Equals(null)))
            {
                for (int i = 0; i < satz.serieTitel.Count; i++)
                {
                    serieData serieData = new serieData();

                    serieData.titleColumn2 = satz.serieTitel[i] + "";
                    serieData.staffelColumn2 = satz.serieStaffel[i] + "";
                    serieData.folgeColumn2 = satz.serieFolge[i] + "";
                    serieData.anbieterColumn2 = satz.serieAnbieter[i] + "";
                    serieData.bewertungColumn2 = satz.serieBewetung[i] + "";
                    serieData.datumColumn2 = satz.serieDatum[i] + "";
                    serieData.beendetColumn2 = satz.serieBeendet[i] + "";
                    dataGridContent.Items.Add(serieData);
                }
            }
        }


        //Suche
        private void txtSuche_TextChanged(object sender, TextChangedEventArgs e)
        {
            suchen();
        }
        private void cBoxAnbieter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            suchen();
        }
        private void chkFertig_CheckedChanged(object sender, RoutedEventArgs e)
        {
            suchen();
        }

        private void suchen()
        {
            string eingabe = txtSuche.Text.ToUpper();
            Console.WriteLine("---------------Bin in TxtSuche --------------");
            if (type == 1)
            {
                ArrayList buchTitel = new ArrayList();
                ArrayList buchAutor = new ArrayList();
                ArrayList buchBewertung = new ArrayList();
                ArrayList buchDatum = new ArrayList();
                if (!(satz.buchTitel.Equals(null)))
                {
                    for (int i = 0; i < satz.buchTitel.Count; i++)
                    {
                        if ((satz.buchTitel[i] + "").ToUpper().Contains(eingabe) || (satz.buchAutor[i] + "").ToUpper().Contains(eingabe) || (satz.buchDatum[i] + "").ToUpper().Contains(eingabe)) // || satz.buchAutor.Contains(txtSuche.Text) || satz.buchDatum.Contains(txtSuche.Text)
                        {
                            Console.WriteLine("------------------------Bin in Contains-------------------");
                            buchTitel.Add(satz.buchTitel[i]);
                            buchAutor.Add(satz.buchAutor[i]);
                            buchBewertung.Add(satz.buchBewertung[i]);
                            buchDatum.Add(satz.buchDatum[i]);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("------------Kein Datensatzvorhanden-----------");
                }

                //BuchAnzeigen
                dataGridContent.Items.Clear();
                Console.WriteLine("Buch Anzeigen" + buchTitel.Count);
                if (!(buchTitel.Equals(null)))
                {
                    for (int i = 0; i < buchTitel.Count; i++)
                    {
                        buchData buchData = new buchData();
                        buchData.titleColumn2 = buchTitel[i] + "";
                        buchData.autorColumn2 = buchAutor[i] + "";
                        buchData.datumColumn2 = buchDatum[i] + "";
                        buchData.bewertungColumn2 = buchBewertung[i] + "";
                        dataGridContent.Items.Add(buchData);
                    }
                }
            }
            else if (type == 2)
            {
                ArrayList serieTitel = new ArrayList();     //Suchen
                ArrayList serieStaffel = new ArrayList();
                ArrayList serieFolge = new ArrayList();
                ArrayList serieAnbieter = new ArrayList();  //Suchen
                ArrayList serieBewetung = new ArrayList();
                ArrayList serieDatum = new ArrayList();     //Suchen
                ArrayList serieBeendet = new ArrayList();
                if (!satz.serieTitel.Equals(null))
                {
                    //Falls Anbieter
                    if (!(cBoxAnbieter.SelectedItem.Equals("Alle")))
                    {
                        Console.WriteLine("----------Bin in Cbox-------------");
                        //Nur Durchgeguckte
                        if ((bool)chkFertig.IsChecked)
                        {
                            Console.WriteLine("----------Bin in CHK-------------");

                            for (int i = 0; i < satz.serieTitel.Count; i++)
                            {
                                if (((satz.serieTitel[i] + "").ToUpper().Contains(eingabe) || (satz.serieDatum[i] + "").ToUpper().Contains(eingabe)) && (satz.serieAnbieter[i].Equals(cBoxAnbieter.SelectedItem) && (satz.serieBeendet[i] + "").Equals("Ja")))
                                {
                                    serieTitel.Add(satz.serieTitel[i]);
                                    serieStaffel.Add(satz.serieStaffel[i]);
                                    serieFolge.Add(satz.serieFolge[i]);
                                    serieAnbieter.Add(satz.serieAnbieter[i]);
                                    serieBewetung.Add(satz.serieBewetung[i]);
                                    serieDatum.Add(satz.serieDatum[i]);
                                    serieBeendet.Add(satz.serieBeendet[i]);
                                }
                            }
                        }
                        //Nicht und Durchgeguckte
                        else
                        {
                            for (int i = 0; i < satz.serieTitel.Count; i++)
                            {
                                if (((satz.serieTitel[i] + "").ToUpper().Contains(eingabe) || (satz.serieDatum[i] + "").ToUpper().Contains(eingabe)) && satz.serieAnbieter[i].Equals(cBoxAnbieter.SelectedItem))
                                {
                                    serieTitel.Add(satz.serieTitel[i]);
                                    serieStaffel.Add(satz.serieStaffel[i]);
                                    serieFolge.Add(satz.serieFolge[i]);
                                    serieAnbieter.Add(satz.serieAnbieter[i]);
                                    serieBewetung.Add(satz.serieBewetung[i]);
                                    serieDatum.Add(satz.serieDatum[i]);
                                    serieBeendet.Add(satz.serieBeendet[i]);
                                }
                            }
                        }

                    }//Kein Anbieter
                    else
                    {
                        //Nur Durchgeguckte
                        if ((bool)chkFertig.IsChecked)
                        {
                            for (int i = 0; i < satz.serieTitel.Count; i++)
                            {
                                if (((satz.serieTitel[i] + "").ToUpper().Contains(eingabe) || (satz.serieDatum[i] + "").ToUpper().Contains(eingabe)) && (satz.serieBeendet[i] + "").Equals("Ja"))
                                {
                                    serieTitel.Add(satz.serieTitel[i]);
                                    serieStaffel.Add(satz.serieStaffel[i]);
                                    serieFolge.Add(satz.serieFolge[i]);
                                    serieAnbieter.Add(satz.serieAnbieter[i]);
                                    serieBewetung.Add(satz.serieBewetung[i]);
                                    serieDatum.Add(satz.serieDatum[i]);
                                    serieBeendet.Add(satz.serieBeendet[i]);
                                }
                            }
                        }
                        else
                        {
                            for (int i = 0; i < satz.serieTitel.Count; i++)
                            {
                                if (((satz.serieTitel[i] + "").ToUpper().Contains(eingabe) || (satz.serieDatum[i] + "").ToUpper().Contains(eingabe)))
                                {
                                    serieTitel.Add(satz.serieTitel[i]);
                                    serieStaffel.Add(satz.serieStaffel[i]);
                                    serieFolge.Add(satz.serieFolge[i]);
                                    serieAnbieter.Add(satz.serieAnbieter[i]);
                                    serieBewetung.Add(satz.serieBewetung[i]);
                                    serieDatum.Add(satz.serieDatum[i]);
                                    serieBeendet.Add(satz.serieBeendet[i]);
                                }
                            }
                        }
                    }

                    //Ausgeben
                    dataGridContent.Items.Clear();
                    if (!(serieTitel.Equals(null)))
                    {
                        for (int i = 0; i < serieTitel.Count; i++)
                        {
                            serieData serieData = new serieData();

                            serieData.titleColumn2 = serieTitel[i] + "";
                            serieData.staffelColumn2 = serieStaffel[i] + "";
                            serieData.folgeColumn2 = serieFolge[i] + "";
                            serieData.anbieterColumn2 = serieAnbieter[i] + "";
                            serieData.bewertungColumn2 = serieBewetung[i] + "";
                            serieData.datumColumn2 = serieDatum[i] + "";
                            serieData.beendetColumn2 = serieBeendet[i] + "";
                            dataGridContent.Items.Add(serieData);
                        }

                    }
                }

            }
            else if (type == 3)
            {
                ArrayList filmTitel = new ArrayList();
                ArrayList filmAnbieter = new ArrayList();
                ArrayList filmBewetung = new ArrayList();
                ArrayList filmDatum = new ArrayList();
                if (!(satz.filmTitel.Equals(null)))
                {
                    if (!(cBoxAnbieter.SelectedItem.Equals("Alle")))
                    {
                        for (int i = 0; i < satz.filmTitel.Count; i++)
                        {
                            if (((satz.filmTitel[i] + "").ToUpper().Contains(eingabe) || (satz.gameDatum[i] + "").ToUpper().Contains(eingabe)) && satz.filmAnbieter[i].Equals(cBoxAnbieter.SelectedItem))
                            {
                                filmTitel.Add(satz.filmTitel[i]);
                                filmAnbieter.Add(satz.filmAnbieter[i]);
                                filmBewetung.Add(satz.filmBewetung[i]);
                                filmDatum.Add(satz.filmDatum[i]);
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < satz.filmTitel.Count; i++)
                        {
                            if (((satz.filmTitel[i] + "").ToUpper().Contains(eingabe) || (satz.gameDatum[i] + "").ToUpper().Contains(eingabe)))
                            {
                                filmTitel.Add(satz.filmTitel[i]);
                                filmAnbieter.Add(satz.filmAnbieter[i]);
                                filmBewetung.Add(satz.filmBewetung[i]);
                                filmDatum.Add(satz.filmDatum[i]);
                            }
                        }
                    }
                    dataGridContent.Items.Clear();
                    if (!(filmTitel.Equals(null)))
                    {
                        for (int i = 0; i < filmTitel.Count; i++)
                        {
                            filmData filmData = new filmData();
                            filmData.titleColumn2 = filmTitel[i] + "";
                            filmData.anbieterColumn2 = filmAnbieter[i] + "";
                            filmData.bewertungColumn2 = filmBewetung[i] + "";
                            filmData.datumColumn2 = filmBewetung[i] + "";
                            dataGridContent.Items.Add(filmData);
                        }
                    }
                }


            }
            else if (type == 4)
            {
                ArrayList gameTitel = new ArrayList();
                ArrayList gameBewertung = new ArrayList();
                ArrayList gameDatum = new ArrayList();
                if (!(satz.gameTitel.Equals(null)))
                {
                    for (int i = 0; i < satz.gameTitel.Count; i++)
                    {
                        if ((satz.gameTitel[i] + "").ToUpper().Contains(eingabe) || (satz.gameDatum[i] + "").ToUpper().Contains(eingabe)) // || satz.buchAutor.Contains(txtSuche.Text) || satz.buchDatum.Contains(txtSuche.Text)
                        {
                            Console.WriteLine("------------------------Bin in Contains-------------------");
                            gameTitel.Add(satz.gameTitel[i]);
                            gameBewertung.Add(satz.gameBewertung[i]);
                            gameDatum.Add(satz.gameDatum[i]);
                        }
                    }
                }

                dataGridContent.Items.Clear();
                if (!(gameTitel.Equals(null)))
                {
                    for (int i = 0; i < gameTitel.Count; i++)
                    {
                        gamesData gamesData = new gamesData();
                        gamesData.titleColumn2 = gameTitel[i] + "";
                        gamesData.datumColumn2 = gameDatum[i] + "";
                        gamesData.bewertungColumn2 = gameBewertung[i] + "";
                        dataGridContent.Items.Add(gamesData);
                    }
                }
            }
            else if (type == 5)
            {
                //Bald
            }
        }


        //WPF

        private void buchHeaderErstellen()
        {
            //DataGrid Zeilen Füllen
            dataGridContent.Columns.Clear();
            //Titel
            DataGridTextColumn titleColumn = new DataGridTextColumn();
            titleColumn.Header = "Titel";
            titleColumn.Binding = new Binding("titleColumn2");
            titleColumn.FontSize = 20;

            //Autor
            DataGridTextColumn autorColumn = new DataGridTextColumn();
            autorColumn.Header = "Autor";
            autorColumn.Binding = new Binding("autorColumn2");
            autorColumn.FontSize = 20;
            //Datum
            DataGridTextColumn datumColumn = new DataGridTextColumn();
            datumColumn.Header = "Datum";
            datumColumn.Binding = new Binding("datumColumn2");
            datumColumn.FontSize = 20;
            datumColumn.MaxWidth = 115;
            //Bewertung
            DataGridTextColumn bewertungColumn = new DataGridTextColumn();
            bewertungColumn.Header = "Bewertung";
            bewertungColumn.Binding = new Binding("bewertungColumn2");
            bewertungColumn.IsReadOnly = true;
            bewertungColumn.FontSize = 20;
            bewertungColumn.MaxWidth = 160;


            //Überschriften Hinzufuegen
            dataGridContent.Columns.Add(titleColumn);
            dataGridContent.Columns.Add(autorColumn);
            dataGridContent.Columns.Add(datumColumn);
            dataGridContent.Columns.Add(bewertungColumn);
        }

        private void filmHeaderErstellen()
        {
            //DataGrid Zeilen Füllen
            dataGridContent.Columns.Clear();
            //Titel
            DataGridTextColumn titleColumn = new DataGridTextColumn();
            titleColumn.Header = "Titel";
            titleColumn.Binding = new Binding("titleColumn2");
            titleColumn.FontSize = 20;
            //Anbieter
            DataGridTextColumn anbieterColumn = new DataGridTextColumn();
            anbieterColumn.Header = "Anbieter";
            anbieterColumn.Binding = new Binding("anbieterColumn2");
            anbieterColumn.FontSize = 20;
            anbieterColumn.MaxWidth = 100;
            //Datum
            DataGridTextColumn datumColumn = new DataGridTextColumn();
            datumColumn.Header = "Datum";
            datumColumn.Binding = new Binding("datumColumn2");
            datumColumn.FontSize = 20;
            datumColumn.MaxWidth = 115;
            //Bewertung
            DataGridTextColumn bewertungColumn = new DataGridTextColumn();
            bewertungColumn.Header = "Bewertung";
            bewertungColumn.Binding = new Binding("bewertungColumn2");
            bewertungColumn.IsReadOnly = true;
            bewertungColumn.FontSize = 20;
            bewertungColumn.MaxWidth = 160;

            dataGridContent.Columns.Add(titleColumn);
            dataGridContent.Columns.Add(anbieterColumn);
            dataGridContent.Columns.Add(datumColumn);
            dataGridContent.Columns.Add(bewertungColumn);



        }

        private void serienHeaderErstellen()
        {
            //DataGrid Zeilen Füllen
            dataGridContent.Columns.Clear();
            //Titel
            DataGridTextColumn titleColumn = new DataGridTextColumn();
            titleColumn.Header = "Titel";
            titleColumn.Binding = new Binding("titleColumn2");
            titleColumn.FontSize = 20;
            //Staffel
            DataGridTextColumn staffelColumn = new DataGridTextColumn();
            staffelColumn.Header = "Staffel";
            staffelColumn.Binding = new Binding("staffelColumn2");
            staffelColumn.FontSize = 20;
            staffelColumn.MaxWidth = 50;
            //Folge
            DataGridTextColumn folgeColumn = new DataGridTextColumn();
            folgeColumn.Header = "Folge";
            folgeColumn.Binding = new Binding("folgeColumn2");
            folgeColumn.FontSize = 20;
            folgeColumn.MaxWidth = 50;
            //Anbieter
            DataGridTextColumn anbieterColumn = new DataGridTextColumn();
            anbieterColumn.Header = "Anbieter";
            anbieterColumn.Binding = new Binding("anbieterColumn2");
            anbieterColumn.FontSize = 20;
            anbieterColumn.MaxWidth = 100;
            //Datum
            DataGridTextColumn datumColumn = new DataGridTextColumn();
            datumColumn.Header = "Datum";
            datumColumn.Binding = new Binding("datumColumn2");
            datumColumn.FontSize = 20;
            datumColumn.MaxWidth = 115;
            //Bewertung
            DataGridTextColumn bewertungColumn = new DataGridTextColumn();
            bewertungColumn.Header = "Bewertung";
            bewertungColumn.Binding = new Binding("bewertungColumn2");
            bewertungColumn.IsReadOnly = true;
            bewertungColumn.FontSize = 20;
            bewertungColumn.MaxWidth = 160;
            //Bewertung
            DataGridTextColumn beendetColumn = new DataGridTextColumn();
            beendetColumn.Header = "Beendet";
            beendetColumn.Binding = new Binding("beendetColumn2");
            beendetColumn.IsReadOnly = true;
            beendetColumn.FontSize = 20;
            beendetColumn.MaxWidth = 65;

            dataGridContent.Columns.Add(titleColumn);
            dataGridContent.Columns.Add(staffelColumn);
            dataGridContent.Columns.Add(folgeColumn);
            dataGridContent.Columns.Add(anbieterColumn);
            dataGridContent.Columns.Add(datumColumn);
            dataGridContent.Columns.Add(bewertungColumn);
            dataGridContent.Columns.Add(beendetColumn);


        }

        private void gamesHeaderErstellen()
        {
            //DataGrid Zeilen Füllen
            dataGridContent.Columns.Clear();
            //Titel
            DataGridTextColumn titleColumn = new DataGridTextColumn();
            titleColumn.Header = "Titel";
            titleColumn.Binding = new Binding("titleColumn2");
            titleColumn.FontSize = 20;


            //Datum
            DataGridTextColumn datumColumn = new DataGridTextColumn();
            datumColumn.Header = "Datum";
            datumColumn.Binding = new Binding("datumColumn2");
            datumColumn.FontSize = 20;
            datumColumn.MaxWidth = 115;
            //Bewertung
            DataGridTextColumn bewertungColumn = new DataGridTextColumn();
            bewertungColumn.Header = "Bewertung";
            bewertungColumn.Binding = new Binding("bewertungColumn2");
            bewertungColumn.IsReadOnly = true;
            bewertungColumn.FontSize = 20;
            bewertungColumn.MaxWidth = 160;


            //Überschriften Hinzufuegen
            dataGridContent.Columns.Add(titleColumn);
            dataGridContent.Columns.Add(datumColumn);
            dataGridContent.Columns.Add(bewertungColumn);
        }

        private class buchData
        {
            public string titleColumn2 { get; set; }
            public string autorColumn2 { get; set; }
            public string datumColumn2 { get; set; }
            public string bewertungColumn2 { get; set; }
        }
        private class gamesData
        {
            public string titleColumn2 { get; set; }
            public string datumColumn2 { get; set; }
            public string bewertungColumn2 { get; set; }
        }

        private class filmData
        {
            public string titleColumn2 { get; set; }
            public string anbieterColumn2 { get; set; }
            public string datumColumn2 { get; set; }
            public string bewertungColumn2 { get; set; }
        }

        private class serieData
        {
            public string titleColumn2 { get; set; }
            public string staffelColumn2 { get; set; }
            public string folgeColumn2 { get; set; }
            public string anbieterColumn2 { get; set; }
            public string datumColumn2 { get; set; }
            public string bewertungColumn2 { get; set; }
            public string beendetColumn2 { get; set; }
        }


        //Sonstiges




        //Unbenutze Methoden
        
        

        private void Window_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void dataGridContent_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            return;
        }

        private void dataGridContent_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            
        }
    }
}
//1:Buch 2:Serie 3:Film 4:Game
