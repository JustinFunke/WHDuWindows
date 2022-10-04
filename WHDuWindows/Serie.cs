using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace WHDuWindows
{
    class Serie 
    {
        private string titel;
        private int folge;
        private int staffel;
        private int sterne;
        private int datum;
        private string anbieter;
        private int fertig = 0;

        public Serie(string titel, int folge, int staffel, int sterne, int datum, string anbieter,int fertig)
        {
            this.titel = titel;
            this.folge = folge;
            this.staffel = staffel;
            this.sterne = sterne;
            this.datum = datum;
            this.anbieter = anbieter;
            this.fertig = fertig;
        }

        public string getTitel()
        {
            return this.titel;
        }
        public string getAnbieter()
        {
            return this.anbieter;
        }

        public int getSterne()
        {
            return this.sterne;
        }

        public int getDatum()
        {
            return this.datum;
        }

        public int getStaffel()
        {
            return this.staffel;
        }

        public int getFolge()
        {
            return this.folge;
        }

        public int getFertig()
        {
            return this.fertig;
        }
    }
}