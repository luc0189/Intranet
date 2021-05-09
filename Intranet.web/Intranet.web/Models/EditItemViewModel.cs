using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Intranet.web.Models
{
    public class EditItemViewModel:ItemViewModel
    {
        [Display(Name = "User Modified")]
        [MaxLength(30)]
        public string UserModify { get; set; }
        [Display(Name = "Date Modified")]
        public DateTime DateModify { get; set; }
    }
}
