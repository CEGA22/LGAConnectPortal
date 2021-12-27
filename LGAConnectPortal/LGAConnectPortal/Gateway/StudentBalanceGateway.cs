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
    public class StudentBalanceGateway
    {
        static string BaseUrl = "http://cegagabrang-001-site1.btempurl.com/api/lga/studentBalance";

        public async Task<IEnumerable<StudentBalance>> GetStudentBalanceByAccount(int ID)
        {
            try
            {
                string url = $"{BaseUrl}/get_by_id/{ID}";
                var content = await WebMethods.MakeGetRequest(url);
                var result = JsonConvert.DeserializeObject<IEnumerable<StudentBalance>>(content);
                return result;
            }
            catch
            {
                return Enumerable.Empty<StudentBalance>();
            }
        }
    }
}
