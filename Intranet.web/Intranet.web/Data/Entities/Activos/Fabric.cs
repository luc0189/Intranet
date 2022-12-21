using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Intranet.web.Data.Entities.Activos
{
    public class Fabric : Chereda
    {
        public int Id { get; set; }

        [Display(Name = "Nombre Fabricante")]
        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        [MaxLength(35, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        public string Name { get; set; }
        public ICollection<Item> Items { get; set; }
    }
}
