using System;
using System.ComponentModel.DataAnnotations;

namespace Intranet.web.Models
{
    public class EditnegociationViewModel : NegociationViewModel
    {
        [Display(Name = "UserModif")]
        [MaxLength(30)]
        public string UserModify { get; set; }
        public DateTime DateModifica { get; set; }
    }
}
