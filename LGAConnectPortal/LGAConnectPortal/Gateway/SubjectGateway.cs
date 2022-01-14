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
    public class SubjectGateway
    {
        static string BaseUrl = "http://cega07-001-site1.gtempurl.com/api/lga/subjects";

        public async Task<IEnumerable<Subjects>> GetSubjects()
        {
            try
            {
                string url = BaseUrl + "/get_all";
                var content = await WebMethods.MakeGetRequest(url);
                var result = JsonConvert.DeserializeObject<IEnumerable<Subjects>>(content);
                return result;
            }
            catch
            {
                return Enumerable.Empty<Subjects>();
            }
        }
    }
}
