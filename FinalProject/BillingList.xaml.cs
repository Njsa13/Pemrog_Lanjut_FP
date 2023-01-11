using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for BillingList.xaml
    /// </summary>
    public partial class BillingList : Page
    {
        GetSetData gtData = new GetSetData();

        public BillingList()
        {
            InitializeComponent();

            listTb.ItemsSource = gtData.DataList(gtData.getFile()).DefaultView;
            Total.Content = string.Format("Total : Rp {0}", gtData.SumData(gtData.getFile()));
        }

        private void BackList(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void PayList(object sender, RoutedEventArgs e)
        {
            if (Cash.IsChecked == true)
            {
                MessageBox.Show("You Can Pay In Cash Through The Cashier", "Cash Payment",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                this.NavigationService.GoBack();
            }
            else if (QRIS.IsChecked == true)
            {
                var qrcode = new QrCode();
                NavigationService.Navigate(qrcode);
            }
        }

        private void QRIS_Button(object sender, RoutedEventArgs e)
        {

        }

        private void Cash_Button(object sender, RoutedEventArgs e)
        {

        }

        private void listTb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
