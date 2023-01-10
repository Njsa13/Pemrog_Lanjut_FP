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
using System.Windows.Threading;

namespace FinalProject
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Page
    {
        GetSetData gtData = new GetSetData();
        public DispatcherTimer Timer;
        private int time;

        public MainMenu()
        {
            InitializeComponent();

            time = gtData.getTime(gtData.getFile());

            Timer = new DispatcherTimer();
            Timer.Interval = new TimeSpan(0, 0, 1);
            Timer.Tick += Timer_Tick;
            Timer.Start();
        }

        void Timer_Tick(object sender, EventArgs e)
        {
            if ((time > 0) && gtData.updateTime(gtData.getFile(), time))
            {               
                if (time > 3600)
                {
                    time--;

                    if ((time / 3600 < 10) && ((time / 60) - ((time / 3600) * 60) < 10) && (time % 60 < 10))
                    {
                        ShTime.Content = string.Format(" 0{0}:0{1}:0{2}", time / 3600, (time / 60) - ((time / 3600) * 60), time % 60);
                    }
                    else if ((time / 3600 < 10) && ((time / 60) - ((time / 3600) * 60) < 10))
                    {
                        ShTime.Content = string.Format(" 0{0}:0{1}:{2}", time / 3600, (time / 60) - ((time / 3600) * 60), time % 60);
                    }
                    else if (((time / 60) - ((time / 3600) * 60) < 10) && (time % 60 < 10))
                    {
                        ShTime.Content = string.Format(" {0}:0{1}:0{2}", time / 3600, (time / 60) - ((time / 3600) * 60), time % 60);
                    }
                    else if ((time / 3600 < 10) && (time % 60 < 10))
                    {
                        ShTime.Content = string.Format(" 0{0}:{1}:0{2}", time / 3600, (time / 60) - ((time / 3600) * 60), time % 60);
                    }
                    else if (time / 3600 < 10)
                    {
                        ShTime.Content = string.Format(" 0{0}:{1}:{2}", time / 3600, (time / 60) - ((time / 3600) * 60), time % 60);
                    }
                    else if ((time / 60) - ((time / 3600) * 60) < 10)
                    {
                        ShTime.Content = string.Format(" {0}:0{1}:{2}", time / 3600, (time / 60) - ((time / 3600) * 60), time % 60);
                    }
                    else if (time % 60 < 10)
                    {
                        ShTime.Content = string.Format(" {0}:{1}:0{2}", time / 3600, (time / 60) - ((time / 3600) * 60), time % 60);
                    }
                    else
                    {
                        ShTime.Content = string.Format(" {0}:{1}:{2}", time / 3600, (time / 60) - ((time / 3600) * 60), time % 60);
                    }
                }

                else
                {
                    time--;

                    if ((time / 3600 < 10) && ((time / 60) - ((time / 3600) * 60) < 10) && (time % 60 < 10))
                    {
                        ShTime.Content = string.Format(" 0{0}:0{1}:0{2}", time / 3600, (time / 60) - ((time / 3600) * 60), time % 60);
                    }
                    else if ((time / 3600 < 10) && ((time / 60) - ((time / 3600) * 60) < 10))
                    {
                        ShTime.Content = string.Format(" 0{0}:0{1}:{2}", time / 3600, (time / 60) - ((time / 3600) * 60), time % 60);
                    }
                    else if (((time / 60) - ((time / 3600) * 60) < 10) && (time % 60 < 10))
                    {
                        ShTime.Content = string.Format(" {0}:0{1}:0{2}", time / 3600, (time / 60) - ((time / 3600) * 60), time % 60);
                    }
                    else if ((time / 3600 < 10) && (time % 60 < 10))
                    {
                        ShTime.Content = string.Format(" 0{0}:{1}:0{2}", time / 3600, (time / 60) - ((time / 3600) * 60), time % 60);
                    }
                    else if (time / 3600 < 10)
                    {
                        ShTime.Content = string.Format(" 0{0}:{1}:{2}", time / 3600, (time / 60) - ((time / 3600) * 60), time % 60);
                    }
                    else if ((time / 60) - ((time / 3600) * 60) < 10)
                    {
                        ShTime.Content = string.Format(" {0}:0{1}:{2}", time / 3600, (time / 60) - ((time / 3600) * 60), time % 60);
                    }
                    else if (time % 60 < 10)
                    {
                        ShTime.Content = string.Format(" {0}:{1}:0{2}", time / 3600, (time / 60) - ((time / 3600) * 60), time % 60);
                    }
                    else
                    {
                        ShTime.Content = string.Format(" {0}:{1}:{2}", time / 3600, (time / 60) - ((time / 3600) * 60), time % 60);
                    }
                }

            }
            else
            {
                Timer.Stop();
                MessageBox.Show("Time's up", "Time's up Message",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                while (this.NavigationService.CanGoBack)
                {
                    this.NavigationService.GoBack();
                }
            }
        }

        private void Add_Billing(object sender, RoutedEventArgs e)
        {
            var addbilling = new AddBilling();
            NavigationService.Navigate(addbilling);
        }

        private void Food_Button(object sender, RoutedEventArgs e)
        {
            var food = new FoodnBev();
            NavigationService.Navigate(food);
        }

        private void Billing_List(object sender, RoutedEventArgs e)
        {
            var list = new BillingList();
            NavigationService.Navigate(list);
        }

        private void Log_Out(object sender, RoutedEventArgs e)
        {
            Timer.Stop();
            while (this.NavigationService.CanGoBack)
            {
                this.NavigationService.GoBack();
            }
        }
    }
}
