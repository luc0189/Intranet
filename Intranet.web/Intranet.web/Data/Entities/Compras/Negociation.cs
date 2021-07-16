using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Intranet.web.Data.Entities.Compras
{
    public class Negociation
    {
        public int Id { get; set; }
        public DateTime DateIn { get; set; }
        
        [Required (ErrorMessage ="El campo {0} es requerido.")]
        [MaxLength(300)]
        [Display(Name ="Detalle Negociacion")]
        public string Detalle { get; set; }


        public int ValorNegociacion { get; set; }
        public int BaseLiquidacion { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [MaxLength(300)]
        [Display(Name = "N Documento")]
        public string Document { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [MaxLength(100)]
        [Display(Name = "Usuario")]
        public string UsuCreate { get; set; }

       
        [Display(Name = "Verificado ")]
        public bool Verificado { get; set; }

       
        [Display(Name = "Pago")]
        public bool Pago { get; set; }

        public Clasification Clasification { get; set; }
        public Providercompras Providercompras { get; set; }
        public User User { get; set; }
        public Mes Mes { get; set; }
    }
}
