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
        public AsyncCommand HomePageCommand { get; }
        public LoginPageViewModel()
        {         
            HomePageCommand = new AsyncCommand(GotoHomePage);
        }

        public string StudentID { get; set; }
        public string password { get; set; }

        async Task GotoHomePage()
        {           
            LoginService loginService = new LoginService();
            var result = await loginService.StudentAccountLogin(new StudentLoginRequest
            {
                StudentNumber = StudentID,
                Password = password
            });

            if (result.IsSuccess)
            {
                PersistentData(result.ID, result.Firstname, result.Lastname, result.Fullname, result.Middlename, result.Password, result.GradeLevel, result.SectionName, result.StudentProfile);
                Application.Current.MainPage = new NavigationPage(new DashboardTabbedPage());

            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Wrong Student ID or Password", "OK");
            }
        }

        public void PersistentData(int ID, string firstname, string lastname, string fullname, string middlename, string password, string gradelevel, string sectionname, byte[] StudentProfile)
        {
            string studentprofile = System.Convert.ToBase64String(StudentProfile);
            Preferences.Set("ID", ID);
            Preferences.Set("Firstname", firstname);
            Preferences.Set("Lastname", lastname);
            Preferences.Set("Fullname", fullname);
            Preferences.Set("Middlename", middlename);
            Preferences.Set("Password", password);
            Preferences.Set("GradeLevel", gradelevel);
            Preferences.Set("SectionName", sectionname);
            Preferences.Set("StudentProfile", studentprofile);
        }
    }
}
