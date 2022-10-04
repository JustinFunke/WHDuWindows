using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Collections;
using System.Windows.Forms;

namespace WHDuWindows
{
    public class RegistrierenCode
    {
        private string username;
        private string vorname;
        private string nachname;
        private string passwort;
        private string email;
        private string hashedPasswort;
        private string timestamp;


        


         private ArrayList emailList = new ArrayList();
         private  ArrayList userList = new ArrayList();
         private LoginScreen loginScreen = new LoginScreen();
         Datenbank db = new Datenbank();

        public void ReturnElements(string vorname, string nachname, string username, string passwort, string email)
        {
            
            this.vorname = vorname.Replace(" ", "");
            this.nachname = nachname.Replace(" ", "");
            this.username = username.Replace(" ", "");
            this.passwort = passwort.Replace(" ","");
            this.email = email;
            this.timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
        }



      
        public string RegistrierenDuchfuehren()
        {
            if (!vorname.Equals("") && !vorname.Equals("Vorname") && !nachname.Equals("") && !nachname.Equals("Nachname") && !username.Equals("") && !username.Equals("Username") && !email.Equals("Email") && !email.Equals("") && !passwort.Equals("") && !passwort.Equals("Passwort"))
            {

                //Prüfen ob Gültig
                if (!EmailIstGueltig())
                {
                    MessageBox.Show("Email nicht Gültig");

                    return "NE";
                }
                if (!KeineZahl(vorname) || !KeineZahl(nachname))
                {
                    MessageBox.Show("Namen haben keine Zahl");
                    return "NE";
                }
                if (db.EmailVergeben(email))
                {
                    MessageBox.Show("Email schon Registriert");
                    return "NE";
                }
                if (db.UsernameVergeben(username))
                {
                    MessageBox.Show("Username schon vergeben");
                    return "NE";
                }


                try
                {

                    //Passwort codieren mit trrr und Timestamp
                    ConvertHash CH = new ConvertHash();
                    this.hashedPasswort = CH.toHash(this.passwort, this.email);
                    //Umwandlung in Hash
                    db.NutzerHinzufuegen(vorname, nachname, username, this.hashedPasswort, timestamp, email);
                    MessageBox.Show("Erfolgreich Registriert");
                    //Fenster Schließen
                    loginScreen.Show();
                    return "E";

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return "NE";
                }

            }
            else
            {
                MessageBox.Show("Füllen Sie alle Felder aus");
                return "NE";
            }

        }

        private bool KeineZahl(string a)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(a, "^[a-zA-Z ]*$"))
                return false;
            return true;
        }
        

        

        

        private bool EmailIstGueltig()
        {
            var foo = new EmailAddressAttribute();
            if (foo.IsValid(email))
                return true;
            return false;
        }
    }

}
