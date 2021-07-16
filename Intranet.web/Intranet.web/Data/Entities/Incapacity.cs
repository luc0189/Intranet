using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Intranet.web.Data.Entities
{
    public class Incapacity
    {
        public int Id { get; set; }

        [Display(Name = "Fecha Inicio")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = false)]
        public DateTime StartDate { get; set; }

        [Display(Name ="Dias Novedad")]
        [Required(ErrorMessage ="El campo {0} es Requerido")]
        public int CantDay { get; set; }

        [Display(Name = "Fecha Fin")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = false)]
        public DateTime EndDate { get; set; }

        [Display(Name = "Novedad")]
        [MaxLength(350, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public string Novedad { get; set; }
        public Employee Employee { get; set; }
        public TypeNew TypeNew { get; set; }

        public DateTime DateRegistro { get; set; }

        [MaxLength(30)]
        public string UserRegistra { get; set; }

        [MaxLength(30)]
        public string UserModify { get; set; }

        public DateTime DateModify { get; set; }
    }
}
