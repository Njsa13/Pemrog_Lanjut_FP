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
    /// Interaction logic for FoodnBev.xaml
    /// </summary>
    public partial class FoodnBev : Page
    {
        public FoodnBev()
        {
            InitializeComponent();
        }

        GetSetData gtData = new GetSetData();

        int[] Food = new int[5] {0, 0, 0, 0, 0 };

        private void minus_1(object sender, RoutedEventArgs e)
        {
            if(Food[0] > 0)
            {
                Food[0] = Food[0] - 1;
                Labl1.Content = string.Format("{0}", Food[0]);
            }           
        }

        private void plus_1(object sender, RoutedEventArgs e)
        {
            if (Food[0] < 5)
            {
                Food[0] = Food[0] + 1;
                Labl1.Content = string.Format("{0}", Food[0]);
            }
        }

        private void minus_2(object sender, RoutedEventArgs e)
        {
            if (Food[1] > 0)
            {
                Food[1] = Food[1] - 1;
                Labl2.Content = string.Format("{0}", Food[1]);
            }
        }

        private void plus_2(object sender, RoutedEventArgs e)
        {
            if (Food[1] < 5)
            {
                Food[1] = Food[1] + 1;
                Labl2.Content = string.Format("{0}", Food[1]);
            }
        }

        private void minus_3(object sender, RoutedEventArgs e)
        {
            if (Food[2] > 0)
            {
                Food[2] = Food[2] - 1;
                Labl3.Content = string.Format("{0}", Food[2]);
            }
        }

        private void plus_3(object sender, RoutedEventArgs e)
        {
            if (Food[2] < 5)
            {
                Food[2] = Food[2] + 1;
                Labl3.Content = string.Format("{0}", Food[2]);
            }
        }

        private void BackFood(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void minus_4(object sender, RoutedEventArgs e)
        {
            if (Food[3] > 0)
            {
                Food[3] = Food[3] - 1;
                Labl4.Content = string.Format("{0}", Food[3]);
            }
        }

        private void plus_4(object sender, RoutedEventArgs e)
        {
            if (Food[3] < 5)
            {
                Food[3] = Food[3] + 1;
                Labl4.Content = string.Format("{0}", Food[3]);
            }
        }

        private void minus_5(object sender, RoutedEventArgs e)
        {
            if (Food[4] > 0)
            {
                Food[4] = Food[4] - 1;
                Labl5.Content = string.Format("{0}", Food[4]);
            }
        }

        private void plus_5(object sender, RoutedEventArgs e)
        {
            if (Food[4] < 5)
            {
                Food[4] = Food[4] + 1;
                Labl5.Content = string.Format("{0}", Food[4]);
            }
        }

        private void OrderFood(object sender, RoutedEventArgs e)
        {
            if (Food[0] > 0 || Food[1] > 0 || Food[2] > 0 || Food[3] > 0 || Food[4] > 0)
            {
                if (Food[0] > 0)
                {
                    gtData.UpAndInsOdr(gtData.getFile(), "Indomie Goreng + Telur", Food[0], 7000);
                }

                if (Food[1] > 0)
                {
                    gtData.UpAndInsOdr(gtData.getFile(), "Indomie Soto + Telor", Food[1], 7000);
                }

                if (Food[2] > 0)
                {
                    gtData.UpAndInsOdr(gtData.getFile(), "Mie Dok Dok", Food[2], 12000);
                }

                if (Food[3] > 0)
                {
                    gtData.UpAndInsOdr(gtData.getFile(), "Es Teh", Food[3], 3000);
                }

                if (Food[4] > 0)
                {
                    gtData.UpAndInsOdr(gtData.getFile(), "Ayam Geprek", Food[4], 12000);
                }

                MessageBox.Show("Food Order Successfully", "Order Successfully",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                this.NavigationService.GoBack();
            }
            else
            {
                MessageBox.Show("Please Select The Menu You Want to Order", "Order Failed",
                        MessageBoxButton.OK, MessageBoxImage.Error);
            }
           

        }
    }
}
