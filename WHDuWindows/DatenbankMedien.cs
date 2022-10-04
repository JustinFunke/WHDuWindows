using System;
using System.Configuration;
using System.Data.SQLite;
using System.Collections;
using System.Windows;
using System.Collections.Generic;
using System.IO;
using System.Windows.Controls;
using System.Windows.Media.Imaging;


namespace WHDuWindows
{
    class DatenbankMedien
    {
        private static string conString = "Data Source=WHDuDatabase.db;Version=3;"; //Hier hönnte ein Fehler sein
        private static SQLiteConnection con = new SQLiteConnection(conString);
        private static SQLiteCommand com = new SQLiteCommand(con);
        private static SQLiteDataReader reader;
        //Buch
        public ArrayList buchTitel = new ArrayList();
        public ArrayList buchAutor = new ArrayList();
        public ArrayList buchBewertung = new ArrayList();
        public ArrayList buchDatum = new ArrayList();
        //Games
        public ArrayList gameTitel = new ArrayList();
        public ArrayList gameBewertung = new ArrayList();
        public ArrayList gameDatum = new ArrayList();
        //Filme
        public ArrayList filmTitel = new ArrayList();
        public ArrayList filmAnbieter = new ArrayList();
        public ArrayList filmBewetung = new ArrayList();
        public ArrayList filmDatum = new ArrayList();
        //Serie
        public ArrayList serieTitel = new ArrayList();
        public ArrayList serieStaffel = new ArrayList();
        public ArrayList serieFolge = new ArrayList();
        public ArrayList serieAnbieter = new ArrayList();
        public ArrayList serieBewetung = new ArrayList();
        public ArrayList serieDatum = new ArrayList();
        public ArrayList serieBeendet = new ArrayList();

        public void BuchHinzufuegen(Buecher buch, string user) {
            try
            {                              
                con.Open();
                com.CommandText = "insert into '"+user+"' (titel,creator,bewertung,Fertigwann,typ) values ('" + buch.getTitel() + "', '" + buch.getAutor() + "'," + buch.getSterne() + "," + buch.getDatum() + ",'Buch'" + ")";
                com.ExecuteNonQuery();
                con.Close();                
                MessageBox.Show("Buch erfolgreich hinzugefügt");

            }
            catch (SQLiteException ex)
            {
                Console.WriteLine(ex.ErrorCode);
            }
        }

        public void UpdateBuch(Buecher buch, string user, string altTitel, string altAutor)
        {
            con.Open();
            com.CommandText = "Update '"+user+ "' SET titel = '"+buch.getTitel()+"', creator ='"+buch.getAutor()+"', bewertung='"+buch.getSterne()+"', FertigWann='"+buch.getDatum()+"' WHERE titel = '"+altTitel+"' AND creator ='"+altAutor+"' ";
            com.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Buch erfolgreich geändert");
        }

        public void DelBuch(string titel, string autor,string user)
        {
            con.Open();
            com.CommandText ="DELETE FROM '"+user+ "' WHERE titel = '" + titel + "' AND creator ='" + autor + "' ";
            com.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Buch gelöscht");
        }

        public void GameHinzufuegen(Games game,string user)
        {

            con.Open();
            com.CommandText = "insert into '" + user + "' (titel,bewertung,Fertigwann,typ) values ('" + game.getTitel() + "'," + game.getSterne() + "," + game.getDatum() + ",'Games'" + ")";
            com.ExecuteNonQuery();
            con.Close();            
            MessageBox.Show("Game erfolgreich hinzugefügt");
        }

        public void UpdateGame(Games games, string user, string altTitel)
        {
            con.Open();
            com.CommandText = "Update '" + user + "' SET titel = '" + games.getTitel() + "', bewertung='" + games.getSterne() + "', FertigWann='" + games.getDatum() + "' WHERE titel = '" + altTitel + "' AND typ ='Games'";
            com.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Game erfolgreich geändert");
        }
        public void DelGame(string titel, string user)
        {
            con.Open();
            com.CommandText = "DELETE FROM '" + user + "' WHERE titel = '" + titel + "' AND typ ='Games'";
            com.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Game gelöscht");


        }

