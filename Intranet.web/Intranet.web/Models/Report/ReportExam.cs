using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace Intranet.web.Models.Report
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
        public string FullName { get; set; }

        [Display(Name = "Start Date")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]

        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }

        [Display(Name = "Start Date")]

        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime StartDateLocal => StartDate.ToLocalTime();

        [Display(Name = "End Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime EndDateLocal => EndDate.ToLocalTime();

        [MaxLength(30)]
        public string UserModify { get; set; }
        [MaxLength(30)]
        public string State { get; set; }

        public DateTime DateModify { get; set; }

        public bool Activo { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [Display(Name = "Cargo")]
        public int PositionEmpId { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [Display(Name = "ExamTypeId")]
        public int ExamtypeId { get; set; }

        public IEnumerable<SelectListItem> ExamTypes { get; set; }

        public IEnumerable<SelectListItem> PositionEmplooyed { get; set; }

    }
}
