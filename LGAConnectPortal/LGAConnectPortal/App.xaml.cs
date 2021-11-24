using LGAConnectPortal.Views;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LGAConnectPortal
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            var ID = Preferences.Get("ID", 0);          
            if (ID != 0)
            {
                MainPage = new NavigationPage(new DashboardTabbedPage());
            }

            else
            {
                MainPage = new NavigationPage(new LoginPageView());
            }
            
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
