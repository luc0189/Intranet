using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Intranet.web.Data.Entities.Fidelizacion
{
    public class Campaña
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "el campo {0} es Obligatorio")]
        [Display(Name = "Nombre Campaña")]
        [MaxLength(150)]
        public string NameCampaña { get; set; }

        [Required(ErrorMessage = "el campo {0} es Obligatorio")]
        [Display(Name = "Consecutivo campaña")]
        [MaxLength(60)]
        public string NumberConsecutive { get; set; }

        [Required(ErrorMessage = "el campo {0} es Obligatorio")]
        [Display(Name = "Fecha de Inicio")]
        [MaxLength(60)]
        public string Datein { get; set; }

        [Required(ErrorMessage = "el campo {0} es Obligatorio")]
        [Display(Name = "Fecha Fin")]
        [MaxLength(60)]
        public string DateOut { get; set; }

        public int Valor { get; set; }

        [Required(ErrorMessage = "el campo {0} es Obligatorio")]
        [Display(Name = "Condiciones y Restricciones")]
        [MaxLength(500)]
        public string Condiciones { get; set; }

        [Required(ErrorMessage = "el campo {0} es Obligatorio")]
        [Display(Name = "Usuario Crea")]
        [MaxLength(150)]
        public string UsuarioCrea { get; set; }

        [Required(ErrorMessage = "el campo {0} es Obligatorio")]
        [Display(Name = "Fecha Creacion")]
        [MaxLength(150)]
        public string DateCrea { get; set; }

        public ICollection<Boletas> Boletas { get; set; }
    }
}
