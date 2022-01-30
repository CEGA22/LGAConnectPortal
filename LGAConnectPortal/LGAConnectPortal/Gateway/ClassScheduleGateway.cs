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
    public class ClassScheduleGateway
    {
        static string BaseUrl = "http://cega22-001-site1.ftempurl.com/api/lga/classSchedule";

        public async Task<IEnumerable<ClassSchedule>> GetClassScheduleStudent(int ID)
        {
            try
            {
                string url = $"{BaseUrl}/get_all_student/{ID}";
                var content = await WebMethods.MakeGetRequest(url);
                var result = JsonConvert.DeserializeObject<IEnumerable<ClassSchedule>>(content);
                return result;
            }
            catch
            {
                return Enumerable.Empty<ClassSchedule>();
            }
        }

        public async Task<IEnumerable<ClassSchedule>> GetClassScheduleByWeekDayStudent(int ID, string weekday)
        {
            try
            {
                string url = $"{BaseUrl}/get_by_Weekday_Faculty/{ID}/{weekday}";
                var content = await WebMethods.MakeGetRequest(url);
                var result = JsonConvert.DeserializeObject<IEnumerable<ClassSchedule>>(content);
                return result;
            }
            catch
            {
                return Enumerable.Empty<ClassSchedule>();
            }
        }
    }
}
