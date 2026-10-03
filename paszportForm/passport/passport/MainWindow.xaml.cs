using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace passport
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            photoImage.Source = new BitmapImage(new Uri($"/Properties/{numberTextBox.Text}-zdjecie.jpg", UriKind.Relative));
            fingerprintImage.Source = new BitmapImage(new Uri($"/Properties/{numberTextBox.Text}-odcisk.jpg", UriKind.Relative));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string color = "";
            if (rBlue.IsChecked == true)
            {
                color = "blue";
            }
            if (rGreen.IsChecked == true)
            {
                color = "green";
            }
            if (rHazel.IsChecked == true)
            {
                color = "hazel";
            }

            if (numberTextBox.Text.Length > 0 && firstNameTextBox.Text.Length > 0 && lastNameTextBox.Text.Length > 0)
            {
                MessageBox.Show($"{firstNameTextBox.Text} {lastNameTextBox.Text} eye color {color}");
            }
            else
            {
                MessageBox.Show("Enter data");
            }
        }
    }
}