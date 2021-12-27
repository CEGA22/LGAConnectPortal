using LGAConnectPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LGAConnectPortal.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LatestNewsandAnnouncementPage : ContentPage
    {
        public LatestNewsandAnnouncementPage()
        {
            InitializeComponent();
        }

        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var details  = e.Item as NewsAndAnnouncements;
            await Navigation.PushAsync( new NewsAndAnnouncementView(details.Thumbnail, details.Title, details.Content, details.DateCreated));
        }
    }
}