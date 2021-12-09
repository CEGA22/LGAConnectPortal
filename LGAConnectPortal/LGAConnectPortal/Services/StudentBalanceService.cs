using LGAConnectPortal.Gateway;
using LGAConnectPortal.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LGAConnectPortal.Services
{
    public class StudentBalanceService
    {
        public static async Task<IEnumerable<StudentBalance>> GetStudentBalanceByAccount(int ID)
        {
            var apiGateway = new StudentBalanceGateway();
            var content = await apiGateway.GetStudentBalanceByAccount(ID);
            return content;
        }
    }
}
