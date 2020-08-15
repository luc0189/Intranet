using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Intranet.web.Data.Entities
{
    public class Area
    {
        public int Id { get; set; }
       
        [Required (ErrorMessage ="El campo {0} es Obligatorio.")]
        [Display(Name ="Nombre del Area")]
        [MaxLength(40)]
        public String Nombre { get; set; }
    }
}
