using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Intranet.web.Models.Compras
{
    public class ProductViewModel
    {
        [Required(ErrorMessage = "El campo {0} es Obligatiorio.")]
        [Display(Name = "PLU")]
        [MaxLength(40)]
        public string Plu { get; set; }

        [Required(ErrorMessage = "Ell campo {0} es Obligatorio.")]
        [MaxLength(150)]
        [Display(Name = "Nombre Articulo")]
        public string Detalle { get; set; }
    }
}
