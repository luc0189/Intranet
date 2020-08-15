using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Intranet.web.Data.Entities
{
    public class CreditEntities
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo {0} es Obligatiorio.")]
        [Display(Name = "Nombre de Entidad")]
        [MaxLength(100)]
        public String Name { get; set; }
    }
}
