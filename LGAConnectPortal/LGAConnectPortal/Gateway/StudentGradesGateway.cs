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
    public class StudentGradesGateway
    {
        static string BaseUrl = "http://ceejaygabrang-001-site1.itempurl.com/api/lga/classrecordstudent";

        public async Task<IEnumerable<StudentGrades>> GetStudentGradesByID(int ID)
        {
            try
            {
                string url = $"{BaseUrl}/get_all/{ID}";
                var content = await WebMethods.MakeGetRequest(url);
                var result = JsonConvert.DeserializeObject<IEnumerable<StudentGrades>>(content);
                return result;
            }
            catch
            {
                return Enumerable.Empty<StudentGrades>();
            }
        }
    }
}
