using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Intranet.web.Data.Entities.Activos
{
    public class Chereda
    {
       
        public DateTime Datecreate { get; set; }

       
        public DateTime Datemod { get; set; }

        [Display(Name = "Usuario crea")]
        [MaxLength(500)]
        [Required]
        public string Usucreo { get; set; }

        [Display(Name = "Usuario Modifica")]
        [MaxLength(500)]
        public string Usermod { get; set; }
    }
}
