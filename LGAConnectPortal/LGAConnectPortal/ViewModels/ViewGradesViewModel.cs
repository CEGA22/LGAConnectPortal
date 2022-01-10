using LGAConnectPortal.Models;
using LGAConnectPortal.Services;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace LGAConnectPortal.ViewModels
{
    public class ViewGradesViewModel : BaseViewModel
    {

        //public ObservableRangeCollection<StudentGrades> studentGrades { get; }

        public ObservableCollection<StudentGradesPerSubject> studentGrades { get; set; } = new ObservableCollection<StudentGradesPerSubject>();       
        IEnumerable<StudentGrades> studentGradesList = new List<StudentGrades>();
        IEnumerable<FinalGrade> finalgrades = new List<FinalGrade>();
        IEnumerable<Subjects> subjects = new List<Subjects>();
        public AsyncCommand RefreshCommand { get; }
        public double Average { get; set; }

        public bool ShowAverage { get; set; }
        public ViewGradesViewModel()
        {
            //studentGrades = new ObservableRangeCollection<StudentGrades>();
            RefreshCommand = new AsyncCommand(RefreshStudentGrades);
            PreparePageBindings();
        }
 

        private async void PreparePageBindings()
        {
            await DisplayStudentGrades();
        }

        public async Task DisplayStudentGrades()
        {
            var ID = Preferences.Get("ID", 0);
            studentGradesList = await StudentGradesService.GetStudentgradesByID(ID);
            finalgrades = await FinalGradeService.GetStudentFinalgradesByID(ID);
            subjects = await SubjectsService.GetSubjects();
            //studentGrades.AddRange(studentGradesList);         
            var subjectList = studentGradesList.Select(x => x.SubjectName).Distinct();

            ShowAverage = studentGradesList.All(a => a.SaveDraft == 1);

            foreach (var subject in subjectList)
            {
                var SubjectName = subjects.First(x => x.ID == subject).SubjectName;  

                var quarterGrades = studentGradesList.Where(x => x.SubjectName == subject).OrderBy(o => o.GradingPeriod);
                var finalgradeslist = finalgrades.Where(x => x.SubjectName == SubjectName).Distinct();

                if (quarterGrades.Any())
                {
                    
                    var firstGrading = quarterGrades.FirstOrDefault(x => x.GradingPeriod == 1).QuarterlyGrade;
                    var secondGrading = quarterGrades.FirstOrDefault(x => x.GradingPeriod == 2).QuarterlyGrade;
                    var thirdGrading = quarterGrades.FirstOrDefault(x => x.GradingPeriod == 3).QuarterlyGrade;
                    var fourthGrading = quarterGrades.FirstOrDefault(x => x.GradingPeriod == 4).QuarterlyGrade;
                    var finalgrade = finalgradeslist.FirstOrDefault(x => x.SubjectName.Equals(SubjectName)).finalGrade;
                    Average = finalgradeslist.FirstOrDefault(x => x.SubjectName.Equals(SubjectName)).Average;

                    var isFirstGradingSubmitted = quarterGrades.FirstOrDefault(x => x.GradingPeriod == 1).SaveDraft == 1;
                    var isSecondGradingSubmitted = quarterGrades.FirstOrDefault(x => x.GradingPeriod == 2).SaveDraft == 1;
                    var isThirdGradingSubmitted = quarterGrades.FirstOrDefault(x => x.GradingPeriod == 3).SaveDraft == 1;
                    var isFourthGradingSubmitted = quarterGrades.FirstOrDefault(x => x.GradingPeriod == 4).SaveDraft == 1;

                    var itemToAdd = new StudentGradesPerSubject
                    {
                        SubjectName = SubjectName,

                        FirstGrading = firstGrading,
                        IsFirstGradingSubmitted = isFirstGradingSubmitted,

                        SecondGrading = secondGrading,
                        IsSecondGradingSubmitted = isSecondGradingSubmitted,

                        ThirdGrading = thirdGrading,
                        IsThirdGradingSubmitted = isThirdGradingSubmitted,

                        FourthGrading = fourthGrading, 
                        IsFourthGradingSubmitted = isFourthGradingSubmitted,

                        FinalGrade = finalgrade,
                    };

                    studentGrades.Add(itemToAdd);
                }
            }
        }

        public async Task RefreshStudentGrades()
        {
            var ID = Preferences.Get("ID", 0);
            IsBusy = true;
            await Task.Delay(2000);
            studentGrades.Clear();
            var final = finalgrades.ToList();
            final.Clear();
            studentGradesList = await StudentGradesService.GetStudentgradesByID(ID);
            subjects = await SubjectsService.GetSubjects();
            //studentGrades.AddRange(studentGradesList);
            var subjectList = studentGradesList.Select(x => x.SubjectName).Distinct();

            ShowAverage = studentGradesList.All(a => a.SaveDraft == 1);

            foreach (var subject in subjectList)
            {
                var SubjectName = subjects.First(x => x.ID == subject).SubjectName;
                var quarterGrades = studentGradesList.Where(x => x.SubjectName == subject).OrderBy(o => o.GradingPeriod);
                var finalgradeslist = finalgrades.Where(x => x.SubjectName == SubjectName).Distinct();

                if (quarterGrades.Any())
                {
                    var firstGrading = quarterGrades.FirstOrDefault(x => x.GradingPeriod == 1).QuarterlyGrade;
                    var secondGrading = quarterGrades.FirstOrDefault(x => x.GradingPeriod == 2).QuarterlyGrade;
                    var thirdGrading = quarterGrades.FirstOrDefault(x => x.GradingPeriod == 3).QuarterlyGrade;
                    var fourthGrading = quarterGrades.FirstOrDefault(x => x.GradingPeriod == 4).QuarterlyGrade;
                    var finalgrade = finalgradeslist.FirstOrDefault(x => x.SubjectName.Equals(SubjectName)).finalGrade;
                    Average = finalgradeslist.FirstOrDefault(x => x.SubjectName.Equals(SubjectName)).Average;

                    var isFirstGradingSubmitted = quarterGrades.FirstOrDefault(x => x.GradingPeriod == 1).SaveDraft == 1;
                    var isSecondGradingSubmitted = quarterGrades.FirstOrDefault(x => x.GradingPeriod == 2).SaveDraft == 1;
                    var isThirdGradingSubmitted = quarterGrades.FirstOrDefault(x => x.GradingPeriod == 3).SaveDraft == 1;
                    var isFourthGradingSubmitted = quarterGrades.FirstOrDefault(x => x.GradingPeriod == 4).SaveDraft == 1;

                    var itemToAdd = new StudentGradesPerSubject
                    {
                        SubjectName = SubjectName,

                        FirstGrading = firstGrading,
                        IsFirstGradingSubmitted = isFirstGradingSubmitted,

                        SecondGrading = secondGrading,
                        IsSecondGradingSubmitted = isSecondGradingSubmitted,

                        ThirdGrading = thirdGrading,
                        IsThirdGradingSubmitted = isThirdGradingSubmitted,

                        FourthGrading = fourthGrading,
                        IsFourthGradingSubmitted = isFourthGradingSubmitted,

                        FinalGrade = finalgrade,
                    };

                    studentGrades.Add(itemToAdd);
                }
            }
            IsBusy = false;
        }
    }
}
