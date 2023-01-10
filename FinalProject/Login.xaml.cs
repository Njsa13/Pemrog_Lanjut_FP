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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
        }

        GetSetData gtData = new GetSetData();

        private void LoginButton(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPasswordnew.Password;

            DataTable dtTable = new DataTable();
            dtTable = gtData.cekProfileData(username, password);


            if (dtTable.Rows.Count > 0)
            {
                if (gtData.getTime(gtData.getId(username)) <= 120)
                {
                    gtData.saveFile(gtData.getId(username));
                    var getbilling = new GetBilling();
                    NavigationService.Navigate(getbilling);
                }
                else
                {
                    gtData.saveFile(gtData.getId(username));
                    var mainmenu = new MainMenu();
                    NavigationService.Navigate(mainmenu);
                }                
            }
            else
            {
                if (username.Trim().Equals(""))
                {
                    MessageBox.Show("Enter Username to Login", "Empty Username",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else if (password.Trim().Equals(""))
                {
                    MessageBox.Show("Enter Password to Login", "Empty Password",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    MessageBox.Show("Wrong Username or Password", "Wrong Data",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
         
        }

        private void Back1_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
    }
}
