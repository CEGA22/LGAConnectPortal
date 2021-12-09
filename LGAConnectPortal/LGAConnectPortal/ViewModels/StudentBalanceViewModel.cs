using LGAConnectPortal.Models;
using LGAConnectPortal.Services;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;

namespace LGAConnectPortal.ViewModels
{
    public class StudentBalanceViewModel : BaseViewModel
    {


        public ObservableRangeCollection<StudentBalance> studentBalances { get; } 
        public AsyncCommand RefreshCommand { get;}       
        public StudentBalanceViewModel()
        {
            studentBalances = new ObservableRangeCollection<StudentBalance>();
            RefreshCommand = new AsyncCommand(RefreshStudentBalance);
            PreparePageBindings();
        }


        private async void PreparePageBindings()
        {
            await DisplayStudentBalance();
        }

        public async Task DisplayStudentBalance()
        {
            var ID = Preferences.Get("ID", 0);
            var studentBalanceservice = await StudentBalanceService.GetStudentBalanceByAccount(ID);
            var studentBalance = studentBalanceservice.ToList();
            studentBalances.AddRange(studentBalance);
        }


        public async Task RefreshStudentBalance()
        {
            var ID = Preferences.Get("ID", 0);
            IsBusy = true;
            await Task.Delay(2000);
            studentBalances.Clear();
            var studentBalanceservice = await StudentBalanceService.GetStudentBalanceByAccount(ID);
            var studentBalance = studentBalanceservice.ToList();
            studentBalances.AddRange(studentBalance);
            IsBusy = false;

        }
    }
}
