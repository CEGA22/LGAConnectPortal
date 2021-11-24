using LGAConnectPortal.Models;
using LGAConnectPortal.Services;
using LGAConnectPortal.Views;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace LGAConnectPortal.ViewModels
{
    public class LoginPageViewModel : BaseViewModel
    {
        public LoginPageViewModel()
        {
            _HomePage = new AsyncCommand(GotoHomePage);
        }

        //public ICommand _HomePage => new Command(async() => await GotoHomePage());
        public ICommand _HomePage { get; }


        public string StudentID { get; set; }
        public string password { get; set; }

        async Task GotoHomePage()
        {
            //Application.Current.MainPage.Navigation.PushAsync(new DashboardTabbedPage());
            //Application.Current.MainPage = new NavigationPage(new DashboardTabbedPage());
            LoginService loginService = new LoginService();
            var result = await loginService.StudentAccountLogin(new StudentLoginRequest
            {
                StudentNumber = StudentID,
                Password = password
            });

            if (result.IsSuccess)
            {
                PersistentData(result.ID, result.Firstname, result.Lastname, result.Fullname);
                Application.Current.MainPage = new NavigationPage(new DashboardTabbedPage());

            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Wrong Student ID or Password", "OK");
            }
        }

        public void PersistentData(int ID, string firstname, string lastname, string fullname)
        {
            Preferences.Set("ID", ID);
            Preferences.Set("Firstname", firstname);
            Preferences.Set("Lastname", lastname);
            Preferences.Set("Fullname", fullname);
        }
    }
}
