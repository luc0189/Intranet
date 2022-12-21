using System;
using System.ComponentModel.DataAnnotations;

namespace Intranet.web.Models
{
    public class ContractViewModel
    {
        public int EmployeeIds { get; set; }
        public int Id { get; set; }

        [Display(Name = "Fecha inicio")]
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime DateStart { get; set; }

        [Display(Name = "Fecha Fin")]
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime DateEnd { get; set; }

        [Display(Name = "Clausulas")]
        [MaxLength(500)]
        public string Clausulas { get; set; }

        [Display(Name = "Notas")]
        [MaxLength(500)]
        public string Note { get; set; }
    }
}
