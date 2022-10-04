using System;
using System.Text;
using System.Security.Cryptography;
using System.Windows;

namespace WHDuWindows
{
    public class ConvertHash
    {
        private String rzz = "WHDU232321##&&JustinFunke";
        public string toHash(string rowBlankPasswort,string sqlRegisterTime)
        {

            //Combinate
            
            string rowPasswort = rzz + rowBlankPasswort + sqlRegisterTime.Replace(" ","");
            Console.WriteLine(rowPasswort);
            //To hash
            byte[] tmpSource;
            byte[] tmpHash;
            tmpSource = ASCIIEncoding.ASCII.GetBytes(rowPasswort);
            tmpHash = new SHA256CryptoServiceProvider().ComputeHash(tmpSource);

            //Convert to String

            StringBuilder builder = new StringBuilder();
            for(int i =0; i<tmpHash.Length; i++)
            {
                builder.Append(tmpHash[i].ToString("x2"));
            }
            Console.WriteLine(builder);

            return builder.ToString();
        }

        public bool checkHash(string passwortEingabe, string hashpasswort, string email)
        {
            byte[] tmpSource;
            byte[] tmpNewHash;
            byte[] tmpHash;

            //Console.WriteLine(sqlRegisterTime);
            string rowPasswort = rzz + passwortEingabe + email.Replace(" ", "");
            
            tmpHash = ASCIIEncoding.ASCII.GetBytes(hashpasswort);

            tmpSource = ASCIIEncoding.ASCII.GetBytes(rowPasswort);
            tmpNewHash = new SHA256CryptoServiceProvider().ComputeHash(tmpSource);


            //Convert to Sting 
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < tmpNewHash.Length; i++)
            {
                builder.Append(tmpNewHash[i].ToString("x2"));
            }
            //Console.WriteLine(builder);
            //rowPasswort = builder.ToString;
            tmpNewHash = ASCIIEncoding.ASCII.GetBytes(builder.ToString());
            //MessageBox.Show("Bin CheckHash");

            if (hashpasswort.Equals(builder.ToString()))
            {
                Console.WriteLine("Hat geklappt");
                return true;
            }
            else
            {
                MessageBox.Show("Falsches Passwort");
                return false;
            }

            
                                    
        }

        



    }
}
