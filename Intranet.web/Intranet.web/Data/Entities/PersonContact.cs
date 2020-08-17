using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Intranet.web.Data.Entities
{
    public class PersonContact
    {
        public int Id { get; set; }

        [Required (ErrorMessage ="el campo {0} es Obligatorio")]
        [Display (Name= "Nombre del contacto")]
        [MaxLength(50)]
        public String Name { get; set; }

        [Required(ErrorMessage = "el campo {0} es Obligatorio")]
        [Display(Name = "telefono")]
        [MaxLength(10)]
        public String Telephone { get; set; }

        [Required(ErrorMessage = "el campo {0} es Obligatorio")]
        [Display(Name = "Parentesco")]
        [MaxLength(50)]
        public String relationship { get; set; }
        public Employee Employee { get; set; }

    }
}
