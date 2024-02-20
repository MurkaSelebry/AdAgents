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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace EmerAgency
{
    public partial class UserInfo : Window
    {
        private static AdDbContext adc = new AdDbContext();
        public UserInfo(int clientCode)
        {
            InitializeComponent();
            var user = from client_ in adc.Clients
                       where client_.ClientCode == clientCode
                       select $"\nКод заказчика: {client_.ClientCode}\nНазвание: {client_.Name}\nБанковские реквизиты: {client_.BankDetails}" +
                       $"\nНомер телефона: {client_.Phone}\nКонтактное лицо: {client_.ContactPerson}";
            UserInfoLabel.Content = string.Join("\n", user);
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
