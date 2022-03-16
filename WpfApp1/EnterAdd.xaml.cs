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
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for EnterAdd.xaml
    /// </summary>
    public partial class EnterAdd : Window
    {

        public string SearchName { get; set; }
        public string SearchPrice { get; set; }
        public string SearchImagePath { get; set; }


        OpenFileDialog op = new OpenFileDialog();


        BitmapImage logo = new BitmapImage();

        public int Index { get; set; }

        List<string> AllName = new List<string> { };
        List<string> AllPrice = new List<string> { };


        public EnterAdd()
        {
            InitializeComponent();
           
        }

        public void Searchh(string name, string price, string path)
        {
            SearchName = name;
            SearchPrice = price;
            SearchImagePath = path;

            Name.Text = SearchName;
            Price.Text = "$" + SearchPrice;

            if (Index == 0) 
            {

                Uri resourceUri = new Uri("Food/Burger.png", UriKind.Relative);
                Image.Source = new BitmapImage(resourceUri); 
            }
            else if (Index == 1)
            {

                Uri resourceUri = new Uri("Food/ChickenFries.png", UriKind.Relative);
                Image.Source = new BitmapImage(resourceUri);
            }
            else if (Index == 2)
            {

                Uri resourceUri = new Uri("Food/Fries.png", UriKind.Relative);
                Image.Source = new BitmapImage(resourceUri);
            }
            else if (Index == 3)
            {

                Uri resourceUri = new Uri("Food/Pizza.png", UriKind.Relative);
                Image.Source = new BitmapImage(resourceUri);
            }
            else if (Index == 4)
            {

                Uri resourceUri = new Uri("Food/Chicken Nuggets.png", UriKind.Relative);
                Image.Source = new BitmapImage(resourceUri);
            }
            else if (Index == 5)
            {

                Uri resourceUri = new Uri("Food/CocaCola.png", UriKind.Relative);
                Image.Source = new BitmapImage(resourceUri);
            }
            else
            {

                logo.BeginInit();
                logo.UriSource = new Uri(path);
                logo.EndInit();
                
                Image.Source = logo;
            }

        }


        public void IndexSearch(int other)
        {
            Index = other;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            string dosyayolu1 = @"C:\Users\LITHIUM\Desktop\Homework\WpfApp1\WpfApp1\AllFood.txt";
            FileStream fileStream5 = new FileStream(dosyayolu1, FileMode.OpenOrCreate, FileAccess.Read);
            using (StreamReader reader = new StreamReader(fileStream5))
            {
                while (true)
                {
                    string satir = reader.ReadLine();
                    AllName.Add(satir);
                    if (satir == null) break;
                }
                reader.Close();
            }
            fileStream5.Close();

            string dosyayolu2 = @"C:\Users\LITHIUM\Desktop\Homework\WpfApp1\WpfApp1\ImageName.txt";
            FileStream fileStream6 = new FileStream(dosyayolu2, FileMode.OpenOrCreate, FileAccess.Read);
            using (StreamReader reader = new StreamReader(fileStream6))
            {
                while (true)
                {
                    string satir = reader.ReadLine();
                    AllName.Add(satir);
                    if (satir == null) break;
                }
                reader.Close();
            }
            fileStream6.Close();


            string dosyayolu12 = @"C:\Users\LITHIUM\Desktop\Homework\WpfApp1\WpfApp1\AllPrice.txt";
            FileStream fileStream55 = new FileStream(dosyayolu12, FileMode.OpenOrCreate, FileAccess.Read);
            using (StreamReader reader = new StreamReader(fileStream55))
            {
                while (true)
                {
                    string satir = reader.ReadLine();
                    AllPrice.Add(satir);
                    if (satir == null) break;
                }
                reader.Close();
            }
            fileStream55.Close();


            string dosyayolu13 = @"C:\Users\LITHIUM\Desktop\Homework\WpfApp1\WpfApp1\ImagePrice.txt";
            FileStream fileStream54 = new FileStream(dosyayolu13, FileMode.OpenOrCreate, FileAccess.Read);
            using (StreamReader reader = new StreamReader(fileStream54))
            {
                while (true)
                {
                    string satir = reader.ReadLine();
                    AllPrice.Add(satir);
                    if (satir == null) break;
                }
                reader.Close();
            }
            fileStream54.Close();


            for (int i = 0; i < AllName.Count; i++)
            {
                if(SearchName == AllName[i])
                {

                    if(i <= 5)
                    {

                        string dosyayolu11 = @"C:\Users\LITHIUM\Desktop\Homework\WpfApp1\WpfApp1\SelectionName.txt";
                        string dosyayolu22 = @"C:\Users\LITHIUM\Desktop\Homework\WpfApp1\WpfApp1\SelectionPrice.txt";
                        File.AppendAllText(dosyayolu11, AllName[Index] + Environment.NewLine);
                        File.AppendAllText(dosyayolu22, AllPrice[Index] + Environment.NewLine);
                      
                    }
                    else
                    {

                        string dosyayolu11 = @"C:\Users\LITHIUM\Desktop\Homework\WpfApp1\WpfApp1\SelectionName.txt";
                        string dosyayolu22 = @"C:\Users\LITHIUM\Desktop\Homework\WpfApp1\WpfApp1\SelectionPrice.txt";
                        File.AppendAllText(dosyayolu11, AllName[Index] + Environment.NewLine);
                        File.AppendAllText(dosyayolu22, AllPrice[Index - 1] + Environment.NewLine);
                        Name.Text = (i - Index).ToString();
                       
                        // Davam
                    }

                    break;
                    
                }
            }

        }



        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
