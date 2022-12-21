using System;
using System.ComponentModel.DataAnnotations;

namespace Intranet.web.Data.Entities
{
    public class Endowment
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatiorio.")]
        [Display(Name = "Nota")]
        [MaxLength(100, ErrorMessage = "Maximo 100 Caracteres")]
        public string Detail { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatiorio.")]
        [Display(Name = "Cantidad")]

        public int Count { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatiorio.")]
        [Display(Name = "Talla")]
        [MaxLength(10)]
        public string Size { get; set; }

        [Display(Name = "DateDelivery")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = false)]
        public DateTime DateDelivery { get; set; }
        [Display(Name = "DateVence")]

        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = false)]
        public DateTime DateVence { get; set; }

        [Display(Name = "DateDelivery")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = false)]
        public DateTime DateDeliveryLocal => DateDelivery.ToLocalTime();

        public Employee Employee { get; set; }

        public DateTime DateRegistro { get; set; }

        [MaxLength(30)]
        public string UserRegistra { get; set; }

        [MaxLength(30)]
        public string UserModify { get; set; }

        public DateTime DateModify { get; set; }

        public EndowmentType EndowmentType { get; set; }
    }
}
