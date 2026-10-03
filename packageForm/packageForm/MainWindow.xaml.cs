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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace packageForm
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnCheckPrice_Click(object sender, RoutedEventArgs e)
        {
            // CHECK PRICE
            if (rPostcard.IsChecked == true)
            {
                imgPackageType.Source = new BitmapImage(new Uri("pocztowka.png", UriKind.Relative));
                lblPrice.Content = "Price: $1";
            }
            else if (rLetter.IsChecked == true)
            {
                imgPackageType.Source = new BitmapImage(new Uri("list.png", UriKind.Relative));
                lblPrice.Content = "Price: $1.5";
            }
            else if (rPackage.IsChecked == true)
            {
                imgPackageType.Source = new BitmapImage(new Uri("paczka.png", UriKind.Relative));
                lblPrice.Content = "Price: $10";
            }
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            if (postalCodeTextBox.Text.Length != 5)
            {
                MessageBox.Show("Invalid number of digits in postal code");
            }
            else if (!int.TryParse(postalCodeTextBox.Text, out _)) // _ = discard
            {
                MessageBox.Show("Postal code should consist of digits only");
            }
            else
            {
                MessageBox.Show("Shipment details have been entered successfully");
            }
        }
    }
}