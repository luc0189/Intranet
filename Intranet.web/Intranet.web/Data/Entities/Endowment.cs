using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Intranet.web.Data.Entities
{
    public class Endowment
    {
        public int Id { get; set; }
        [Required (ErrorMessage ="El campo {0} es Obligatiorio.")]
        [Display (Name ="Dotacion")]
        [MaxLength(70)]
        public String Detail { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatiorio.")]
        [Display(Name = "Cantidad")]
        [MaxLength(10)]
        public int Count { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatiorio.")]
        [Display(Name = "Talla")]
        [MaxLength(10)]
        public String Size { get; set; }

        [Display(Name = "DateDelivery")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime DateDelivery { get; set; }

        [Display(Name = "DateDelivery")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime DateDeliveryLocal => DateDelivery.ToLocalTime();
    }
}
