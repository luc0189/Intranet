using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Intranet.web.Data.Entities
{
    public class SiteHeadquarters
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        [Display(Name = "Nombre de Sede")]
        [MaxLength(50)]
        public String Nombre { get; set; }
        public ICollection<Area> Areas { get; set; }

    }
}
