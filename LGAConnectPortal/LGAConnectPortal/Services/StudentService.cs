using LGAConnectPortal.Gateway;
using LGAConnectPortal.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LGAConnectPortal.Services
{
    public class StudentService
    {
        public async Task<IEnumerable<StudentAccount>> GetStudentAccount()
        {
            var apiGateway = new StudentAccountGateway();
            var content = await apiGateway.GetStudentAccount();
            return content;
        }

        public async Task<bool> UpdateStudentPassword(StudentAccount request)
        {
            var apiGateway = new StudentAccountGateway();
            var content = await apiGateway.UpdateStudentPassword(request);
            return JsonConvert.DeserializeObject<bool>(content);
        }
    }
}
