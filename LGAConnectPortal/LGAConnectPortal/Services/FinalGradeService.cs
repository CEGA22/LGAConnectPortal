using LGAConnectPortal.Gateway;
using LGAConnectPortal.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LGAConnectPortal.Services
{
    public class FinalGradeService
    {
        public static async Task<IEnumerable<FinalGrade>> GetStudentFinalgradesByID(int ID)
        {
            var apiGateway = new FinalGradeGateway();
            var content = await apiGateway.GetStudentGradesByID(ID);
            return content;
        }
    }
}
