using System;
using System.Collections.Generic;
using System.Text;

namespace LGAConnectPortal.Models
{
    public class FinalGrade
    {
        public int StudentID { get; set; }

        public string StudentName { get; set; }

        public int SubjectID { get; set; }

        public string SubjectName { get; set; }

        public double finalGrade { get; set; }

        public double Average { get; set; }

        public DateTime DateModified { get; set; }
    }
}
