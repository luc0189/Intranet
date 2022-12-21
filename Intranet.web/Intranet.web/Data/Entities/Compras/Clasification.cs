using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Intranet.web.Data.Entities.Compras
{
    public class Clasification
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatiorio.")]
        [Display(Name = "Nombre Clasificacion")]
        [MaxLength(100)]
        public string Name { get; set; }


        [Display(Name = "Usuario")]
        [MaxLength(100)]
        public string Usercrete { get; set; }

        //[Required(ErrorMessage = "El campo {0} es Obligatiorio.")]
        [Display(Name = "Fecha")]
        [MaxLength(100)]
        public string TimeCreate { get; set; }
        public ICollection<Negociation> Negociations { get; set; }
    }
}
