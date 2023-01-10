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

namespace FinalProject
{
    /// <summary>
    /// Interaction logic for GetBilling.xaml
    /// </summary>
    public partial class GetBilling : Page
    {
        public GetBilling()
        {
            InitializeComponent();
        }

        GetSetData gtData = new GetSetData();

        private void BackAdd(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void Bill1(object sender, RoutedEventArgs e)
        {          
            int tempTime = gtData.getTime(gtData.getFile());
            int price = 5000;
            tempTime = tempTime + 1800;
            
            if(gtData.updateTime(gtData.getFile(), tempTime) && gtData.UpAndInsOdr(gtData.getFile(), "30 Menit", 1, price))
            {
                MessageBox.Show("Get Billing Successfully", "Get Billing Success",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                var mainmenu = new MainMenu();
                NavigationService.Navigate(mainmenu);
            }
            else
            {
                MessageBox.Show("Failed to Get Billing", "Get Billing Failed",
                        MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Bill2(object sender, RoutedEventArgs e)
        {
            int tempTime = gtData.getTime(gtData.getFile());
            int price = 10000;
            tempTime = tempTime + 3600;

            if (gtData.updateTime(gtData.getFile(), tempTime) && gtData.UpAndInsOdr(gtData.getFile(), "1 Jam", 1, price))
            {
                MessageBox.Show("Get Billing Successfully", "Get Billing Success",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                var mainmenu = new MainMenu();
                NavigationService.Navigate(mainmenu);
            }
            else
            {
                MessageBox.Show("Failed to Get Billing", "Get Billing Failed",
                        MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Bill3(object sender, RoutedEventArgs e)
        {
            int tempTime = gtData.getTime(gtData.getFile());
            int price = 20000;
            tempTime = tempTime + 7200;

            if (gtData.updateTime(gtData.getFile(), tempTime) && gtData.UpAndInsOdr(gtData.getFile(), "2 Jam", 1, price))
            {
                MessageBox.Show("Get Billing Successfully", "Get Billing Success",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                var mainmenu = new MainMenu();
                NavigationService.Navigate(mainmenu);
            }
            else
            {
                MessageBox.Show("Failed to Get Billing", "Get Billing Failed",
                        MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Bill4(object sender, RoutedEventArgs e)
        {
            int tempTime = gtData.getTime(gtData.getFile());
            int price = 30000;
            tempTime = tempTime + 10800;

            if (gtData.updateTime(gtData.getFile(), tempTime) && gtData.UpAndInsOdr(gtData.getFile(), "3 Jam", 1, price))
            {
                MessageBox.Show("Get Billing Successfully", "Get Billing Success",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                var mainmenu = new MainMenu();
                NavigationService.Navigate(mainmenu);
            }
            else
            {
                MessageBox.Show("Failed to Get Billing", "Get Billing Failed",
                        MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
