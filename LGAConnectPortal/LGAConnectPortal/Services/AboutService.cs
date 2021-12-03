using LGAConnectPortal.Gateway;
using LGAConnectPortal.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LGAConnectPortal.Services
{
    public class AboutService
    {
        public static async Task<IEnumerable<About>> GetAboutDetails()
        {
            var apiGateway = new AbouGateway();
            var content = await apiGateway.GetAbout();
            return content;
        }
    }
}
