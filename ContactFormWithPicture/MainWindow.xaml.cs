using Microsoft.Win32;
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

namespace ContactFormWithPicture
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string N1 { get; set; }
        public string adr { get; set; }
        public string ag { get; set; }

        public Image file;


        public MainWindow()
        {
            InitializeComponent();
            string read = System.IO.File.ReadAllText(@"C:\Users\Public\TestFolder\WriteText3.txt");

            string[] values = read.Split(',');

            N1 = values[0].ToString();
            adr = values[1].ToString();
            ag = values[2].ToString();

            Name1.Text = N1;
            Address1.Text = adr;
            Age1.Text = ag;

            string readImagePath = System.IO.File.ReadAllText(@"C:\Users\Public\TestFolder\ImageLocation.txt");
            string[] values2 = readImagePath.Split(',');

            string path = values2[0].ToString();
            I1.Source = new BitmapImage(new Uri(path));
        }
        private void Image_Click(object sender, RoutedEventArgs e)
        {   
            //BitmapCache 
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
       "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
       "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {

                string appPath = System.IO.Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory) + @"\assets\";
                var fileNameToSave = RandomString(5)+ System.IO.Path.GetExtension(op.SafeFileName);
                var imagePath = System.IO.Path.Combine(appPath + fileNameToSave);

                if (!System.IO.Directory.Exists(appPath))
                {
                    System.IO.Directory.CreateDirectory(appPath);
                }

                System.IO.File.Copy(op.FileName, imagePath);
                I1.Source = new BitmapImage(new Uri(op.FileName));

                System.IO.File.WriteAllText(@"C:\Users\Public\TestFolder\ImageLocation.txt", imagePath);
                //file=Image.fro
            }
        }
        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            string N1 = null;  
            string adr = null;
            string ag = null;

            N1 = Name1.Text;
            adr =Address1.Text;
            ag = Age1.Text;

            MessageBox.Show(N1 + adr + ag );
            string text = N1 + "," + adr + "," + ag ;
            System.IO.File.WriteAllText(@"C:\Users\Public\TestFolder\WriteText3.txt", text);

       //     SaveFileDialog f = new SaveFileDialog();
       //     f.Filter= "All supported graphics|*.jpg;*.jpeg;*.png|" +
       //"JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
       //"Portable Network Graphic (*.png)|*.png";

       //     if(f.ShowDialog()==true)
       //     {

       //         SaveFile(f);
       //     }

         

        }

        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private void Read_Click(object sender, RoutedEventArgs e)
        {
            string read = System.IO.File.ReadAllText(@"C:\Users\Public\TestFolder\WriteText3.txt");

            string[] values = read.Split(',');

            N1 = values[0].ToString();
            adr = values[1].ToString();
            ag = values[2].ToString();

            Name1.Text = N1;
            Address1.Text = adr;
            Age1.Text = ag;

            string readImagePath = System.IO.File.ReadAllText(@"C:\Users\Public\TestFolder\ImageLocation.txt");
            string[] values2 = readImagePath.Split(',');

            string path = values2[0].ToString();
            I1.Source = new BitmapImage(new Uri(path));

        }
    }
}
