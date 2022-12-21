using System;
using System.ComponentModel.DataAnnotations;

namespace Intranet.web.Data.Entities.Compras
{
    public class ProductBonifi
    {
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


        public string Total => $"{ValorUnit * Cant}";

        public DateTime Dateregistro { get; set; }

        [Required(ErrorMessage = "el campo {0} es Obligatorio")]
        [Display(Name = "Usuario Registra")]
        [MaxLength(100)]
        public string Userregistro { get; set; }

        public Negociation Negociation { get; set; }

    }
}
