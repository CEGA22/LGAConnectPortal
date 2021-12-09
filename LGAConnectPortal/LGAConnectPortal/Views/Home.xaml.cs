using LGAConnectPortal.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
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
            var profile = Preferences.Get("StudentProfile", string.Empty);
            byte[] convertprofile = System.Convert.FromBase64String(profile);
            var imageMemoryStream = new MemoryStream(convertprofile);
            txtGreetings.Text = "Good Day,\n" + Preferences.Get("Firstname", string.Empty);
            DateTime currentDateTime = DateTime.Now;
            TodayClasses.Text = currentDateTime.DayOfWeek.ToString();
            btnStudentProfile.Source = ImageSource.FromStream(() => imageMemoryStream);
            LoadData();
        }

        public async void LoadData()
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