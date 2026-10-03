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

namespace rgb
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            sliderR.Value = 255;
            sliderG.Value = 255;
            sliderB.Value = 255;
        }

        private void btnPick_Click(object sender, RoutedEventArgs e)
        {
            byte r = (byte)sliderR.Value;
            byte g = (byte)sliderG.Value;
            byte b = (byte)sliderB.Value;

            lblSmallRec.Content = $"{r} {g} {b}";

            Color newColor = Color.FromRgb(r, g, b);
            smallRec.Fill = new SolidColorBrush(newColor);

            lblR.Content = r;
            lblG.Content = g;
            lblB.Content = b;
        }


        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (lblR != null && lblG != null && lblB != null && sliderR != null && sliderG != null && sliderB != null)
            {
                byte r = (byte)sliderR.Value;
                byte g = (byte)sliderG.Value;
                byte b = (byte)sliderB.Value;

                Color newColor = Color.FromRgb(r, g, b);
                bigRec.Fill = new SolidColorBrush(newColor);

                lblR.Content = r;
                lblG.Content = g;
                lblB.Content = b;
            }
        }
    }
}