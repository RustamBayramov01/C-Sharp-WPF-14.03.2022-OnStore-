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
    /// Interaction logic for MenuPage.xaml
    /// </summary>
    public partial class MenuPage : Page
    {

        string Verif;

        List<string> SelectionName = new List<string> { };
        List<string> TotalMoney = new List<string> { };

        List<string> SelectionNameCopy = new List<string> { };
        List<string> TotalMoneyCopy = new List<string> { };
        List<string> TotalPath = new List<string> { };

        public MenuPage()
        {

            InitializeComponent();

            SelectionName.Clear();
            TotalMoney.Clear();


            string dosyayolu1 = @"C:\Users\LITHIUM\Desktop\Homework\WpfApp1\WpfApp1\AllFood.txt";
            FileStream fileStream1 = new FileStream(dosyayolu1, FileMode.OpenOrCreate, FileAccess.Read);
            using (StreamReader reader = new StreamReader(fileStream1))
            {
                while (true)
                {
                    string satir = reader.ReadLine();
                    SelectionName.Add(satir);
                    if (satir == null) break;
                }
                reader.Close();
            }
            fileStream1.Close();


            string dosyayolu2 = @"C:\Users\LITHIUM\Desktop\Homework\WpfApp1\WpfApp1\AllPrice.txt";
            FileStream fileStream2 = new FileStream(dosyayolu2, FileMode.OpenOrCreate, FileAccess.Read);
            using (StreamReader reader = new StreamReader(fileStream2))
            {
                while (true)
                {
                    string satir = reader.ReadLine();
                    TotalMoney.Add(satir);
                    if (satir == null) break;
                }
                reader.Close();
            }
            fileStream2.Close();


            string dosyayoluVerif = @"C:\Users\LITHIUM\Desktop\Homework\WpfApp1\WpfApp1\Verif.txt";
            FileStream fileStream3 = new FileStream(dosyayoluVerif, FileMode.OpenOrCreate, FileAccess.Read);
            using (StreamReader reader = new StreamReader(fileStream3))
            {
                while (true)
                {
                    string satir = reader.ReadLine();
                    Verif += satir;
                    if (satir == null) break;
                }
                reader.Close();
            }
            fileStream3.Close();

            if(Verif == "True")
            {
                string dosyayoluName = @"C:\Users\LITHIUM\Desktop\Homework\WpfApp1\WpfApp1\ImageName.txt";
                FileStream fileStream4 = new FileStream(dosyayoluName, FileMode.OpenOrCreate, FileAccess.Read);
                using (StreamReader reader = new StreamReader(fileStream4))
                {
                    while (true)
                    {
                        string satir = reader.ReadLine();
                        SelectionNameCopy.Add(satir);
                        if (satir == null) break;
                    }
                    reader.Close();
                }
                fileStream4.Close();


                string dosyayoluPrice = @"C:\Users\LITHIUM\Desktop\Homework\WpfApp1\WpfApp1\ImagePrice.txt";
                FileStream fileStream5 = new FileStream(dosyayoluPrice, FileMode.OpenOrCreate, FileAccess.Read);
                using (StreamReader reader = new StreamReader(fileStream5))
                {
                    while (true)
                    {
                        string satir = reader.ReadLine();
                        TotalMoneyCopy.Add(satir);
                        if (satir == null) break;
                    }
                    reader.Close();
                }
                fileStream5.Close();


                string dosyayoluPath = @"C:\Users\LITHIUM\Desktop\Homework\WpfApp1\WpfApp1\ImagePath.txt";
                FileStream fileStream6 = new FileStream(dosyayoluPath, FileMode.OpenOrCreate, FileAccess.Read);
                using (StreamReader reader = new StreamReader(fileStream6))
                {
                    while (true)
                    {
                        string satir = reader.ReadLine();
                        TotalPath.Add(satir);
                        if (satir == null) break;
                    }
                    reader.Close();
                }
                fileStream6.Close();



                for (int i = 0; i < SelectionNameCopy.Count - 1; i++)
                {
                    string Name = SelectionNameCopy[i];
                    string Price = "$" + TotalMoneyCopy[i];
                    string path = TotalPath[i];

                    BitmapImage logo = new BitmapImage();
                    logo.BeginInit();
                    logo.UriSource = new Uri(path);
                    logo.EndInit();

                    ButtonUsecontrol buttonUsecontrol = new ButtonUsecontrol
                    {
                        
                    };

                    buttonUsecontrol.Add.Click += MouseClickk;

                    buttonUsecontrol.Name.Text = Name;
                    buttonUsecontrol.Price.Text = Price;
                    buttonUsecontrol.Image.Source = logo; 

                    listBox.Items.Add(buttonUsecontrol);

                }
            }

        }

        private void MouseClickk(object sender, EventArgs e)
        {
            int index = -1;
            index = listBox.SelectedIndex;

            if (index != -1)
            {
                string dosyayolu1 = @"C:\Users\LITHIUM\Desktop\Homework\WpfApp1\WpfApp1\SelectionName.txt";
                string dosyayolu2 = @"C:\Users\LITHIUM\Desktop\Homework\WpfApp1\WpfApp1\SelectionPrice.txt";
                File.AppendAllText(dosyayolu1, SelectionNameCopy[index - 6] + Environment.NewLine);
                File.AppendAllText(dosyayolu2, TotalMoneyCopy[index - 6] + Environment.NewLine);

            }
            else
            {

                Info info = new Info();
                info.ShowDialog();

            }
        }



        private void Add(object sender, RoutedEventArgs e)
        {
            int index = -1;
            index = listBox.SelectedIndex;

            if(index != -1)
            {

                string dosyayolu1 = @"C:\Users\LITHIUM\Desktop\Homework\WpfApp1\WpfApp1\SelectionName.txt";
                string dosyayolu2 = @"C:\Users\LITHIUM\Desktop\Homework\WpfApp1\WpfApp1\SelectionPrice.txt";
                File.AppendAllText(dosyayolu1, SelectionName[index] + Environment.NewLine);
                File.AppendAllText(dosyayolu2, TotalMoney[index] + Environment.NewLine);

            }
            else
            {

                Info info = new Info();
                info.ShowDialog();

            }

        }
    }
}
