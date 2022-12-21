using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Intranet.web.Data.Entities
{
    public class CajaCompensacion
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "el campo {0} es Obligatorio")]
        [Display(Name = "Nombre de Entidad")]
        [MaxLength(50)]
        public String Nombre { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
