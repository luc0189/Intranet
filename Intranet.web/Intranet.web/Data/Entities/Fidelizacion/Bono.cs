using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Intranet.web.Data.Entities.Fidelizacion
{
    public class Bono
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "el campo {0} es Obligatorio")]
        [Display(Name = "codigo")]
        [MaxLength(150)]
        public string Codigo{ get; set; }
               
        public bool Redimido { get; set; }

        [Display(Name = "Fecha Registro")]
        [MaxLength(200)]
       public string Actividad { get; set; }

        public int Valor { get; set; }

        [Display(Name = "Fecha Registro")]
        [MaxLength(150)]
        public string Fechacreado { get; set; }

        [Display(Name = "Usuario Registra")]
        [MaxLength(150)]
        public string Usuariocrea { get; set; }

        [Display(Name = "Fecha Redimido")]
        [MaxLength(150)]
        public string FechaRedimido { get; set; }

        [Display(Name = "Usuario Check")]
        [MaxLength(150)]
        public string UsuarioRedime { get; set; }
    }
}
