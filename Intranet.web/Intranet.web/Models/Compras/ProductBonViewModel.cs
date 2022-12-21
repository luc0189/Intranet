using System;
using System.ComponentModel.DataAnnotations;

namespace Intranet.web.Models.Compras
{
    public class ProductBonViewModel
    {
        public int NegociacionId { get; set; }

        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatiorio.")]
        [Display(Name = "PLU")]
        [MaxLength(40)]
        public string Plu { get; set; }

        [Required(ErrorMessage = "Ell campo {0} es Obligatorio.")]
        [MaxLength(150)]
        [Display(Name = "Nombre Articulo")]
        public string Articulo { get; set; }

        [Required(ErrorMessage = "Ell campo {0} es Obligatorio.")]
        [Display(Name = "Valor Unitario")]
        public int ValorUnit { get; set; }

        [Required(ErrorMessage = "Ell campo {0} es Obligatorio.")]
        [Display(Name = "Cantidad")]
        public int Cant { get; set; }

        public DateTime Dateregistro { get; set; }


        [Display(Name = "Usuario Registra")]
        [MaxLength(100)]
        public string Userregistro { get; set; }


    }
}
