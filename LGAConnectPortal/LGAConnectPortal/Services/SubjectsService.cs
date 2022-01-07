using LGAConnectPortal.Gateway;
using LGAConnectPortal.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LGAConnectPortal.Services
{
    public class SubjectsService
    {
        public static async Task<IEnumerable<Subjects>> GetSubjects()
        {
            var apiGateway = new SubjectGateway();
            var content = await apiGateway.GetSubjects();
            return content;
        }
    }
}
