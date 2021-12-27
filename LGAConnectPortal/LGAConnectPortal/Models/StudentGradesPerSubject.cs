using System;
using System.Collections.Generic;
using System.Text;

namespace LGAConnectPortal.Models
{
    public class StudentGradesPerSubject
    {
        public string SubjectName { get; set; }

        public string FacultyName { get; set; }

        public double FirstGrading { get; set; }

        public double SecondGrading { get; set; }

        public double ThirdGrading { get; set; }

        public double FourthGrading { get; set; }
    }
}
