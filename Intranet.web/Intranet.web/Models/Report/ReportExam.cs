using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace Intranet.web.Models
{
    public class ReportExam
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatiorio.")]
        [Display(Name = "Document")]
        public int Document { get; set; }


        [Display(Name = "First Name")]
        [MaxLength(50, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [MaxLength(50, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public string LastName { get; set; }

        [MaxLength(100, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatiorio.")]
        [Display(Name = "Tipo RH")]
        [MaxLength(50)]
        public string Rh { get; set; }

        [Display(Name = "Movil")]
        [MaxLength(10)]
        [DisplayFormat(DataFormatString = "{0:(###) ###-####}", ApplyFormatInEditMode = true)]
        public string Movil { get; set; }


        [Display(Name = "Fecha Cumpleaños")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = false)]
        public string DateCumple { get; set; }

        [Display(Name = "Fecha retiro")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = false)]
        public string DateRetiro { get; set; }

        [Display(Name = "Fecha Ingreso")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = false)]
        public string DateIngreso { get; set; }

        //aqui los campos que para tigger

        [MaxLength(30)]
        public string UserCrea { get; set; }

        public DateTime DateRegistro { get; set; }

        [Required(ErrorMessage = "The Field {0} is mandatory.")]
        [Display(Name = "Area")]
        public int AreaId { get; set; }


        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [Display(Name = "Cargo")]
        public int PositionEmpId { get; set; }
        
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [Display(Name = "ExamTypeId")]
        public int ExamtypeId { get; set; }



        public IEnumerable<SelectListItem> Areas { get; set; }
        public IEnumerable<SelectListItem> ExamTypes { get; set; }
       
        
        public IEnumerable<SelectListItem> PositionEmplooyed { get; set; }
      
    }
}
