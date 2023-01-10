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
    /// Interaction logic for Create.xaml
    /// </summary>
    public partial class Create : Page
    {
        public Create()
        {
            InitializeComponent();
        }

        GetSetData gtData = new GetSetData();

        private void CreateCrt(object sender, RoutedEventArgs e)
        {
            string username = Username_Crt.Text;
            string password = newPassCrt.Password;
            string confPass = newPassCrt1.Password;

            DataTable dtTable = new DataTable();
            dtTable = gtData.cekProfileData(username, password);

            if (username.Trim().Equals(""))
            {
                MessageBox.Show("Enter Username to Sign Up", "Empty Username",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (password.Trim().Equals(""))
            {
                MessageBox.Show("Enter Password to Sign Up", "Empty Password",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (confPass.Trim().Equals(""))
            {
                MessageBox.Show("Enter Confirm Password to Sign Up", "Empty Confirm Password",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (username.Contains(" "))
            {
                MessageBox.Show("Username Cannot Contain Spaces", "Wrong Format Username",
                        MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (password.Contains(" ") || (password.Length < 5))
            {
                MessageBox.Show("Password Cannot Contain Spaces and Cannot be Less Than 5 Characters", "Wrong Format Password",
                        MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (password != confPass)
            {
                MessageBox.Show("Confirm Password is Wrong", "Wrong Confirm Password",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (dtTable.Rows.Count > 0)
            {
                MessageBox.Show("Username Already Exists", "Exists Username",
                        MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if(gtData.addProfile(username, password))
                {
                    MessageBox.Show("Account Created Successfully", "Add Profile",
                        MessageBoxButton.OK, MessageBoxImage.Information);

                    while (this.NavigationService.CanGoBack)
                    {
                        this.NavigationService.GoBack();
                    }
                }
                else
                {
                    MessageBox.Show("Account Not Created", "Add Profile Error",
                       MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void BackCrt(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void Username_Crt_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
