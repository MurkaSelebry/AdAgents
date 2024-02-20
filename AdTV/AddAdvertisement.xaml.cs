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
    /// Логика взаимодействия для AddAdvertisement.xaml
    /// </summary>
    public partial class AddAdvertisement : Window
    {
        private static AdDbContext adc = new AdDbContext();
        public AddAdvertisement()
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
            } while (adc.Advertisements.Any(x => x.AdCode == Convert.ToInt32(randomString)) == true);

            Advertisement advertisements = new Advertisement()
            {
                AdCode = Convert.ToInt32(randomString),
                TransmissionCode = Convert.ToInt32(TransmissionCodeTextBox.Text),
                ClientCode = Convert.ToInt32(ClientCodeTextBox.Text),
                DateConclusion = DateOnly.FromDateTime(DateConclusionPicker.DisplayDate), //dateonly
                Duration = Convert.ToInt32(DurationMinutesTextBox.Text),
                AgentCode = Convert.ToInt32(AgentCodeTextBox.Text)
            };

            adc.Advertisements.Add(advertisements);
            adc.SaveChanges();
            this.Close();
        }
    }
}
