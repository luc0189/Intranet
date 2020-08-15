using System;
using System.ComponentModel.DataAnnotations;

namespace Intranet.web.Data.Entities
{
    public class Credit
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "El campo {0} es Obligatiorio.")]
        [Display(Name = "Numero de libranza")]
        [MaxLength(90)]
        public int NumberL { get; set; }
        
        [Required(ErrorMessage = "El campo {0} es Obligatiorio.")]
        [Display(Name = "Cuota por Mes")]
        [MaxLength(50)]
        public int Quotmonthly { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatiorio.")]
        [Display(Name = "Valor Total")]
        [MaxLength(30)]
        public int TotalPrice { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatiorio.")]
        [Display(Name = "Plazo")]
        [MaxLength(50)]
        public int DeadlinePay { get; set; }

        [Display(Name = "Start Date")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }

        [Display(Name = "Is Active?")]
        public bool IsActive { get; set; }

        [Display(Name = "Start Date")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime StartDateLocal => StartDate.ToLocalTime();

        [Display(Name = "End Date")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime EndDateLocal => EndDate.ToLocalTime();
    }
}
