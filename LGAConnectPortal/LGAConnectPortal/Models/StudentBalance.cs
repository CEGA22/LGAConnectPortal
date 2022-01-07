using System;
using System.Collections.Generic;
using System.Text;

namespace LGAConnectPortal.Models
{
    public class StudentBalance
    {
        public int id { get; set; }

        public string StudentNumber { get; set; }

        public string Lastname { get; set; }

        public string Middlename { get; set; }

        public string Firstname { get; set; }

        public int Total { get; set; }

        public int Balance { get; set; }

        public string PaymentMode { get; set; }

        public int DownPayment { get; set; }

        public string Description { get; set; }

        public int Studentid { get; set; }

        public int Amount { get; set; }

        public DateTime TransactionDate { get; set; }

        public string Note { get; set; }

        private DateTime date = DateTime.Now;

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

    }
}
