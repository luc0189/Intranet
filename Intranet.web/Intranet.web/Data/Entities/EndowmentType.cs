using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Intranet.web.Data.Entities
{
    public class EndowmentType
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The field {0} is Required")]
        [Display(Name = "Dotacion")]
        [MaxLength(150)]
        public string NameType { get; set; }

        [Display(Name = "Meses")]
        [Required(ErrorMessage = "The field {0} is Required")]
        public int EspirationDate { get; set; }


        public string UserRegistra { get; set; }
        public string UserModify { get; set; }
        public DateTime DateRegistro { get; set; }
        public DateTime DateModify { get; set; }
        public ICollection<Endowment> Endowments { get; set; }
    }
}
