using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Intranet.web.Data.Entities
{
    public class Contract
    {
        public int Id { get; set; }
     
        [Display(Name = "Fecha Inicio")]
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = false)]
        public DateTime DateStart { get; set; } 
        
        
        [Display(Name = "Fecha retiro")]
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = false)]
        public DateTime DateEnd { get; set; }

        [Display(Name = "Clausulas")]
        [MaxLength(500)]        
        public string Clausulas{ get; set; }

        [Display(Name = "Notas")]
        [MaxLength(500)]
        public string Note { get; set; }
        public Employee Employee { get; set; }
    }
}
