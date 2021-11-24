using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace LGAConnectPortal.Models
{
    public class ClassSchedule
    {
        public int ID { get; set; }

        public string Subject { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string StartTime { get; set; }

        public string EndTime { get; set; }

        public string Teacher { get; set; }

        public string WeekDay { get; set; }

        public string Fullname
        {
            get
            {
                return $"{Firstname} {Lastname}";
            }
        }

        public string Time
        {
            get
            {
                return $"{StartTime} - {EndTime}";
            }
        }

        public Color TileColor { get; set; }

    }
}
