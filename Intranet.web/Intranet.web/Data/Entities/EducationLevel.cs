using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Intranet.web.Data.Entities
{
    public class EducationLevel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "el campo {0} es Obligatorio")]
        [Display(Name = "Nivel Educativo")]
        [MaxLength(50)]
        public String Level { get; set; }
        public Employee Employee { get; set; }
    }
}
