using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace contacformEmail
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private object txt;
        private string filePath;

        public MainWindow()
        {
            InitializeComponent();
        }


        private void Image_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
       "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
       "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                filePath = op.FileName;

            }

            I1.Source = new BitmapImage(new Uri(op.FileName));

        }


        private string RandomString(int v)
        {
            throw new NotImplementedException();
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {

            MailMessage mail = new MailMessage("jaytha20@gmail.com", "jaytha20@gmail.com", "ContactForm", Name1.Text + "\n" + Address1.Text + "\n" + Age1.Text);
            System.Net.NetworkCredential auth = new System.Net.NetworkCredential("jaytha20@gmail.com", "kernel20");
            SmtpClient client = new SmtpClient("smtp.gmail.com", 25);


            mail.Attachments.Add(new Attachment(filePath));

            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = auth;
            client.Send(mail);

        }

    }
}
