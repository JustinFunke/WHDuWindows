using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WHDuWindows
{
    public class Datensaetze
    {
        DatenbankMedien dbMedien = new DatenbankMedien();

        //Buch
        public ArrayList buchTitel = new ArrayList();
        public ArrayList buchAutor = new ArrayList();
        public ArrayList buchBewertung = new ArrayList();
        public ArrayList buchDatum = new ArrayList();
        //Games
        public ArrayList gameTitel = new ArrayList();
        public ArrayList gameBewertung = new ArrayList();
        public ArrayList gameDatum = new ArrayList();
        //Film
        public ArrayList filmTitel = new ArrayList();
        public ArrayList filmAnbieter = new ArrayList();
        public ArrayList filmBewetung = new ArrayList();
        public ArrayList filmDatum = new ArrayList();
        //serie
        public ArrayList serieTitel = new ArrayList();
        public ArrayList serieStaffel = new ArrayList();
        public ArrayList serieFolge = new ArrayList();
        public ArrayList serieAnbieter = new ArrayList();
        public ArrayList serieBewetung = new ArrayList();
        public ArrayList serieDatum = new ArrayList();
        public ArrayList serieBeendet = new ArrayList();

        private bool neu = false;
        private string neuWas = "";

        public bool Neu { get => neu; set => neu = value; }
        public string NeuWas { get => neuWas; set => neuWas = value; }

        public void datenbankListenFuellen(string user)
        {
            datenbankGamesFuellen(user);
            datenbankBuchFuellen(user);
            datenbankFilmFuellen(user);
            datenbankSerieFuellen(user);
        }
        public void datenbankGamesFuellen(string user)
        {
            gameTitel.Clear();
            gameBewertung.Clear();
            gameDatum.Clear();
            dbMedien.getGames(user);
            this.gameTitel = dbMedien.gameTitel;
            this.gameBewertung = dbMedien.gameBewertung;
            this.gameDatum = dbMedien.gameDatum;
        }
        public void datenbankBuchFuellen(string user)
        {
            buchTitel.Clear();
            buchAutor.Clear();
            buchBewertung.Clear();
            buchDatum.Clear();
            dbMedien.getBuecher(user);
            this.buchTitel = dbMedien.buchTitel;
            this.buchAutor = dbMedien.buchAutor;
            this.buchBewertung = dbMedien.buchBewertung;
            this.buchDatum = dbMedien.buchDatum;
        }
        public void datenbankFilmFuellen(string user)
        {
            filmTitel.Clear();
            filmAnbieter.Clear();
            filmBewetung.Clear();
            filmDatum.Clear();
            dbMedien.getFilme(user);
            Console.WriteLine(dbMedien.filmTitel.Count);
            this.filmTitel = dbMedien.filmTitel;
            this.filmAnbieter = dbMedien.filmAnbieter;
            this.filmBewetung = dbMedien.filmBewetung;
            this.filmDatum = dbMedien.filmDatum;
            
        }
        public void datenbankSerieFuellen(string user)
        {
            serieTitel.Clear();
            serieStaffel.Clear();
            serieFolge.Clear();
            serieAnbieter.Clear();
            serieBewetung.Clear();
            serieDatum.Clear();
            serieBeendet.Clear();
            dbMedien.getSerie(user);
            Console.WriteLine(dbMedien.serieTitel.Count);
            this.serieTitel = dbMedien.serieTitel;
            this.serieStaffel = dbMedien.serieStaffel;
            this.serieFolge = dbMedien.serieFolge;
            this.serieAnbieter = dbMedien.serieAnbieter;
            this.serieBewetung = dbMedien.serieBewetung;
            this.serieDatum = dbMedien.serieDatum;
            this.serieBeendet = dbMedien.serieBeendet;
        }
    }
}
