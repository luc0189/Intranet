using System;
using System.Collections.Generic;
using System.Text;

namespace Intranet.Common.Models
{
   public class ExamsResponse
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime EndDateLocal => EndDate.ToLocalTime();
        public DateTime StartDateLocal => StartDate.ToLocalTime();
        public ExamTypeResponse ExamTypeResponse { get; set; }

    }
}
