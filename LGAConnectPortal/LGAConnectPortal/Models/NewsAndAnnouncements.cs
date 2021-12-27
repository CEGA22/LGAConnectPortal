using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace LGAConnectPortal.Models
{
    public class NewsAndAnnouncements
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public byte[] ContentPhoto { get; set; }

        public ImageSource Thumbnail
        {
            get
            {
                return ImageSource.FromStream(() => new MemoryStream(ContentPhoto));
            }
        }

        public string AuthorsName { get; set; }

        public DateTime DateCreated { get; set; }

        public string Date
        {
            get
            {
                return DateCreated.ToShortDateString();
            }
        }
    }
}
