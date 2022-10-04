using System;
using System.Configuration;
using System.Data.SQLite;
using System.Collections;
using System.Windows;

namespace WHDuWindows
{
    class Datenbank
    {
        
        //private static string dbPath = Application.path + "\\" + "WHDuDatabase.db;";
        private static string conString = "Data Source=WHDuDatabase.db;Version=3;"; //Hier hönnte ein Fehler sein
        private static SQLiteConnection con = new SQLiteConnection(conString);
        private static SQLiteCommand com = new SQLiteCommand(con);
        private static SQLiteDataReader reader;
        

        
        //Registrieren
        public void NutzerHinzufuegen(string vorname,string nachname, string username, string passwort, string timestamp, string email)
        {
            try
            {
                con.Open();
                com.CommandText = "insert into login(vorname,nachname,username,passwort,timestamp,email) values ('"+vorname+"', '"+nachname+"', '"+username+"','"+passwort+"','"+timestamp+ "','"+email+"')";                
                com.ExecuteNonQuery();
                con.Close();
                Console.WriteLine("Nutzer erfolgreich hinzugefügt");

            }
            catch(SQLiteException ex)
            {
                Console.WriteLine(ex.ErrorCode);
            }
            tableHinzufuegen(username);


            
        }

        public void tableHinzufuegen(string username)
        {
            try
            {
                con.Open();
                com.CommandText = "CREATE TABLE '"+username+"' ('ID'INTEGER,'Titel'	TEXT NOT NULL,'Creator'	TEXT,'Staffel'INTEGER,'Folge'	INTEGER,'Fertig'INTEGER,'Bewertung'	INTEGER,'FertigWann'	TEXT,'Anbieter'	TEXT,'AufPC'	TEXT,'Typ'	TEXT,PRIMARY KEY('ID' AUTOINCREMENT));";
                com.ExecuteNonQuery();
                con.Close();
                Console.WriteLine("Table erfolgreich erstellt");
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine(ex.ErrorCode);
            }
        }


        public bool UsernameVergeben(string user)
        {
            ArrayList list = new ArrayList();

            try
            {

                con.Open();
                com.CommandText= "select * from login";                                             
                reader = com.ExecuteReader();
                
                while (reader.Read())
                {
                    list.Add(reader["Username"]);
                }
                reader.Close();
                con.Close();


                for (int i = 0; i < list.Count; i++)
                {
                    if (String.Equals((string)list[i], user, StringComparison.OrdinalIgnoreCase)) //(userList[i].Equals(username))
                    {

                        return true;
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("FehlerUser");
            }
            return false;

        }

        public bool EmailVergeben(string email)
        {
            ArrayList list = new ArrayList();
            try
            {
                //conn.Open();//
                //command.CommandText = "select * from benutzer";//

                con.Open();
                com.CommandText = "select * from login";
                reader = com.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(reader["Email"]);
                }
                reader.Close();
                con.Close();


                for (int i = 0; i < list.Count; i++)
                {

                    if (String.Equals((string)list[i], email, StringComparison.OrdinalIgnoreCase))
                    {

                        return true;
                    }
                }
                //conn.Close();//
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("FehlerEmail");
            }
            return false;
        }

        //Login

        public string Login(string email)
        {
            string passwort="";
            
            
            try
            {
                con.Open();
                com.CommandText = "select passwort from login where Email='"+email+"'";
                reader = com.ExecuteReader();

                while (reader.Read())
                {
                    passwort =""+(reader["passwort"]);
                }
                reader.Close();
                con.Close();
                return passwort;

            }
            catch(SQLiteException ex)
            {
                Console.WriteLine(ex.ErrorCode);
                return "";
            }
        }

        public string user(string email)
        {
            string username ="";
            try
            {
                con.Open();
                com.CommandText = "select Username from login where Email='" + email + "'";
                reader = com.ExecuteReader();

                while (reader.Read())
                {
                    username = "" + (reader["Username"]);
                }
                reader.Close();
                con.Close();
                return username;
            }

        
            catch(SQLiteException ex)
            {
                Console.WriteLine(ex.ErrorCode);
                return username;
            }
            
            
        }
    }




}
