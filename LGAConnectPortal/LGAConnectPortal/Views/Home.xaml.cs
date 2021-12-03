using LGAConnectPortal.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LGAConnectPortal.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home : ContentPage
    {
        public Home()
        {
            InitializeComponent();
            txtGreetings.Text = "Good Day,\n" + Preferences.Get("Firstname", string.Empty);
            DateTime currentDateTime = DateTime.Now;
            TodayClasses.Text = currentDateTime.DayOfWeek.ToString();
            LoadData();
        }

        public async Task LoadData()
        {
            DateTime currentDateTime = DateTime.Now;          
            var todaysweek = currentDateTime.DayOfWeek.ToString();
            if (BindingContext is HomeViewModel vm)
            {

                await vm.DisplayClassSchedule(todaysweek.ToString());
                lblNoRecords.IsVisible = !vm.classschedule.Any();
                lblNoRecords.IsVisible = !vm.classschedule.Any();
            }
        }      
    }
}