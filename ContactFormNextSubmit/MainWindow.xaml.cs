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

namespace ContactFormNextSubmit
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string fName { get; set; }
        public string lName { get; set; }
        public string adr { get; set; }
        public string ag { get; set; }


        //Hi I am on dev_vrunda branch

        //private object txtname;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            fName = T1.Text;
            lName = T2.Text;
            MessageBox.Show(fName + lName);
            string text = fName + "," + lName;

            System.IO.File.WriteAllText(@"C:\Users\Public\TestFolder\WriteText2.txt", text);


            S.Visibility = Visibility.Collapsed;
            P.Visibility = Visibility.Visible;
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            adr = T3.Text;
            ag = T4.Text;

            MessageBox.Show(fName + lName + adr + ag);
            string text = fName + "," + lName + "," + adr + "," + ag;
            System.IO.File.WriteAllText(@"C:\Users\Public\TestFolder\WriteText2.txt", text);

        }
    }
}