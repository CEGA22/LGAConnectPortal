using LGAConnectPortal.Helpers;
using LGAConnectPortal.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LGAConnectPortal.Gateway
{
    public class LoginGateway
    {
        static string BaseUrl = "http://cega22-001-site1.ftempurl.com/api/lga/account/studentlogin";
       

        public async Task<string>StudentAccountLogin(StudentLoginRequest studentrequest)
        {
            var uri = new Uri(string.Format(BaseUrl, "login"));
            return await WebMethods.MakePostRequest(uri, studentrequest);
        }       
    }
}
