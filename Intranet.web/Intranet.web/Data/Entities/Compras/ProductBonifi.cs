using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Intranet.web.Data.Entities.Compras
{
    public class ProductBonifi
    {
        public int Id { get; set; }
        [Required (ErrorMessage = "El campo {0} es Obligatiorio.")]
        [Display (Name ="PLU")]
        [MaxLength(40)]
        public string Plu { get; set; }

        [Required(ErrorMessage ="Ell campo {0} es Obligatorio.")]
        [MaxLength(100)]
        [Display(Name ="Nombre Articulo")]
        public string Articulo { get; set; }

        [Required(ErrorMessage = "Ell campo {0} es Obligatorio.")]
      
        [Display(Name = "Valor Unitario")]
        public int ValorUnit { get; set; }

        [Required(ErrorMessage = "Ell campo {0} es Obligatorio.")]
      
        [Display(Name = "Cantidad")]
        public int Cant { get; set; }

        [Required(ErrorMessage = "Ell campo {0} es Obligatorio.")]
       
        [Display(Name = "Total")]
        public int Total { get; set; }
    }
}
