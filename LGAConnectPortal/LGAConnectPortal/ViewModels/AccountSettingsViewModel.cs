using LGAConnectPortal.Models;
using LGAConnectPortal.Services;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace LGAConnectPortal.ViewModels
{
    public class AccountSettingsViewModel : BaseViewModel
    {
        public AsyncCommand UpdatePasswordCommand { get; }
        public AccountSettingsViewModel()
        {
            UpdatePasswordCommand = new AsyncCommand(UpdatePassword);
        }

        public string CurrentPassword { get; set; }

        public string NewPassword { get; set; }

        public string RetypeNewPassword { get; set; }

        async Task UpdatePassword()
        {
            var ID = Preferences.Get("ID", 0);
            var password = Preferences.Get("Password", string.Empty); 
            if(CurrentPassword == null)
            {
                await Application.Current.MainPage.DisplayAlert("LGA Connect Portal", "Please enter your current password", "OK");
            }

            else if(NewPassword == null)
            {
                await Application.Current.MainPage.DisplayAlert("LGA Connect Portal", "Please enter new password", "OK");
            }

            else if (RetypeNewPassword == null)
            {
                await Application.Current.MainPage.DisplayAlert("LGA Connect Portal", "Please Re-type new password", "OK");
            }

            else
            {
                try
                {
                    if (CurrentPassword == password)
                    {
                        StudentService studentService = new StudentService();
                        var IsSucess = await studentService.UpdateStudentPassword(new StudentAccount
                        {
                            ID = ID,
                            Password = NewPassword
                        });

                        if (IsSucess)
                        {
                            await Application.Current.MainPage.DisplayAlert("LGA Connect Portal", "Updated Successfully", "OK");
                            Preferences.Set("Password", NewPassword);
                        }

                        else
                        {
                            await Application.Current.MainPage.DisplayAlert("LGA Connect Portal", "Error. Please Try Again", "OK");
                        }
                    }
                }
                catch (Exception e)
                {
                    
                }
            }

            
        }
    }
}
