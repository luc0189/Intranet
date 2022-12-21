using System;
using System.ComponentModel.DataAnnotations;

namespace Intranet.web.Models
{
    public class EditItemViewModel : ItemViewModel
    {
        [Display(Name = "User Modified")]
        [MaxLength(30)]
        public string UserModify { get; set; }
        [Display(Name = "Date Modified")]
        public DateTime DateModify { get; set; }
    }
}
