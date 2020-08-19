using Intranet.web.Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Intranet.web.Models
{
    public class ExamViewModel : Exams
    {
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "The Field {0} is mandatory.")]
        [Display(Name = "Exam Type")]
        [Range(1, int.MaxValue, ErrorMessage = "You must select a Exam type.")]
        public int ExamTypeId { get; set; }

        public IEnumerable<SelectListItem> ExamTypes { get; set; }
    }
}
