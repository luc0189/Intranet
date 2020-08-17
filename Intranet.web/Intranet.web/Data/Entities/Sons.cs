using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Intranet.web.Data.Entities
{
    public class Sons
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "el campo {0} es Obligatorio")]
        [Display(Name = "Nombre Completo")]
        [MaxLength(50)]
        public String Name { get; set; }

        [Required(ErrorMessage = "el campo {0} es Obligatorio")]
        [Display(Name = "Fecha de Nacimiento")]
        [MaxLength(50)]
        public String Datebirth { get; set; }

        [Required(ErrorMessage = "el campo {0} es Obligatorio")]
        [Display(Name = "Genero")]
        [MaxLength(50)]
        public int Genero { get; set; }
        public Employee Employee { get; set; }
    }
}
