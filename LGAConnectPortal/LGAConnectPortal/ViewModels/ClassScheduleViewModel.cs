using LGAConnectPortal.Models;
using LGAConnectPortal.Services;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace LGAConnectPortal.ViewModels
{
    public class ClassScheduleViewModel : BaseViewModel
    {
        private List<string> tileColors = new List<string>
        {
            "#f03434",
            "#fabe58",
            "#8E44AD",
            "#1ba39c",
            "#f27935",
            "#f2784b",
            "#2c82c9",
            "#22313f",
            "#9f5afd",
            "#674172"
        };
            
        public bool IsNoRecordToShow { get; set; }
        private Random _random = new Random();
        public int RandomNumber(int min, int max)
        {      
            return _random.Next(min, max);
        }
        public ObservableRangeCollection<ClassSchedule> classschedule { get; }
        //public ObservableRangeCollection<ClassSchedule> classscheduleWeek { get; }
        public AsyncCommand DisplayCommand { get; set; }
        public AsyncCommand DisplayWeekCommand { get; set; }
        public AsyncCommand RefreshCommand { get; set; }      
        public ClassScheduleViewModel()
        {
            
            classschedule = new ObservableRangeCollection<ClassSchedule>();
            //classscheduleWeek = new ObservableRangeCollection<ClassSchedule>();
            //DisplayCommand = new AsyncCommand(DisplayClassSchedule);
            //DisplayWeekCommand = new AsyncCommand(DisplayClassScheduleByWeek);
            //RefreshCommand = new AsyncCommand(RefreshClassSchedule);
            PreparePageBindings();
        }

        private async void PreparePageBindings() 
        {
            await DisplayClassSchedule();           
        }

        //DateTime currentDateTime = DateTime.UtcNow;
        List<ClassSchedule> classSchedulesList = new List<ClassSchedule>();
        public async Task DisplayClassSchedule(string weekDay = "Entire Week")
        {        
            var ID = Preferences.Get("ID", 0);
            var classscheduleservice = await ClassScheduleService.GetClassScheduleDetailsStudent(ID);
            classSchedulesList = classscheduleservice.ToList();
            classSchedulesList.ForEach(x => { x.TileColor = Color.FromHex(tileColors[RandomNumber(0, 10)]); });
            classschedule.Clear();

            if (weekDay == "Entire Week")
            {
                classschedule.AddRange(classSchedulesList);
            }
            else
            {
                var filteredScheduleList = classSchedulesList.Where(x => x.WeekDay == weekDay);
                classschedule.AddRange(filteredScheduleList);
            } 
        }

        //public async Task RefreshClassSchedule(string weekDay = "Entire Week")
        //{
        //    var ID = Preferences.Get("ID", 0);
        //    IsBusy = true;
        //    await Task.Delay(2000);
        //    classschedule.Clear();
        //    if (weekDay == "Entire Week")
        //    {
        //        classschedule.AddRange(classSchedulesList);
        //    }
        //    else
        //    {
        //        var filteredScheduleList = classSchedulesList.Where(x => x.WeekDay == weekDay);
        //        classschedule.AddRange(filteredScheduleList);
        //    }
        //    IsBusy = false;
        //}      
    }
}
