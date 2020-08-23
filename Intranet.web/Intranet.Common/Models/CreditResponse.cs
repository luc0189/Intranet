using System;
using System.Collections.Generic;
using System.Text;

namespace Intranet.Common.Models
{
    public class CreditResponse
    {
        public int Id { get; set; }
        public string NumberL { get; set; }
        public long Quotmonthly { get; set; }
        public long TotalPrice { get; set; }
        public int DeadlinePay { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
        public EntitiesCreditResponse EntitiesCreditResponse { get; set; }
        public DateTime StartDateLocal => StartDate.ToLocalTime();
        public DateTime EndDateLocal => EndDate.ToLocalTime();
    }
}
