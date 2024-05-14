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
using Курсач_Джураева_1125;

namespace TaxiDispatcher4
{

    public partial class Hello : Window
    {
        public Hello()
        {
            InitializeComponent();

        }
        private void Duspecher_click(object sender, RoutedEventArgs e)
        {

            LogIn logIn = new LogIn();
            logIn.Show();
            this.Close();
        }
        private void Chirka_click(object sender, RoutedEventArgs e)
        {

            cirkaRegister cirkaRegister = new cirkaRegister();
            cirkaRegister.Show();
        }
    }
}