        public void SerieHinzufuegen(Serie serie, string user)
        {
            con.Open();
            com.CommandText = "insert into '" + user + "' (titel,folge,staffel,bewertung,fertig,fertigwann,anbieter,typ) values ('" + serie.getTitel() + "', " + serie.getFolge() + "," + serie.getStaffel() + "," + serie.getSterne() + "," + serie.getFertig() + "," + serie.getDatum() + ",'" + serie.getAnbieter() + "','Serie'" + ")";
            com.ExecuteNonQuery();
            con.Close();           
            MessageBox.Show("Serie erfolgreich hinzugefügt");
        }
        public void UpdateSerie(Serie serie, string user, string altTitel, string altAnbieter)
        {
            con.Open();         
            com.CommandText = "Update '" + user + "' SET titel = '" + serie.getTitel() + "',staffel='" + serie.getStaffel() + "', folge='" + serie.getFolge() + "', anbieter ='" + serie.getAnbieter() + "', bewertung='" + serie.getSterne()+"', fertig='"+serie.getFertig() + "', FertigWann='" + serie.getDatum() + "' WHERE titel = '" + altTitel + "' AND anbieter ='" + altAnbieter + "' AND typ ='Serie'";
            com.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Serie erfolgreich geändert");
        }

        public void DelSerie(string titel, string anbieter, string user)
        {
            con.Open();
            com.CommandText = "DELETE FROM '" + user + "' WHERE titel = '" + titel + "' AND anbieter ='" + anbieter + "' AND typ ='Serie'";
            com.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Serie gelöscht");


        }

        public void FilmHinzufuegen(Filme film,string user)
        {
            con.Open();
            com.CommandText = "insert into '" + user + "' (titel,anbieter,Bewertung,FertigWann,typ) values ('" + film.getTitel() + "', '" + film.getAnbieter() + "'," + film.getSterne() + "," + film.getDatum() +",'Film'" + ")";
            com.ExecuteNonQuery();
            con.Close();            
            MessageBox.Show("Film erfolgreich hinzugefügt");
            
        }

        public void UpdateFilm(Filme film,string user, string altTitel, string altAnbieter)
        {
            con.Open();
            com.CommandText = "Update '" + user + "' SET titel = '" + film.getTitel() + "', anbieter ='" + film.getAnbieter() + "', bewertung='" + film.getSterne() + "', FertigWann='" + film.getDatum() + "' WHERE titel = '" + altTitel + "' AND anbieter ='" + altAnbieter + "' ";
            com.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Film erfolgreich geändert");
        }
        
        public void DelFilm(string titel, string anbieter, string user)
        {
            con.Open();
            com.CommandText = "DELETE FROM '" + user + "' WHERE titel = '" + titel + "' AND anbieter ='" + anbieter + "' AND typ ='Film'";
            com.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Film gelöscht");
        }
        public void getBuecher(string user)
        {
            string datum = "";
            string bewertung = "";
            //Absteigen sortieren
            //Alle Daten Holen
            con.Open();
            com.CommandText = "Select * from '" + user + "' where typ ='Buch' ORDER BY  FertigWann DESC, Titel ASC, creator ASC";
            reader = com.ExecuteReader();
            while (reader.Read())
            {
                buchTitel.Add(reader["titel"]);
                buchAutor.Add(reader["creator"]);
                bewertung = Helper.zahlInBewertung(reader["Bewertung"] + "");
                buchBewertung.Add(bewertung);
                datum = reader["FertigWann"] + "";
                if (datum == "0")
                {
                    buchDatum.Add("Unbekannt");
                }
                else
                    buchDatum.Add(datum);

            }
            reader.Close();
            con.Close();           
        }

        public void getGames(string user)
        {
            string datum = "";
            string bewertung = "";
            //Absteigen sortieren
            //Alle Daten Holen
            con.Open();
            com.CommandText = "Select * from '" + user + "' where typ ='Games' ORDER BY  FertigWann DESC, Titel ASC";
            reader = com.ExecuteReader();
            while (reader.Read())
            {
                gameTitel.Add(reader["titel"]);
                bewertung = Helper.zahlInBewertung(reader["Bewertung"] + "");
                gameBewertung.Add(bewertung);
                datum = reader["FertigWann"] + "";
                if (datum == "0")
                {
                    gameDatum.Add("Unbekannt");
                }
                else
                    gameDatum.Add(datum);

            }
            reader.Close();
            con.Close();
        }

