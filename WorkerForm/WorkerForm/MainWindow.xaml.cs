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

namespace WorkerForm
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

        private string finalPassword = "";

        private void btnGenerate_Click(object sender, RoutedEventArgs e)
        {
            // password
            string lowerLetters = "abcdefghijklmnopqrstuvwxyz";
            string upperLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string digits = "0123456789";
            string specialChars = "!@#$%^&*()_+-=";

            if (!int.TryParse(charCountTextBox.Text, out int length) || length <= 0)
            {
                MessageBox.Show("Idiot"); // Zostawiłem Twoją oryginalną wiadomość, tylko po angielsku :)
                return;
            }

            Random rand = new Random();

            char[] passwordArray = new char[length];

            for (int i = 0; i < length; i++)
            {
                passwordArray[i] = lowerLetters[rand.Next(0, lowerLetters.Length)];
            }

            if (lowerUpperCheckBox.IsChecked == true && length > 0)
            {
                passwordArray[0] = upperLetters[rand.Next(0, upperLetters.Length)];
            }
            if (digitsCheckBox.IsChecked == true && length > 1)
            {
                passwordArray[1] = digits[rand.Next(0, digits.Length)];
            }
            if (specialCheckBox.IsChecked == true && length > 2)
            {
                passwordArray[2] = specialChars[rand.Next(0, specialChars.Length)];
            }
            finalPassword = new string(passwordArray);
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Employee details: {firstNameTextBox.Text} {lastNameTextBox.Text} {positionComboBox.Text} Password: {finalPassword}");
        }
    }
}