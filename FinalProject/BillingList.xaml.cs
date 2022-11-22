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
    /// Interaction logic for BillingList.xaml
    /// </summary>
    public partial class BillingList : Page
    {
        public BillingList()
        {
            InitializeComponent();
        }

        private void BackList(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void PayList(object sender, RoutedEventArgs e)
        {

        }

        private void QRIS_Button(object sender, RoutedEventArgs e)
        {

        }

        private void Cash_Button(object sender, RoutedEventArgs e)
        {

        }
    }
}
