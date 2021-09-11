using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Intranet.web.Data.Entities.Fidelizacion
{
    public class TercBnet
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "el campo {0} es Obligatorio")]
        [Display(Name = "Documento")]
        [MaxLength(150)]
        public string Documento { get; set; }

        [Required(ErrorMessage = "el campo {0} es Obligatorio")]
        [Display(Name = "Primer Nombre")]
        [MaxLength(150)]
        public string Nombre { get; set; }

        [Display(Name = "Segundo Nombre")]
        [MaxLength(150)]
        public string Nombre2 { get; set; }

        [Required(ErrorMessage = "el campo {0} es Obligatorio")]
        [Display(Name = "Primer Apellido")]
        [MaxLength(150)]
        public string  Apellido1 { get; set; }

   
        [Display(Name = "codigo")]
        [MaxLength(150)]
        public string  Apellido2 { get; set; }

        [Required(ErrorMessage = "el campo {0} es Obligatorio")]
        [Display(Name = "Telefono")]
        [MaxLength(150)]
        public string  Telefono { get; set; }
        
        [Required(ErrorMessage = "el campo {0} es Obligatorio")]
        [Display(Name = "codigo")]
        [MaxLength(150)]
        public string  Correo { get; set; } 
        
        [Required(ErrorMessage = "el campo {0} es Obligatorio")]
        [Display(Name = "Usuario")]
        [MaxLength(150)]
        public string  Usercreo { get; set; }

        [Required(ErrorMessage = "el campo {0} es Obligatorio")]
        [Display(Name = "codigo")]
        [MaxLength(150)]
        public string Datecrea { get; set; }
    }
}
