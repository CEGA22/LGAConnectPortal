using LGAConnectPortal.Services;
using LGAConnectPortal.ViewModels;
using MvvmHelpers;
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
    public partial class ClassSchedule : ContentPage
    {
        public ObservableRangeCollection<ClassSchedule> classscheduleWeek { get; }
        public ClassSchedule()
        {
            InitializeComponent();
            classscheduleWeek = new ObservableRangeCollection<ClassSchedule>();
        }

      

        private void Label_Focused(object sender, FocusEventArgs e)
        {

        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            
                Weekdays.Focus();                                   
        }

        
        private async void Weekdays_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                Picker picker = sender as Picker;
                var selectedItem = picker.SelectedItem;
                selectedWeekDay.Text = selectedItem.ToString();

                if (BindingContext is ClassScheduleViewModel vm)
                {
                    await vm.DisplayClassSchedule(selectedItem.ToString());
                    lblNoRecords.IsVisible = !vm.classschedule.Any();
                }
            }
            catch (Exception x)
            {

                throw;
            }

            

        }
    }
}