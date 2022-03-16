using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for AddPage.xaml
    /// </summary>
    public partial class AddPage : Page
    {

        string dosyayolu = @"C:\Users\LITHIUM\Desktop\Homework\WpfApp1\WpfApp1\ImagePath.txt";
        string dosyayoluName = @"C:\Users\LITHIUM\Desktop\Homework\WpfApp1\WpfApp1\ImageName.txt";
        string dosyayoluPriece = @"C:\Users\LITHIUM\Desktop\Homework\WpfApp1\WpfApp1\ImagePrice.txt";
        string dosyayoluVerif = @"C:\Users\LITHIUM\Desktop\Homework\WpfApp1\WpfApp1\Verif.txt";

        OpenFileDialog op = new OpenFileDialog();
        bool verif = false;


        public AddPage()
        {
            InitializeComponent();

            Border2.Visibility = Visibility.Hidden;
        }


        private void Add(object sender, RoutedEventArgs e)
        {
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                Border1.Visibility = Visibility.Hidden;
                Border2.Visibility = Visibility.Visible;

                SelectionName.Source = new BitmapImage(new Uri(op.FileName));
                verif = true;
            }
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            if(Price.Text.Length != 0 && Name.Text.Length != 0 && verif == true)
            {
                File.AppendAllText(dosyayolu, op.FileName + Environment.NewLine);
                File.AppendAllText(dosyayoluName, Name.Text + Environment.NewLine);
                File.AppendAllText(dosyayoluPriece, Price.Text + Environment.NewLine);
                File.WriteAllText(dosyayoluVerif, "True" + Environment.NewLine);

                Price.Text = null;
                Name.Text = null;
                verif = false;
                SelectionName.Source = null;
                Border1.Visibility = Visibility.Visible;
                Border2.Visibility = Visibility.Hidden;
            }
        }

       
    }
}
