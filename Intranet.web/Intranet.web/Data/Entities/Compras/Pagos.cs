using System;
using System.ComponentModel.DataAnnotations;

namespace Intranet.web.Data.Entities.Compras
{
    public class Pagos
    {
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
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public long ValorPagado { get; set; }

        [Display(Name = "Fecha Pago")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = false)]
        public string DatePago { get; set; }


        public DateTime Dateregistro { get; set; }

        [Required(ErrorMessage = "el campo {0} es Obligatorio")]
        [Display(Name = "Usuario Registra")]
        [MaxLength(100)]

        public string Userregistro { get; set; }
        [MaxLength(100)]
        public string UserModify { get; set; }

        public DateTime DateModify { get; set; }
        public Negociation Negociation { get; set; }
    }
}
