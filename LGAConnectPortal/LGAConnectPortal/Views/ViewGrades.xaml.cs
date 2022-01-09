using LGAConnectPortal.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LGAConnectPortal.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewGrades : ContentPage
    {
        public ViewGrades()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            if (BindingContext is ViewGradesViewModel vm)
            {
                var x = vm.Average;
                Average.Text = vm.Average.ToString();
            }           
            base.OnAppearing();
        }
    }
}