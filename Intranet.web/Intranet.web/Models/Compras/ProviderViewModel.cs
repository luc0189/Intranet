using System.ComponentModel.DataAnnotations;

namespace Intranet.web.Models.Compras
{
    public class ProviderViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatiorio.")]
        [Display(Name = "Nombre del Proveedor")]
        [MaxLength(100)]
        public string NameProvider { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatiorio.")]
        [Display(Name = "Numero Tel")]
        public int TelProvider { get; set; }

        [Display(Name = "Usuario")]
        [MaxLength(100)]
        public string UsuCreate { get; set; }

        [Display(Name = "Fecha Creacion")]
        [MaxLength(100)]
        public string TimeCreate { get; set; }
    }
}
