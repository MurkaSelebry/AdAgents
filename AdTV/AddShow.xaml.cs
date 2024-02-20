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
    /// <summary>
    /// Логика взаимодействия для AddShow.xaml
    /// </summary>
    public partial class AddShow : Window
    {
        private static AdDbContext adc = new AdDbContext();
        public AddShow()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            string randomString = "";
            do
            {
                Random random = new Random();
                for (int i = 0; i < 6; i++)
                {
                    randomString += random.Next(0, 10);
                }
            } while (adc.Transmissions.Any(x => x.TransmissionCode == Convert.ToInt32(randomString)) == true);

            Transmission transmission = new Transmission()
            {
                TransmissionCode = Convert.ToInt32(randomString),
                Title = TitleTextBox.Text,
                Rating = Convert.ToInt32(RatingTextBox.Text),
                CostPerMinute = Convert.ToDecimal(CostPerMinuteTextBox.Text)
            };

            adc.Transmissions.Add(transmission);
            adc.SaveChanges();
            this.Close();
        }
    }
}
