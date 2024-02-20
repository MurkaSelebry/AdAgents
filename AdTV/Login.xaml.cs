using EmerAgency.adModels;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
    public partial class Login : Window
    {
        private static AdDbContext adc = new AdDbContext();
        public Login()
        {
            InitializeComponent();
        }

        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            Registration registration = new Registration();
            this.Close();
            registration.Show();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            var user = from client_ in adc.Clients
                       where client_.ClientCode == Convert.ToInt32(ClientCodeTextBox.Text)
                       select $"\nКод заказчика: {client_.ClientCode}\nНазвание: {client_.Name}\nБанковские реквизиты: {client_.BankDetails}" +
                       $"\nНомер телефона: {client_.Phone}\nКонтактное лицо: {client_.ContactPerson}";
            if(user != null) 
            { 
                MainWindow mw = new MainWindow(Convert.ToInt32(ClientCodeTextBox.Text));
                this.Close();
                mw.Show();
            }
        }
    }
}
