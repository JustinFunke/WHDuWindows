using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WHDuWindows
{
    class Filme
    {
        private string titel;
        private int sterne;  //int
        private int datum;
        private string anbieter;

        public Filme(string titel, int sterne, int datum, string anbieter)
        {
            this.titel = titel;
            this.sterne = sterne;
            this.datum = datum;
            this.anbieter = anbieter;
        }

        public string getTitel()
        {
            return this.titel;
        }
        public int getSterne()
        {
            return this.sterne;
        }
        public int getDatum()
        {
            return this.datum;
        }
        public string getAnbieter()
        {
            return this.anbieter;
        }
    }
}
