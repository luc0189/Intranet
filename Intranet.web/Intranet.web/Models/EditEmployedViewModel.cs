using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Intranet.web.Models
{
    public class EditEmployedViewModel : EmployeViewModel
    {
        
        [Display(Name = "UserModif")]
        [MaxLength(30)]
        public string UserModify { get; set; }
        public DateTime DateModify { get; set; }
    }
}
