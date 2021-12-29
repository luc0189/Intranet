using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Intranet.web.Models.Compras
{
    public class PagoViewModel
    {
        public int NegociacionId { get; set; }

        public int Id { get; set; }

        [Required(ErrorMessage = "el campo {0} es Obligatorio")]
        [Display(Name = "Novedad")]
        [MaxLength(500)]
        public string Novedad { get; set; }

        [Required(ErrorMessage = "el campo {0} es Obligatorio")]
        [Display(Name = "Doc. de Cobro")]
        [MaxLength(300)]
        public string DocCobro { get; set; }

        [Required(ErrorMessage = "el campo {0} es Obligatorio")]
        [Display(Name = "Doc. de Legalizacion")]
        [MaxLength(300)]
        public string DocLegalizacion { get; set; }

        [Required(ErrorMessage = "el campo {0} es Obligatorio")]
        [Display(Name = "Valor Pagado")]
        public int ValorPagado { get; set; }

        [Display(Name = "Fecha Pago")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = false)]
        public string DatePago { get; set; }

        
        public DateTime Dateregistro { get; set; }

        [Display(Name = "Usuario Registra")]
        [MaxLength(100)]
        public string Userregistro { get; set; }



    }
}
