using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Intranet.web.Data.Entities.Activos
{
    public class Category : Chereda
    {
        public int Id { get; set; }

        [Display(Name = "Nombre Categoria")]
        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        [MaxLength(35,ErrorMessage = "The {0} field can not have more than {1} characters.")]
        public string Name { get; set; }

        [Display(Name = "Vida Util")]
        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        public int  LifeUse { get; set; }
        public bool Otros { get; set; }
        public ICollection<Item> Items { get; set; }
    }
}
