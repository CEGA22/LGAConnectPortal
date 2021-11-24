using LGAConnectPortal.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace LGAConnectPortal.ViewModels
{
    public class HomeViewModel
    {
        public HomeViewModel()
        {

        }

        public ICommand _accountCommand => new Command(async () => await GotoMenuPage());
        public ICommand _latestNewsandAnnouncement => new Command(async () => await GotoLatestNewsandAnnouncementPage());
        public ICommand _viewGrades => new Command(async () => await GotoViewGrades());

        async Task GotoMenuPage()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new MenuPage());
            //Application.Current.MainPage.Navigation.(new MenuPage());
        }

        async Task GotoLatestNewsandAnnouncementPage()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new LatestNewsandAnnouncementPage());
        }

        async Task GotoViewGrades()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new ViewGrades());
        }


    }
}
