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

        public MainWindow()
        {
            InitializeComponent();
        }

       

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            //System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
            //client.Port = 587;
            //client.Host = "smtp.gmail.com";
            //client.EnableSsl = true;
            //client.Timeout = 10000;
            //client.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            //client.UseDefaultCredentials = false;
            //client.Credentials = new System.Net.NetworkCredential("vrundathakkar12@gmail.com", "Thakkar2702@");
            //System.Net.Mail.MailMessage mm = new System.Net.Mail.MailMessage("donotreply@domain.com", "sendtomyemail@domain.co.uk", "subject", txt.Text)
            //{
            //    BodyEncoding = UTF8Encoding.UTF8,
            //    DeliveryNotificationOptions = System.Net.Mail.DeliveryNotificationOptions.OnFailure
            //};
            //client.Send(mm);


            MailMessage mail = new MailMessage("jaytha20@gmail.com", "jaytha20@gmail.com", "ContactForm",Name1.Text+Address1.Text+ Age1.Text);
            System.Net.NetworkCredential auth = new System.Net.NetworkCredential("jaytha20@gmail.com", "kernel20");
            SmtpClient client = new SmtpClient("smtp.gmail.com", 25);
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = auth;
            client.Send(mail);


        }

    }
}
