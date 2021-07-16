using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Intranet.web.Data.Entities.Compras
{
    public class Mes
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="El Campo {0} es Requerido")]
        [Display(Name ="Mes")]
        [MaxLength(80)]
        public  string Name { get; set; }

        public ICollection<Negociation> Negociations { get; set; }
    }
}
