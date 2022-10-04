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
    /// Interaktionslogik für RegistriernScreen.xaml
    /// </summary>
    public partial class RegistriernScreen : Window
    {

        bool clickVorname = false;
        bool clickNachname = false;
        bool clickUsername = false;
        bool clickEmail = false;
        public RegistriernScreen()
        {
            InitializeComponent();
        }

        private void cmdRegistrieren_Click(object sender, RoutedEventArgs e)
        {
            if(chkAGB.IsChecked != true)
            {
                MessageBox.Show("Sie müssen die AGB akzeptieren");
                return;
            }
            RegistrierenCode RC = new RegistrierenCode();
            RC.ReturnElements(txtVorname.Text, txtNachname.Text, txtUsername.Text, txtPasswort.Password, txtEmail.Text);
            if (RC.RegistrierenDuchfuehren().Equals("E"))
            {
                this.Close();
            }
            
        }

                   
        private void txtVorname_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!clickVorname)
            {
                txtVorname.Text = "";
                clickVorname = true;
            }
        }

        private void txtNachname_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!clickNachname)
            {
                txtNachname.Text = "";
                clickNachname = true;
            }
        }

        private void txtEmail_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!clickEmail)
            {
                txtEmail.Text = "";
                clickEmail = true;
            }
        }

        private void txtUsername_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!clickUsername)
            {
                txtUsername.Text = "";
                clickUsername = true;
            }
        }
        
        private void cmdCloseRegistrieren_MouseLeftButtonDown(object sender, RoutedEventArgs e)
        {
            LoginScreen screen = new LoginScreen();
            this.Close();          
            screen.Show();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }



        ////////////////////////////////////////////Nicht///////////////////////////////////
        private void txtVorname_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtPasswort_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void txtPasswort_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
