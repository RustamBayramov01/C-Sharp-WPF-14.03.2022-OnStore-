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
    /// Interaction logic for BasketPage.xaml
    /// </summary>
    public partial class BasketPage : Page
    {
        double totall = 0;
        int i = 0;

        List<string> name = new List<string>();
        List<string> price = new List<string>();

        string dosyayolu = @"C:\Users\LITHIUM\Desktop\Homework\WpfApp1\WpfApp1\SelectionName.txt";
        string dosyayolu2 = @"C:\Users\LITHIUM\Desktop\Homework\WpfApp1\WpfApp1\SelectionPrice.txt";


        public BasketPage()
        {
            InitializeComponent();
            
        }



        private void Refresh(object sender, RoutedEventArgs e)
        {
            name.Clear();
            price.Clear();
            i = 0;

            double total = 0;

            RemoveList.Items.Clear();

            FileStream fileStream1 = new FileStream(dosyayolu2, FileMode.OpenOrCreate, FileAccess.Read);
            using (StreamReader reader = new StreamReader(fileStream1))
            {
                while (true)
                {
                    string satir = reader.ReadLine();
                    price.Add(satir);

                    if (satir == null)
                    {
                        break;
                    }
                }
                reader.Close();
            }
            fileStream1.Close();



            FileStream fileStream = new FileStream(dosyayolu, FileMode.OpenOrCreate, FileAccess.Read);
            using (StreamReader reader = new StreamReader(fileStream))
            {
                while (true)
                {
                    string satir = reader.ReadLine();
                    name.Add(satir);

                    SelectionCatagoriContrik selection = new SelectionCatagoriContrik();
                    selection.name.Text = name[i];
                    selection.price.Text = "$" + price[i];

                    RemoveList.Items.Add(selection);
                    
                    i++;

                    if (satir == null) break;
                }
                reader.Close();
            }
            fileStream.Close();

            
            int index = RemoveList.Items.Count;
            RemoveList.Items.RemoveAt(index - 1);
            price.RemoveAt(index - 1);


            for (int i = 0; i < price.Count; i++)
            {
                total += double.Parse(price[i]);
                
            }


            totalPrice.Text = "$" + total.ToString();
        }

        private void Remove(object sender, RoutedEventArgs e)
        {

            int index = -1;
            index = RemoveList.SelectedIndex;


            if(index != -1)
            {

                name.Clear();

                i = 0;


                FileStream fileStream = new FileStream(dosyayolu, FileMode.OpenOrCreate, FileAccess.Read);
                using (StreamReader reader = new StreamReader(fileStream))
                {
                    while (true)
                    {
                        string satir = reader.ReadLine();

                        if (index != i)
                        {
                            name.Add(satir);
                        }

                        i++;

                        if (satir == null) break;
                    }
                    reader.Close();
                }
                fileStream.Close();

                File.Create(dosyayolu).Close();

                for (int i = 0; i < name.Count - 1; i++)
                {
                    File.AppendAllText(dosyayolu, name[i] + Environment.NewLine);
                }

                Path(index);
                Refresh(sender, e);
            }
            else
            {
                Info info = new Info();
                info.ShowDialog();

            }


        }
        

        public void Path(int Index)
        {

            int index = Index;

            price.Clear();

            i = 0;

            
            FileStream fileStream2 = new FileStream(dosyayolu2, FileMode.OpenOrCreate, FileAccess.Read);
            using (StreamReader reader = new StreamReader(fileStream2))
            {
                while (true)
                {
                    string satir = reader.ReadLine();

                    if (index != i)
                    {
                        price.Add(satir);
                    }

                    i++;

                    if (satir == null) break;
                }
                reader.Close();
            }
            fileStream2.Close();

            File.Create(dosyayolu2).Close();

            for (int i = 0; i < price.Count - 1; i++)
            {
                File.AppendAllText(dosyayolu2, price[i] + Environment.NewLine);
            }

        }

        private void Pay(object sender, RoutedEventArgs e)
        {
            totall = price.Count;
            if(totall != 0)
            {
                Succses succses = new Succses();
                succses.ShowDialog();

                totalPrice.Text = "$0,00";

                name.Clear();
                price.Clear();
                RemoveList.Items.Clear();

                File.Create(dosyayolu).Close();
                File.Create(dosyayolu2).Close();

            }
        }
    }
}
