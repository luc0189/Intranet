using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Intranet.web.Models
{
    public class ContractViewModel
    {
        public int EmployeeIds { get; set; }
        public int Id { get; set; }

        [Display(Name = "Fecha inicio")]
        [Required]
        [MaxLength(100)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = false)]
        public DateTime DateStart { get; set; }

        [Display(Name = "Fecha Fin")]
        [Required]
        [MaxLength(100)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = false)]
        public DateTime DateEnd { get; set; }

        [Display(Name = "Clausulas")]
        [MaxLength(500)]
        public string Clausulas { get; set; }

        [Display(Name = "Notas")]
        [MaxLength(500)]
        public string Note { get; set; }
    }
}
