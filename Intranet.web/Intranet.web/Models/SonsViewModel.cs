using System;
using System.ComponentModel.DataAnnotations;

namespace Intranet.web.Models
{
    public class SonsViewModel
    {

        public int EmployeeId { get; set; }

        public int Id { get; set; }

        [Required(ErrorMessage = "el campo {0} es Obligatorio")]
        [Display(Name = "Nombre Completo")]
        [MaxLength(50)]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = false)]
        [Required(ErrorMessage = "el campo {0} es Obligatorio")]
        [Display(Name = "Fecha de Nacimiento")]
        public string Datebirth { get; set; }

        [Required(ErrorMessage = "el campo {0} es Obligatorio")]
        [Display(Name = "Genero")]
        [MaxLength(50)]
        public string Genero { get; set; }

        public DateTime DateRegistro { get; set; }

        [MaxLength(30)]
        public string UserRegistra { get; set; }


    }
}
