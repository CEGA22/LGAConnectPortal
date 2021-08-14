using LGAConnectPortal.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace LGAConnectPortal.ViewModels
{
    public class LoginPageViewModel
    {
        public LoginPageViewModel()
        {

        }

        public ICommand _HomePage => new Command(GotoHomePage);

        void GotoHomePage()
        {
            Application.Current.MainPage.Navigation.PushAsync(new DashboardTabbedPage());
        }
    }
}
