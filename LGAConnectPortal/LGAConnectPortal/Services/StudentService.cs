using LGAConnectPortal.Gateway;
using LGAConnectPortal.Models;
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
    }
}
