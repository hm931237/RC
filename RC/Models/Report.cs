using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RC.Models
{
    public class Report
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime Date { get; set; }

        public ReportType reportType { get; set; }
        public int reportTypeId { get; set; }

        public User reporter { get; set; }
        public int reporterId { get; set; }

        public User reported { get; set; }
        public int reportedId { get; set; }

        public ReportKind reportKind { get; set; }
        public int reportKindId { get; set; }


    }
}