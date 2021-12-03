using LGAConnectPortal.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace LGAConnectPortal.ViewModels
{
    public class MenuPageViewModel 
    {            
        public MenuPageViewModel()
        {                   

        }

        
        public ICommand _accountSettings => new Command(async () => await GotoAccountSettings());
        public ICommand _About => new Command(async () => await GoToAbout());
        public ICommand _logout => new Command(async () => await LogoutAccount());


        async Task GotoAccountSettings()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new AccountSettingsPage());
            
        }

        async Task GoToAbout()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new AboutPageView());
        }

        async Task LogoutAccount()
        {            
            Preferences.Clear();
            Application.Current.MainPage = new NavigationPage(new LoginPageView());
        }



    }
}
