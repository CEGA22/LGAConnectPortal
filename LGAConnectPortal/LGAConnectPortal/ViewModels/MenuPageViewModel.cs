using LGAConnectPortal.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace LGAConnectPortal.ViewModels
{
    public class MenuPageViewModel : INotifyPropertyChanged
    {       
        public event PropertyChangedEventHandler PropertyChanged;
       
        public MenuPageViewModel()
        {
            
            //this.accountcommand = new Command(
            //    async () =>
            //    {
            //        await Application.Current.MainPage.Navigation.PushAsync(new AccountSettingsPage());
            //    });

        }

        public ICommand _accountSettings => new Command(GotoAccountSettings);

        void GotoAccountSettings()
        {
            Application.Current.MainPage.Navigation.PushAsync(new AccountSettingsPage());
        }

     

    }
}
