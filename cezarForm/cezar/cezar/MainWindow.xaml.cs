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
using Microsoft.Win32;

namespace cezar
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

        private void btnEncrypt_Click(object sender, RoutedEventArgs e)
        {
            string keyRaw = keyTBox.Text;
            string textRaw = normalTextTBox.Text;
            string encryptedText = "";
            List<int> unicodeText = new List<int>();

            int key = 0;

            try
            {
                key = Int32.Parse(keyRaw);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            int trueKey = key = key % 26;
            if (trueKey < 0) trueKey += 26;
            int codedText = 0;

            for (int i = 0; i < textRaw.Length; i++)
            {
                if (textRaw[i] == ' ')
                {
                    codedText = 32;
                }
                else
                {
                    codedText = (int)textRaw[i] + trueKey;

                    if (codedText > 97) codedText += 26;
                    if (codedText > 122) codedText -= 26;
                }
                unicodeText.Add(codedText);
            }
            for (int i = 0; i < unicodeText.Count; i++)
            {
                encryptedText += (char)unicodeText[i];
            }
            encryptedTextTBlock.Text = encryptedText;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            string textToSave = encryptedTextTBlock.Text;
            if (string.IsNullOrEmpty(textToSave))
            {
                MessageBox.Show("You must encrypt the text first to save it!");
                return;
            }

            SaveFileDialog saveDialog = new SaveFileDialog();

            saveDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            saveDialog.Title = "Select save location for the encrypted text";
            saveDialog.FileName = "encrypted_text.txt";

            if (saveDialog.ShowDialog() == true)
            {
                try
                {
                    System.IO.File.WriteAllText(saveDialog.FileName, textToSave);

                    MessageBox.Show("File saved successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while saving the file: " + ex.Message);
                }
            }
        }
    }
}