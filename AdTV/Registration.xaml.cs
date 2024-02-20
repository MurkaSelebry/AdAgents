using EmerAgency.adModels;
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
using System.Windows.Shapes;

namespace EmerAgency
{
    public partial class Registration : Window
    {
        private static AdDbContext adc = new AdDbContext();
        public Registration()
        {
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            string randomString = "";
            do
            {
                Random random = new Random();
                for (int i = 0; i < 6; i++)
                {
                    randomString += random.Next(0, 10);
                }
            } while (adc.Clients.Any(x => x.ClientCode == Convert.ToInt32(randomString)) == true);

            Client client = new Client
            {
                ClientCode = Convert.ToInt32(randomString),
                Name = nameTextBox.Text,
                BankDetails = BankDetailsTextBox.Text,
                Phone = PhoneTextBox.Text,
                ContactPerson = ContactPersonTextBox.Text,
            };
            adc.Clients.Add(client);
            adc.SaveChanges();
            MainWindow mw = new MainWindow(Convert.ToInt32(randomString));
            this.Close();
            mw.Show();
        }
    }
}
