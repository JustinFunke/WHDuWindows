using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WHDuWindows
{
    class Buecher
    {
        private string titel;
        private string autor;
        private int sterne;  //int
        private int datum;

        public Buecher(string titel, string autor, int sterne, int datum)
        {
            this.titel = titel;
            this.autor = autor;
            this.sterne = sterne;   //int
            this.datum = datum;
        }

        public string getTitel()
        {
            return this.titel;
        }

        public string getAutor()
        {
            return this.autor;
        }

        public int getSterne()
        {
            return this.sterne;
        }
        public int getDatum()
        {
            return this.datum;
        }
        
    }
    
}
