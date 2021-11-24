using LGAConnectPortal.Gateway;
using LGAConnectPortal.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LGAConnectPortal.Services
{
    public class LoginService
    {
        public async Task<StudentLoginResult>StudentAccountLogin(StudentLoginRequest request)
        {
            var apiGateway = new LoginGateway();
            var content = await apiGateway.StudentAccountLogin(request);
            return JsonConvert.DeserializeObject<StudentLoginResult>(content);
        }
    }
}
