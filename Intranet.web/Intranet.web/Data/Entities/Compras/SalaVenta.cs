using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Intranet.web.Data.Entities.Compras
{
    public class SalaVenta
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "el campo {0} es Obligatorio")]
        [Display(Name = "Sala de Ventas")]
        [MaxLength(500)]
        public string Name { get; set; }
        public ICollection<Negociation> Negociations { get; set; }
    }
}
