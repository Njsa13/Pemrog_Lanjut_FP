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
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Page
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void Add_Billing(object sender, RoutedEventArgs e)
        {

        }

        private void Food_Button(object sender, RoutedEventArgs e)
        {

        }

        private void Billing_List(object sender, RoutedEventArgs e)
        {

        }

        private void Log_Out(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
            this.NavigationService.GoBack();
        }
    }
}