        public void getFilme(string user)
        {
            //Doppelt liste ?
            string datum = "";
            string bewertung = "";
            con.Open();
            com.CommandText = "Select * from '" + user + "' where typ ='Film' ORDER BY  FertigWann DESC, Titel ASC, anbieter asc";
            reader = com.ExecuteReader();
            while (reader.Read())
            {
                filmTitel.Add(reader["titel"]);
                filmAnbieter.Add(reader["anbieter"]);
                bewertung = Helper.zahlInBewertung(reader["Bewertung"] + "");
                filmBewetung.Add(bewertung);
                datum = reader["FertigWann"] + "";
                if (datum == "0")
                {
                    filmDatum.Add("Unbekannt");
                }
                else
                    filmDatum.Add(datum);
            }
            reader.Close();
            con.Close();
        }

        public void getSerie(string user)
        {
            string datum = "";
            string beendet = "";
            string bewertung = "";
            con.Open();
            com.CommandText= "Select * from '" + user + "' where typ ='Serie' ORDER BY  FertigWann DESC, Titel ASC, anbieter ASC";
            reader = com.ExecuteReader();
            while (reader.Read())
            {
                serieTitel.Add(reader["titel"]);
                serieStaffel.Add(reader["Staffel"]);
                serieFolge.Add(reader["Folge"]);
                serieAnbieter.Add(reader["Anbieter"]);
                bewertung = Helper.zahlInBewertung(reader["Bewertung"] + "");
                serieBewetung.Add(bewertung);
                datum = reader["FertigWann"] + "";
                if (datum == "0")
                {
                    serieDatum.Add("Unbekannt");
                }
                else
                    serieDatum.Add(datum);
                beendet = reader["Fertig"]+"";
                if (beendet == "0")
                    serieBeendet.Add("Nein");
                else if (beendet == "1")
                    serieBeendet.Add("Ja");
            }
            reader.Close();
            con.Close();
        }

        //Bilder
        public BitmapImage getPB()
        {
            string base64 = "";
            con.Open();
            com.CommandText = "Select * from  Sonstiges where name= 'PB'" ;
            reader = com.ExecuteReader();
            while (reader.Read())
            {
                base64 = (String)reader["Base64"];
            }
            reader.Close();
            con.Close();

            byte[] imgBytes = Convert.FromBase64String(base64);
            BitmapImage bitmap = new BitmapImage();
            MemoryStream ms = new MemoryStream(imgBytes);
            bitmap.BeginInit();
            bitmap.StreamSource = ms;
            bitmap.EndInit();
            return bitmap;


        }
        public BitmapImage getSternLeer()
        {
            string base64 = "";
            con.Open();
            com.CommandText = "Select * from  Sonstiges where name= 'sLeer'";
            reader = com.ExecuteReader();
            while (reader.Read())
            {
                base64 = (String)reader["Base64"];
            }
            reader.Close();
            con.Close();

            byte[] imgBytes = Convert.FromBase64String(base64);
            BitmapImage bitmap = new BitmapImage();
            MemoryStream ms = new MemoryStream(imgBytes);
            bitmap.BeginInit();
            bitmap.StreamSource = ms;
            bitmap.EndInit();
            return bitmap;
        }

        public BitmapImage getSternVoll()
        {
            string base64 = "";
            con.Open();
            com.CommandText = "Select * from  Sonstiges where name= 'sVoll'";
            reader = com.ExecuteReader();
            while (reader.Read())
            {
                base64 = (String)reader["Base64"];
            }
            reader.Close();
            con.Close();

            byte[] imgBytes = Convert.FromBase64String(base64);
            BitmapImage bitmap = new BitmapImage();
            MemoryStream ms = new MemoryStream(imgBytes);
            bitmap.BeginInit();
            bitmap.StreamSource = ms;
            bitmap.EndInit();
            return bitmap;
        }


        
        
        

    }
}
