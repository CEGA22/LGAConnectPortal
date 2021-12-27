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

namespace LGAConnectPortal.ViewModels
{
    public class ViewGradesViewModel : BaseViewModel
    {

        //public ObservableRangeCollection<StudentGrades> studentGrades { get; }

        public List<StudentGradesPerSubject> StudentGrades { get; set; } = new List<StudentGradesPerSubject>();
        public AsyncCommand RefreshCommand { get; }

        public ViewGradesViewModel()
        {
            //studentGrades = new ObservableRangeCollection<StudentGrades>();
            //RefreshCommand = new AsyncCommand(RefreshStudentBalance);
            PrepareBindings();
        }

        public async void PrepareBindings()
        {
            await DisplayStudentGrades();
        }

        IEnumerable<StudentGrades> studentGradesList = new List<StudentGrades>();
        public async Task DisplayStudentGrades()
        {
            var ID = Preferences.Get("ID", 0);
            studentGradesList = await StudentGradesService.GetStudentgradesByID(ID);
            //studentGrades.AddRange(studentGradesList);

            var subjectList = studentGradesList.Select(x => x.SubjectName).Distinct();

            foreach (var subject in subjectList)
            {
                var quarterGrades = studentGradesList.Where(x => x.SubjectName == subject).OrderBy(o => o.GradingPeriod);

                if (quarterGrades.Any())
                {
                    var firstGrading = quarterGrades.FirstOrDefault(x => x.GradingPeriod == 1).QuarterlyGrade;
                    var secondGrading = quarterGrades.FirstOrDefault(x => x.GradingPeriod == 2).QuarterlyGrade;
                    var thirdGrading = quarterGrades.FirstOrDefault(x => x.GradingPeriod == 3).QuarterlyGrade;
                    var fourthGrading = quarterGrades.FirstOrDefault(x => x.GradingPeriod == 4).QuarterlyGrade;

                    var itemToAdd = new StudentGradesPerSubject
                    {
                        SubjectName = subject,
                        FirstGrading = firstGrading,
                        SecondGrading = secondGrading,
                        ThirdGrading = thirdGrading,
                        FourthGrading = fourthGrading
                    };

                    StudentGrades.Add(itemToAdd);
                }
            }
        }

        //public async Task RefreshStudentBalance()
        //{
        //    var ID = Preferences.Get("ID", 0);
        //    IsBusy = true;
        //    await Task.Delay(2000);
        //    studentGradesList = await StudentGradesService.GetStudentgradesByID(ID);
        //    //studentGrades.AddRange(studentGradesList);

        //    var subjectList = studentGradesList.Select(x => x.SubjectName).Distinct();

        //    foreach (var subject in subjectList)
        //    {
        //        var quarterGrades = studentGradesList.Where(x => x.SubjectName == subject).OrderBy(o => o.GradingPeriod);

        //        if (quarterGrades.Any())
        //        {
        //            var firstGrading = quarterGrades.FirstOrDefault(x => x.GradingPeriod == 1).QuarterlyGrade;
        //            var secondGrading = quarterGrades.FirstOrDefault(x => x.GradingPeriod == 2).QuarterlyGrade;
        //            var thirdGrading = quarterGrades.FirstOrDefault(x => x.GradingPeriod == 3).QuarterlyGrade;
        //            var fourthGrading = quarterGrades.FirstOrDefault(x => x.GradingPeriod == 4).QuarterlyGrade;

        //            var itemToAdd = new StudentGradesPerSubject
        //            {
        //                SubjectName = subject,
        //                FirstGrading = firstGrading,
        //                SecondGrading = secondGrading,
        //                ThirdGrading = thirdGrading,
        //                FourthGrading = fourthGrading
        //            };

        //            StudentGrades.Add(itemToAdd);
        //        }
        //        IsBusy = false;
        //    }
        //}
    }
}
