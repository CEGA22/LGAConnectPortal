using System;
using System.Collections.Generic;
using System.Text;

namespace LGAConnectPortal.Models
{
    public class StudentLoginRequest
    {
        public string StudentNumber { get; set; }

        public string Password { get; set; }
    }
}
