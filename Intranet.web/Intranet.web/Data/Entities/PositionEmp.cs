using System;
using System.ComponentModel.DataAnnotations;

namespace Intranet.web.Data.Entities
{
    public class PositionEmp
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio")]
        [Display(Name = "Cargos de Empleados")]
        [MaxLength(50)]
        public String Position { get; set; }

    }
}
