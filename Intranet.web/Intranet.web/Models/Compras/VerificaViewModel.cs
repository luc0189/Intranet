using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Intranet.web.Models.Compras
{
    public class VerificaViewModel
    {
        public int NegociacionId { get; set; }

        public int Id { get; set; }
        [Required(ErrorMessage = "el campo {0} es Obligatorio")]
        [Display(Name = "Novedad")]
        [MaxLength(500)]
        public string Novedad { get; set; }

        [Display(Name = "Fecha Registro")]

        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = false)]
        public string Dateregistro { get; set; }

        [Display(Name = "Usuario Registro")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = false)]
        public string UserRegistro { get; set; }

    
    }
}

