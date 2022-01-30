using LGAConnectPortal.Helpers;
using LGAConnectPortal.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LGAConnectPortal.Gateway
{
    public class NewsAndAnnouncementsGateway
    {
        static string BaseUrl = "http://cega22-001-site1.ftempurl.com/api/lga/newsAndAnnouncements";

        public async Task<IEnumerable<NewsAndAnnouncements>> GetNewsAndAnnouncements()
        {

            try
            {
                string url = BaseUrl + "/get_all";
                var content = await WebMethods.MakeGetRequest(url);
                var result = JsonConvert.DeserializeObject<IEnumerable<NewsAndAnnouncements>>(content);
                return result;
            }
            catch
            {
                return Enumerable.Empty<NewsAndAnnouncements>();
            }
        }
    }
}
