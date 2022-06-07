using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Intranet.web.Models
{
    public class AddHistorialEmpleadoViewModel
    {
        public int EmployeeId { get; set; }
        public int Id { get; set; }

        [Required(ErrorMessage = "el campo {0} es Obligatorio")]
        [Display(Name = "Nota")]
        [MaxLength(600, ErrorMessage = "El campo {0} maximo {1} Caracteres.")]
        public string Notas { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = false)]
        [Required(ErrorMessage = "el campo {0} es Obligatorio")]
        [Display(Name = "Fecha")]
        public string Fecha { get; set; }
    
        public DateTime DateRegistro { get; set; }

        [MaxLength(30)]
        public string UserRegistra { get; set; }

       
    }
}
