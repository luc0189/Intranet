using Intranet.web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intranet.web.Models
{
    public class AddAreaViewModel :Area
    {
        public int SiteId { get; set; }
    }
}
