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
   public class StudentAccountGateway
    {
        static string BaseUrl = "http://ceejaygabrang-001-site1.itempurl.com/api/lga/student";

        public async Task<IEnumerable<StudentAccount>> GetStudentAccount()
        {

            try
            {
                string url = BaseUrl + "/get_all";
                var content = await WebMethods.MakeGetRequest(url);
                var result = JsonConvert.DeserializeObject<IEnumerable<StudentAccount>>(content);
                return result;
            }
            catch
            {
                return Enumerable.Empty<StudentAccount>();
            }
        }
    }
}
