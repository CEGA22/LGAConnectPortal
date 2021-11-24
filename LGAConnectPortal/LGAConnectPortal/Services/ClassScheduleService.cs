using LGAConnectPortal.Gateway;
using LGAConnectPortal.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LGAConnectPortal.Services
{
    public static class ClassScheduleService
    {
        public static async Task<IEnumerable<ClassSchedule>> GetClassScheduleDetailsStudent(int ID)
        {
            var apiGateway = new ClassScheduleGateway();
            var content = await apiGateway.GetClassScheduleStudent(ID);
            return content;
        }

        public static async Task<IEnumerable<ClassSchedule>> GetClassScheduleByWeekDayDetailsStudent(int ID, string weekday)
        {
            var apiGateway = new ClassScheduleGateway();
            var content = await apiGateway.GetClassScheduleByWeekDayStudent(ID, weekday);
            return content;
        }
    }
}
