using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WHDuWindows
{
    class Games
    {
        private string titel;
        private int sterne;  //int
        private int datum;

        public Games(string titel, int sterne, int datum)
        {
            this.titel = titel;
            this.sterne = sterne;
            this.datum = datum;

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
    }
}
