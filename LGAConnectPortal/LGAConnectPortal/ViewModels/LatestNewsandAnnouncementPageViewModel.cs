using LGAConnectPortal.Models;
using LGAConnectPortal.Services;
using LGAConnectPortal.Views;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace LGAConnectPortal.ViewModels
{
    public class LatestNewsandAnnouncementPageViewModel: BaseViewModel
    {
        public ObservableRangeCollection<NewsAndAnnouncements> newsAndAnnouncements { get; }
        public AsyncCommand SelectedNewsAndAnnouncements { get; set; }     
        public LatestNewsandAnnouncementPageViewModel()
        {
            newsAndAnnouncements = new ObservableRangeCollection<NewsAndAnnouncements>();           
            PrepareBindings();
        }
         
        public async void PrepareBindings()
        {
            await DisplayNewsAndAnnouncements();          
        }

        public async Task DisplayNewsAndAnnouncements()
        {
            try
            {
                IsBusy = true;
                var result = await NewsAndAnnouncementsService.GetNewsAndAnnouncements();
                var resultOrder = result.OrderByDescending(x => x.DateCreated);
                newsAndAnnouncements.AddRange(resultOrder);
                IsBusy = false;
            }

            catch (Exception e)
            {
            }
        }       
    }
}
