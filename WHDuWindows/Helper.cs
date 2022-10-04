using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WHDuWindows
{
    public class Helper
    {
        public static string zahlInBewertung(string zahl)
        {
            if (zahl == "1")
            {
                return "Sehr Schlecht";
            }
            else if (zahl == "2")
            {
                return "Schlecht";
            }
            else if (zahl == "3")
            {
                return "Mittelmäßig";
            }
            else if (zahl == "4")
            {
                return "Gut";
            }
            else if (zahl == "5")
            {
                return "Ausgezeichnet";
            }
            else if (zahl == "0")
                return "Keine";
            else
                return zahl;


        }
        
    }
}
