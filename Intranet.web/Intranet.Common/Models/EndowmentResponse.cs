using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Intranet.Common.Models
{
    public class EndowmentResponse
    {
        public int Id { get; set; }
        public string Detail { get; set; }
        public int Count { get; set; }
        public string Size { get; set; }
        public DateTime DateDelivery { get; set; }
        public DateTime DateDeliveryLocal => DateDelivery.ToLocalTime();
        
    }
}
