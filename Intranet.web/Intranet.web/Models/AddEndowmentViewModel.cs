using Intranet.web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intranet.web.Models
{
    public class AddEndowmentViewModel : Endowment
    {
        public int EmployeeId { get; set; }
    }
}
