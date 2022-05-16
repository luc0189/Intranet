using Intranet.web.Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Intranet.web.Models
{
    public class AddEndowmentViewModel 
    {
        public int EmployeeId { get; set; }
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatiorio.")]
        [Display(Name = "Nota")]
        [MaxLength(100, ErrorMessage ="Solo 100 Caracter")]
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
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime DateDelivery { get; set; }

        [Display(Name = "DateVence")]
        
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime DateVence { get; set; }

        [Display(Name = "DateDelivery")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime DateDeliveryLocal => DateDelivery.ToLocalTime();

        public Employee Employee { get; set; }
        public DateTime DateRegistro { get; set; }

        [MaxLength(30)]
        public string UserRegistra { get; set; }

        [Required(ErrorMessage = "The Field {0} is mandatory.")]
        [Display(Name = "Endowment Type")]
        [Range(1, int.MaxValue, ErrorMessage = "You must select a Endowment Type.")]
        public int EndowmentTypeId { get; set; }


        public IEnumerable<SelectListItem> EndowmnetsTypes { get; set; }
    }
}
