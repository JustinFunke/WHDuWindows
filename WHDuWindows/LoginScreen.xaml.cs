using WHDuWindows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WHDuWindows
{
    /// <summary>
    /// Interaktionslogik für LoginScreen.xaml
    /// </summary>
    public partial class LoginScreen : Window
    {

        RegistriernScreen RegistrierenForm = new RegistriernScreen();
        MainWindow MainWindowForm = new MainWindow();
        ConvertHash CH = new ConvertHash();
        Datenbank db = new Datenbank();


        public LoginScreen()
        {
            InitializeComponent();
        }
        private void LoginWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void CmdLogin_Click(object sender, RoutedEventArgs e)
        {
            if (db.EmailVergeben(txtEmail.Text.Replace(" ", "")) && !txtPasswort.Password.Equals(""))      //Passwort checken
            {
                string hashPasswort = "";

                Console.WriteLine("Bin in IF");

                try
                {

                    hashPasswort = db.Login(txtEmail.Text.Replace(" ", ""));
                    Console.WriteLine(hashPasswort);
                    //erfolgreich =CH.checkHash(txtPasswort.Text, hashPasswort, sqlRegisterTime);
                    if (CH.checkHash(txtPasswort.Password, hashPasswort, txtEmail.Text.Replace(" ", "")))
                    {
                        Console.WriteLine("Erfolgreich eingeloggt");
                        MainWindowForm.setUser(db.user(txtEmail.Text.Replace(" ", "")));
                        this.Close();
                        MainWindowForm.Show();
                    }                       
                    else
                    {

                        
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Email oder Passwort falsch!");
            }
        }

        private void cmdCloseLogin_Click(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void cmdRegistrieren_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            RegistrierenForm.Show();
        }

        private void txtEmail_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            

        }

        private void CmdLogin_Click(object sender, DragEventArgs e)
        {

        }
    }
}
