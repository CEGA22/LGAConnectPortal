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
    public partial class NewsAndAnnouncementView : ContentPage
    {
        public NewsAndAnnouncementView(ImageSource contentPhoto, string title, string content, DateTime datecreated)
        {
            InitializeComponent();
            Title.Text = title;
            ContentPhoto.Source = contentPhoto;
            Content.Text = content;
            DateCreated.Text = datecreated.ToShortDateString();
        }
    }
}