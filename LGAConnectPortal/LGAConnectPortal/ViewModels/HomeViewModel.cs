using LGAConnectPortal.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace LGAConnectPortal.ViewModels
{
    public class HomeViewModel
    {
        public HomeViewModel()
        {

        }

        public ICommand _accountCommand => new Command(GotoMenuPage);
        public ICommand _latestNewsandAnnouncement => new Command(GotoLatestNewsandAnnouncementPage);
        public ICommand _viewGrades => new Command(GotoViewGrades);

        void GotoMenuPage()
        {
            Application.Current.MainPage.Navigation.PushAsync(new MenuPage());
        }

        void GotoLatestNewsandAnnouncementPage()
        {
            Application.Current.MainPage.Navigation.PushAsync(new LatestNewsandAnnouncementPage());
        }

        void GotoViewGrades()
        {
            Application.Current.MainPage.Navigation.PushAsync(new ViewGrades());
        }


    }
}
