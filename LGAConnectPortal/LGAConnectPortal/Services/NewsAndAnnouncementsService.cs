using LGAConnectPortal.Gateway;
using LGAConnectPortal.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LGAConnectPortal.Services
{
    public class NewsAndAnnouncementsService
    {
        public static async Task<IEnumerable<NewsAndAnnouncements>> GetNewsAndAnnouncements()
        {
            var apiGateway = new NewsAndAnnouncementsGateway();
            var content = await apiGateway.GetNewsAndAnnouncements();
            return content;
        }
    }
}
