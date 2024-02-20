using EmerAgency.adModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public partial class MainWindow : Window
    {
        private static AdDbContext adc = new AdDbContext();
        private static int clientCode_;
        public MainWindow(int clientCode)
        {
            InitializeComponent();
            clientCode_ = clientCode;
            LoadData();
        }

        private void OnContractButtonClick(object sender, RoutedEventArgs e)
        {
            Advertisement selectedAdvertisements = (Advertisement)dgAdvertisements.SelectedItem;
            Transmission selectedShow = (Transmission)dgShows.SelectedItem;
            var user = from client_ in adc.Clients
                       where client_.ClientCode == Convert.ToInt32(selectedAdvertisements.ClientCode)
                       select new Client
                       {
                           ClientCode = client_.ClientCode,
                           Name = client_.Name,
                           BankDetails = client_.BankDetails,
                           Phone = client_.Phone,
                           ContactPerson = client_.ContactPerson
                       };

            if (user.FirstOrDefault() != null)
            {
                string dataToWrite = $" Передача: {selectedShow.Title}, Код передачи: {selectedShow.TransmissionCode}," +
                                     $" Код рекламы: {selectedAdvertisements.AdCode}," +
                                     $" Контактное лицо: {user.FirstOrDefault().ContactPerson}, " +
                                     $" Номер телефона: {user.FirstOrDefault().Phone}" +
                                     $" Банковские реквизиты: {user.FirstOrDefault().BankDetails}";

                string fileName = $"{selectedShow}_{selectedAdvertisements}_{DateTime.Now:yyyyMMdd}.txt";

                System.IO.File.WriteAllText(fileName, dataToWrite);
            }
            else
            {
                MessageBox.Show("Клиент не найден.");
            }
        }

        private void LoadData()
        {
            dgShows.ItemsSource = new ObservableCollection<Transmission>(adc.Transmissions.ToList());
            dgAdvertisements.ItemsSource = new ObservableCollection<Advertisement>(adc.Advertisements.ToList());
        }

        private void UserInfoButtonClick(object sender, RoutedEventArgs e)
        {
            UserInfo ui = new UserInfo(clientCode_);
            this.Hide();
            ui.ShowDialog();
            this.Show();
        }

        private void OnCalculateButtonClick(object sender, RoutedEventArgs e)
        {
            Advertisement selectedAdvertisements = (Advertisement)dgAdvertisements.SelectedItem;
            Transmission selectedShow = (Transmission)dgShows.SelectedItem;

            if (selectedShow != null && selectedAdvertisements != null)
            {
                Cost.Content = CalculateAdvertisementCost(selectedShow.CostPerMinute, selectedAdvertisements.Duration);
            }
        }

        // Метод для расчета стоимости рекламы
        private string CalculateAdvertisementCost(decimal? costPerMinute, decimal? duration)
        {
            return (costPerMinute * duration).ToString();
        }

        // Метод для расчета общей стоимости рекламы для заказчика
        private decimal CalculateTotalAdvertisementCostForCustomer(decimal[] advertisementCosts)
        {
            return advertisementCosts.Sum();
        }

        // Метод для расчета заработка агента
        private decimal CalculateAgentEarnings(decimal totalAdvertisementCost, decimal commissionPercentage)
        {
            return totalAdvertisementCost * commissionPercentage / 100;
        }

        private void DeleteRow(object sender, RoutedEventArgs e)
        {
            if (dgShows.SelectedItem != null)
            {
                Transmission selectedShow = dgShows.SelectedItem as Transmission;

                
                adc.Transmissions.Remove(selectedShow);
                adc.SaveChanges();
            }

            if (dgAdvertisements.SelectedItem != null)
            {
                Advertisement selectedAdvertisement = dgAdvertisements.SelectedItem as Advertisement;


                adc.Advertisements.Remove(selectedAdvertisement);
                adc.SaveChanges(); 
            }
            LoadData();
        }

        private void AddShowClick(object sender, RoutedEventArgs e)
        {
            this.Hide();
            AddShow addShow = new AddShow();
            addShow.ShowDialog();
            this.Show();
            LoadData();
        }

        private void AddAdvertisementClick(object sender, RoutedEventArgs e)
        {
            this.Hide();
            AddAdvertisement addAdvertisement = new AddAdvertisement();
            addAdvertisement.ShowDialog();
            this.Show();
            LoadData();
        }
    }
}
