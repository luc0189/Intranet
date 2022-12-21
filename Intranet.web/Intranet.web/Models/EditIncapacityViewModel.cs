using System;
using System.ComponentModel.DataAnnotations;

namespace Intranet.web.Models
{
    public class EditIncapacityViewModel : AddIncapacityViewModel
    {


        [MaxLength(30)]
        public string UserModify { get; set; }

        public DateTime DateModify { get; set; }
    }
}
