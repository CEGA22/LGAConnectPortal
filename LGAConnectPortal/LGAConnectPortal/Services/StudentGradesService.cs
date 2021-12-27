using LGAConnectPortal.Gateway;
using LGAConnectPortal.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LGAConnectPortal.Services
{
    public class StudentGradesService
    {
        public static async Task<IEnumerable<StudentGrades>> GetStudentgradesByID(int ID)
        {
            var apiGateway = new StudentGradesGateway();
            var content = await apiGateway.GetStudentGradesByID(ID);
            return content;
        }
    }
}
