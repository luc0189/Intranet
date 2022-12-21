using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Intranet.web.Data.Entities.Compras
{
    public class Providercompras
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatiorio.")]
        [Display(Name = "Nombre del Proveedor")]
        [MaxLength(100)]
        public string NameProvider { get; set; }


        [Display(Name = "Usuario")]
        [MaxLength(100)]
        public string UsuCreate { get; set; }

        [Display(Name = "Fecha Creacion")]
        [MaxLength(100)]
        public string TimeCreate { get; set; }
        public ICollection<Negociation> Negociations { get; set; }

    }
}
