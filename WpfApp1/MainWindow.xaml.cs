using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        int index = 0;

        DispatcherTimer dispatcherTimer1 = new DispatcherTimer();
        DispatcherTimer dispatcherTimer2 = new DispatcherTimer();

        List<string> Verif = new List<string> { };
        List<string> VerifPrice = new List<string> { };
        List<string> VerifImage = new List<string> { };


        static int incerement = 120;
        bool CatagoriBorderVerif = false;

        MenuPage menuPage = new MenuPage();

        BasketPage BasketPage = new BasketPage();
        AddPage addPage = new AddPage();


        public MainWindow()
        {
            InitializeComponent();
            

            string dosyayolu1 = @"C:\Users\LITHIUM\Desktop\Homework\WpfApp1\WpfApp1\SelectionName.txt";
            string dosyayolu2 = @"C:\Users\LITHIUM\Desktop\Homework\WpfApp1\WpfApp1\SelectionPrice.txt";

            File.Delete(dosyayolu1);
            File.Delete(dosyayolu2);

            string dosyayoluName = @"C:\Users\LITHIUM\Desktop\Homework\WpfApp1\WpfApp1\ImageName.txt";
            string dosyayoluPrice = @"C:\Users\LITHIUM\Desktop\Homework\WpfApp1\WpfApp1\ImagePrice.txt";
            string dosyayoluPath = @"C:\Users\LITHIUM\Desktop\Homework\WpfApp1\WpfApp1\ImagePath.txt";

            File.Delete(dosyayoluName);
            File.Delete(dosyayoluPrice);
            File.Delete(dosyayoluPath);

            PrviousImage.Source = new BitmapImage(new Uri("Icon/previous.png", UriKind.Relative));
            CatagoriBorderMargin.Margin = new Thickness(120, 0, 0, 0);
            CatagoriBorderVerif = true;

            TextSearch.Text = "Search";
            

            BasketFrame.Navigate(menuPage);

        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try { DragMove(); }
            catch (Exception) { throw; }
        }

        private void MenuButton(object sender, RoutedEventArgs e)
        {


            if (CatagoriBorderVerif == false)
            {
                dispatcherTimer1.Interval = TimeSpan.FromSeconds(0.0005);
                dispatcherTimer1.Tick += MarginnIncer;
                dispatcherTimer1.Start();

            } 
            else 
            {

                dispatcherTimer2.Interval = TimeSpan.FromSeconds(0.0005);
                dispatcherTimer2.Tick += MarginnDecr;
                dispatcherTimer2.Start();

            }

        }

        public void MarginnIncer(object sender, EventArgs e)
        {
            incerement++;
            if (incerement != 120) { CatagoriBorderMargin.Margin = new Thickness(incerement, 0, 0, 0);}
            else 
            {
                dispatcherTimer1.Stop();
                CatagoriBorderVerif = true;
                PrviousImage.Source = new BitmapImage(new Uri("Icon/previous.png", UriKind.Relative));
            }
        }

        public void MarginnDecr(object sender, EventArgs e)
        {
            incerement--;
            if (incerement != 0) { CatagoriBorderMargin.Margin = new Thickness(incerement, 0, 0, 0); }
            else 
            {
                dispatcherTimer2.Stop();
                CatagoriBorderVerif = false;
                PrviousImage.Source = new BitmapImage(new Uri("Icon/menu.png", UriKind.Relative));

            }
        }

        private void BasketButton(object sender, RoutedEventArgs e)
        {
            BasketFrame.Navigate(BasketPage);

        }

        private void MenuList(object sender, RoutedEventArgs e)
        {

            MenuPage menuPage = new MenuPage();
            BasketFrame.Navigate(menuPage);


        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            string dosyayolu1 = @"C:\Users\LITHIUM\Desktop\Homework\WpfApp1\WpfApp1\SelectionName.txt";
            string dosyayolu2 = @"C:\Users\LITHIUM\Desktop\Homework\WpfApp1\WpfApp1\SelectionPrice.txt";

            File.Delete(dosyayolu1);
            File.Delete(dosyayolu2);

            string dosyayoluName = @"C:\Users\LITHIUM\Desktop\Homework\WpfApp1\WpfApp1\ImageName.txt";
            string dosyayoluPrice = @"C:\Users\LITHIUM\Desktop\Homework\WpfApp1\WpfApp1\ImagePrice.txt";
            string dosyayoluPath = @"C:\Users\LITHIUM\Desktop\Homework\WpfApp1\WpfApp1\ImagePath.txt";

            File.Delete(dosyayoluName);
            File.Delete(dosyayoluPrice);
            File.Delete(dosyayoluPath);

            Close();
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            BasketFrame.Navigate(addPage);

        }

        private void Enter(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                VerifImage.Clear();
                Verif.Clear();
                VerifPrice.Clear();

                string dosyayolu1 = @"C:\Users\LITHIUM\Desktop\Homework\WpfApp1\WpfApp1\AllFood.txt";
                FileStream fileStream5 = new FileStream(dosyayolu1, FileMode.OpenOrCreate, FileAccess.Read);
                using (StreamReader reader = new StreamReader(fileStream5))
                {
                    while (true)
                    {
                        string satir = reader.ReadLine();
                        Verif.Add(satir);
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
                        Verif.Add(satir);
                        if (satir == null) break;
                    }
                    reader.Close();
                }
                fileStream6.Close();


                string dosyayolu3 = @"C:\Users\LITHIUM\Desktop\Homework\WpfApp1\WpfApp1\AllPrice.txt";
                FileStream fileStream7 = new FileStream(dosyayolu3, FileMode.OpenOrCreate, FileAccess.Read);
                using (StreamReader reader = new StreamReader(fileStream7))
                {
                    while (true)
                    {
                        string satir = reader.ReadLine();
                        VerifPrice.Add(satir);
                        if (satir == null) break;
                    }
                    reader.Close();
                }
                fileStream7.Close();


                string dosyayolu4 = @"C:\Users\LITHIUM\Desktop\Homework\WpfApp1\WpfApp1\ImagePrice.txt";
                FileStream fileStream8 = new FileStream(dosyayolu4, FileMode.OpenOrCreate, FileAccess.Read);
                using (StreamReader reader = new StreamReader(fileStream8))
                {
                    while (true)
                    {
                        string satir = reader.ReadLine();
                        VerifPrice.Add(satir);
                        if (satir == null) break;
                    }
                    reader.Close();
                }
                fileStream8.Close();





                for (int i = 0; i < Verif.Count; i++)
                {
                    if (TextSearch.Text == Verif[i])
                    {
                        EnterAdd enterAdd = new EnterAdd();
                        
                        enterAdd.IndexSearch(index);

                        if(index <= 5)
                        {
                            enterAdd.Searchh(TextSearch.Text.ToString(), VerifPrice[index], null);
                        }
                        else
                        {
                            string dosyayolu5 = @"C:\Users\LITHIUM\Desktop\Homework\WpfApp1\WpfApp1\ImagePath.txt";
                            FileStream fileStream123 = new FileStream(dosyayolu5, FileMode.OpenOrCreate, FileAccess.Read);
                            using (StreamReader reader = new StreamReader(fileStream123))
                            {
                                while (true)
                                {
                                    string satir = reader.ReadLine();
                                    VerifImage.Add(satir);
                                    if (satir == null) break;
                                }
                                reader.Close();
                            }
                            fileStream123.Close();

                            enterAdd.Searchh(TextSearch.Text.ToString(), VerifPrice[index - 1], VerifImage[index - 8]);


                        }

                        enterAdd.ShowDialog();
                        index = 0;
                        
                        break;
                    }
                    else
                    {
                        index++;
                        
                    }

                }

                
            }
        }
    }
}

